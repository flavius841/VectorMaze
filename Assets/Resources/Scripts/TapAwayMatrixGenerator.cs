using System.Collections.Generic;
using UnityEngine;

public class TapAwayMatrixGenerator : MonoBehaviour
{
    public GameDataScript gameData;
    public int width;
    public int height;
    public GameObject arrowPrefab;
    public float spacing = 2.0f;

    void Awake()
    {
        width = gameData.MazeSize2D;
        height = gameData.MazeSize2D;
    }
    void Start()
    {
        int[,] resultMatrix = GenerateMatrix(width, height);

        PrintMatrixToConsole(resultMatrix, width, height);

        SpawnVisuals(resultMatrix);
    }

    void Update()
    {
        width = gameData.MazeSize2D;
        height = gameData.MazeSize2D;
    }

    public void SpawnVisuals(int[,] matrix)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                int direction = matrix[y, x];

                Vector3 localPos = new Vector3(x * spacing, 0, -y * spacing);

                Quaternion localRot = Quaternion.Euler(0, direction * 90f, 0);

                GameObject arrow = Instantiate(arrowPrefab, transform);

                arrow.transform.localPosition = localPos;
                arrow.transform.localRotation = localRot;

                arrow.name = $"Arrow [{y},{x}]";
            }
        }
    }
    public int[,] GenerateMatrix(int w, int h)
    {
        while (true)
        {
            int[,] matrix = new int[w, h];
            int totalCells = w * h;
            int placedCount = 0;
            bool gotStuck = false;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    matrix[x, y] = -1;
                }
            }

            while (placedCount < totalCells)
            {
                List<Candidate> validMoves = new List<Candidate>();

                for (int x = 0; x < w; x++)
                {
                    for (int y = 0; y < h; y++)
                    {
                        if (matrix[x, y] == -1)
                        {
                            if (IsPathEmpty(matrix, w, h, x, y, 0)) validMoves.Add(new Candidate(x, y, 0)); // Up
                            if (IsPathEmpty(matrix, w, h, x, y, 1)) validMoves.Add(new Candidate(x, y, 1)); // Right
                            if (IsPathEmpty(matrix, w, h, x, y, 2)) validMoves.Add(new Candidate(x, y, 2)); // Down
                            if (IsPathEmpty(matrix, w, h, x, y, 3)) validMoves.Add(new Candidate(x, y, 3)); // Left
                        }
                    }
                }

                if (validMoves.Count == 0)
                {
                    gotStuck = true;
                    break;
                }

                Candidate pick = validMoves[UnityEngine.Random.Range(0, validMoves.Count)];

                matrix[pick.x, pick.y] = pick.dir;
                placedCount++;
            }

            if (!gotStuck)
            {
                return matrix;
            }
        }
    }

    private bool IsPathEmpty(int[,] matrix, int w, int h, int startX, int startY, int dir)
    {
        int currentX = startX;
        int currentY = startY;

        while (true)
        {
            if (dir == 0) currentY++;
            else if (dir == 1) currentX++;
            else if (dir == 2) currentY--;
            else if (dir == 3) currentX--;

            if (currentX < 0 || currentX >= w || currentY < 0 || currentY >= h)
                return true;

            if (matrix[currentX, currentY] != -1)
                return false;
        }
    }

    private void PrintMatrixToConsole(int[,] matrix, int w, int h)
    {
        string output = $"Generated {w}x{h} Tap Away Puzzle (0=Up, 1=Right, 2=Down, 3=Left):\n";

        for (int y = h - 1; y >= 0; y--)
        {
            for (int x = 0; x < w; x++)
            {
                output += matrix[x, y] + "   ";
            }
            output += "\n";
        }

        Debug.Log(output);
    }

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