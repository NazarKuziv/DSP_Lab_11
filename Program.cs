using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP_Lab_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            FileViewer file = new FileViewer();
            int[,] graf = file.ReadFile();
            Weighted_graphs WeightedGra = new Weighted_graphs();
            int[,] Grapf = WeightedGra.CreateMatrix(file, graf);       
            Console.WriteLine("Алгоритм Флойда-Уоршелла:");    

            Floyd_Warshall_Algorithm FWA = new Floyd_Warshall_Algorithm(Grapf,WeightedGra);

        }
    }
}
