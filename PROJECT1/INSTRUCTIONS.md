# HOW TO MAKE A TOP-DOWN GAME QUEST GAME

## Level Creation (2D Tilemaps)

Open the Unity editor and follow these instructions:

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Landscapes` folder.

![finding landscapes](./INSTRUCTION_images/LevelCreation/locating_landscapes.PNG "A screenshot of file structure, finding the landscape prefabs")

#### Using a Pre-made Landscape 
- The `Landscapes` folder has many different landscapes you can choose from. Drag your favorite landscape into the Scene Hierarchy (All colliders are already set up for you).

![landscape into scene](./INSTRUCTION_images/LevelCreation/premade_landscape.PNG "A screenshot of Scene Hierarchy containing landscape that was dragged into it.")

#### Making Your Own Landscape

4. Within the `Landscapes` folder, locate the prefab named `YourLandscape` and drag it into the Scene Hierarchy. This is a grid where you can draw your own landscape for your level.

![your landscape](./INSTRUCTION_images/LevelCreation/your_landscape.PNG "A screenshot of the prefab "YourLandscape")

![landscape into scene](./INSTRUCTION_images/LevelCreation/yourlandscape_into_scene.PNG "A screenshot of Scene Hierarchy containing landscape that was dragged into it.")

5. Look at the top of the screen and click the `Window` menu button. From there, click on the `2D` button, then within that menu click on `Tile Palette`. This is the window that helps you draw your own landscape. Drag the `Tile Palette` window to the side so that the Scene view is visible.

![finding tilepalette](./INSTRUCTION_images/LevelCreation/finding_tilepalette.PNG)

![tilepalette_window](./INSTRUCTION_images/LevelCreation/tilepalette_window.PNG)

6. Within the `Tile Palette` window, the dropdown menu next to the text `Active Tilemap` tells you which layer you are drawing in. Within that dropdown menu, select `GroundLayer`. If a Window called "Open in Prefab Mode" opens up, select "Prefab Mode".

![prefab mode](./INSTRUCTION_images/LevelCreation/prefab_mode.PNG)

7. Now, click on the paint brush icon.

![paint brush](./INSTRUCTION_images/LevelCreation/paint_brush.PNG)

8. Within the `Tile Palette` window, select a portion that you want to use in your level (preferably something that would be considered the Ground).

For example:
![select portion](./INSTRUCTION_images/LevelCreation/select_portion.PNG)

9. Once you have selected a portion, start drawing on the Scene view however you see fit. Be creative! If you make a mistake, you can use the eraser tool.

![paint scene](./INSTRUCTION_images/LevelCreation/paint_scene.PNG)
![eraser](./INSTRUCTION_images/LevelCreation/eraser.PNG)

10. When you think you are done drawing in this Tilemap, change the `Active Tilemap` to `Obstacles`. Try to select a portion of the Tilemap that is an obstacle. Then start drawing on the Scene view.

![obstacle menu](./INSTRUCTION_images/LevelCreation/obstacle.PNG)

11. Optionally, you can change the `Active Tilemap` to `PassUnder`. This Tilemap is where you think the player can pass under like a bridge. However, this layer can be difficult because you would have to make sure that there is a filled in `Ground Layer` underneath the section you want there to be a `PassUnder`. This is so that the colliders do not conflict each other, and there would be complexities to fix.

If you think you are done with your landscape, Congratulations! You just created your own landscape! This is an example end product:

![end product](./INSTRUCTION_images/LevelCreation/example_endproduct.PNG)

## Adding Main Character

1. Click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Players` folder.

![locating players](./INSTRUCTION_images/AddingMainCharacter/locating_players.PNG)

4. Select your favorite player, and drag them into the Scene Hierarchy.

5. In the Scene Hierarchy, rename the player to `Player` if applicable. This is so the built-in scripts can work normally.

![player into scene](./INSTRUCTION_images/AddingMainCharacter/player_into_scene.PNG)

6. In the Scene Hierarchy, drag the Game Object named `Main Camera` onto the Player to make it its child. This makes sure the camera follows the player when it moves around.

![player camera](./INSTRUCTION_images/AddingMainCharacter/player_camera.PNG)

## Adding Enemies

1. Click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `Enemies` folder.

![locating enemies](./INSTRUCTION_images/AddingEnemies/locating_enemies.PNG)

4. Select your favorite enemy, and drag them into the Scene Hierarchy.

![enemy into scene](./INSTRUCTION_images/AddingEnemies/enemy_into_scene.PNG)

## Adding Loot

TODO

## Adding Treasure Chests

TODO

## Setting Up Sprites

Do the following while the `Player` or `Enemy` game object you want to set up is selected in the Scene Hierarchy:

1. Set the position of `Player` and/or `Enemy` within the bounds of your `Landscape`. You can do so by first selecting the `Player` or `Enemy` object in the Scene Hierarchy, then using the `Move Tool` within the Scene Window, dragging the `Player` into place.

![moving character](./INSTRUCTION_images/SettingUpSprites/moving_character.gif)

2. The `Box Collider 2D` component will be used for when the character runs into walls, obstacles, etc. Click the "Edit Collider" icon. Here, you can adjust the size of the collider. Ideally, adjust the collider shape to match the size of your Sprite.

![boxcollider2d](./INSTRUCTION_images/SettingUpSprites/boxcollider2d.PNG)

3. The `Capsule Collider 2D` component will be triggered when the the Player run into Enemies. click the "Edit Collider" icon. Here, you can adjust the size of the collider. Ideally, adjust the collider shape to match the size of your Sprite.

![capsulecollider2d](./INSTRUCTION_images/SettingUpSprites/capsulecollider2d.PNG)

### Player Sprite

The following instructions apply to the `Player` game object only:

1. While the `Player` game object is selected, in the "Inspector" window, change its Tag to "Player". Click "Add Tag" if the tag is not already there.

![Player Tag](./INSTRUCTION_images/SettingUpSprites/PlayerSprite/tag.PNG)

![Player Layer](./INSTRUCTION_images/SettingUpSprites/PlayerSprite/layer.PNG)

2. In the `Player` script component, set the values however you would like. Recommended values are as follows:
- "Attack" = 25
- "Defense" = 10
- "Max Health" = 100
- "Health" = 0
- "Player Score" = 0

3. Locate the `Player Input` script component, set the "Run Speed" to 3. Feel free to adjust this if you would like.

4. Locate the `Inventory` script component, this is where you store items such as armour, weapons, healing potions, etc.

5. Locate the `Dealing Damage` script component, set "Attack Range" to 1. Set "Enemy Layers" to "Enemies". The `UpAttackPoint`,`DownAttackPoint`, `LeftAttackPoint` and `RightAttackPoint` are where the player can attack in all directions.

6. In the `Save Manager` script component, you can save the details about the Player's progress in the game.

7. The `UI Controls` script component, allows the Player to control the User Interface, like pausing the game, showing inventory, etc.

8. The `Inventory` script component stores the equipment that a Player has acquired or equipped.

### Enemy Sprite

The following instructions apply to the `Enemy` game object(s) only:

1. While the `Enemy` game object is selected check the "Inspector" window. Change its Tag to "Enemy". Click "Add Tag" if the tag is not already there.

2. Change the `Enemy` game object's "Layer" as "Enemies". Click "Add Layer" if the tag is not already there.

3. In the `Enemy` script component, set the values however you would like, especially the "Enemy Name". Default values are as follows:
- "Attack" = 40
- "Defense" = 5
- "Max Health" = 50
- "Health" = 0
- "Value" = 100 (The amount added to Player Score when defeated)

4. In the `Enemy Movement` script component, drag the `Player` game object into the "Player" value for the component (This is what the Enemy will follow and try to defeat). Set Movement Speed to 1. Set Hostile Radius to 7. You can adjust the values of these fields if you want.

5. In the `Enemy Spawning` script component, set "Time To Respawn" to 20, or any integer value you want.

## In-Game Menus / Interfaces

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Prefabs` folder.
3. Within the `Prefabs` folder, click on the `UserInterface` folder.

![locating menus](./INSTRUCTION_images/InGameMenusInterfaces/locating_menus.PNG)

4. Within the `UserInterface` folder, locate the prefab called `InGameMenus` and drag it into the Scene Hierarchy. You will see a bunch of the menus layered on top of each other. In Game Mode, they will only be shown if the Player toggles them.

![menu into scene](./INSTRUCTION_images/InGameMenusInterfaces/dragmenu.PNG)

### Heads Up Display (HUD)

- Within the `UserInterface` folder, locate the prefab called `HUD` and drag it into the Scene Hierarchy.

If you want to see the rest of the scene more easily, make the `InGameMenus` game object inactive.

![inactive](./INSTRUCTION_images/InGameMenusInterfaces/inactive.PNG)


### Inventory Customization

TODO

### Pause Menu Customization

TODO

### Death Screen Customization

TODO

## Main Menu

1. In the Project window, click on the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, click on the `Scenes` folder.

![locate scenes](./INSTRUCTION_images/MainMenu/locatescenes.PNG)

3. Within the `Scenes` folder, right-click on an empty space in the folder and create a new Scene. Name it as `Main Menu`.

![add scene](./INSTRUCTION_images/MainMenu/addscene.PNG)

4. Double click on the `Main Menu` Scene to open it. 
5. In the Project window, click on the `Assets` folder if it is not already opended.
6. Within the `Assets` folder, click on the `Prefabs` folder.
7. Within the `Prefabs` folder, click on the `UserInterface` folder.

![locating menus](./INSTRUCTION_images/InGameMenusInterfaces/locating_menus.PNG)

8. Within the `UserInterface` folder, locate the prefab called `MainMenu`. Drag `Main Menu` into the Scene Hierarchy.

9. Within the Scene Hierarchy, open the children of `MainMenu` and locate `MenuInterface`. Open the children of `MenuInterface` and select the `Background` game object. 

![locating background](./INSTRUCTION_images/MainMenu/locate_background.PNG)

10. In the "Inspector" window, locate the Image component. You can customize the Image of the background of the main menu, or change the color. Be creative!

![edit background](./INSTRUCTION_images/MainMenu/image.PNG)

## Setting Up Level Goals

### ...