using System;
using System.Collections.Generic;
using System.Linq;

namespace LHH_Opgave1.Models
{
    public class Graph
    {
        private List<State> states;
        private List<Connection> connections;

        public Graph()
        {
            states = new List<State>();
            connections = new List<Connection>();
        }

        // Add a vertex to the graph.
        public State AddState(String name, int population)
        {
            State s = new State(name, population);
            states.Add(s);
            return s;
        }

        // Remove a vertex from the graph.
        public State RemoveState(State s)
        {
            State result = null;

            try
            {
                if (states.Contains(s))
                {
                    if (Degree(s) > 0)
                    {
                        foreach (Connection c in s.GetConnections())
                        {
                            RemoveConnection(c);
                        }
                    }
                    states.Remove(s);
                    result = s;
                }
                else
                {
                    throw new ArgumentException("The argument is not valid. Only members of the graph can be removed from it.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;   
        }

        // Add an edge to the graph.
        public Connection AddConnection(State a, State b)
        {
            Connection result = null;

            try
            {
                if (states.Contains(a) && states.Contains(b))
                {
                    Connection c = new Connection(a, b);
                    connections.Add(c);
                    a.AddConnection(c);
                    b.AddConnection(c);
                    result = c;
                }
                else
                {
                    throw new ArgumentException("One or both arguments are invalid. Both arguments have to be members of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            
            return result; ;
        }

        // Remove an edge from the graph.
        public Connection RemoveConnection(Connection c)
        {
            Connection result = null;

            try
            {
                if (connections.Contains(c))
                {
                    c.GetEndpoints()[0].RemoveConnection(c);
                    c.GetEndpoints()[1].RemoveConnection(c);
                    connections.Remove(c);
                    result = c;
                }
                else
                {
                    throw new ArgumentException("The argument is not valid. Only members of the graph can be removed from it.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            
            return result;
        }

        // Get the number of vertices in the graph.
        public int StatesCount()
        {
            return states.Count;
        }

        // Get the number of edges in the graph.
        public int ConnectionsCount()
        {
            return connections.Count;
        }

        // Create vertices iterator.
        public IEnumerable<State> IterStates()
        {
            foreach (State s in states)
            {
                yield return s;
            }
        }

        // Create edges iterator.
        public IEnumerable<Connection> IterConnections()
        {
            foreach (Connection c in connections)
            {
                yield return c;
            }
        }

        // Create iterator of incident edges to a vertex.
        public IEnumerable<Connection> IncidentConnections(State s)
        {
            if (states.Contains(s) && Degree(s) > 0)
            {
                foreach (Connection c in s.GetConnections())
                {
                    yield return c;
                }
            }
        }

        // Create iterator of adjacent vertices to a vertex.
        public IEnumerable<State> AdjacentStates(State s)
        {
            if (states.Contains(s) && Degree(s) > 0)
            {
                foreach (Connection c in s.GetConnections())
                {
                    yield return Opposite(s, c);
                }
            }
        }

        // Get the opposite endpoint of an edge.
        public State Opposite(State s, Connection c)
        {
            State result = null;

            try
            {
                if (states.Contains(s) && connections.Contains(c))
                {
                    if (c.GetEndpoints()[0] == s)
                    {
                        result = c.GetEndpoints()[1];
                    }
                    else
                    {
                        result = c.GetEndpoints()[0];
                    }
                }
                else
                {
                    throw new ArgumentException("One or both arguments are invalid. Both arguments have to be members of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;
        }

        // Get the degree of a vertex.
        public int Degree(State s)
        {
            int result = -1;

            try
            {
                if (states.Contains(s))
                {
                    result = s.GetConnections().Count;
                }
                else
                {
                    throw new ArgumentException("The argument is invalid. The argument has to be a member of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;
        }

        // Check if two vertices are adjacent.
        public bool AreAdjacent(State s, State t)
        {
            bool result = false;

            try
            {
                if (states.Contains(s) && states.Contains(t))
                {
                    if (Degree(s) <= Degree(t))
                    {
                        foreach (Connection c in s.GetConnections())
                        {
                            if (c.GetEndpoints().Contains(t))
                            {
                                result = true;
                            }
                        }
                        result = false;
                    }
                    else
                    {
                        foreach (Connection c in t.GetConnections())
                        {
                            if (c.GetEndpoints().Contains(s))
                            {
                                result = true;
                            }
                        }
                        result = false;
                    }
                }
                else
                {
                    throw new ArgumentException("One or both arguments are invalid. Both arguments have to be members of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;
        }
    }
}

