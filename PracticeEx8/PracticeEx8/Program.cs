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
            string str = "";
            for (int i = 0; i < nodes.Length; i++)
            {
                // Number of lines with a current vertex.
                int numOfCurrEdges = rnd.Next(0, nodes.Length - i - 1);
                // The lisy of lines with a current vertex.
                string currEdges = "";
                for (int j = 0; j < numOfCurrEdges; j++)
                {
                    // A random index of a second vertex in a line.
                    int randomIndex;
                    do
                    {
                        randomIndex = rnd.Next(i, nodes.Length - 1);
                    } while (currEdges.Contains(nodes[randomIndex]) || nodes[randomIndex] == nodes[i]);
                    currEdges += nodes[i] + nodes[randomIndex] + " ";
                }
                str += currEdges;
            }
            if (str != "")
                str = str.Remove(str.Length - 1, 1);
            string[] edges = str.Split(' ');
            return edges;
        }
        static string wantedClique = "";
        static void Analysis(string combination, int clique)
        {
            char[] nodes = combination.ToCharArray();
            Array.Sort(nodes);
            bool ok = true;
            for (int i = 0; i < nodes.Length; i += clique - 1)
            {
                for (int j = i; j < i + clique - 2; j++)
                {
                    if (nodes[i] != nodes[i + 1])
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok)
                    break;
            }
            if (ok == true)
            {
                for (int i = 0; i < nodes.Length; i += clique - 1)
                {
                    wantedClique += nodes[i];
                }
                wantedClique += " ";
            }
        }
        static string Combinations(int clique, int edgesAmount, int begin, int end, string[] edges, string combination)
        {
            if (edgesAmount == 0)
            {
                Analysis(combination, clique);
                return "";
            }
            else
            {
                if (end >= edges.Length)
                    end = edges.Length - 1;
                for (int i = begin; i <= end; i++)
                {
                    combination += edges[i];
                    combination += Combinations(clique, edgesAmount - 1, i + 1, end + 1, edges, combination);
                    combination = combination.Substring(0, combination.Length - 2);
                }
                return "";
            }
        }
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
                Combinations(clique, edgesAmount, 0, end, edges, "");
                if (wantedClique == "")
                    Console.WriteLine("Не найдено клики искомой длины.");
                else
                {
                    Console.WriteLine("Клики длины {0} в заданном графе: ", clique);
                    Console.WriteLine(wantedClique);
                }

            }
            else
                Console.WriteLine("Искомой клики не существует.");
            Console.ReadLine();
        }
    }
}
