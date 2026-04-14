using System;
using System.Collections.Generic;

namespace TapAway3DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 4; // You can change the size, but the maximum is 4

            Console.WriteLine($"Generating {size}x{size}x{size} 3D Tap Away Puzzle...\n");

            TapAway3DGenerator generator = new TapAway3DGenerator();
            int[,,] resultMatrix = generator.Generate3DMatrix(size);

            if (resultMatrix != null)
            {
                PrintMatrixToConsole(resultMatrix, size);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void PrintMatrixToConsole(int[,,] matrix, int size)
        {
            Console.WriteLine("Direction Key: 0=Fwd, 1=Right, 2=Back, 3=Left, 4=Up, 5=Down\n");

            for (int y = 0; y < size; y++)
            {
                Console.WriteLine($"--- Layer Y = {y} (Bottom to Top) ---");
                for (int z = size - 1; z >= 0; z--)
                {
                    for (int x = 0; x < size; x++)
                    {
                        Console.Write(matrix[x, y, z].ToString().PadRight(4));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }

    public class TapAway3DGenerator
    {
        public int[,,] Generate3DMatrix(int size)
        {
            int totalCells = size * size * size;
            Random rand = new Random();

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
                    float minDistance = float.MaxValue;
                    List<Candidate> deepestMoves = new List<Candidate>();

                    foreach (Candidate c in allValidMoves)
                    {
                        float dist = Math.Abs(c.x - center) + Math.Abs(c.y - center) + Math.Abs(c.z - center);

                        if (dist < minDistance - 0.001f)
                        {
                            minDistance = dist;
                            deepestMoves.Clear();
                            deepestMoves.Add(c);
                        }
                        else if (Math.Abs(dist - minDistance) < 0.001f)
                        {
                            deepestMoves.Add(c);
                        }
                    }

                    Candidate pick = deepestMoves[rand.Next(deepestMoves.Count)];

                    matrix[pick.x, pick.y, pick.z] = pick.dir;
                    placedCount++;
                }

                if (!gotStuck)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully generated unique 3D Matrix!\n");
                    Console.ResetColor();

                    return matrix;
                }
            }
        }

        private bool IsPathEmpty3D(int[,,] matrix, int size, int startX, int startY, int startZ, int dir)
        {
            int cx = startX; int cy = startY; int cz = startZ;

            while (true)
            {
                if (dir == 0) cz++;
                else if (dir == 1) cx++;
                else if (dir == 2) cz--;
                else if (dir == 3) cx--;
                else if (dir == 4) cy++;
                else if (dir == 5) cy--;

                if (cx < 0 || cx >= size || cy < 0 || cy >= size || cz < 0 || cz >= size) return true;
                if (matrix[cx, cy, cz] != -1) return false;
            }
        }

        private struct Candidate
        {
            public int x, y, z, dir;
            public Candidate(int x, int y, int z, int d) { this.x = x; this.y = y; this.z = z; this.dir = d; }
        }
    }
}