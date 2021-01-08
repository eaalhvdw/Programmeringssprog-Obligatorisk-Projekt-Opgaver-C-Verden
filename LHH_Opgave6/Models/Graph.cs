using System;
using System.Collections.Generic;
using System.Linq;

namespace LHH_Opgave6.Models
{
    public class Graph
    {
        private List<City> cities;
        private List<Connection> connections;

        public Graph()
        {
            cities = new List<City>();
            connections = new List<Connection>();
        }

        // Add a vertex to the graph.
        public City AddCity(String name)
        {
            City c = new City(name);
            cities.Add(c);
            return c;
        }

        // Add a vertex with a priority to the graph.
        public City AddCityWithPriority(string name, int priority)
        {
            City c = new City(name, priority);
            cities.Add(c);
            return c;
        }

        // Remove a vertex from the graph.
        public City RemoveCity(City c)
        {
            City result = null;

            try
            {
                if (cities.Contains(c))
                {
                    if (Degree(c) > 0)
                    {
                        List<Connection> connections = c.GetConnections();
                        for (int i = 0; i < connections.Count; i++)
                        {
                            RemoveConnection(connections[i]);
                        }
                    }
                    cities.Remove(c);
                    result = c;
                }
                else
                {
                    throw new ArgumentException("The argument is not valid. " +
                        "Only members of the graph can be removed from it.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;   
        }

        // Add an edge to the graph.
        public Connection AddConnection(City a, City b, int element)
        {
            Connection result = null;

            try
            {
                if (cities.Contains(a) && cities.Contains(b))
                {
                    Connection c = new Connection(a, b, element);
                    connections.Add(c);
                    a.AddConnection(c);
                    b.AddConnection(c);
                    result = c;
                }
                else
                {
                    throw new ArgumentException("One or two arguments are invalid. " +
                        "Arguments of type 'City' have to be members of the graph.");
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
                    throw new ArgumentException("The argument is not valid. " +
                        "Only members of the graph can be removed from it.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            
            return result;
        }

        // Get the number of vertices in the graph.
        public int CitiesCount()
        {
            return cities.Count;
        }

        // Get the number of edges in the graph.
        public int ConnectionsCount()
        {
            return connections.Count;
        }

        // Create vertices iterator.
        public IEnumerable<City> IterCities()
        {
            foreach (City c in cities)
            {
                yield return c;
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
        public IEnumerable<Connection> IncidentConnections(City c)
        {
            if (cities.Contains(c) && Degree(c) > 0)
            {
                foreach (Connection con in c.GetConnections())
                {
                    yield return con;
                }
            }
        }

        // Create iterator of adjacent vertices to a vertex.
        public IEnumerable<City> AdjacentCities(City c)
        {
            if (cities.Contains(c) && Degree(c) > 0)
            {
                foreach (Connection con in c.GetConnections())
                {
                    yield return Opposite(c, con);
                }
            }
        }

        // Get the opposite endpoint of an edge.
        public City Opposite(City c, Connection con)
        {
            City result = null;

            try
            {
                if (cities.Contains(c) && connections.Contains(con))
                {
                    if (con.GetEndpoints()[0] == c)
                    {
                        result = con.GetEndpoints()[1];
                    }
                    else
                    {
                        result = con.GetEndpoints()[0];
                    }
                }
                else
                {
                    throw new ArgumentException("One or both arguments are invalid. " +
                        "Both arguments have to be members of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;
        }

        // Get the degree of a vertex.
        public int Degree(City c)
        {
            int result = -1;

            try
            {
                if (cities.Contains(c))
                {
                    result = c.GetConnections().Count;
                }
                else
                {
                    throw new ArgumentException("The argument is invalid. " +
                        "The argument has to be a member of the graph.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return result;
        }

        // Check if two vertices are adjacent.
        public bool AreAdjacent(City c, City d)
        {
            bool result = false;

            try
            {
                if (cities.Contains(c) && cities.Contains(d))
                {
                    if (Degree(c) <= Degree(d))
                    {
                        foreach (Connection con in c.GetConnections())
                        {
                            if (con.GetEndpoints().Contains(d))
                            {
                                result = true;
                            }
                        }
                        result = false;
                    }
                    else
                    {
                        foreach (Connection con in d.GetConnections())
                        {
                            if (con.GetEndpoints().Contains(d))
                            {
                                result = true;
                            }
                        }
                        result = false;
                    }
                }
                else
                {
                    throw new ArgumentException("One or both arguments are invalid. " +
                        "Both arguments have to be members of the graph.");
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
