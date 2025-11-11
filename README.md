# Game Development Scripts (Unity / C#)

[![Unity](https://img.shields.io/badge/Unity-2021%2B-black.svg)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-8%2B-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![Build](https://img.shields.io/badge/Workflows-Unity%20Editor%20%7C%20PlayMode%20Tests-informational.svg)](#tests)
[![License: MIT](https://img.shields.io/badge/License-Educational-green.svg)](#license)

A curated set of reusable Unity C# scripts for common gameplay systems and prototyping.  
Focus: clean, modular components, easy integration, and testable gameplay logic.

---

## 🧠 Features
- Player movement controllers (2D/3D), camera follow, and input mapping  
- Basic AI behaviors (patrol, chase, line-of-sight)  
- Health, damage, and cooldown systems  
- Inventory and pickup interactions  
- UI helpers (HUD binding, progress bars, message prompts)  
- Utilities (object pooling, timers, math helpers, scriptable configs)

---

## 🗂 Project Structure
```text
.
├── Scripts/
│   ├── Movement/           # CharacterController, TopDownController, CameraFollow
│   ├── AI/                 # PatrolAI, ChaseAI, FieldOfView, WaypointSystem
│   ├── Combat/             # Health, Damageable, Cooldown, Projectile
│   ├── Inventory/          # Inventory, ItemPickup, ItemData (ScriptableObject)
│   ├── UI/                 # HealthBar, PromptUI, Crosshair, HUDBinder
│   └── Utilities/          # ObjectPool, Timer, GameEvents, MathExtensions
├── ScriptableObjects/      # Tunable data assets (speed, HP, damage, etc.)
├── Samples/                # Minimal demo scenes and prefabs
├── Tests/                  # Unity Test Framework (EditMode/PlayMode)
└── README.md
````

---

## ⚙️ Requirements

* Unity 2021 LTS or newer
* Input System (recommended) or legacy Input Manager
* .NET 4.x / C# 8+ compatibility

---

## 🚀 Quick Start

1. Clone or download this repository.
2. Copy the `Scripts/` (and optionally `ScriptableObjects/` and `Samples/`) into your Unity project under `Assets/`.
3. Open a sample scene or create a new one.
4. Add components to your GameObjects as needed (see examples below).

### Example: Player Movement (3D)

```csharp
// Attach to a Player GameObject with a CharacterController
public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private Movement.CharacterController3D controller;
    [SerializeField] private float speed = 6f;

    void Update()
    {
        var dx = Input.GetAxis("Horizontal");
        var dz = Input.GetAxis("Vertical");
        controller.Move(new Vector3(dx, 0f, dz), speed);
    }
}
```

### Example: Health & Damage

```csharp
// Attach Health to any damageable entity; call ApplyDamage from projectiles or enemies
var health = GetComponent<Combat.Health>();
health.OnDeath += () => Destroy(gameObject);
health.ApplyDamage(25f);
```

### Example: Object Pool

```csharp
// Spawn projectiles efficiently
var bullet = ObjectPool.Instance.Get("Bullet");
bullet.transform.SetPositionAndRotation(spawnPos, spawnRot);
```

---

## 🧪 Tests

This repo is compatible with the **Unity Test Framework**.

* **EditMode:** pure C# logic (utilities, math, cooldowns)
* **PlayMode:** behaviors that require scene objects (AI, movement, pooling)

Run tests via: `Window → General → Test Runner` (Unity)
Example structure:

```text
Tests/
├── EditMode/
│   ├── TimerTests.cs
│   └── CooldownTests.cs
└── PlayMode/
    ├── PatrolAITests.cs
    └── HealthIntegrationTests.cs
```

---

## 🧱 Development Guidelines

* Keep components single-purpose and composable
* Prefer `ScriptableObject` for tunable data (no magic numbers)
* Use events for decoupling (e.g., `GameEvents`/C# events)
* Avoid allocations in `Update()` when possible (reuse lists, caching)
* Validate public fields in `OnValidate()` for safer authoring

---

## 🗺️ Roadmap

* Input System samples (gamepad & rebindable controls)
* 2D platformer controller with coyote time & jump buffer
* NavMesh-based AI sample with obstacles and off-mesh links
* Save/load service with JSON and ScriptableObject sync
* Shader Graph samples for simple effects (hit flash, dissolve)

---

## 📄 License

MIT License (Educational Use)

Copyright (c) 2025 Ziv Gohasi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to use
the Software for educational, research, or personal learning purposes,
including viewing, studying, and running the code.

Permission is NOT granted for commercial use, redistribution, or incorporation
of the Software into proprietary products without the author's explicit consent.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND.

