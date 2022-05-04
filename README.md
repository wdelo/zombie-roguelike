# Zombie Roguelike Dungeon Crawler
This project is a game made in Unity3D and all the code is written with C#. You play as a soldier in a dungeon overrun by zombies and have to kill off the zombies room by room. You can't advance to the next room until you defeat all the zombies in your current room.

The starting game scene has a predefined room with 4 doors, one on each side. Upon start up, the game generates a random map made up of a set of prefabricated rooms, using the doors to determine where a new room can spawn and still be accessible. Spawn points exist in each room where a random prop or pickup can be spawned (from a list of predefined prefabs). Each room besides the entry room has one or two doorways.

The player can control their character using the WASD keys to move on the X and Z axes and the mouse to move their aim 360 degrees around the character. The player can use the left mouse button to shoot their gun and the R key to reload their gun.

As the player moves their character to a room that has not been visited before, all the doors are locked and a hoard of zombies spawn. The player must aim their gun at the zombies and shoot them to kill them, and once all the zombies in the room have been defeated, the doors open up again and the player can advance to the next room or revisit the room they came from.

On the HUD, the player can see their remaining health, how much ammo they currently have, and the score. The character looses health when the zombies strike the character. Throughout the rooms they player can find pickups to refill their ammo and heal their character. Each zombie killed increases the player's score by 100 points.

Some challenges that were faced during development were making sure rooms did not spawn on top of each other, having the camera move to a new room upon the character entering the new room, animating the player character, and determining when there were no zombies remaining in the room (so the doors could be opened).

## Installation Instructions
Steps:
1. Install the Unity Hub if you don't already have it, and install the editor for Unity version 2021.2.19f1. Download for Unity Hub can be found here: https://unity3d.com/get-unity/download
2. Clone to repository to your desired directory on your computer.
3. In the Unity Hub, under projects, click the dropdown arrow next to "Open", and select "Add project from disk". Navigate to the "zombie-roguelike" folder and select "Add Project".
4. Inside the Unity Editor, navigate to the "Scenes" folder and double click the "Level01" Unity scene file.
5. Press the play button at the top of the Unity Editor.

## Credits
This project was contributed to by Matthew Manning (https://github.com/matt-manning), William Delo (https://github.com/wdelo), and Oskar Klear (https://github.com/oskarklear).
