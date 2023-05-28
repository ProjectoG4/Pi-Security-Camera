import sys
from gtts import gTTS
import pygame

text = sys.argv[1]
tts = gTTS(text=text, lang="es-ES")
tts.save("hello.mp3")

pygame.init()
pygame.mixer.init()
pygame.mixer.music.load("hello.mp3")
pygame.mixer.music.play()

while pygame.mixer.music.get_busy():
    pygame.time.Clock().tick(10)

pygame.quit()
