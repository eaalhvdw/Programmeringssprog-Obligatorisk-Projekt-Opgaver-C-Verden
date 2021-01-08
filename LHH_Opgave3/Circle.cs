using System;

namespace LHH_Opgave3
{
    public class Circle
    {
        private double radius;

        public Circle(double radius)
        {
            try
            {
                if (radius > 0)
                {
                    this.radius = radius;
                }
                else
                {
                    throw new ArgumentException("The argument must have a value greater than zero.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        public double GetRadius()
        {
            return radius;
        }

        public void SetRadius(double radius) 
        {
            if (radius > 0)
            {
                this.radius = radius;
            }
        }
    }
}
