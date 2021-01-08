using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LHH_Opgave3
{
    class Program
    {
        /**
         * Make the number of circles specified 
         * by the parameter and save them in a
         * list. Then measure how much time
         * the program will spend making
         * and saving these cirles.
         * Print the time measured and
         * the number of circles made.
         */
        static void MakeListOfCirclesTimed(int numCircles)
        {
            Stopwatch stopWatch = new Stopwatch();
            List<Circle> circles = new List<Circle>();
            double r = 1;

            try
            {
                stopWatch.Start();
                
                while (circles.Count < numCircles)
                {
                    Circle c = new Circle(r);
                    circles.Add(c);
                    r++;
                }

                stopWatch.Stop();
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("CAUGHT ERROR: " + e.Message);
            }

            TimeSpan ts = stopWatch.Elapsed;

            String elapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}", 
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine($"There were made {circles.Count} circles.");
        }

        /**
         * Make the number of circles specified
         * by the parameter and count them as 
         * they are made but not saved.
         * Measure the time it takes for
         * the program to make the circles.
         * Print the measured time and 
         * the number of circles made.
         */
        static void MakeCirclesTimed(int numCircles)
        {
            Stopwatch stopWatch = new Stopwatch();
            double r = 1;
            int counter = 0;
            int i = 0;

            stopWatch.Start();

            while (i < numCircles)
            {
                Circle c = new Circle(r);
                r++;
                counter++;
                i++;
            }

            stopWatch.Stop();
            
            TimeSpan ts = stopWatch.Elapsed;

            String elapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}", 
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine($"There were made {counter} circles.");
        }

        static void Main(string[] args)
        {
            // ---------- Testing MakeCirclesTimed(double r) ------------------------------------------

            Console.WriteLine("\nMaking circles without saving them in a list:");

            Console.Write("Making 1 mio circles: ");
            MakeCirclesTimed(1000000);
            Console.Write("\nMaking 10 mio circles: ");
            MakeCirclesTimed(10000000);
            Console.Write("\nMaking 100 mio circles: ");
            MakeCirclesTimed(100000000);
            Console.Write("\nMaking 134217728 (134,217 mio) circles: ");
            MakeCirclesTimed(134217728);
            Console.Write("\nMaking 134217729 (134,217 mio) circles: ");
            MakeCirclesTimed(134217729);
            Console.Write("\nMaking 1 billion circles: ");
            MakeCirclesTimed(1000000000);
            Console.Write("\nMaking 2.147.483.647 (2,147 billion) circles: ");
            MakeCirclesTimed(2147483647);
            
            Console.WriteLine("\nDone making circles without a list.");
            Console.ReadLine();
            
            // ---------- Testing MakeListOfCirclesTimed(double r) ------------------------------------

            Console.WriteLine("\nMaking list of circles:");

            Console.Write("Making 1 mio circles: ");
            MakeListOfCirclesTimed(1000000);
            Console.Write("\nMaking 10 mio circles: ");
            MakeListOfCirclesTimed(10000000);
            Console.Write("\nMaking 100 mio circles: ");
            MakeListOfCirclesTimed(100000000);
            Console.Write("\nMaking 134217728 (134,217 mio) circles: ");
            MakeListOfCirclesTimed(134217728);
            
            // RuntimeErrors - OutOfMemoryException.
            Console.Write("\nMaking 134217729 (134,217 mio) circles: ");
            MakeListOfCirclesTimed(134217729);
            Console.Write("\nMaking 1 billion circles: ");
            MakeListOfCirclesTimed(1000000000);
            Console.Write("\nMaking 2.147.483.647 (2,147 billion) circles: ");
            MakeListOfCirclesTimed(2147483647);

            Console.WriteLine("\nDone making list of circles.");
            Console.ReadLine();

            // ---------- TESTDATA WITH COMPILER ERRORS - CAN BE INVOKED FOR EITHER METHOD ------------

            //Making 2.147.483.648 (2,147 billion) circles.
            //MakeCirclesTimed(2147483648); // CompilerError - CS1503: cannot convert from uint to int.
            //Making 4.294.967.296 (4,294 billion) circles.
            //MakeCirclesTimed(4294967296); // CompilerError - CS1503: cannot convert from long to int.
            //Making 9.223.372.036.854.775.808 (9,223 quintillion) circles.
            //MakeCirclesTimed(9223372036854775808); // CompilerError - CS1503: cannot convert from ulong to int.
            //Making 18.446.744.073.709.551.616 (18,446 quintillion) circles.
            //MakeCirclesTimed(18446744073709551616); // CompilerError - CS1021: integral constant is too large.


            // ---------- Testing making list of circles directly from within Main() ------------------

            Console.WriteLine("\nTest making list of circles directly from within Main().");
            Console.Write("Making {numCirles} circles: ");
            
            Stopwatch stopWatch = new Stopwatch();
            List<Circle> circles = new List<Circle>();
            double r = 1;
            int numCircles = 2147483647;  // Number of cirles here.

            try
            {
                stopWatch.Start();

                while (circles.Count < numCircles)
                {
                    Circle c = new Circle(r);
                    circles.Add(c);
                    r++;
                }

                stopWatch.Stop();
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("CAUGHT ERROR: " + e.Message);
            }

            TimeSpan ts = stopWatch.Elapsed;

            String elapsedTime = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}", 
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine($"There were made {circles.Count} circles.");
            Console.WriteLine("Done making list of circles directly from within Main().");
            Console.ReadLine();
            
            // ---------- Testing making circles directly from within Main() --------------------------

            Console.WriteLine("\nTest making circles directly from within Main().");
            Console.Write("Making {numCirles} circles: ");

            stopWatch.Reset();
            r = 1;
            int i = 0;
            int counter = 0;
            numCircles = 2147483647; // Number of cirles here.

            stopWatch.Start();

            while (i < numCircles)
            {
                Circle c = new Circle(r);
                r++;
                i++;
                counter++;
            }

            stopWatch.Stop();

            TimeSpan ts_1 = stopWatch.Elapsed;

            String elapsedTime_1 = String.Format(@"{0:00}:{1:00}:{2:00}.{3:00}", 
                ts_1.Hours, ts_1.Minutes, ts_1.Seconds, ts_1.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime_1);

            Console.WriteLine($"There were made {counter} circles.");
            Console.WriteLine("Done making circles directly from within Main().");
            Console.ReadLine();
        }
    }
}
