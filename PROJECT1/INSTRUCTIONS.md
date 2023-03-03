# HOW TO MAKE A TOP-DOWN GAME QUEST GAME

## Level Creation (2D Tilemaps)

Open the Unity editor and follow these instructions:

1. Click on the "Assets" folder if it is not already opended.
2. Within the "Assets" folder, click on the "Prefabs" folder.
3. Within the "Prefabs" folder, click on the "Landscapes" folder.

[ Provide Screenshot ]

#### Using a Pre-made Landscape 
- The "Landscapes" folder has many different landscapes you can choose from. Drag your favorite landscape into the scene (All colliders are already set up for you).

#### Making Your Own Landscape

4. Within the "Landscapes" folder, locate the prefab named "YourLandscape" and double-click on it. This opens a grid where you can draw your own landscape for your level.

[ Provide Screenshot ]

5. Look at the top of the screen and click the "Window" menu button. From there, click on the "2D" button, then within that menu click on "Tile Palette". This is the window that helps you draw your own landscape. Drag the "Tile Palette" window to the side so that the Scene view is visible.

[ Provide Screenshot ]

6. Within the "Tile Palette" window, the dropdown menu next to the text "Active Tilemap" tells you which layer you are drawing in. Within that dropdown menu, select "GroundLayer".

[ Provide Screenshot ]

7. Now, click on the paint brush icon.

[ Provide Screenshot ]

8. Within the "Tile Palette" window, select a portion that you want to use in your level (preferably something that would be considered the Ground).

For example:
[ Provide Screenshot ]

9. Once you have selected a portion, start drawing on the Scene view however you see fit. Be creative! If you make a mistake, you can use the eraser tool.

[ Provide Screenshot ]

10. When you think you are done drawing, change the "Active Tilemap" to "Obstacles". Try to select a portion of the Tilemap that is an obstacle. Then start drawing on the Scene view.

11. Drag the prefab you just drew on, named "YourLandscape" into the Scene. Congratulations! You just created your own landscape!

This is an example end product:
[ Provide Screenshot ]

## Adding Main Character

### Using Pre-made Players

1. Click on the "Assets" folder if it is not already opended.
2. Within the "Assets" folder, click on the "Prefabs" folder.
3. Within the "Prefabs" folder, click on the "Players" folder.

[ Provide Screenshot ]

4. Select your favorite player, and drag them into the scene.
5. In the Scene Hierarchy, rename the player to "Player" if applicable. This is so the built-in scripts can work normally.
6. In the Scene Hierarchy, drag the Game Object named "Main Camera" onto the Player to make it its child. This makes sure the camera follows the player when it moves around.

### Making Your Own Player

See "Sprite Animation" Section below.

## Adding Enemies

### Using Pre-made Enemies

1. Click on the "Assets" folder if it is not already opended.
2. Within the "Assets" folder, click on the "Prefabs" folder.
3. Within the "Prefabs" folder, click on the "Enemies" folder.

[ Provide Screenshot ]

4. Select your favorite enemy, and drag them into the Scene Hierarchy.

[ Provide Screenshot ]

### Making Your Own Enemy

See "Sprite Animation" Section below.

## Adding Loot

TODO

## Adding Treasure Chests

TODO

## Sprite Animation

Search the Internet for a free-to-use Sprite sheet or a Sprite sheet that you have rights to. You can also use Sprite sheets within this repository. Otherwise, remember to give credit if using someone else's work. A website to make a custom sprite sheet used in this project is the following:

- [https://sanderfrenken.github.io/Universal-LPC-Spritesheet-Character-Generator/]

If you would like to work from one of the provided Sprites in the Assets, follow the following instructions:

1. Click on the "Assets" folder if it is not already opended.
2. Within the "Assets" folder, click on the "Sprites" folder.

[ Provide Screenshot ]

3. If you are using your own Sprite sheet or a Sprite sheet you obtained from online, within the "Sprites" folder, drag your Sprites into the "YourSprites" folder. If you are using Sprites from this repository, click on the "Players" folder.
4. In order to view each individual Sprite in a Sprite sheet, click the arrow next to it. You are now viewing the child elements (each Sprite) of the Sprite sheet. The main Sprite sheet is called the "parent". 
5. Once you have chosen your favorite Sprite sheet to use, select the "parent" then click on the "Inspector" window.

6. 

### Player Animations

#### Walking

TODO

#### Attacking

TODO

### Enemy Animations

TODO

## Menus and Interfaces

### Main Menu

TODO

### Heads Up Display (HUD)

TODO

### Inventory

TODO

### Pause Menu

TODO

### Death Screen

TODO

## Other Scripts

### ...