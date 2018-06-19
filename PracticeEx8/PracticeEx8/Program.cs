﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx8
{
    class Program
    {
        static void ShowList(List<List<int>> list)
        {
            int c = 0;
            foreach (List<int> element in list)
            {
                c++;
                Console.Write(c + "   ");
                foreach (int node in element)
                {
                    Console.Write(node + 1 + " ");
                }
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int nodes = rnd.Next(1, 10);
            Console.WriteLine("Количество вершин в графе: {0}.", nodes);
            int edges = rnd.Next(0, (nodes * nodes - 1) / 2 + 1);
            Console.WriteLine("Количество ребер в графе: {0}.", edges);
            int clique;
            if (edges == 0 || nodes < 2)
            {
                Console.WriteLine("В графе не существует никакой клики.");
                return;
            }
            else
            {
                clique = rnd.Next(2, nodes + 1);
                Console.WriteLine("Длина искомой клики: {0}.", clique);
            }
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < nodes; i++)
            {
                list.Add(new List<int>());
            }
            for (int i = 0; i < edges; i++)
            {
                int firstNode = -1;
                int secondNode = -1;
                while (true)
                {
                    bool ok = true;
                    firstNode = rnd.Next(0, nodes);
                    secondNode = rnd.Next(0, nodes);
                    if (firstNode == secondNode || list[firstNode].Contains(secondNode))
                        ok = false;
                    if (ok == true)
                        break;
                }
                list[firstNode].Add(secondNode);
                list[secondNode].Add(firstNode);
            }
            Console.WriteLine("Список вершин и ребер выглядит следующим образом: ");
            ShowList(list);
            Console.WriteLine();
        }
    }
}
