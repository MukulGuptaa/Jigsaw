# Jigsaw Puzzle Game

A Unity-based jigsaw puzzle game where players can drag and drop pieces to complete puzzle images.

## Features

- Drag and drop puzzle pieces
- Progress saving
- Visual effects, sound effects and haptic feedback
- Persistent game state
- UI animations and effects

## Project Structure

```
Assets/
├── Scripts/
│   ├── Data/           # Data models and structures
│   ├── DataManagers/   # Data persistence and management
│   ├── EventSystem/    # Game events
│   ├── UI/            # UI components and controllers
│   └── Utils/         # Utility classes
├── Prefabs/           # Game prefabs
└── Scenes/           # Unity scenes
```

## Dependencies

- https://github.com/mob-sakai/UIEffect.git?path=Packages/src
- https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.0/manual/index.html

## Setup

1. Clone the repository
2. Open project in Unity
3. Open SplashScene from Scenes folder

## Implementation Details

- Uses EventSystem for drag-drop functionality
- Implements haptic feedback
- Saves game progress using Newtonsoft.Json
- Custom UI effects when the jigsaw piece is placed at its correct position using Coffee.UIEffects

## Architecture

- Event-driven architecture for decoupled components
- Data persistence using serializable classes
- Separation of UI and game logic
- Modular piece management system
