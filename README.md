README.md
# Chaos Runner (Unity Game)

## Description
Chaos Runner is a fast-paced Unity endless runner-style game where the player automatically moves forward while avoiding obstacles and fighting enemies. The player can switch between lanes, jump, collect rings, and shoot projectiles to eliminate enemies and earn points. Enemies are spawned along the track and attack when the player is aligned in the same lane and within range. The game features score, ring, and health tracking, along with win and lose conditions triggered by reaching the finish line or losing all health.

---

## Group Members
- Caleb Sandoval  
- Solo Project  

---

## Features
- Continuous forward player movement
- Lane-based movement system (left, middle, right)
- Jumping mechanic with gravity
- Projectile-based shooting system for the player
- Bullets destroy enemies and increase score
- Enemy shooting system based on lane alignment, range, and cooldown timing
- Enemy spawning system across lanes along the track
- Collectible ring system that increases the player’s ring count
- Rotating ring collectibles for visual feedback
- Ring spawning system that places ring columns across lanes while avoiding enemy zones
- Custom hit detection using position-based distance checks
- Score, ring count, and health tracking via HUD
- Health system based on 3 rings = 100%
- Damage system from enemy projectiles and environmental traps
- Dynamic camera shake effects when taking damage
- Win condition triggered by reaching the finish line
- Game over and win UI panels
- Restart level and quit-to-menu functionality
- Main menu with play and quit options
- Finish-line particle effects
- Environmental hazards such as spike traps
- Spike trap spawning system with spacing rules to avoid rings and enemies
- Interactive UI with hover effects for buttons

---

## Scripts
- `PlayerRunner.cs` – Controls player movement, lane switching, jumping, gravity, and shooting  
- `Bullet.cs` – Moves player bullets forward, destroys enemies on impact, and updates score  
- `EnemyBullet.cs` – Handles enemy projectile movement, direction, and lifetime  
- `EnemyDamage.cs` – Detects when enemy projectiles hit the player and applies damage with camera shake feedback  
- `EnemyShooter.cs` – Makes enemies fire at the player when aligned in the same lane and within range  
- `EnemySpawner.cs` – Spawns enemies across track lanes up to a point before the finish line  
- `RingCollectible.cs` – Detects when the player collects a ring, adds to the ring count, and removes the collectible  
- `RingSpawner.cs` – Spawns columns of rings across lanes while maintaining spacing and avoiding enemy areas  
- `RingSpin.cs` – Rotates ring collectibles for visual effect  
- `SpikeTrapDamage.cs` – Damages the player on contact with spike traps with controlled re-triggering  
- `SpikeTrapSpawner.cs` – Spawns spike traps across lanes while maintaining spacing from rings and enemies  
- `FinishLine.cs` – Detects when the player reaches the finish line and triggers the win state  
- `GameManager.cs` – Manages score, rings, health, HUD updates, win/game over states, restart, and menu transitions  
- `MainMenu.cs` – Handles scene transitions for starting and quitting the game  
- `CameraShake.cs` – Applies randomized camera shake effect for visual feedback when damage occurs  
- `ButtonHover.cs` – Adds blinking hover effect to UI buttons for user interaction  

---

## Assets & Attribution

- **Shadow The Hedgehog Model (Player Character)**  
  Creator: HiddenMatrixYT  
  Source: https://sketchfab.com/3d-models/shadow-the-hedgehog-14bd84573d5a437e89dbcd752d5993c1  
  License: CC Attribution  
  Usage: Used as the main playable character  

- **Sonic Generations - Shadow the Hedgehog Statue (Main Menu Model)**  
  Creator: blacktailsthefox  
  Source: https://sketchfab.com/3d-models/sonic-generations-shadow-the-hedgehog-statue-570671caaf874c3188cd9c3c177ef97f  
  License: CC Attribution  
  Usage: Used in the main menu scene  

- **Android Shadow (Enemy Model)**  
  Creator: theamazingdonovan207  
  Source: https://sketchfab.com/3d-models/android-shadow-335b9faf5ae94fd29a0c5baeb53b2149  
  License: CC Attribution  
  Usage: Used as enemy characters  

- **Missile Model (Enemy Projectile)**  
  Creator: Resilientpicture  
  Source: https://sketchfab.com/3d-models/missile-b84538d0e6d0445183243a27e4a8b29e  
  License: CC Attribution  
  Usage: Used as enemy bullets/projectiles  

- **Dungeon Trap Models (Spike Traps)**  
  Creator: notdgames  
  Source: https://www.cgtrader.com/free-3d-models/military/other/dungeon-traps-free-low-poly-3d-model  
  License: Free (credit requested)  
  Usage: Used for spike trap hazards  

- **Rocky Terrain Texture (Environment Floor)**  
  Creator: Amal Kumar  
  Source: https://polyhaven.com/a/rocky_terrain  
  License: CC0 (No attribution required)  
  Usage: Used as ground/floor texture  

- **Overcast Soil Sky HDRI (Skybox)**  
  Creators: Jarod Guest, Sergej Majboroda  
  Source: https://polyhaven.com/a/overcast_soil_puresky  
  License: CC0 (No attribution required)  
  Usage: Used as skybox/environment lighting  

> All third-party assets are used under their respective licenses and credited appropriately.

---

## How to Run the Project
1. Open Unity Hub  
2. Click "Add Project" and select the project folder  
3. Open the project in Unity  
4. Load the main scene  
5. Press Play to start the game  

---

## Gameplay Objective
Survive and complete the course by:
- Avoiding obstacles  
- Defeating enemies  
- Collecting rings  
- Managing health  
- Reaching the finish line  

---

## Controls
- Move Left: A / Left Arrow  
- Move Right: D / Right Arrow  
- Jump: Spacebar  
- Shoot: F or Left Click  

---

## Notes
- The full Unity project contains large files such as textures and models that may not be uploaded due to GitHub size limitations.  
- Only essential scripts and project files are included in the repository.  

---

## Disclaimer
This project is for educational purposes only. All rights to original characters and third-party assets belong to their respective creators.
