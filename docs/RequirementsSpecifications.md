# 5.0  Requirements Specification
# 5.1      Introduction

This Software Requirements Specification (SRS) documents the requirements for the DoodleFight game project. DoodleFight is a 2D fighting game application that will allow users to control a character to maneuver a two-dimensional environment while in combat with another character. The DoodleFight game client is comprised of a menu system, with game-mode-selection, stage-selection, and settings menu, and core playable game. The user will be able to navigate the menu system to select and play either practice mode, versus mode, and edit various parameters for gameplay.


## 5.1.1   Outline

* 5.2     CSCI Component Breakdown
* 5.3      Functional Requirements by CSC
* 5.4      Performance Requirements by CSC
* 5.5      Project Environment Requirements

## 5.1.2     Definitions

| Term  | Definition  |   
|---|---|
| Player  | The person who is playing the game.  |  
|  Character  | The actor the player is currently controlling in game.  |  
| Bot | An AI that controls a character |
| Versus  |  A game mode in fighting games where a player faces off against another player or bot  |  
| Game Client  | Umbrella term for every aspect of the game, including the menu screen and the core game.   |  
| Core Game  | Playable portion of the game, including the HUD, the pause menu, and characters  |  
| HUD  | The heads-up display, or HUD, presents visual information to players in the Core Game as a part of the game’s UI.     |  
| Stages  | The space in which characters fight characterized by the various platforms and obstacles in it  |  

# 5.2       CSCI Component Breakdown

### 5.2.1 Top Level Menu

5.2.1.1 Game Mode Selection Menu    
5.2.1.2 Stage Selection Menu      
5.2.1.3 Settings Menu      
&nbsp;&nbsp;&nbsp;&nbsp;5.2.1.3.1 Controls     
&nbsp;&nbsp;&nbsp;&nbsp;5.2.1.3.2 Sound       

### 5.2.2 Core Game   

5.2.2.1 Fighting System              
5.2.2.2 Health System    
5.2.2.3 HUD    
5.2.2.4 Pause Menu    
5.2.2.5 Continue Screen  


# 5.3       Functional Requirements

## 5.3.1     Game Client

### 5.3.1.1   Menu

5.3.1.1.1 The Main Menu for the application shall provide the user with a way to select what function of the application they want to proceed to.      

  There will exist a tree of menus as follows:      
  - Main Menu Menu
    - Game Mode Menu
      - Versus Menu
        - Player vs. Player
        - Player vs. Bot
          - Stage Select Menu
      - Practice Menu
        - Stage Select Menu
    - Settings Menu

5.3.1.1.2 Main Menu         
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.2.1 The Main Menu shall allow the player to access the submenus Game Mode and Settings.     
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.2.2 The Main Menu shall allow the player to quit the application.       

5.3.1.1.3 Settings Menu      

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.3.1 The Settings Menu shall allow the player to change the buttons for controlling the game. These buttons will include, but not be limited to, the following buttons:            
* Left     
* Right      
* Up     
* Down     
* Attack     
* Special
* Guard

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.3.2 The Settings Menu shall allow the player to edit the sound levels of the application.       
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.3.3 The Settings Menu shall provide the player access back to the Top Level Menu.      

5.3.1.1.4 Game Mode Menu               
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.4.1 The Game Mode Menu shall display a list of potential game modes.          
* The player will be able to select Player vs. Player
* The player will be able to select Player vs. Bot
* The player will be able enter practice mode

5.3.1.1.4.2 Stage Select Menu         
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.4.2.1 The Stage Select Menu shall provide a set of buttons providing the player to each accessible stage.

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.4.2.2 The World Selection Menu shall provide the player access back to the File Selection Screen.

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.1.4.3 The Game Mode Menu shall provide the player access back to the Top Level Menu.


###  5.3.1.2   Core Game        
The Core Game is where combat takes place between two characters.             
The Core Game will display to the user the current game state and respond to player inputs.         

5.3.1.2.1 Main Game           
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.1.1 The Fighting System shall allow the player to perform combinations of attacks using various directional inputs combined with the attack or special button.      
* The character will perform a unique attack depending on whether the directional input is left/right/up/down + attack button.
* The character will perform a unique attack depending on whether the directional input is left/right/up/down + special button.
* The character will perform grab when the guard and attack buttons are pressed simultaneously.
* The character will defend themselves from all attacks with the exception of grabs while holding the guard button.

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.1.2 The Health System gives the player the option to defeat a character by depleting their health completely, or weakening the character and knocking them off of the stage.

&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.1.3 The HUD will display the characters health bars, the time remaining for the round of combat, as well as the amount of knockouts scored by each character.   

5.3.1.2.2 Pause Menu
 &nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.2.1 The Pause Menu shall halt the game. While the game is halted the following elements shall be displayed on the screen:       
* "Resume" will return the game to a running state from a halted state       
* "Return to Stage Select" will return the game to the stage selection screen          
* "Return to Main Menu" will return the game to its main menu
* "Settings" will open the Settings Menu

5.3.1.2.3 Continue Screen       
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.3.1 The Continue shall be displayed when one player has won the requisite amount of rounds (3 - 5 depending on settings).      
&nbsp;&nbsp;&nbsp;&nbsp;5.3.1.2.3.2 The Continue Screen shall allow the player to choose between a rematch, returning to stage select, or returning to the main menu     

## 5.3.2     Game Assets

5.3.2.1   The game shall have assets including 2D Models and animations
5.3.2.2   The characters in game shall be represented the 2D Models.       
5.3.2.3   The characters in the game shall use animations.      

# 5.4       Performance Requirements

5.4.1     Game Responsiveness      
&nbsp;&nbsp;&nbsp;&nbsp;5.4.1.1   The game shall run at a reasonable speed without frame drops on most modern systems.      
&nbsp;&nbsp;&nbsp;&nbsp;5.4.1.2   The game client shall load in under 3 seconds.       
&nbsp;&nbsp;&nbsp;&nbsp;5.4.1.3   The controls shall be responsive and instant to the player.        
&nbsp;&nbsp;&nbsp;&nbsp;5.4.1.4   The game client shall handle errors in a way to avoid crashing.       

# 5.5       Environment Requirements

5.5.1     Unity recommends this setup of hardware to run software developed in it at an adequate level:      

| Category  | Requirement  |  
|---|---|
| Operating System | Windows XP SP2+, Mac OS X 10.9+, Ubuntu 12.04+, SteamOS+ |   
| Processor | SSE2 instruction set support |
| Memory  | 8 GB RAM  |  
| Video Card/DirectX Version  |  DX9 (shader model 3.0) or DX11 with feature level 9.3 capabilities |
