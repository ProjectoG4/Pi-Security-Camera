import os
import time
import requests

os.system('sudo rm -rf /var/lib/motion/*')

directory = '/var/lib/motion/'  # Replace with the path to your directory
folder_id = ''  # Replace with your gofile.io folder ID
token_api = '' # Replace with your gofile.io token API

# Get the list of JPG files in the directory
jpg_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]

while True:
    # Get the current list of JPG files
    current_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]
    
    # Check for new files
    new_files = set(current_files) - set(jpg_files)
    for f in new_files:

        # Upload the new file to gofile.io
        with open(os.path.join(directory, f), 'rb') as file:
            response = requests.post(
                url='https://store3.gofile.io/uploadFile',
                files={'file': file},
                data={'folderId': folder_id, 'token': token_api}
            )
            print(response.json())
    
    # Update the list of JPG files
    jpg_files = current_files
    
    # Wait for 1 second before checking again
    time.sleep(1)
