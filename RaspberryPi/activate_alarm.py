import os
import time

os.system('sudo rm -rf /var/lib/motion/*')

directory = '/var/lib/motion'  # Path to directory

# Get the list of JPG files in the directory
jpg_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]

while True:
    # Get the current list of JPG files
    current_files = [f for f in os.listdir(directory) if f.endswith('.jpg')]
    
    # Check for new files
    new_files = set(current_files) - set(jpg_files)
    for f in new_files:
        os.system(f'aplay sound.wav')
    
    # Update the list of JPG files
    jpg_files = current_files

    # Wait for 1 second before checking again
    time.sleep(1)
