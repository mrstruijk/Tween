# Tweening Library

- Based on: [Sasquatch B Studio Tutorial](https://www.youtube.com/watch?v=43o0FzU55V4) 
- By: Maarten R. Struijk Wilbrink
- For: Leiden University SOSXR
- Fully open source: Feel free to add to, or modify, anything you see fit.


## Overview

This Unity C# library provides a flexible and easy-to-use tweening system for various Unity components and types. The library supports tweening of primitives, transforms, and renderers with minimal setup.

## Features

- Tween primitive types (float, Vector2, Vector3, Quaternion)
- Transform tweening:
    - Scale
    - Position (local and world)
    - Rotation (local and world)
- Renderer tweening:
    - Sprite Renderer alpha
    - Canvas Renderer alpha
    - Material alpha


## Installation

1. Open the Unity project you want to install this package in.
2. Open the Package Manager window.
3. Click on the `+` button and select `Add package from git URL...`.
4. Paste the URL of this repo into the text field
5. Add `.git` at the end
6. Press `Add`.


## Usage Examples

See also the Demo folder. 


### Tweening a Transform

```csharp
// Scale a transform over 1 second
transform.TweenScale(Vector3.one * 2f, 1f);

// Move a transform to a specific position
transform.TweenPosition(new Vector3(10, 0, 0), 1.5f);

// Rotate a transform
transform.TweenRotation(Quaternion.Euler(0, 180, 0), 1f);
```

### Tweening Renderers

```csharp
// Fade a sprite renderer
spriteRenderer.TweenAlpha(0f, 1f);

// Fade a material
material.TweenAlpha(0f, 1f);
```

### Advanced Tweening

```csharp
// Custom start and end values
transform.TweenLocalPosition(Vector3.zero, new Vector3(5, 0, 0), 2f);

// Relative positioning
transform.TweenRelativeLocalPosition(new Vector3(10, 0, 0), 1f);
```

## Credits

- Inspired by Sasquatch B Studio Tutorial
- Developed with assistance from AI tools