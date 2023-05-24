using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security_Camera
{
    public partial class Login : Form
    {
        private const string LoginUrl = "https://yourwordpress.com/login.php";
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var parameters = new MultipartFormDataContent();
                parameters.Add(new StringContent(UsernameTextBox.Text), "username");
                parameters.Add(new StringContent(PasswordTextBox.Text), "password");
                parameters.Add(new StringContent("Login"), "submit");

                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(LoginUrl, parameters);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"An error occurred while connecting to the server: {ex.Message}",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string responseContent = await response.Content.ReadAsStringAsync();

                if (responseContent.Contains("You are logged in successfully"))
                {
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UsernameTextBox.ContextMenuStrip = new ContextMenuStrip();
        }

        private void UsernameTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (Clipboard.ContainsText())
                {
                    int selectionStart = UsernameTextBox.SelectionStart;
                    string originalText = UsernameTextBox.Text;

                    string clipboardText = Clipboard.GetText();
                    string newText = originalText.Insert(selectionStart, clipboardText);

                    UsernameTextBox.Text = newText;
                    UsernameTextBox.SelectionStart = selectionStart + clipboardText.Length;
                    UsernameTextBox.SelectionLength = 0;
                }
            }
        }

        private async void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (HttpClient client = new HttpClient())
                {
                    var parameters = new MultipartFormDataContent();
                    parameters.Add(new StringContent(UsernameTextBox.Text), "username");
                    parameters.Add(new StringContent(PasswordTextBox.Text), "password");
                    parameters.Add(new StringContent("Login"), "submit");

                    HttpResponseMessage response;
                    try
                    {
                        response = await client.PostAsync(LoginUrl, parameters);
                        response.EnsureSuccessStatusCode();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"An error occurred while connecting to the server: {ex.Message}",
                            "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (responseContent.Contains("You are logged in successfully"))
                    {
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                UsernameTextBox.SelectAll();
                e.Handled = true;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextBox.ContextMenuStrip = new ContextMenuStrip();
        }

        private void PasswordTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (Clipboard.ContainsText())
                {
                    int selectionStart = PasswordTextBox.SelectionStart;
                    string originalText = PasswordTextBox.Text;

                    string clipboardText = Clipboard.GetText();
                    string newText = originalText.Insert(selectionStart, clipboardText);

                    PasswordTextBox.Text = newText;
                    PasswordTextBox.SelectionStart = selectionStart + clipboardText.Length;
                    PasswordTextBox.SelectionLength = 0;
                }
            }
        }

        private async void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (HttpClient client = new HttpClient())
                {
                    var parameters = new MultipartFormDataContent();
                    parameters.Add(new StringContent(UsernameTextBox.Text), "username");
                    parameters.Add(new StringContent(PasswordTextBox.Text), "password");
                    parameters.Add(new StringContent("Login"), "submit");

                    HttpResponseMessage response;
                    try
                    {
                        response = await client.PostAsync(LoginUrl, parameters);
                        response.EnsureSuccessStatusCode();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"An error occurred while connecting to the server: {ex.Message}",
                            "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (responseContent.Contains("You are logged in successfully"))
                    {
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                PasswordTextBox.SelectAll();
                e.Handled = true;
            }
        }
    }
}
