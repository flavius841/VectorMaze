using System;
using System.Collections.Generic;

namespace TapAwayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TapAwayMatrixGenerator generator = new TapAwayMatrixGenerator();

            int width = 5;
            int height = 5;
            // You can change the width and height up to 6

            int[,] resultMatrix = generator.GenerateMatrix(width, height);

            Console.WriteLine($"Generated {width}x{height} Tap Away Puzzle:");
            Console.WriteLine("0=Up, 1=Right, 2=Down, 3=Left\n");
            PrintMatrix(resultMatrix, width, height);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void PrintMatrix(int[,] matrix, int w, int h)
        {
            for (int y = h - 1; y >= 0; y--)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.Write(matrix[x, y] + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    public class TapAwayMatrixGenerator
    {
        public int[,] GenerateMatrix(int width, int height)
        {
            int[,] matrix = new int[width, height];
            int totalCells = width * height;
            int placedCount = 0;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    matrix[x, y] = -1;

            Random rand = new Random();

            while (placedCount < totalCells)
            {
                List<Candidate> validMoves = new List<Candidate>();

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (matrix[x, y] == -1)
                        {
                            for (int d = 0; d < 4; d++)
                            {
                                if (IsPathEmpty(matrix, width, height, x, y, d))
                                    validMoves.Add(new Candidate(x, y, d));
                            }
                        }
                    }
                }

                if (validMoves.Count == 0) return GenerateMatrix(width, height);

                Candidate pick = validMoves[rand.Next(validMoves.Count)];
                matrix[pick.x, pick.y] = pick.direction;
                placedCount++;
            }
            return matrix;
        }

        private bool IsPathEmpty(int[,] matrix, int width, int height, int startX, int startY, int dir)
        {
            int cx = startX;
            int cy = startY;
            while (true)
            {
                if (dir == 0) cy++; else if (dir == 1) cx++; else if (dir == 2) cy--; else if (dir == 3) cx--;
                if (cx < 0 || cx >= width || cy < 0 || cy >= height) return true;
                if (matrix[cx, cy] != -1) return false;
            }
        }

        private struct Candidate
        {
            public int x, y, direction;
            public Candidate(int x, int y, int d) { this.x = x; this.y = y; this.direction = d; }
        }
    }
}