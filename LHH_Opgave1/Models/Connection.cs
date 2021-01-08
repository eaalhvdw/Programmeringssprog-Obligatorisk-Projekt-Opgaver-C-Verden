using System;

namespace LHH_Opgave1.Models
{
    public class Connection
    {
        private State[] endpoints;

        public Connection(State a, State b)
        {
            try
            {
                if (a != null && b != null)
                {
                    endpoints = new State[] { a, b };
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

        public State[] GetEndpoints()
        {
            return endpoints;
        }

        public void SetEndpoints(State s, State t)
        {
            if (s != null && t != null)
            {
                this.endpoints = new State[] { s, t };
            }
        }

        public override String ToString()
        {
            return $"({endpoints[0]}, {endpoints[1]})";
        }
    }
}
