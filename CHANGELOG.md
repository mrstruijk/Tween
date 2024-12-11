# Changelog

All notable changes to this project will be documented in this file.
The changelog format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)

## [1.0.0] - 2024-12-11

### Added
- Comprehensive tweening support for Unity primitives:
    - Float tweening with dynamic value retrieval and setting
    - Vector2 tweening with start and end value support
    - Vector3 tweening with flexible configuration
    - Quaternion tweening for rotation interpolation
- Transform tweening extensions:
    - Scale tweening (local scale)
    - Position tweening (world and local positions)
    - Relative local position tweening
    - Rotation tweening (world and local rotations)
- Renderer tweening extensions:
    - Alpha tweening for SpriteRenderer
    - Alpha tweening for CanvasRenderer
    - Alpha tweening for Materials
- Unique identifier generation for each tween based on target object's hash code
- Overloaded methods to support various input configurations (start/end values, duration)
- Implemented extension methods to provide a more intuitive and concise tweening API
- Standardized tween creation process across different types and components
- Handling of color structs in renderer alpha tweening
- Proper color alpha modifications for different renderer types
- Consistent naming and identification of tween instances

### Fixed
- N/A (Initial release)

### Changed
- N/A (Initial release)

### Removed
- N/A (Initial release)