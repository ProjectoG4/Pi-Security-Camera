using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Accord.Video;
using Accord.Video.FFMPEG;
using System.Net;
using System.IO;
using System.Threading;

namespace Security_Camera
{
    public partial class Main : Form
    {
        private bool isRecording = false;
        private bool isPlayAlarmRunning = false;
        private bool isAlarmRunning = false;
        private bool isEmailRunning = false;
        private bool isUploadRunning = false;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Bitmap bitmap;
        MJPEGStream stream;
        private VideoFileWriter writer = null;
        private System.Windows.Forms.Timer timer = null;
        private SshClient sshClient;

        public static api KeyAuthApp = new api(
            name: "put your product name",
            ownerid: " put your ownerid",
            secret: "put your secret",
            version: "1.0"
        );

        public Main()
        {
            InitializeComponent();
            KeyAuthApp.init();
            StartStreaming();
            sshClient = new SshClient("put your raspberry pi | ssh ip", 22, "user", "pass");
        }

        private void License()
        {
            string jsonFilePath = "License.json";

            if (!File.Exists(jsonFilePath))
            {
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
                string licenseValue = jsonObject["Key"];

                if (KeyAuthApp.license(licenseValue))
                {
                    this.Size = new Size(640, 660);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void StartStreaming()
        {
            stream = new MJPEGStream("https://yourdomain.com/");
            stream.Login = "user for motion";
            stream.Password = "password for motion";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(stream.Source);
            request.PreAuthenticate = true;
            string authInfo = $"{stream.Login}:{stream.Password}";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = $"Basic {authInfo}";

            stream.NewFrame += new NewFrameEventHandler(GetNewFrame);
            stream.Start();
        }

        void GetNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            Camera.Invoke((MethodInvoker)delegate {
                Camera.Image = bitmap;
            });
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            License();

            await Task.Run(async () =>
            {
                await Task.Delay(1900);
                Invoke(new Action(() => LoadingCamera.Visible = false));

                sshClient.Connect();

                var result = await Task.Run(() => sshClient.RunCommand("sudo rm -rf /var/lib/motion/* && sudo systemctl start motion"));
                result = await Task.Run(() => sshClient.RunCommand("ps aux | grep python"));

                if (result.Result.Contains("activate_alarm.py"))
                {
                    Invoke(new Action(() => AlarmDetectionButton.FillColor = Color.Red));
                }

                if (result.Result.Contains("send_mail.py"))
                {
                    Invoke(new Action(() => EmailAlertButton.FillColor = Color.Red));
                }

                if (result.Result.Contains("upload_file.py"))
                {
                    Invoke(new Action(() => CloudUploadButton.FillColor = Color.Red));
                }
            });
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        private void Camera_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Camera_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Camera_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Security Camera\\Images";
            string fileName = "picture_" + now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            Bitmap bmp = new Bitmap(Camera.Width, Camera.Height);
            Camera.DrawToBitmap(bmp, new Rectangle(0, 0, Camera.Width, Camera.Height));
            string filePath = Path.Combine(folderName, fileName);
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                RecordButton.FillColor = Color.Red;
                isRecording = true;

                string now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Security Camera\\Videos";
                string fileName = "video_" + now + ".mp4";
                string filePath = Path.Combine(folderName, fileName);

                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }

                writer = new VideoFileWriter();
                writer.Open(filePath, Camera.Width, Camera.Height, 30, VideoCodec.MPEG4);

                timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000 / 60;
                timer.Tick += new EventHandler(TimerTick);
                timer.Start();
            }
            else
            {
                RecordButton.FillColor = Color.DodgerBlue;
                isRecording = false;

                if (timer != null)
                {
                    timer.Stop();
                    timer = null;
                }
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Camera.Width, Camera.Height);
            Camera.DrawToBitmap(bmp, new Rectangle(0, 0, Camera.Width, Camera.Height));
            writer.WriteVideoFrame(bmp);
        }

        private async void RebootButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                sshClient.RunCommand("sudo systemctl start motion && sudo systemctl restart motion");
            });
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            if (mouseEventArgs?.Button == MouseButtons.Left && Control.ModifierKeys.HasFlag(Keys.Control))
            {
                await Task.Run(() =>
                {
                    if (!sshClient.IsConnected)
                    {
                        sshClient.Connect();
                    }

                    sshClient.RunCommand("sudo init 0");
                });
            }

            stream.Stop();
            sshClient.Disconnect();
            Application.Exit();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            stream.Stop();
            sshClient.Disconnect();
            Application.Exit();
        }

        private async void AlarmSoundButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                if (!isPlayAlarmRunning)
                {
                    isPlayAlarmRunning = true;
                    sshClient.RunCommand("aplay sound.wav");
                }
                else
                {
                    isPlayAlarmRunning = false;
                    sshClient.RunCommand("pkill aplay");
                }
            });
        }

        private async void AlarmDetectionButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                if (!isAlarmRunning)
                {
                    AlarmDetectionButton.FillColor = Color.Red;
                    isAlarmRunning = true;

                    sshClient.RunCommand("python3 activate_alarm.py");
                }
                else
                {
                    AlarmDetectionButton.FillColor = Color.DodgerBlue;
                    isAlarmRunning = false;

                    sshClient.RunCommand("sudo pkill -f \"python3 activate_alarm.py\"");
                }
            });
        }

        private async void EmailAlertButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                if (!isEmailRunning)
                {
                    EmailAlertButton.FillColor = Color.Red;
                    isEmailRunning = true;

                    sshClient.RunCommand("python3 send_mail.py");
                }
                else
                {
                    EmailAlertButton.FillColor = Color.DodgerBlue;
                    isEmailRunning = false;

                    sshClient.RunCommand("sudo pkill -f \"python3 send_mail.py\"");
                }
            });
        }

        private async void CloudUploadButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                if (!isUploadRunning)
                {
                    CloudUploadButton.FillColor = Color.Red;
                    isUploadRunning = true;

                    sshClient.RunCommand("python3 upload_file.py");
                }
                else
                {
                    CloudUploadButton.FillColor = Color.DodgerBlue;
                    isUploadRunning = false;

                    sshClient.RunCommand("sudo pkill -f \"python3 upload_file.py\"");
                }
            });
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox.ContextMenuStrip = new ContextMenuStrip();
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (Clipboard.ContainsText())
                {
                    int selectionStart = TextBox.SelectionStart;
                    string originalText = TextBox.Text;

                    string clipboardText = Clipboard.GetText();
                    string newText = originalText.Insert(selectionStart, clipboardText);

                    TextBox.Text = newText;
                    TextBox.SelectionStart = selectionStart + clipboardText.Length;
                    TextBox.SelectionLength = 0;
                }
            }
        }

        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string speech = TextBox.Text;

                await Task.Run(() =>
                {
                    if (!sshClient.IsConnected)
                    {
                        sshClient.Connect();
                    }

                    sshClient.RunCommand($"python3 tts.py \"{speech}\"");
                });
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                TextBox.SelectAll();
                e.Handled = true;
            }
        }

        private async void TextToSpeechButton_Click(object sender, EventArgs e)
        {
            string speech = TextBox.Text;

            await Task.Run(() =>
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                sshClient.RunCommand($"python3 tts.py \"{speech}\"");
            });
        }
    }
}
