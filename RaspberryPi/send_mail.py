import os
import time
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from email.mime.image import MIMEImage
import imghdr

os.system('sudo rm -rf /var/lib/motion/*')

# Replace the values in the following variables with your email and SMTP server details
sender_email = ''
sender_password = ''
recipient_email = ''
smtp_server = 'smtp.outlook.com'
smtp_port = 587

directory = '/var/lib/motion/'  # Replace with the path to your directory

# Get the list of JPG files in the directory
jpg_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]

while True:
    # Get the current list of JPG files
    current_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]
    
    # Check for new files
    new_files = set(current_files) - set(jpg_files)
    for f in new_files:
        
        # Create a multipart message object
        msg = MIMEMultipart()
        msg['From'] = sender_email
        msg['To'] = recipient_email
        msg['Subject'] = 'Camera Alert: Motion Detected!'
        msg.attach(MIMEText('This is an automatically generated email from the security camera.'))
        
        # Attach the JPG file to the message
        attachment = os.path.join(directory, f)
        with open(attachment, 'rb') as img_file:
            img_data = img_file.read()
            img_type = imghdr.what(img_file)
            img = MIMEImage(img_data, _subtype=img_type)
            img.add_header('Content-Disposition', 'attachment', filename=f)
            msg.attach(img)
        
        # Send the message via SMTP server
        with smtplib.SMTP(smtp_server, smtp_port) as server:
            server.starttls()
            server.login(sender_email, sender_password)
            server.sendmail(sender_email, recipient_email, msg.as_string())
    
    # Update the list of JPG files
    jpg_files = current_files

    # Wait for 1 second before checking again
    time.sleep(1)
