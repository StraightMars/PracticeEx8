using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx8
{
    class Program
    {
        static string[] GetNodes(Random rnd)
        {
            string[] nodes = new string[rnd.Next(2, 10)];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = ((char)(i + 65)).ToString();
            }
            return nodes;
        }
        static string[] GetEdges(Random rnd, string[] nodes)
        {
            string edges = "";
            for (int i = 0; i < nodes.Length; i++)
            {
                int curEdgeNumber = rnd.Next(0, nodes.Length - i - 1);
                string cur = "";
                for (int j = 0; j < curEdgeNumber; j++)
                {
                    int index;
                    do
                    {
                        index = rnd.Next(i, nodes.Length - 1);
                    } while (cur.Contains(nodes[index]) || nodes[index] == nodes[i]);
                    cur += nodes[i] + nodes[index] + " ";
                }
                edges += cur;
            }
            if (edges != "")
                edges = edges.Remove(edges.Length - 1, 1);
            string[] resEdges = edges.Split(' ');
            return resEdges;
        }
        //static string[] GetClique(int clique)
        //{
            
        //}
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Здравствуйте.\nСгенерированные вершины и ребра выглядят следующим образом: ");
            string[] nodes = GetNodes(rnd);
            foreach (string elem in nodes)
                Console.Write(elem + " ");
            Console.WriteLine();
            string[] edges = GetEdges(rnd, nodes);
            foreach (string elem in edges)
                Console.Write(elem + " ");
            Console.WriteLine();
            Console.WriteLine("Введите длину искомой клики: ");
            bool ok;
            int clique;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out clique);
                if (!ok || clique <= 1)
                {
                    Console.WriteLine("Ошибка ввода! Длина клики - натуральное число не меньше 2!");
                    ok = false;
                }
            } while (!ok);
            if (clique <= nodes.Length)
            {
                int edgesAmount = clique * (clique - 1) / 2;
                int end;
                if (clique == 2)
                    end = edges.Length - 1;
                else
                    end = edges.Length - clique;

            }
        }
    }
}
