using System;

namespace LHH_Opgave6.Models
{
    public class Connection
    {
        private City[] endpoints;
        private int element;

        public Connection(City a, City b, int element)
        {
            try
            {
                if (a != null && b != null)
                {
                    endpoints = new City[] { a, b };
                    this.element = element;
                }
                else
                {
                    throw new ArgumentNullException("Arguments cannot be null.");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        public City[] GetEndpoints()
        {
            return endpoints;
        }

        public void SetEndpoints(City s, City t)
        {
            if (s != null && t != null)
            {
                this.endpoints = new City[] { s, t };
            }
        }

        public int GetElement()
        {
            return element;
        }

        public override String ToString()
        {
            return $"({endpoints[0]}, {endpoints[1]}): {element}";
        }
    }
}
