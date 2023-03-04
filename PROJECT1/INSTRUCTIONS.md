# HOW TO MAKE A TOP-DOWN GAME QUEST GAME

## Level Creation (2D Tilemaps)

Open the Unity editor and follow these instructions:

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Landscapes` folder.

[ Provide Screenshot ]

#### Using a Pre-made Landscape 
- The `Landscapes` folder has many different landscapes you can choose from. Drag your favorite landscape into the scene (All colliders are already set up for you).

#### Making Your Own Landscape

4. Within the `Landscapes` folder, locate the prefab named `YourLandscape` and double-click on it. This opens a grid where you can draw your own landscape for your level.

[ Provide Screenshot ]

5. Look at the top of the screen and click the `Window` menu button. From there, click on the `2D` button, then within that menu click on `Tile Palette`. This is the window that helps you draw your own landscape. Drag the `Tile Palette` window to the side so that the Scene view is visible.

[ Provide Screenshot ]

6. Within the `Tile Palette` window, the dropdown menu next to the text `Active Tilemap` tells you which layer you are drawing in. Within that dropdown menu, select `GroundLayer`.

[ Provide Screenshot ]

7. Now, click on the paint brush icon.

[ Provide Screenshot ]

8. Within the `Tile Palette` window, select a portion that you want to use in your level (preferably something that would be considered the Ground).

For example:
[ Provide Screenshot ]

9. Once you have selected a portion, start drawing on the Scene view however you see fit. Be creative! If you make a mistake, you can use the eraser tool.

[ Provide Screenshot ]

10. When you think you are done drawing, change the `Active Tilemap` to `Obstacles`. Try to select a portion of the Tilemap that is an obstacle. Then start drawing on the Scene view.

11. Drag the prefab you just drew on, named `YourLandscape` into the Scene. Congratulations! You just created your own landscape!

This is an example end product:
[ Provide Screenshot ]

## Adding Main Character

### Using Pre-made Players

1. Click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Players` folder.

[ Provide Screenshot ]

4. Select your favorite player, and drag them into the scene.

5. In the Scene Hierarchy, rename the player to `Player` if applicable. This is so the built-in scripts can work normally.

6. In the Scene Hierarchy, drag the Game Object named `Main Camera` onto the Player to make it its child. This makes sure the camera follows the player when it moves around.

### Making Your Own Player

See `Setting Up Sprites` and `Player Sprite` Sections below.

## Adding Enemies

### Using Pre-made Enemies

1. Click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Enemies` folder.

[ Provide Screenshot ]

4. Select your favorite enemy, and drag them into the Scene Hierarchy.

[ Provide Screenshot ]

### Making Your Own Enemy

See `Setting Up Sprites` and `Enemy Sprite` Sections below.

## Adding Loot

TODO

## Adding Treasure Chests

TODO

## Setting Up Sprites

Search the Internet for a free-to-use Sprites or Sprites that you have rights to. It is recommended to obtain a Sprite that has multiple animation possibilities like the following:

- Idle Animation
- Walking Animation
- Attacking Animation
- Death Animtion

You can also use Sprite sheets within this repository. Otherwise, remember to give credit if using someone else's work. A website to make a custom sprite sheet used in this project is the following:

[https://sanderfrenken.github.io/Universal-LPC-Spritesheet-Character-Generator/]

If you would like to work from one of the provided Sprites in the Assets, follow the following instructions:

1. Click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Sprites` folder.

[ Provide Screenshot ]

3. If you are using your own Sprite sheet or a Sprite sheet you obtained from online, within the `Sprites` folder, drag your Sprites into the `YourSprites` folder. If you are using Sprites from this repository, click on the `Players` folder for Players or the `Enemies` folder for Enemies.

4. In order to view each individual Sprite in a Sprite sheet, click the arrow next to it. You are now viewing the child elements (each Sprite) of the Sprite sheet. The main Sprite sheet is called the `parent`. 

5. Once you have chosen your favorite Sprite sheet to use, one of the child elements (preferably one that looks like the default standing Sprite) then drag it into the Scene Hierarchy.

6. Rename the Sprite you just dragged into the Scene Hierarchy as `Player` if it is a Player. If the Sprite is an `Enemy`, name it whatever you want.

7. Set the position of `Player` and/or `Enemy` within the bounds of your `Landscape`. You can do so by first selecting the `Player` or `Enemy` object in the Scene Hierarchy, then using the `Move Tool` within the Scene Window, dragging the `Player` into place.

[Provide Screenshot]

8. While selecting the `Player` or `Enemy` object(s), within the Inspector window, add a `Box Collider 2D` component. This component will be used for when the character runs into walls, obstacles, etc.

[Provide Screenshot]

9. Within the `Box Collider 2D` component, click the "Edit Collider" icon. Here, you can adjust the size of the collider. Ideally, adjust the collider shape to match the size of your Sprite.

11. Add the `Rigidbody 2D` component to `Player` and `Enemy` object(s). Set Body Type to "Dynamic", set "Gravity Scale" to 0, and within the Constranits section, check the "Freeze Rotation" box for "Z". This makes it so you only move along the X and Y axes, and in the context of this Top-Down game, gravity is neglible.

12. Add the `Capsule Collider 2D` component to `Player` and `Enemy` objects. Check the box for "isTrigger", meaning that this component will be triggered when the the Player run into Enemies.

13. Within the `Capsule Collider 2D` component, click the "Edit Collider" icon. Here, you can adjust the size of the collider. Ideally, adjust the collider shape to match the size of your Sprite.


### Player Sprite

The following instructions apply to the `Player` game object only:

1. While the `Enemy` game object is selected, in the "Inspector" window, change its Tag to "Player". Click "Add Tag" if the tag is not already there.

2. Add the `Player` script as a component. Set the values however you would like. Default values are as follows:
- "Attack" = 25
- "Defense" = 10
- "Max Health" = 100
- "Health" = 0
- "Player Score" = 0

3. Add the `Player Input` script as a component. Set the "Run Speed" to 3. Feel free to adjust this if you would like. Also, drag the `Player` game object from the Scene Hierarchy into the "Player" slot. Note: this script will not work without an Animator, so you will have to see the "Player Animations" section below to make it work.

4. Add the `Inventory` script as a component. This is where you store items such as armour, weapons, healing potions, etc.

5. Add the `Dealing Damage` script as a component. Also, drag the `Player` game object from the Scene Hierarchy into the "Player" slot. Set "Attack Range" to 1. Set "Enemy Layers" to "Enemies". Now, to set up Attacking points in all directions:

- Right click the `Player` game object, then press "Create Empty". Rename this game object as `RightAttackPoint`.

- Re-position the `RightAttackPoint` game object slightly on the right handside of the `Player` Sprite. This will be used as the position where the Player can hit enemies. (Do this for all directions, and name the rest of the objects `UpAttackPoint`,`DownAttackPoint` and `LeftAttackPoint`)

- When you are done positioning each attack point, drag each of the attack points in the appropriate place in the `Dealing Damage` component.

6. Add the `Save Manager` script as a component. This component allows you to save the details about the Player's progress in the game.

7. Add the `UI Controls` script as a component. This component allows you to control the User Interface, like pausing the game, showing inventory, etc.

8. Add the `Inventory` script as a component. This component stores the equipment that a Player has equipped.

### Enemy Sprite

The following instructions apply to the `Enemy` game object(s) only:

1. While the `Enemy` game object is selected, change its Tag to "Enemy". Click "Add Tag" if the tag is not already there.

2. Change the `Enemy` game object's "Layer" as "Enemies". Click "Add Layer" if the tag is not already there.

3. Add the `Enemy` script as a component. Set the values however you would like, especially the "Enemy Name". Default values are as follows:
- "Attack" = 40
- "Defense" = 5
- "Max Health" = 50
- "Health" = 0
- "Value" = 100 (The amount added to Player Score when defeated)

4. Add the `Enemy Movement` script as a component. Drag the `Player` game object into the "Player" value for the component (This is what the Enemy will follow and try to defeat). Set Movement Speed to 1. Set Hostile Radius to 7. You can adjust the values of these fields if you want.

5. Add the `Enemy Spawning` script as a component. Set "Time To Respawn" to 20, or any value you want.


## Sprite Animation

### Player Animations

#### Walking

TODO

#### Attacking

TODO

### Enemy Animations

TODO

## In-Game Menus / Interfaces

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `UserInterface` folder.

4. Within the `UserInterface` game object, locate the prefab called `InGameMenus` and drag it into the Scene Hierarchy.

### Heads Up Display (HUD)

- Within the `UserInterface` game object, locate the prefab called `HUD` and drag it into the Scene Hierarchy.

### Inventory Customization

TODO

### Pause Menu Customization

TODO

### Death Screen Customization

TODO

## Main Menu

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Scenes` folder.
3. Within the `Scenes` folder, right-click on an empty space in the folder and create a new Scene. Name it as `Main Menu`.

4. Double click on the `Main Menu` Scene to open it. 
5. In the Project window, click on the `Assets` folder if it is not already opended.
6. Within the `Assets` folder, click on the `Prefabs` folder.
7. Within the `Prefabs` folder, click on the `UserInterface` folder.
8. Within the `UserInterface` folder, locate the prefab called `MainMenu`. Drag `Main Menu` into the Scene Hierarchy.

9. Within the Scene Hierarchy, open the children of `MainMenu` and locate `MenuInterface`. Open the children of `MenuInterface` and select the `Background` game object. In the "Inspector" window, locate the Image component. You can customize the Image of the background of the main menu, or change the color. Be creative!

## Other Scripts

### ...