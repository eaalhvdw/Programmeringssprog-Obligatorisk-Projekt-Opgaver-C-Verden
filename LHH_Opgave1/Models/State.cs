using System;
using System.Collections.Generic;

namespace LHH_Opgave1.Models
{
    public class State
    {
        private string name;
        private int population;
        private List<Connection> connections { get; }

        public State(string name, int population)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(name))
                {
                    this.name = name;
                }
                else
                {
                    throw new ArgumentException("The argument 'name' of type 'String' cannot be null, empty or all white-space.");
                }

                if (population >= 0)
                {
                    this.population = population;
                }
                else
                {
                    throw new ArgumentException("The argument 'population' of type 'int' cannot have a negative value.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            connections = new List<Connection>();
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

        public string GetName()
        {
            return name;
        }

        public int GetPopulation()
        {
            return population;
        }

        public void SetPopulation(int population)
        {
            if (population >= 0)
            {
                this.population = population;
            }
        }

        public List<Connection> GetConnections()
        {
            return connections;
        }

        public override String ToString()
        {
            return $"{name}({population})";
        }
    }
}
