using System.Collections.Generic;
using UnityEngine;

public class TapAway3DMatrixGenerator : MonoBehaviour
{
    public int size = 4;
    public int[,] layer0;
    public int[,] layer1;
    public int[,] layer2;
    public int[,] layer3;

    // Direction Key:
    // 0 = Forward (+Z)
    // 1 = Right (+X)
    // 2 = Back (-Z)
    // 3 = Left (-X)
    // 4 = Up (+Y)
    // 5 = Down (-Y)

    void Start()
    {
        layer0 = new int[size, size];
        layer1 = new int[size, size];
        layer2 = new int[size, size];
        layer3 = new int[size, size];

        Debug.Log($"Generating {size}x{size}x{size} 3D Tap Away Puzzle...");

        int[,,] resultMatrix = Generate3DMatrix(size);

        if (resultMatrix != null)
        {
            PrintMatrixToConsole(resultMatrix, size);
        }
    }

    public int[,,] Generate3DMatrix(int size)
    {
        int totalCells = size * size * size;

        while (true)
        {
            int[,,] matrix = new int[size, size, size];
            int placedCount = 0;
            bool gotStuck = false;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    for (int z = 0; z < size; z++)
                        matrix[x, y, z] = -1;

            while (placedCount < totalCells)
            {
                List<Candidate> allValidMoves = new List<Candidate>();

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        for (int z = 0; z < size; z++)
                        {
                            if (matrix[x, y, z] == -1)
                            {
                                for (int d = 0; d < 6; d++)
                                {
                                    if (IsPathEmpty3D(matrix, size, x, y, z, d))
                                    {
                                        allValidMoves.Add(new Candidate(x, y, z, d));
                                    }
                                }
                            }
                        }
                    }
                }

                if (allValidMoves.Count == 0)
                {
                    gotStuck = true;
                    break;
                }

                float center = size / 2f;
                allValidMoves.Sort((a, b) =>
                {
                    float distA = Mathf.Abs(a.x - center) + Mathf.Abs(a.y - center) + Mathf.Abs(a.z - center);
                    float distB = Mathf.Abs(b.x - center) + Mathf.Abs(b.y - center) + Mathf.Abs(b.z - center);
                    return distA.CompareTo(distB);
                });

                Candidate pick = allValidMoves[0];

                matrix[pick.x, pick.y, pick.z] = pick.dir;
                placedCount++;
            }

            if (!gotStuck)
            {
                Debug.Log("<color=green>Successfully generated 3D Matrix!</color>");
                return matrix;
            }
        }
    }

    private bool IsPathEmpty3D(int[,,] matrix, int size, int startX, int startY, int startZ, int dir)
    {
        int cx = startX;
        int cy = startY;
        int cz = startZ;

        while (true)
        {
            if (dir == 0) cz++;      // 0 = Forward (+Z)
            else if (dir == 1) cx++; // 1 = Right (+X)
            else if (dir == 2) cz--; // 2 = Back (-Z)
            else if (dir == 3) cx--; // 3 = Left (-X)
            else if (dir == 4) cy++; // 4 = Up (+Y)
            else if (dir == 5) cy--; // 5 = Down (-Y)

            if (cx < 0 || cx >= size || cy < 0 || cy >= size || cz < 0 || cz >= size)
                return true;

            if (matrix[cx, cy, cz] != -1)
                return false;
        }
    }

    private void PrintMatrixToConsole(int[,,] matrix, int size)
    {
        string fullOutput = "Direction Key: 0=Fwd, 1=Right, 2=Back, 3=Left, 4=Up, 5=Down\n\n";

        for (int y = 0; y < size; y++)
        {
            fullOutput += $"<b>--- Layer Y = {y} (Bottom to Top) ---</b>\n";

            for (int z = size - 1; z >= 0; z--)
            {
                for (int x = 0; x < size; x++)
                {
                    fullOutput += matrix[x, y, z] + "    ";

                    if (y == 0) layer0[x, z] = matrix[x, y, z];
                    else if (y == 1) layer1[x, z] = matrix[x, y, z];
                    else if (y == 2) layer2[x, z] = matrix[x, y, z];
                    else if (y == 3) layer3[x, z] = matrix[x, y, z];
                }
                fullOutput += "\n";
            }
            fullOutput += "\n";
        }

        Debug.Log(fullOutput);
    }

    private struct Candidate
    {
        public int x, y, z, dir;
        public Candidate(int x, int y, int z, int d)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.dir = d;
        }
    }
}
