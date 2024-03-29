# HOW TO MAKE A SINGLE PLAYER TOP-DOWN 2D GAME

## ATTRIBUTION

1. ansimuz 
    - https://opengameart.org/content/rpg-town-pixel-art-assets
    - https://opengameart.org/content/trees-bushes

2. Stephen Challener (Redshrike) and Jetrel, hosted by OpenGameArt.org (https://opengameart.org/content/16x16-indoor-rpg-tileset-the-baseline)

3. Nimrod (https://opengameart.org/content/potion-bottles-1-0)

4. bluecarrot16, Benjamin K. Smith (BenCreating), Evert, Eliza Wyatt (ElizaWy), TheraHedwig, MuffinElZangano, Durrani, Johannes Sj?lund (wulax), Stephen Challener (Redshrike) (https://sanderfrenken.github.io/Universal-LPC-Spritesheet-Character-Generator/)

5. "[LPC] Desert Ruins" by bluecarrot16. Commissioned by Pierre Vigier (pvigier). Licenses: OGA-BY 3.0+, CC-BY 3.0+, GPL 2.0+. http://opengameart.org/content/lpc-desert-ruins

6. "Cave" Art by MrBeast. Commissioned by OpenGameArt.org (http://opengameart.org).

7. "Wolf Animation" Graphic Artist: Stephen "Redshrike" Challener, Contributor: William.Thompsonj. (https://opengameart.org/content/lpc-wolf-animation)

8. Music by Rajiv Williams (PRODUCER RAW) (https://www.youtube.com/channel/UCAUBm2DSjImDdeE9mQ47LbA)


## Getting Started

- Make sure to install the Unity Editor
    https://unity.com/download

- git clone this repository

- Make use of the "Assets" folder in this repository (This includes everything you need to build the game)

## Making a New Scene

Open the Unity Editor and follow these instructions:

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Scenes` folder.

![locate scenes](./INSTRUCTION_images/MainMenu/locatescenes.PNG)

3. Within the `Scenes` folder open the `YourScenes` folder. Right-click on an empty space in the folder and create a new Scene. Name it as `MainScene_Level1`.

![add scene](./INSTRUCTION_images/MainMenu/addscene.PNG)

4. In the Project window, open the `Assets` folder if it is not already opended.
5. Within the `Assets` folder, open the `Scripts` folder.
6. Within the `Scripts` folder, open the `Globals` folder.
7. Within the `Globals` folder, open the `Globals` script in a Text Editor.

![find Globals](./INSTRUCTION_images/LevelCreation/findglobal.PNG)

8. Within the `Globals.cs` script, change the the value of `mainSceneName_Level` in the quotations to "MainScene_Level1". **Note:** This name tells the game where to go when the player wants to restart the game (Very important!).

![edit Globals](./INSTRUCTION_images/LevelCreation/editglobal.PNG)

## Level Creation (2D Tilemaps)

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Prefabs` folder.
3. Within the `Prefabs` folder, open the `Landscapes` folder.

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

If you think you are done with your landscape, congratulations! You just created your own landscape! This is an example end product:

![end product](./INSTRUCTION_images/LevelCreation/example_endproduct.PNG)

## Adding Main Character

1. Open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Prefabs` folder.
3. Within the `Prefabs` folder, open the `Players` folder.

![locating players](./INSTRUCTION_images/AddingMainCharacter/locating_players.PNG)

4. Select your favorite player, and drag them into the Scene Hierarchy.

5. In the Scene Hierarchy, rename the player to `Player` if applicable. This is so the built-in scripts can work normally.

![player into scene](./INSTRUCTION_images/AddingMainCharacter/player_into_scene.PNG)

6. In the Scene Hierarchy, drag the Game Object named `Main Camera` onto the Player to make it its child. This makes sure the camera follows the player when it moves around.

![player camera](./INSTRUCTION_images/AddingMainCharacter/player_camera.PNG)

## Adding Enemies

1. Open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Prefabs` folder.
3. Within the `Prefabs` folder, open the `Enemies` folder.

![locating enemies](./INSTRUCTION_images/AddingEnemies/locating_enemies.PNG)

4. Select your favorite enemy, and drag them into the Scene Hierarchy.

![enemy into scene](./INSTRUCTION_images/AddingEnemies/enemy_into_scene.PNG)

## Sprites Set-Up

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
- "Default Attack" = 25
- "Default Defense" = 10
- "Max Health" = 100
- "Player Score" = 0

Also, to set the "Starting Position" of the Player, navigate to the `Scriptable Objects` folder in the `Assets` folder. You will find the `PlayerPosition` asset. Set the value of the "X" and "Y" of the position you want the player to start at in the first Scene.

![Player Position](./INSTRUCTION_images/SettingUpSprites/PlayerSprite/playerposition.PNG)

Drag this into the slot of the "Starting Position" for the `Player` script. This will allow the player to maintain the same position when entering and exiting `DoorWay` game objects. (**Note:** This should be done for every scene the `Player` is in)

![Starting Position](./INSTRUCTION_images/SettingUpSprites/PlayerSprite/start.PNG)

3. Locate the `Player Input` script component, set the "Run Speed" to 3. Feel free to adjust this if you would like.

4. Locate the `Dealing Damage` script component, set "Attack Range" to 1. Set "Enemy Layers" to "Enemies". The `UpAttackPoint`,`DownAttackPoint`, `LeftAttackPoint` and `RightAttackPoint` are where the player can attack in all directions.

5. In the `Save Manager` script component, you can save the details about the Player's progress in the game.

6. The `UI Controls` script component, allows the Player to control the User Interface, like pausing the game, showing current level, etc.

### Enemy Sprite

The following instructions apply to the `Enemy` game object(s) only:

1. While the `Enemy` game object is selected check the "Inspector" window. Change its Tag to "Enemy". Click "Add Tag" if the tag is not already there.

2. Change the `Enemy` game object's "Layer" as "Enemies". Click "Add Layer" if the tag is not already there.

3. In the `Enemy` script component, set the values however you would like, especially the "Enemy Name". Default values are as follows:
- "Attack" = 40
- "Defense" = 5
- "Max Health" = 50
- "Health" = 0
- "Number Of Lives" = 1
- "Revive Time" = 20
- "Value" = 100 (The amount added to Player Score when defeated)

**Note:** If the "Number Of Lives" is greater than 1, the Enemy is able to Revive. Set the "Revive Time" variable how you want.

4. In the `Enemy Movement` script component, drag the `Player` game object into the "Player" value for the component (This is what the Enemy will follow and try to defeat). Set Movement Speed to 1. Set Hostile Radius to 7. You can adjust the values of these fields if you want.

## In-Game Menus / Interfaces Customization

Each `Player` prefab has a built-in `InGameMenus` in it. You will see a bunch of the menus layered on top of each other. In Game Mode, they will only be shown if the `Player` toggles them.

### Heads Up Display (HUD)

- Within the `UserInterface` folder, locate the prefab called `HUD` and drag it into the Scene Hierarchy.

If you want to see the rest of the scene more easily, make the `InGameMenus` game object inactive. 

**Note:** Make sure to check this box before going into Game Mode.

![inactive](./INSTRUCTION_images/InGameMenusInterfaces/inactive.PNG)

## Main Menu

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Scenes` folder.

![locate scenes](./INSTRUCTION_images/MainMenu/locatescenes.PNG)

3. Within the `Scenes` folder open the `YourScenes` folder. Right-click on an empty space in the folder and create a new Scene. Name it as `Main Menu`.

![add scene](./INSTRUCTION_images/MainMenu/addscene.PNG)

4. Double click on the `Main Menu` Scene to open it. 
5. In the Project window, open the `Assets` folder if it is not already opended.
6. Within the `Assets` folder, open the `Prefabs` folder.
7. Within the `Prefabs` folder, open the `UserInterface` folder.

![locating menus](./INSTRUCTION_images/InGameMenusInterfaces/locating_menus.PNG)

8. Within the `UserInterface` folder, locate the prefab called `MainMenu`. Drag `Main Menu` into the Scene Hierarchy.

9. Go to a child of `MainMenu` named `CreateNewGame` and find the `Create New Game (Script)` component. 

![find CreateNewGame](./INSTRUCTION_images/InGameMenusInterfaces/findcreate.PNG)

10. In the `Create New Game (Script)` component, set the "First Level Name" to the first Scene that you want your `Player` to be in. **Note:** Make sure you spell it correctly, since this value is case sensitive.

![set Level 1](./INSTRUCTION_images/InGameMenusInterfaces/findcreate.PNG)

11. Within the Scene Hierarchy, open the children of `MainMenu` and locate `MenuInterface`. Open the children of `MenuInterface` and select the `Background` game object. 

![locating background](./INSTRUCTION_images/MainMenu/locate_background.PNG)

12. In the "Inspector" window, locate the Image component. You can customize the Image of the background of the main menu, or change the color. Be creative!

![edit background](./INSTRUCTION_images/MainMenu/image.PNG)

13. You can also change the color and size of text across the `MainMenu`. Locate game objects with "Label" in the name. Select one of these objects, for example, `MainMenuLabel`.

![find label](./INSTRUCTION_images/MainMenu/findlabel.PNG)

14. While `MainMenuLabel` is selected, see the "Inspector" window and locate the `TextMeshPro - Text (UI)` component. This is where you can change the text of the Main Menu Title. Under "Text Input" Change "INSOMNIA" to "My Game" or whatever you would like.

![change label](./INSTRUCTION_images/MainMenu/mygame.PNG)

15. In the `TextMeshPro - Text (UI)` component, change the "Vertex Color" to any color you want. This changes the color of your text.

![change color](./INSTRUCTION_images/MainMenu/changecolor.PNG)

You can customize the `PauseMenu`, `DeathScreen` and the `HUD` in the same way by changing colors of text, background and re-sizing things in any way you want. Just make sure it fits on the screen!

## Loading Screen

1. Make a new Scene in the `YourScenes` folder, and name it `LoadingScreen`.

The path to find the `YourScenes` folder:
![MyHouse Scene](./INSTRUCTION_images/DoorWays/either1.PNG)

2. In the Project window, open the `Assets` folder if it is not already opended.
3. Within the `Assets` folder, open the `Prefabs` folder.
4. Within the `Prefabs` folder, open the `LoadingScreen` folder.

![finding LoadingScreen](./INSTRUCTION_images/LoadingScreen/finding.PNG)

5. Within the `LoadingScreen` folder, locate the prefab named `LoadingScreen` and drag it into the Scene Hierarchy. This game object has a loading animation and barriers.

6. Locate the `Player` prefab that you are using, and drag that into the Scene. Re-size it however you want and set the "Run Speed" value of the `Player Input (Script)` component to a speed that matches the size. Have fun with it if you want! Recommended values are as follows:
    - In the `Transform` component, set the Scale to 10 for "X" and "Y".
    ![Setting x and y](./INSTRUCTION_images/LoadingScreen/setxy.PNG)
    - In the `Player Input (Script)` component, set "Run Speed" to 30.
    ![Setting speed](./INSTRUCTION_images/LoadingScreen/speed.PNG)

## Adding Background Music

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Prefabs` folder.
3. Within the `Prefabs` folder, open the `Music` folder.
4. Within the `Music` folder, locate the prefab named `BackgroundMusic` and drag it into the Scene Hierarchy (any Scene you want). This game object makes it so you have background music in your game. It is used by `Settings` where its volume is adjusted.

![finding music](./INSTRUCTION_images/AddingBackgroundMusic/find.PNG)

5. You can change the song by adding your own, or one that you have rights to use by changing the value in the `Audio Source` component.

![change music](./INSTRUCTION_images/AddingBackgroundMusic/change.PNG)

## Door Ways (Difficult)

Door Ways in the context of this project allow you to enter and exit buildings and go to different Scenes in a level. In the titles of the instructions, the place a `Player` is coming from is referred to as an `Entry Way` while the place a `Player` is entering is referred to as a `Destination`.

In these instructions, you will need to store the positions of an `Entry Way` and a `Destination` in different Scenes so that the `Player` starting position makes sense when entering and exiting a `DoorWay`. 

### Getting the Player Starting Position In Entry Way

1. Make sure to open the Scene that you want to make the `DoorWay` in.

2. In the Project window, open the `Assets` folder if it is not already opended.
3. Within the `Assets` folder, open the `Prefabs` folder.
4. Within the `Prefabs` folder, open the `DoorWays` folder.

![finding doorways](./INSTRUCTION_images/DoorWays/finding.PNG)

5. Within the `DoorWays` folder, locate the prefab named `DoorWay` and drag it into the Scene Hierarchy. You can rename it to whatever you would like. This game object will be used at entrances and exits throughout your landscape, if you have buildings with doors, or entrance ways to new scenes.

![drag in doorway](./INSTRUCTION_images/DoorWays/drag.PNG)

6. Move your `DoorWay` where you would like it to be (position it in an entrance way). Make note of the X and Y "Position" values of the `Transform` component. These are the values you will use to store the position of `OutsideDoorWay`, which will be something we can use to store the position (More Details in Step 12).

![x and y positions](./INSTRUCTION_images/DoorWays/notexy.PNG)

7. While the `DoorWay` game object is selected, look in the "Inspector" window. In the `Door Way` script component, set the "Player" to the `Player` game object currently in the Scene Hierarchy.

![script component](./INSTRUCTION_images/DoorWays/scriptcomp.PNG)

8. In the Project window, open the `Assets` folder if it is not already opended.
9. Within the `Assets` folder, open the `ScriptableObjects` folder.
10. Within the `ScriptableObjects` folder, open the `YourDoorWays` folder.

![find YourDoorWays](./INSTRUCTION_images/DoorWays/findyour.PNG)

11. Within the `YourDoorWays` folder, create a new folder and name it the place the `Player` is entering. For example, if you were entering your house, you would name the folder as `MyHouse`. Open the folder you just created.

![new folder](./INSTRUCTION_images/DoorWays/foldermyhouse.PNG)

12. Within this folder, create a new `VectorValue` Scriptable object. This is where you will store the position of the door way in the scene you want the `Player` to go to. Name this object as `OutsideDoorWay`.

![OutsideDoorWay Vector Value](./INSTRUCTION_images/DoorWays/vvoutside.PNG)

13. While `OutsideDoorWay` is selected, look at the "Inspector" window. The "Initial Value" should be the coordinates (X and Y) of the outside of the door way in the current Scene. Enter the X and Y values you noted from the `DoorWay` game object in the current Scene.

![OutsideDoorWay Vector Value](./INSTRUCTION_images/DoorWays/entervalvv.PNG)

14. Navigate to the `ScriptableObjects` folder and open the `PlayerPosition` folder inside of it. Locate the `PlayerPosition` scriptable object and drag it into the "Player Position In Current Scene" value in the `Door Way` script component of the `DoorWay` game object.

![find player position](./INSTRUCTION_images/DoorWays/findpp.PNG)

15. To get the "Player Position in Destination" value for the `Door Way` script component, you must follow the steps for `Setting Up Destination Scene`. When the Vector Value is made for the Destination Scene, then you are able to set this value.

![script component updated](./INSTRUCTION_images/DoorWays/scriptcomp2.PNG)

### Setting Up Destination Scene

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `Scenes` folder.
3. Within the `Scenes` folder, open the `YourScenes` folder. In this folder, you can do either of the following: 
- Create a new Scene. Right-click on an empty space in the folder and create a new Scene. Name it whatever you would like. For example, if you were entering your house you would name it `MyHouse`.

![MyHouse Scene](./INSTRUCTION_images/DoorWays/either1.PNG)

- Locate a Scene that you already made. Make sure that  the Scene is equipped with a `Player`, `Landscape`, `HUD`, and anything else you would like. Then, rename this Scene to whatever you would like. Then, copy the Scene using CTRL-C keyboard shortcut, and then pasting it with CTRL-V. (This method is better since you keep the transition from one Scene to another consistent.)

![add scene](./INSTRUCTION_images/MainMenu/addscene.PNG)

4. If you made a new Scene, set up the Scene with a `Player`, `Landscape`, `HUD`, and anything else you would like.

5. In the Project window, open the `Assets` folder if it is not already opended.
6. Within the `Assets` folder, open the `Prefabs` folder.
7. Within the `Prefabs` folder, open the `DoorWays` folder.

![finding doorways](./INSTRUCTION_images/DoorWays/finding.PNG)

8. Within the `DoorWays` folder, locate the prefab named `DoorWay` and drag it into the Scene Hierarchy. You can rename it to whatever you would like.

![drag in doorway](./INSTRUCTION_images/DoorWays/drag2.PNG)

9. While the `DoorWay` game object is selected, look in the "Inspector" window. In the `Door Way` script component, set the "Player" to the `Player` game object currently in the Scene Hierarchy.

![script component](./INSTRUCTION_images/DoorWays/scriptcomp.PNG)

10. Navigate to the `ScriptableObjects` folder and open the `YourDoorWays` folder inside of it. Open the folder you created recently (in this example it was called `MyHouse`). 

![find OutsideDoorWay](./INSTRUCTION_images/DoorWays/findoutsidevv.PNG)

11. Inside this folder, locate the `OutsideDoorWay` scriptable object and drag it into the "Player Position In Current Scene" value in the `Door Way` script component of the `DoorWay` game object. `OutsideDoorWay` is the `Destination` of the current Scene.

![script component](./INSTRUCTION_images/DoorWays/scriptcomp3.PNG)

12. Navigate to the `ScriptableObjects` folder and open the `PlayerPosition` folder inside of it. Locate the `PlayerPosition` scriptable object and drag it into the "Player Position In Current Scene" value in the `Door Way` script component of the `DoorWay` game object.

![script component](./INSTRUCTION_images/DoorWays/scriptcomp4.PNG)

### Getting the Player Starting Position In Destination

1. In the Project window, open the `Assets` folder if it is not already opended.
2. Within the `Assets` folder, open the `ScriptableObjects` folder.
3. Within the `ScriptableObjects` folder, open the `YourDoorWays` folder.

![find YourDoorWays](./INSTRUCTION_images/DoorWays/findyour.PNG)

4. Within the `YourDoorWays` folder, open the folder that is named the place the `Player` is entering. For example, `MyHouse`.

![find OutsideDoorWay](./INSTRUCTION_images/DoorWays/findoutsidevv.PNG)

5. Open the same folder that `OutsideDoorWay` is stored in.Within this folder, create a new `VectorValue` Scriptable object. This is where you will store the position of the door way in the scene you want the `Player` to go to. Name this object as `InsideDoorWay`.

![create InsideDoorWay](./INSTRUCTION_images/DoorWays/makeinsidevv.PNG)

6. While `InsideDoorWay` is selected, look at the "Inspector" window. The "Initial Value" should be the coordinates (X and Y) of the inside of the door way within the destination Scene.

![vector InsideDoorWay before](./INSTRUCTION_images/DoorWays/inb4.PNG)

7. Open the Scene which is considered the `Destination` for the `DoorWay` that you want the `Player` to go to if it is not already opened (in this example it is the `MyHouse` Scene). Click on the `DoorWay` game object in the Scene Hierarchy. Make note of the X and Y values of the `Transform` component. These are the values you will use for `InsideDoorWay`

![x and y positions](./INSTRUCTION_images/DoorWays/notexy2.PNG)

8. Go back to the folder in the `YourDoorWays` folder where you have the `InsideDoorWay` scriptable object. Enter the X and Y values you noted from the `DoorWay` game object in the current Scene. This will be used for the `DoorWay` game object of the other Scene you are coming from when entering this `DoorWay`

![InsideDoorWay Vector Value](./INSTRUCTION_images/DoorWays/entervalvv2.PNG)

9. Now, open the Scene that is considered the `Entry Way` for this `DoorWay` to enter the missing "Player Position in Destination" value inthe `DoorWay` game object.

10. Select the `DoorWay` game object. Notice that the "Player Position in Destination" value is missing.

![Missing Vector Value](./INSTRUCTION_images/DoorWays/missing.PNG)

11. Go back to the folder in the `YourDoorWays` folder where you have the `InsideDoorWay` scriptable object. Locate the `InsideDoorWay` scriptable object. 

![create InsideDoorWay](./INSTRUCTION_images/DoorWays/makeinsidevv.PNG)

12. Drag `InsideDoorWay` into the "Player Position in Destination" value in the `DoorWay` script component of the `DoorWay` game object.

![script component](./INSTRUCTION_images/DoorWays/scriptcomp5.PNG)

Congratulations! You just made your own `DoorWay`! In game, the character can enter this `DoorWay` by pressing the `Action` button (Spacebar).

**Note:** See the `Building Game` section for the `DoorWay` to work (You have to set up which Scenes can be built).

## Building Game

1. Under the "File" menu at the top of the Unity Editor, go to "Build Settings".

![find build settings](./INSTRUCTION_images/Building/findsettings.PNG)

2. In order for the program to build the Scenes that you made, you have to add them to "Scenes in Build" section. To add a Scene you want to build, make sure it is currently open in the Unity Editor. Then, press the "Add Open Scenes" button to add them. 

![build settings](./INSTRUCTION_images/Building/buildsettings.PNG)

