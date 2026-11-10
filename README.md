# 🌲 Forest Escape

**Forest Escape** is a cooperative 2D platformer developed in **Unity 6** as part of **VGP236 – Assignment 2** at LaSalle College Vancouver.

The game challenges two players to work together, navigate different paths, avoid environmental hazards, and collect rewards to complete the level.

## 🎮 About the Game

Forest Escape is designed around teamwork and coordination.

Two players share the same level, but each has a different route and responsibility. Players must cooperate to overcome obstacles, survive dangerous traps, and reach their objectives.

The game features a forest-themed environment, animated characters, platforming mechanics, and interactive hazards.

## 🕹️ Controls

| Action | Player 1 | Player 2 |
|---|---|---|
| Move Left | A | Left Arrow |
| Move Right | D | Right Arrow |
| Jump | Space | L |

## 🤝 Cooperative Gameplay

**Player 1 – Upper Path**

- Navigates the upper section of the level.
- Avoids obstacles and turret projectiles.
- Collects the reward assigned to Player 1.
- Relies on Player 2 to deactivate the turret temporarily.

**Player 2 – Lower Path**

- Navigates the lower section of the level.
- Activates a pressure plate that temporarily disables the turret.
- Collects the reward assigned to Player 2.
- Helps Player 1 safely progress through dangerous areas.

Both players must stay on their designated paths. Entering the wrong route results in losing the game.

## ⚙️ Game Features

- Two-player local cooperative gameplay
- Independent keyboard controls
- Animated 2D characters
- Tilemap-based platforming environment
- Physics-based movement and jumping
- Pressure plate interaction
- Turret that fires projectiles
- Temporary turret deactivation
- Dangerous traps and environmental hazards
- Restricted paths for each player
- Collectible rewards
- Win and lose conditions
- Camera-follow system
- On-screen gameplay instructions

## 🏆 Objectives

**Winning:** Both players must collect their assigned rewards to complete the game.

**Losing:** The game ends if either player is killed by a hazard, projectile, or forbidden path.

Cooperation is essential: both players must contribute to completing the level.

## 🛠️ Technologies

| Technology | Purpose |
|---|---|
| Unity 6 | Game engine |
| C# | Gameplay programming |
| Unity Input System | Player controls |
| Rigidbody2D | Character physics |
| Collider2D | Collision detection |
| Tilemap | Level construction |
| Animator | Character animations |
| Git & GitHub | Version control |

## 📁 Project Structure

```text
Assets/
├── Animations/
├── Art/
├── ForestArt/
├── Prefabs/
├── Scenes/
└── Scripts/

Packages/
ProjectSettings/
```

The `Scripts` folder contains the main gameplay systems, including player movement, camera following, reward collection, traps, pressure plates, turret behavior, and game management.

## 🚀 How to Run

1. Download or clone this repository.
2. Open **Unity Hub**.
3. Select **Add project from disk**.
4. Choose the downloaded project folder.
5. Open the project using **Unity 6**.
6. Open the `MainLevel` scene.
7. Press **Play** to start the game.

Both players can play locally using the same keyboard.

## 🎨 Art and Assets

The game uses 2D pixel-art characters, platforms, and environmental assets.

Character animations include idle and running animations, with sprites imported and configured using Unity's animation system.

Third-party artwork remains the property of its respective creators.

## 🎓 Academic Information

**Project:** Forest Escape  
**Course:** VGP236 – Assignment 2  
**Institution:** LaSalle College Vancouver  
**Developer:** Guillermo Jiménez  
**Engine:** Unity 6  
**Language:** C#  
**Project Type:** 2D Cooperative Platformer

---

*Forest Escape demonstrates fundamental game programming concepts, including object-oriented C#, physics, animation, collision detection, interactive game mechanics, and cooperative level design.*
