# 🧟 3D FPS Zombie Shooter Game

A 3D First-Person Shooter (FPS) prototype developed in Unity, designed to demonstrate **C# object-oriented programming**, **interface-driven architecture**, and **core gameplay mechanics**.

> **Project Focus:** This project serves as a technical portfolio piece showcasing clean C# code structure and backend programming logic. Visual assets and animations are kept minimal to strictly highlight core programming principles, dynamic AI tracking, and system architecture.

---

## 🎮 Key Gameplay Mechanics

* **FPS Player Controller & Camera:** First-person movement featuring mouse look smoothing (`Quaternion.Euler`), clamp logic, and dynamic stamina management for running.
* **NavMesh AI Tracking:** Enemy zombies dynamically calculate paths and track the player's real-time position using Unity's `NavMeshAgent`.
* **Shooting & Damage System:** Enemy zombies have 100 HP (`HealthManager`) and take 25 damage per bullet hit, requiring 4 shots to be eliminated.
* **Collision & Game Loop Conditions:** Collecting key items (`ICollectable`) and returning to the level exit triggers victory state mechanics (`IWinable`). Conversely, the player is immediately destroyed (`Destroy`) upon enemy contact.

---

## 🛠️ Technical & Architectural Features

* **Interface-Driven Design (OOP):** Built using decoupled interfaces (`ICollectable`, `ICollision`, `IWinable`) for item pickup, collision handling, and game completion states to ensure a modular codebase.
* **AI Pathfinding Safety:** Implemented `NavMesh.SamplePosition` and `Warp` checks to guarantee valid enemy spawning on NavMesh areas.
* **Input & Time Normalization:** Frame-rate independent camera and movement handling utilizing `Time.deltaTime`.
* **Version Control Workflow:** Clean Git repository maintained via GitHub Desktop with custom `.gitignore` rules for Unity.

---

## 🚀 How to Run

1. Clone or download the repository:
   ```bash
   git clone [https://github.com/xaressz/_ZombieShooterGame.git](https://github.com/xaressz/_ZombieShooterGame.git)
