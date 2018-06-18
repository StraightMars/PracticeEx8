using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx8
{
    class Program
    {
        static int ScanNatInt()
        {
            bool ok;
            int buf;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите натуральное число.");
                if (buf <= 0)
                {
                    Console.WriteLine("Ошибка ввода! Введите натуральное число.");
                    ok = false;
                }
            } while (!ok);
            return buf;
        }
        static int ScanInt0()
        {
            bool ok;
            int buf;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите целое число >= 0.");
                if (buf < 0)
                {
                    Console.WriteLine("Ошибка ввода! Введите целое число >= 0.");
                    ok = false;
                }
            } while (!ok);
            return buf;
        }
        static int ScanClique()
        {
            bool ok;
            int buf;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите целое число >= 2.");
                if (buf < 2)
                {
                    Console.WriteLine("Ошибка ввода! Введите целое число >= 2.");
                    ok = false;
                }
            } while (!ok);
            return buf;
        }
        //static int[,] CreateMatrix(int edges, Random rnd, int nodes)
        //{
        //    int[,] matrix = new int[edges, 2];
        //    for (int i = 0; i < edges; i++)
        //    {
        //        for (int j = 0; j < 2; j++)
        //        {
        //            matrix[i, j] = rnd.Next(1, nodes + 1);
        //            while (matrix[i,j] == matrix[i, j - 1])
        //            {
        //                matrix[i, j] = rnd.Next(1, nodes);
        //            }
        //        }
        //    }
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!\nВведите количество вершин!: ");
            int nodes = ScanNatInt();
            Console.WriteLine("Введите количество ребер: ");
            int edges = ScanInt0();
            Console.WriteLine("Введите количество вершин в клике для поиска: ");
            int clique = ScanClique();
            if (edges == 0)
            {
                Console.WriteLine("В заданном графе нет клики длины {0}.", clique);
            }
            else
            {
                int n = Convert.ToInt32(Console.ReadLine());
                List<int>[] a = new List<int>[n];
                for (int i = 0; i < n; i++)
                {
                    string[] strings = Console.ReadLine().Split();
                    a[i] = new List<int>();
                    for (int j = 0; j < strings.Length; j++)
                    {
                        if (strings[j] == "1")
                        {
                            Console.WriteLine("{0} {1}", i + 1, j + 1);
                        }
                    }
                }
            }
        }
    }
}
