# dh-clickbot

## Description
This programs simulates permanent mouse-clicks at a specified location (until you stop it).

Nothing special, but helpful for games like cookie clicker


----

## Usage
Move your mouse to the prefered location (in cookie clicker for example above the large cookie). Then press "Ctrl + P" to set the current mouse position as click position for ClickBot.

Now Press "Ctrl + R" to start ("run") the clicks. ClickBot will now move your mouse to the specified location and starts to click 1 time every 10ms. If you try to move the mouse, ClickBot will correct the location of the cursor again.

If you temporarily want to move your mouse out of the specified location, keep "Alt" pressed.

To stop the program, just press "Ctrl + T" ("terminate").


----

## Notes
ClickBot registers "Ctrl + R", "Ctrl + T" and "Ctrl + P" as global hotkeys. These hotkeys are blocked for every other program while ClickBot is opened. If you close ClickBot, all the hotkeys will be available again.
