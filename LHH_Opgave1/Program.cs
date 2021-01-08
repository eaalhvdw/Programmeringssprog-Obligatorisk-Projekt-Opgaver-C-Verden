using LHH_Opgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHH_Opgave1
{
    class Program
    {
        /**
		 * Find the shortest path in the 
		 * graph from an origin state to 
		 * a destination state, if there
		 * is a path, then print the path.
		 */
        static String FindPathBFS(Graph graph, State origin, State destination)
        {
            string result = "";

            try
            {
                if (!graph.IterStates().Contains(origin) || !graph.IterStates().Contains(destination))
                {
                    throw new ArgumentException();
                }

                Dictionary<State, State> previous = new Dictionary<State, State>();
                Queue<State> statesToVisit = new Queue<State>();

                statesToVisit.Enqueue(origin);

                bool foundDestination = false;

                while (statesToVisit.Count > 0 && !foundDestination)
                {
                    State s = statesToVisit.Dequeue();

                    foreach (State neighbour in graph.AdjacentStates(s))
                    {
                        if (previous.ContainsKey(neighbour))
                        {
                            continue;
                        }

                        previous[neighbour] = s;
                        statesToVisit.Enqueue(neighbour);

                        if (neighbour.Equals(destination))
                        {
                            foundDestination = true;
                            break;
                        }
                    }
                }

                if (!foundDestination)
                {
                    result = $"There is no path from {origin.GetName()} to {destination.GetName()}.";
                }
                else
                {
                    List<State> path = new List<State>();
                    State current = destination;

                    while (!current.Equals(origin))
                    {
                        path.Add(current);
                        current = previous[current];
                    }

                    path.Add(origin);

                    path.Reverse();

                    result = $"There is a path from {origin.GetName()} to {destination.GetName()}: {PrintPath(path)}";
                }
            }
            catch (ArgumentException)
            {
                if (!graph.IterStates().Contains(origin) && !graph.IterStates().Contains(destination))
                {
                    Console.WriteLine($"Error: The graph does not contain the origin and the destination states: {origin.GetName()} and {destination.GetName()}.");
                }
                else if (!graph.IterStates().Contains(origin))
                {
                    Console.WriteLine($"Error: The graph does not contain the origin state: {origin.GetName()}.");
                }
                else
                {
                    Console.WriteLine($"Error: The graph does not contain the destination state: {destination.GetName()}.");
                }
            }

            return result;
        }

        /**
		 * Build a string from the list of states to show a path.
		 */
        static StringBuilder PrintPath(List<State> list)
        {
            StringBuilder path = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                path.Append(list[i].GetName());

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

            State idaho = graph.AddState("Idaho", 1787070);
            State utah = graph.AddState("Utah", 3205960);
            State california = graph.AddState("California", 39512220);
            State newMexico = graph.AddState("New Mexico", 2096830);
            State oregon = graph.AddState("Oregon", 4217740);
            State kansas = graph.AddState("Kansas", 2913310);
            State texas = graph.AddState("Texas", 28995880);
            State southDakota = graph.AddState("South Dakota", 884659);
            State northDakota = graph.AddState("North Dakota", 762062);
            State iowa = graph.AddState("Iowa", 3155070);
            State tennessee = graph.AddState("Tennessee", 6829170);
            State newYork = graph.AddState("New York", 19453560);
            State florida = graph.AddState("Florida", 21477740);

            graph.AddConnection(idaho, utah);
            graph.AddConnection(utah, california);
            graph.AddConnection(utah, newMexico);
            graph.AddConnection(california, oregon);
            graph.AddConnection(newMexico, kansas);
            graph.AddConnection(newMexico, texas);
            graph.AddConnection(kansas, southDakota);
            graph.AddConnection(kansas, texas);
            graph.AddConnection(southDakota, northDakota);
            graph.AddConnection(northDakota, iowa);
            graph.AddConnection(iowa, tennessee);
            graph.AddConnection(tennessee, texas);
            graph.AddConnection(texas, florida);
            graph.AddConnection(florida, tennessee);
            graph.AddConnection(tennessee, newYork);

            // Show number of states in the graph.
            Console.WriteLine($"There are {graph.StatesCount()} states in the graph.");
            
            // Show states in the graph.
            Console.WriteLine("The states in the graph are:");
            foreach (State s in graph.IterStates())
            {
                Console.WriteLine(s.ToString());
            }

            // Show number of connections in the graph.
            Console.WriteLine($"\nThere are {graph.ConnectionsCount()} connections in the graph.");

            // Show connections in the graph.
            Console.WriteLine("The connections in the graph are:");
            foreach (Connection c in graph.IterConnections())
            {
                Console.WriteLine(c.ToString());
            }

            // Test BFS algorithm to find a path.
            Console.WriteLine("\nTest FindPathBFS(Graph graph, State origin, State destination).");
			State colorado = new State("Colorado", 5758740);
            State virginia = new State("Virginia", 8535520);
            State georgia = graph.AddState("Georgia", 1061742);
            Console.WriteLine("The state of Georgia is added to the graph, while the states Colorado and Virginia are initialized but not added to the graph.");
            Console.WriteLine("Case 1: graph, idaho, south dakota.");
            Console.WriteLine($"Result 1: {FindPathBFS(graph, idaho, southDakota)}");
            Console.WriteLine("Case 2: graph, utah, tennessee.");
            Console.WriteLine($"Result 2: {FindPathBFS(graph, utah, tennessee)}");
            Console.WriteLine("Case 3: graph, iowa, georgia.");
            Console.WriteLine($"Result 3: {FindPathBFS(graph, iowa, georgia)}");
            Console.Write("Case 4: graph, idaho, colorado.\nResult 4: ");
            Console.Write($"{FindPathBFS(graph, idaho, colorado)}");
            Console.Write("Case 5: graph, colorado, southDakota.\nResult 5: ");
            Console.Write($"{FindPathBFS(graph, colorado, southDakota)}");
            Console.Write("Case 6: graph, colorado, virginia.\nResult 6: ");
            Console.WriteLine(FindPathBFS(graph, colorado, virginia));
            Console.ReadLine();
        }
    }
}
