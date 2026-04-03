using System.Collections.Generic;
using UnityEngine;

public class FullClearArrowMaze : MonoBehaviour
{
    [Header("Maze Dimensions")]
    public int width = 5;
    public int height = 5;
    public float spacing = 2.0f;

    [Header("Prefabs")]
    public GameObject arrowPrefab;

    // -1 means empty. 0=Up, 1=Right, 2=Down, 3=Left
    private int[,] gridDirections;

    void Start()
    {
        GeneratePuzzle();
    }

    void GeneratePuzzle()
    {
        bool success = false;
        int attempts = 0;

        // Sometimes the random placement accidentally builds a wall and gets stuck.
        // If that happens, we just clear it and try again. It usually takes less than 3 attempts.
        while (!success && attempts < 100)
        {
            attempts++;
            success = TryGenerateReverseBoard();
        }

        if (success)
        {
            InstantiateMaze();
        }
        else
        {
            Debug.LogError("Failed to generate a solvable board after 100 attempts.");
        }
    }

    bool TryGenerateReverseBoard()
    {
        gridDirections = new int[width, height];
        int totalCells = width * height;
        int placedCount = 0;

        // Step 1: Fill the board with -1 (Empty)
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridDirections[x, y] = -1;
            }
        }

        // Step 2: Place arrows one by one
        while (placedCount < totalCells)
        {
            List<Candidate> validMoves = new List<Candidate>();

            // Scan every cell on the board
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // If the cell is empty, check if it has a clear path to the edge
                    if (gridDirections[x, y] == -1)
                    {
                        if (IsLineOfSightClear(x, y, 0)) validMoves.Add(new Candidate(x, y, 0)); // Up
                        if (IsLineOfSightClear(x, y, 1)) validMoves.Add(new Candidate(x, y, 1)); // Right
                        if (IsLineOfSightClear(x, y, 2)) validMoves.Add(new Candidate(x, y, 2)); // Down
                        if (IsLineOfSightClear(x, y, 3)) validMoves.Add(new Candidate(x, y, 3)); // Left
                    }
                }
            }

            // If we have no valid moves but the board isn't full, we got stuck. Return false to restart.
            if (validMoves.Count == 0)
            {
                return false;
            }

            // Pick a random valid placement
            Candidate pick = validMoves[Random.Range(0, validMoves.Count)];

            // Place the arrow
            gridDirections[pick.x, pick.y] = pick.dir;
            placedCount++;
        }

        return true; // Board successfully filled!
    }

    // Checks if an arrow at (startX, startY) pointing in 'dir' has a clear path to the edge
    bool IsLineOfSightClear(int startX, int startY, int dir)
    {
        int checkX = startX;
        int checkY = startY;

        while (true)
        {
            // Move one step in the chosen direction
            if (dir == 0) checkY++;      // Up
            else if (dir == 1) checkX++; // Right
            else if (dir == 2) checkY--; // Down
            else if (dir == 3) checkX--; // Left

            // If we step off the board, the path is completely clear!
            if (checkX < 0 || checkX >= width || checkY < 0 || checkY >= height)
                return true;

            // If we hit a cell that already has an arrow in it, the path is blocked
            if (gridDirections[checkX, checkY] != -1)
                return false;
        }
    }

    void InstantiateMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * spacing, 0, y * spacing);
                int dir = gridDirections[x, y];

                float yRotation = dir * 90f;
                Quaternion rotation = Quaternion.Euler(0, yRotation, 0);

                GameObject arrow = Instantiate(arrowPrefab, position, rotation, transform);
                arrow.name = $"Arrow [{x},{y}]";
            }
        }
    }

    // A simple container to hold potential placement data
    private struct Candidate
    {
        public int x;
        public int y;
        public int dir;

        public Candidate(int x, int y, int dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
        }
    }
}