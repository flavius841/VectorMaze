# VectorMaze

---

**Vector Maze** is a puzzle video game built using the **Unity Engine**

---

**Features**

* **Procedural Mesh Generation:** Utilizes custom mesh manipulation to procedurally generate dynamic environments during runtime.

* **Infinite Replayability:** Includes a sophisticated level generation system that automatically builds unique, randomized vector mazes for every playthrough.

---

**Level Generation Logic**

The core of the infinite replayability lies in the matrix generation scripts. Both scripts utilize a "Reverse-Fill" algorithm. Instead of trying to build a puzzle forward and checking if it can be solved, the algorithm starts with an empty grid and places arrows one by one, ensuring every new piece has a clear exit. Because the puzzle is built backward, it is mathematically guaranteed to be 100% solvable when played forward.

1. **2D Matrix Generator**

* **File Location:** [Logic/MatrixGenerator2D.cs](Logic/MatrixGenerator2D.cs)

* **How it works:**

  * **Dynamic Grid Setup:** Initializes a flat, customizable grid layout based on a specified width and height.

  * **Escape Path Routing:** Scans the board for empty spaces and tests four directions (Up, Down, Left, Right) to guarantee every piece has a clear exit.

  * **Randomized Placement:** Chooses randomly from all valid, safe moves to ensure the puzzle layout is different every time.

  * **Deadlock Protection:** Automatically detects if the algorithm accidentally blocks all remaining empty spaces. If this happens, it instantly clears the board and restarts, ensuring the final puzzle is always solvable.

2. **3D Matrix Generator**

* **File Location:** [Logic/MatrixGenerator2D.cs](Logic/MatrixGenerator3D.cs)

* **How it works:** 

  * **Volumetric Expansion:** Upgrades the logic to a 3-dimensional space (X, Y, Z), expanding the pathfinding to six directional axes (adding Up and Down).

  * **Memory-Safe Architecture:** Utilizes an optimized loop structure. This allows the system to safely and rapidly restart without causing memory crashes if the complex 3D generation gets stuck.

  * **Center-Out Generation:** Calculates the physical center of the cube and forces the algorithm to build from the inside out. This ensures the outer layers never trap the inner layers during generation.

  * **Randomized Selection Logic:** When multiple spaces are the exact same distance from the center, the script applies a randomized selection. This triggers a unique chain reaction of placements, resulting in a vast array of unique variations.

---

**Spawning the visuals**

After the matrix is generated the game will spawn the vectors.

This is how it looks a 2D and a 3D vector maze:

![image alt](https://github.com/flavius841/VectorMaze/blob/268e1852d86374c91fe88167fd1ac6445c0177f1/Maze2D.png)

![image alt](https://github.com/flavius841/VectorMaze/blob/268e1852d86374c91fe88167fd1ac6445c0177f1/Maze3D.png)

---

**Play the game here:**  
https://flavius123.itch.io/vector-maze


---


**Run or continue development locally:**

1. Download or clone this repository.
2. Open the project using the **Unity Editor**.
3. Make sure you are using **Unity 6.1 (6000.1.11f1)**.

> **Note:** The project is only compatible with Unity version **6.1 (6000.1.11f1)**.

---

Enjoy playing or improving the game!
