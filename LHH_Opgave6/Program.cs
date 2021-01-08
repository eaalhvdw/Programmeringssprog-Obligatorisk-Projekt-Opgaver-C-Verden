using LHH_Opgave6.Models;
using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHH_Opgave6
{
    class Program
    {
        /**
         * Dijkstras algorithm to 
         * find the shortest path
         * from one city vertex to
         * another city vertex
         * in a weighted graph.
         */
        static String Dijkstras(Graph g, City start, City end)
        {
            String result = "";

            try
            {
                if (!g.IterCities().Contains(start) || !g.IterCities().Contains(end))
                {
                    throw new ArgumentException();
                }

                SimplePriorityQueue<City> queue = new SimplePriorityQueue<City>();
                Dictionary<City, City> backtrack = new Dictionary<City, City>();

                foreach (City c in g.IterCities())
                {
                    if (c == start)
                    {
                        c.SetPriority(0);
                        queue.Enqueue(c, 0);
                    }
                    else
                    {
                        c.SetPriority(int.MaxValue);
                    }
                }

                bool endFound = false;

                while (queue.Count > 0 && !endFound)
                {
                    City c = queue.Dequeue();
                    Console.WriteLine($"\n\t\tNEXT CITY IN THE PRIORITYQUEUE:\t{c.GetName()}");

                    if (c.Equals(end))
                    {
                        endFound = true;
                        break;
                    }

                    foreach (Connection con in g.IncidentConnections(c))
                    {
                        City w = g.Opposite(c, con);

                        Console.WriteLine($"\n\t\tNeighbour city:\t {w.GetName()}");

                        if (w.GetPriority() > c.GetPriority() + con.GetElement())
                        {
                            int oldPriority = w.GetPriority();
                            w.SetPriority(c.GetPriority() + con.GetElement());
                            Console.WriteLine($"\t\tPriority update! The priority of the City: {w.GetName()}" +
                                $"\n\t\thas been updated from {oldPriority} to {w.GetPriority()}.");

                            if (backtrack.ContainsKey(w))
                            {
                                queue.UpdatePriority(w, w.GetPriority());
                            }
                            else
                            {
                                queue.Enqueue(w, w.GetPriority());
                            }

                            backtrack[w] = c;
                        }
                    }
                }

                if (endFound)
                {
                    List<City> path = new List<City>();
                    City current = end;
                    int cost = end.GetPriority();

                    while (!current.Equals(start))
                    {
                        path.Add(current);
                        current = backtrack[current];
                    }

                    path.Add(start);
                    path.Reverse();

                    result = $"It is possible to get to {end.GetName()} from {start.GetName()} " +
                        $"at a minimum cost of {cost}\n\tby the following route: {PrintPath(path)}";
                }
                else
                {
                    result = $"It is not possible to get to {end} from {start}.";
                }
            }
            catch (ArgumentException)
            {
                if (!g.IterCities().Contains(start) && !g.IterCities().Contains(end))
                {
                    Console.WriteLine($"\n\tError: The graph does not contain the start and the " +
                        $"end cities: {start.GetName()} and {end.GetName()}.");
                }
                else if (!g.IterCities().Contains(start))
                {
                    Console.WriteLine($"\n\tError: The graph does not contain the start city: {start.GetName()}.");
                }
                else
                {
                    Console.WriteLine($"\n\tError: The graph does not contain the end city: {end.GetName()}.");
                }
            }

            return result;
        }

        /**
		 * Build a string from the list of cities to show a path.
		 */
        static StringBuilder PrintPath(List<City> list)
        {
            StringBuilder path = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                path.Append(list[i].ToString());

                if (i + 1 != list.Count)
                {
                    path.Append(" -> ");
                }
            }
            return path;
        }

        static void Main(string[] args)
        {
            // Building the graph.
            Graph graph = new Graph();

            City holstebro = graph.AddCity("Holstebro");
            City herning = graph.AddCity("Herning");
            City esbjerg = graph.AddCity("Esbjerg");
            City vejle = graph.AddCity("Vejle");
            City randers = graph.AddCity("Randers");
            City aarhus = graph.AddCity("Aarhus");
            City aalborg = graph.AddCity("Aalborg");
            City skagen = graph.AddCity("Skagen");
            City anholt = graph.AddCity("Anholt");
            City grenaa = graph.AddCity("Grenaa");

            graph.AddConnection(holstebro, aalborg, 131);
            graph.AddConnection(holstebro, herning, 36);
            graph.AddConnection(herning, esbjerg, 88);
            graph.AddConnection(herning, vejle, 74);
            graph.AddConnection(vejle, randers, 102);
            graph.AddConnection(vejle, aarhus, 72);
            graph.AddConnection(randers, aalborg, 81);
            graph.AddConnection(randers, aarhus, 39);
            graph.AddConnection(aalborg, skagen, 109);
            graph.AddConnection(skagen, anholt, 305);
            graph.AddConnection(anholt, grenaa, 59);
            graph.AddConnection(grenaa, aarhus, 65);
            
            // The number of cities in the graph.
            Console.WriteLine($"\n\tThere are " +
                $"{graph.CitiesCount()} cities in the graph.");

            // Show cities in the graph.
            Console.WriteLine("\tThe cities in the graph are:");
            foreach (City c in graph.IterCities())
            {
                Console.WriteLine("\t" + c.ToString());
            }

            // The number of connections in the graph.
            Console.WriteLine($"\n\tThere are " +
                $"{graph.ConnectionsCount()} connections in the graph.");

            // Show the connections in the graph.
            Console.WriteLine("\tThe connections in the graph are:");
            foreach (Connection c in graph.IterConnections())
            {
                Console.WriteLine("\t" + c.ToString());
            }
            Console.WriteLine();

            // Test Dijkstras algorithm
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tTest Dijkstras(Graph graph, City start, City end)\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tFinding the minimum cost path from Skagen to Herning...");
            Console.WriteLine($"\n\t{Dijkstras(graph, skagen, herning)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tFinding the minimum cost path from Holstebro to Grenaa...");
            Console.WriteLine($"\n\t{Dijkstras(graph, holstebro, grenaa)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tFinding the minimum cost path from Anholt to Vejle...");
            Console.WriteLine($"\n\t{Dijkstras(graph, anholt, vejle)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tFinding the minimum cost path from Esbjerg to Randers...");
            Console.WriteLine($"\n\t{Dijkstras(graph, esbjerg, randers)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            // Error test cases
            City sønderborg = new City("Sønderborg");
            City københavn = new City("København");
            City thisted = graph.AddCity("Thisted");
            Console.WriteLine("\n\tError case: Trying to find the " +
                "minimum cost path from Vejle to Sønderborg...");
            Console.WriteLine($"\n\t{Dijkstras(graph, vejle, sønderborg)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tError case: Trying to find the " +
                "minimum cost path from Sønderborg to Aarhus...");
            Console.WriteLine($"\n\t{Dijkstras(graph, sønderborg, aarhus)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tError case: Trying to find the " +
                "minimum cost path from Sønderborg to København...");
            Console.WriteLine($"\n\t{Dijkstras(graph, sønderborg, københavn)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.WriteLine("\n\tError case: Trying to find the " +
                "minimum cost path from Grenaa to Thisted...");
            Console.WriteLine($"\n\t{Dijkstras(graph, grenaa, thisted)}\n");
            Console.WriteLine("========================================" +
                "======================================================");
            Console.ReadLine();
        }
    }
}
