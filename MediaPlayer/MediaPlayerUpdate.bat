@ECHO OFF
TIMEOUT /t 1 /nobreak > NUL
TASKKILL /IM "MediaPlayer.exe" > NUL
MOVE "C:\Users\qxz08c6\Desktop\Test\MediaPlayerUpdate.exe" "C:\Users\qxz08c6\Desktop\Test\MediaPlayer.exe"
DEL "%~f0" & START "" /B "C:\Users\qxz08c6\Desktop\Test\MediaPlayer.exe"