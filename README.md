# SimpleVr

Simple VR Controller for Unity

## Features:

### Scripts:

- **VRController script**
  - Script that works on Gyroscope. 
- **MouseMovement**
  - Mouse aim for editor or standalone.
- **Raycaster**
  - Raycast module, that update target only if target select or deselect.
  - Send event SelectStatusHandler.
  - Send gameObject from hit to ITargetManager interface.
- **ITargetManager**
  - Interface that takes hit info. Developer can implement that interface at his discretion, there is no need to rewrite the remaining modules.
- **CursorAnimation**
  - Сursor that changes when Raycaster takes event "Select/Deselect".

### Prefabs:
- CameraController
  - Prefab, contains two variants (VREyes, Panorama)

### Download:
- [UnityPackage](url)
- [Test Build](url)