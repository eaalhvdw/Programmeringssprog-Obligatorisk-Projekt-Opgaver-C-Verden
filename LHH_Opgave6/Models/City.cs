using System;
using System.Collections.Generic;

namespace LHH_Opgave6.Models
{
    public class City
    {
        private string name;
        private int priority = -1;
        private List<Connection> connections { get; }

        // Constructor for a City object without specifying priority.
        public City(string name)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    this.name = name;
                }
                else
                {
                    throw new ArgumentException("The argument 'name' of " +
                        "type 'String' cannot be null, empty or all white-space.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            connections = new List<Connection>();
        }

        // Constructor for a City object with a specified priority.
        public City(string name, int priority)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    this.name = name;
                }
                else
                {
                    throw new ArgumentException("The argument 'name' of " +
                        "type 'String' cannot be null, empty or all white-space.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            connections = new List<Connection>();
            this.priority = priority;
        }

        public Connection AddConnection(Connection c)
        {
            connections.Add(c);
            return c;
        }

        public Connection RemoveConnection(Connection c)
        {
            connections.Remove(c);
            return c;
        }

        public void SetPriority(int priority)
        {
            this.priority = priority;
        }

        public int GetPriority()
        {
            return this.priority;
        }

        public string GetName()
        {
            return name;
        }

        public List<Connection> GetConnections()
        {
            return connections;
        }

        public override String ToString()
        {
            if (priority != -1)
            {
                return $"{name}: {priority}";
            }
            else
            {
                return name;
            }
        }
    }
}
