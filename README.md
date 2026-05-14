# Kingdom Crashers (Unity 2D Game)

## Description
Kingdom Crashers is a 2D side-scrolling action game inspired by classic beat-em-up games such as Castle Crashers. The player controls a knight character who can move, jump, attack enemies, collect gold, gain experience, and survive enemy encounters throughout the level. The game features enemy AI, combat systems, loot drops, health and XP progression, animated combat, UI systems, pause functionality, and both victory and game over conditions.

---

## Group Members
- Caleb Sandoval  
- Chris Dodge
- Charles Phan
- Jean Bustamante
- Diego Moreno  

---

## Features
- 2D side-scrolling gameplay
- Player movement and jumping system
- Melee combat attack system
- Animated player attacks
- Enemy AI with player detection and chasing behavior
- Enemy attack system with cooldown timing
- Enemy health and death system
- Gold drop and collection system
- XP and leveling system
- Health bar UI
- XP bar UI
- Gold counter UI
- Pause menu system
- Main menu scene
- Win condition system
- Game over system
- Health pickup system
- Turkey leg healing pickups
- Camera follow system
- Enemy spawning system
- Interactive UI hover and blink effects
- Sprite animations and combat feedback
- Collectible rewards and progression mechanics

---

## Scripts
- `PlayerMovement.cs` – Controls player movement, jumping, attacking, animations, and combat logic  
- `PlayerHealth.cs` – Handles player health, healing, death state, health UI, game over panel, and restarting/menu transitions  
- `PlayerXP.cs` – Manages leveling, XP gain, XP bar UI, and level progression  
- `PlayerGold.cs` – Tracks collected gold and updates gold UI  
- `AttackHitbox.cs` – Detects attack collisions and applies damage to enemies and practice dummies  
- `Enemy.cs` – Handles enemy health, death behavior, XP rewards, gold drops, turkey leg drops, and destroy effects  
- `EnemyAI.cs` – Controls enemy movement, player detection, chasing, attacking, and stun behavior  
- `EnemyAttackHitbox.cs` – Applies damage to the player through enemy attacks  
- `EnemyDamage.cs` – Practice dummy damage/reset system for testing combat  
- `EnemySpawner.cs` – Spawns enemies throughout the level while maintaining spacing rules  
- `GoldPickup.cs` – Handles collectible gold bags and gold UI updates  
- `HealthPickup.cs` – Heals the player when health pickups are collected  
- `TurkeyLegPickup.cs` – Restores player health when turkey leg pickups are collected  
- `CameraFollow.cs` – Smoothly follows the player during gameplay  
- `MainMenu.cs` – Handles scene transitions for starting and exiting the game  
- `PauseMenu.cs` – Handles pausing, resuming, quitting, and returning to the menu  
- `FinishLevel.cs` – Detects when the player reaches the end of the level and triggers the win state  
- `ButtonBlink.cs` – Creates blinking button hover effects for UI interaction  
- `ButtonHoverGold.cs` – Changes button text color to gold when hovered  
- `ButtonHoverRed.cs` – Changes button text color to red when hovered  

---

## Assets & Attribution

- **Castle Crashers Inspired Artwork and References**  
  Inspiration Source: The Behemoth – Castle Crashers  
  Usage: Inspiration for gameplay style and visual direction  

- **Custom Pixel Art Sprites and Animations**  
  Original player, enemy, UI, and environmental sprites were hand-drawn in Procreate and animated specifically for this project.  
  Usage: Used throughout gameplay, combat animations, menus, UI elements, and environmental design.

- **Background Music / Chiptune Music Pack**  
  Creator: SubspaceAudio  
  Source: OpenGameArt.org  
  License: CC0 / Public Domain  
  Usage: Used for menu and gameplay background music.

- **Custom Sprites and UI Elements**  
  Created and edited within Unity for educational purposes.

> All third-party assets are used for educational purposes only.

---

## How to Run the Project
1. Open Unity Hub  
2. Click "Add Project" and select the project folder  
3. Open the project in Unity  
4. Load the `MainMenu` scene  
5. Press Play to start the game  

---

## Gameplay Objective
Progress through the level by:
- Defeating enemies  
- Collecting gold and XP  
- Avoiding damage  
- Managing health  
- Reaching the end of the level  

---

## Controls
- Move Left: A  
- Move Right: D  
- Jump: Spacebar  
- Attack: J  
- Pause Menu: Escape  

---

## Notes
- The repository contains essential Unity project files for the game.  
- Some large Unity-generated folders are excluded using `.gitignore`.  
- Scene files include both the main gameplay scene and main menu scene.

---

## Disclaimer
This project was created for educational purposes only as part of CSE-4410. All rights to referenced games, characters, music, and third-party assets belong to their respective owners.
