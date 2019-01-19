using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LTDT_BTTuan00_2
{
    class Program
    {
        static void Main(string[] args)
        {
            GRAPH g = new GRAPH();
            string input_filename = args[0];
            inputValue(input_filename, g);
            Console.ReadLine();
        }
        private static void inputValue(string input_filename, GRAPH g)
        {
            try
            {
                using (StreamReader reader = new StreamReader(input_filename))
                {
                    string line = reader.ReadLine();
                    g.numberOfVertexes = int.Parse(line);
                    if (g.numberOfVertexes > 2)
                    {
                        g.matrix = new int[g.numberOfVertexes, g.numberOfVertexes];
                        int rowIndex, colIndex;
                        int sIndex = 0;
                        line = reader.ReadToEnd().Replace("\r\n", " ");
                        string[] s = line.Split(' ');
                        while (sIndex < g.numberOfVertexes * 2)
                        {
                            for (rowIndex = 0; rowIndex < g.numberOfVertexes; rowIndex++)
                            {
                                for (colIndex = 0; colIndex < g.numberOfVertexes; colIndex++)
                                {
                                    g.matrix[rowIndex, colIndex] = int.Parse(s[sIndex]);
                                    sIndex++;
                                }
                            }
                        }
                        reader.Close();
                        Console.WriteLine(g.numberOfVertexes); 
                        for (rowIndex = 0; rowIndex < g.numberOfVertexes; rowIndex++)
                        {
                            for (colIndex = 0; colIndex < g.numberOfVertexes; colIndex++)
                                Console.Write(g.matrix[rowIndex, colIndex] + " ");
                            Console.WriteLine();
                        }                        
                        if (g.matrix[g.numberOfVertexes-1 , 0] == 1)
                            Console.WriteLine("Co");
                        else
                            Console.WriteLine("Khong");        
                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine("The number of Vertexes must be greater than 2.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }
        }
    }

	class GRAPH
    {
        private int _numberOfVertexes;
        private int[,] _matrix;

        public int numberOfVertexes {
            get { return _numberOfVertexes; }
            set
            {
                if (value > 2)
                    _numberOfVertexes = value;
            }
        }

        public int[,] matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }
    }
}
