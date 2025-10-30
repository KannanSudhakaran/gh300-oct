# Nibbles (Snake) Game 🐍

A classic Snake game implementation in Python using Pygame. Control a green snake to eat red food and grow longer while avoiding collisions with yourself!

## Features

- 🟢 Green snake that grows when eating food
- 🔴 Red food items that appear randomly
- 📊 Score board to track your progress
- ⌨️ Simple keyboard controls
- 🔄 Auto-reset when game over

## Requirements

- Python 3.7 or higher
- Pygame 2.5.2

## Setup Instructions

### 1. Activate the Virtual Environment

The project includes a virtual environment. Activate it using:

**Windows (CMD):**
```cmd
venv\Scripts\activate
```

**Windows (PowerShell):**
```powershell
venv\Scripts\Activate.ps1
```

**Linux/Mac:**
```bash
source venv/bin/activate
```

### 2. Install Dependencies

Once the virtual environment is activated, install the required packages:

```cmd
pip install -r requirements.txt
```

## How to Run

After activating the virtual environment and installing dependencies:

```cmd
python snake_game.py
```

## How to Play

- **Arrow Keys**: Move the snake (Up, Down, Left, Right)
- **ESC**: Quit the game

### Rules

1. Guide the green snake to eat the red food
2. Each food item increases your score by 10 points
3. The snake grows longer with each food eaten
4. Avoid running into yourself (the game will reset)
5. The snake wraps around screen edges

## Game Controls

| Key | Action |
|-----|--------|
| ↑ | Move Up |
| ↓ | Move Down |
| ← | Move Left |
| → | Move Right |
| ESC | Quit Game |

## Project Structure

```
nibblesgamevibecode/
│
├── venv/                 # Virtual environment (isolated Python environment)
├── snake_game.py         # Main game file
├── requirements.txt      # Python dependencies
└── README.md            # This file
```

## Troubleshooting

### Virtual Environment Issues

If you have trouble activating the virtual environment, you can create a new one:

```cmd
python -m venv venv
```

### Pygame Installation Issues

If pygame fails to install, try:

```cmd
pip install --upgrade pip
pip install pygame
```

## Deactivating the Virtual Environment

When you're done playing, deactivate the virtual environment:

```cmd
deactivate
```

## Credits

Created as a classic Snake/Nibbles game implementation using Python and Pygame.

Enjoy the game! 🎮
