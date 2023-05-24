import sys
import os
import pytube
from moviepy.editor import VideoFileClip

if len(sys.argv) < 2:
    sys.exit(1)
url = sys.argv[1]

youtube = pytube.YouTube(url)
video = youtube.streams.filter(only_audio=True).first()
video.download(output_path=".", filename="temp")

video_clip = VideoFileClip("temp.mp4")
video_clip.audio.write_audiofile("output.wav")

video_clip.close()
os.remove("temp.mp4")
os.system(f"aplay output.wav")
