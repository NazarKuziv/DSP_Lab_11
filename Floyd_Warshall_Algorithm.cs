using System;

namespace DSP_Lab_11
{
    internal class Floyd_Warshall_Algorithm
    {
        private int[,,] minWay;
        private int[,] Way;
        private int Infinity = int.MaxValue;

        public Floyd_Warshall_Algorithm(Weighted_graphs WeightedGra, int[,] weightMatrix)
        {
            int n = WeightedGra.GetN();
            int[,,] matrix = new int[n + 1, n + 1, n + 1];  

            for (int c = 1; c < n + 1; c++)
            {
                for (int r = 1; r < n + 1; r++)
                {
                    for (int x = 1; x < n + 1; x++)
                    {
                        matrix[c, r, x] = weightMatrix[r, x];
                    }
                }
            }

            int[,] P = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i == j)
                    {
                        P[i, j] = 0;
                    }
                    else
                    {
                        P[i, j] = 1;
                    }
                }
            }

            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        if (matrix[k - 1, i, k] != Infinity && matrix[k - 1, k, j] != Infinity)
                        {
                            if ((matrix[k - 1, i, k] + matrix[k - 1, k, j] < matrix[k - 1, i, j]))
                            {
                                matrix[k, i, j] = (matrix[k - 1, i, k] + matrix[k - 1, k, j]);
                                P[i, j] = k;
                            }
                        }
                    }
                }
                Console.WriteLine("Крок" + k);
                Print(matrix, WeightedGra, k);
            }
        }
        public static void Print(int[,,] matrix, Weighted_graphs WeightedGra, int k)
        {
            Console.Write("   |");
            for (int j = 1; j < WeightedGra.GetN() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < WeightedGra.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < WeightedGra.GetN() + 1; j++)
                {
                    if (matrix[k, i, j] == int.MaxValue)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write($"{matrix[k, i, j],2} |");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}