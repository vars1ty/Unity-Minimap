# Unity-Minimap
A simple base for a minimap with 1 icon.

This only serves as a **base** for a minimap without a Render Texture, its not a fully fledged system as that you'll have to make on your own.

You can move the `icon` to match the position of any object in the world using `ConvertPosition(pos) * spacing` and obviously changing the anchored position to the returned value.
