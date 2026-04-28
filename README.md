# Modular Weapon Attachment System
**Unity · C# · Interface-Driven Architecture**

A runtime weapon customization system built around a socket-based attachment model and interface-driven polymorphism. Designed to be data-agnostic — adding a new attachment type requires no changes to core weapon logic.

---

## Overview

The system allows weapons to accept interchangeable attachments across four categories — Scope, Muzzle, Magazine, and Grip — each slotting into a tagged socket on the weapon. Attachment behavior is defined entirely through interfaces, keeping the `Gun` class decoupled from any specific attachment implementation.

---

## Architecture

```
Gun
├── AttachmentSocket[] (Scope / Muzzle / Mag / Grip)
│   └── struct { GameObject slot, bool isOccupied }
├── AttachAttachments()     — walks registry, parents to first free matching socket
└── Dispatch via GetComponentInChildren<IXxxHandler>().UsingXxx()

GameManager (Singleton)
└── Attachment Registry     — central list of available attachments

Interfaces
├── IScopeHandler
├── IMuzzleHandler
├── IMagHandler
└── IGripHandler

Attachments (implement respective interfaces)
├── Scopes:     TwoXScope, RedDot, GreenDot
├── Muzzles:    Compensator, Suppressor
├── Magazines:  ExtendedMag, QuickDrawMag
└── Grips:      HeavyGrip, LightWeightGrip
```

---

## Key Design Decisions

**Socket-based attachment** — Each socket is a struct holding a reference slot and an `isOccupied` flag. `AttachAttachments()` walks the registry, matches by category tag, and parents the attachment to the first free socket. No hardcoded slot references.

**Interface polymorphism over inheritance** — Each attachment category has a dedicated handler interface. The `Gun` dispatches behavior by querying `GetComponentInChildren<IXxxHandler>()`, meaning it never needs to know what specific attachment is equipped.

**Open for extension** — Adding a new attachment requires only: implementing the relevant interface, tagging the prefab correctly. Zero changes to `Gun.cs` or `GameManager.cs`.

---

## What This Demonstrates

- Interface-driven component design
- Runtime parent/child manipulation for modular assembly
- Singleton registry pattern for asset management
- Clean separation between weapon logic and attachment behavior

---

## Tech

- Unity 2022.3 · C#
- No third-party dependencies
