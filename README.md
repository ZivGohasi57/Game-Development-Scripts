# ⚔️ 3rd Person Action RPG - Architecture & Scripts

[![Unity](https://img.shields.io/badge/Engine-Unity%203D-black.svg)](https://unity.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Pattern-Event%20Driven-blue.svg)](#architecture)
[![Refactoring](https://img.shields.io/badge/Status-Refactored-orange.svg)](#development-philosophy)
[![License: MIT](https://img.shields.io/badge/License-Personal-green.svg)](#license)

A robust collection of gameplay scripts and a custom **Event-Driven Framework** designed for a 3rd-person action-adventure game.
This repository demonstrates the transition from decoupled scripts to a centralized architecture using **GameManagers** and **Event Systems**.

---

## 🎬 Gameplay Demo

Check out the gameplay mechanics, combat system, and mission flow in action:

[![Watch Gameplay](https://img.shields.io/badge/▶%EF%B8%8F_Watch_Gameplay_Demo-Google_Drive-red?style=for-the-badge&logo=google-drive)](https://drive.google.com/file/d/1hnek_utfByi0nZN4sLvUJr2yDJiiI8cS/view)

---

## 🏗️ System Architecture

This project was recently refactored from loose scripts into a cohesive **Framework**. The architecture relies on the **Observer Pattern** to decouple game logic from UI and Data management.

### 1. 🧠 The Framework Core
* **`EventManager`**: The central nervous system. It handles global events (e.g., `OnPlayerHealthChanged`, `OnMissionAdvanced`, `OnWeaponCollected`) so scripts don't need direct references to each other.
* **`GameManager`**: Controls the high-level application flow (GameState: Playing, Paused, GameOver) and scene management.
* **`PersistentObjectManager`**: A Singleton that acts as the central data store, preserving state (Inventory, HP, Quest Progress) between scene loads.

### 2. 🎮 Gameplay Logic
* **Player Controller**: Handles movement, combat states (Combos), and interaction with the `EventManager`.
* **Managers (Passive)**: `GoldManager`, `HPManager`, and `MissionManager` now act as passive listeners, updating the UI only when relevant events are fired.
* **Interactions**: Modular scripts for Chests, Doors, and Pickups that broadcast events rather than modifying data directly.

---

## 🧠 Core Features

### ⚔️ Combat & Movement
* **Combo System**: Support for multi-stage attacks (Single vs. Combo) with animation locking.
* **Weapon Switching**: Dynamic switching between **Fists** and **Sword**, affecting damage output and animations.
* **Enemy AI**: State-machine based AI (Patrol, Chase, Attack) with distance-based logic.

### 📜 Quest & Progression
* **Dynamic Missions**: A `MissionManager` that updates objectives automatically based on player actions (e.g., "Find the Sword" completes instantly upon pickup).
* **Persistence**: Seamless data transfer between scenes (The Cave, The Forest, etc.).
* **Unlockables**: Gate and Door logic requiring specific keys or mission states to open.

### 💰 Economy & Items
* **Inventory System**: Tracks gold, weapons, and key items.
* **Interactive Objects**: Breakable jars, openable chests, and document collectibles with audio feedback.

---

## 🚀 Tech Stack

| Component | Technologies |
|-----------|--------------|
| **Engine** | Unity 3D |
| **Language** | C# (.NET) |
| **Patterns** | Singleton, Observer (Event-Driven), State Machine |
| **Data** | PlayerPrefs & Runtime Persistence |
| **UI** | Unity UI (Canvas, Sliders, TextMeshPro) |

---

## 🧪 Development Philosophy

This project represents a journey from **prototyping** to **professional engineering**.
The code began as isolated behaviours attached to GameObjects. It was then **Refactored** to solve common gamedev problems:
* **Spaghetti Code**: Solved by implementing the `EventManager` to remove direct dependencies (e.g., The *Coin* no longer needs to find the *MissionManager*).
* **Race Conditions**: Solved by centralizing initialization in the `GameManager`.
* **Scalability**: New features (like a new weapon type) can be added by simply firing a new event, without rewriting existing Managers.

---

## 🗺️ Roadmap

- [x] Basic Movement & Combat
- [x] Enemy AI Implementation
- [x] **Major Refactor:** Implementation of Event-Driven Architecture
- [x] UI & HUD Integration
- [ ] Save/Load System (Serialization)
- [ ] Sound Manager implementation

---

## 📄 License

**Personal Portfolio Project**
Copyright (c) 2025 Ziv Gohasi.
