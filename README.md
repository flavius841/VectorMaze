# VectorMaze

---

**Vector Maze** is a puzzle video game built using the **Unity Engine**

---

**Features**

* **Procedural Mesh Generation:** It uses code for creating certain geometric bodys.

* **Infinite Replayability:** Includes a level generation system that builds randomized vector mazes for every playthrough.

---

**Level Generation Logic**

First, the level generates a matrix that will be the base for spawning the visuals. It uses a "Reverse-Fill" algorithm, because instead of building the maze randomly and then at the end checking if it is solvable, my code will check after every vector that is spawned if it has a clear path.

1. **2D Matrix Generator**

* **File Location:** [Logic/MatrixGenerator2D.cs](Logic/MatrixGenerator2D.cs)

* **How it works:**

  * Initializes an empty grid layout based on a specified width and height.

  * Scans the board for empty spaces and tests in four directions (Up, Down, Left, Right) to see if every piece has a clear exit.

  * Chooses randomly from all valid moves to make sure the puzzle is different every time.

  * Detects if the algorithm blocks the remaining empty spaces. If this happens, it clears the board and restarts.

2. **3D Matrix Generator**

* **File Location:** [Logic/MatrixGenerator3D.cs](Logic/MatrixGenerator3D.cs)

* **How it works:** 

  * Now the logic will use two more directions: forward and back.

  * Instead of using recursive logic like the previous code, this one has just a simple loop. It is safer in order not to crash

  * Calculates the center of the cube and builds from the inside out. This way we make sure that the upper layer will not block the previous layer

  * When multiple spaces are at the exact same distance from the center, the script applies a randomized selection because otherwise it will in result the same matrix again and again


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
