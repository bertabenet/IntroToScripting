# INTERACTIVE SYSTEMS
## Practice 2
### Introduction to Scripting - Tutorial

Author: Berta Benet i Cugat

__________________________

This project contains the game _Sheep Rescue_ as described in both tutorials [Introduction To Unity Scripting - Part 1](https://www.raywenderlich.com/4180726-introduction-to-unity-scripting-part-1) and [Introduction To Unity Scripting - Part 2](https://www.raywenderlich.com/4180875-introduction-to-unity-scripting-part-2). 

Apart from what is implemented in these tutorials, the following features were also added:

- Both `Start` and `Quit` buttons are floating in the Title scene
- You can listen to background music in both the Title and the Game scenes
- An "error" in the tutorial was fixed: when sheeps collided with the SheepDestroyer, the counter of collision was increased by 2 for only one single sheep. The problem was that both the Sheep and the SheepDestroyer colliders collided two times in a row. Therefore, to fix the problem, a variable to know if the Sheep and the SheepDestroyer are colliding at current time was added.
- Each sheep spawn is closer to the one before, threfore the game becomes more difficult over time
