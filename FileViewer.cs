using System;
using System.IO;

namespace DSP_Lab_11
{
    internal class FileViewer
    {
        private int n = 0;
        private int m = 0;

        public int GetM() { return this.m; }
        public int GetN() { return this.n; }
        public FileViewer() { n = 0; m = 0; }

        public int[,] ReadFile()
        {
            string line;
            string[] substr;
            int[,] fileInfo = null;

            StreamReader streamReader = new StreamReader("..\\..\\graf\\graph.txt");
            line = streamReader.ReadLine();
            substr = line.Split();
            this.n = Convert.ToInt32(substr[0]);
            this.m = Convert.ToInt32(substr[1]);

            fileInfo = new int[m + 1, 3];
            line = streamReader.ReadLine();
            for (int i = 1; line != null; i++)
            {
                substr = line.Split();
                fileInfo[i, 0] = Convert.ToInt32(substr[0]);
                fileInfo[i, 1] = Convert.ToInt32(substr[1]);
                fileInfo[i, 2] = Convert.ToInt32(substr[2]);
                line = streamReader.ReadLine();
            }
            streamReader.Close();

            return fileInfo;
        }

    }
}