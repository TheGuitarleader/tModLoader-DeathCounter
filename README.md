# DeathCounter
This mod adds a on screen death counter. Deaths are stored in `.txt` files which can be used to tie into an OBS text GDI+ source for fully customizable overlays on a livestream or recording.

### How to setup with OBS
1. Add a new `Text (GDI+)` source to your scene.
2. Check `Read from file` and browse to `~Documents\My Games\Terraria\tModLoader\Death Counter`. All text files are stored as the assigned as `<Player Name>.txt`. If there is no file for your player, simple load into the world and one will be generated.
3. That's it! Now you can play around with fonts, colors, styles, etc and the source will update as your player gets killed in real-time.