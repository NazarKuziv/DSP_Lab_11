using System;

namespace DSP_Lab_11
{
    internal class Floyd_Warshall_Algorithm
    {
                
        public int INF = int.MaxValue;
        private static void Print(int[,] distance, int N,int k)
        {
            
            Console.WriteLine("Крок " +k);
            Console.Write("\n");
            Console.Write("   |");
            for (int j = 1; j < N+1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 0; i < N; ++i)
            {
                Console.Write($"{i+1,2} |");
                for (int j = 0; j < N; ++j)
                {
                    if (distance[i, j] == int.MaxValue)
                    {
                        Console.Write("   |");
                    }
                    else
                        Console.Write($"{distance[i, j],2} |");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Floyd_Warshall_Algorithm(int[,] graph, Weighted_graphs weighted)
        {         
            int N = weighted.GetN();
            int[,] distance = new int[N, N];

            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    distance[i, j] = graph[i + 1, j + 1];
         

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (distance[i, k] != INF && distance[ k, j] != INF)
                        {
                            if (distance[i, k] + distance[k, j] < distance[i, j])
                                distance[i, j] = distance[i, k] + distance[k, j];
                        }
                                                    
                    }
                }
                Print(distance, N,k+1);
            }          

        }
    }
}