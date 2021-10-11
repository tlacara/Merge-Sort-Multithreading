using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MultiThreadPi
{
    class MainClass
    {
        static void Main(string[] args)
        {
            long numberOfSamples = 100000000;
            long hits = 0;
            int threadnum = 4;

            Stopwatch watch = new Stopwatch();

            //Single Thread Appoach

            watch.Start();
            double pi = EstimatePI(numberOfSamples, ref hits);
            hits = 0;
            watch.Stop();

            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(pi);
            

            //Multi-Thread Approach

            Stopwatch multiwatch = new Stopwatch();
            TimeSpan tsmulti = multiwatch.Elapsed;
            List<Thread> threads = new List<Thread>();

            long samplenum = numberOfSamples / threadnum;

            multiwatch.Start();

            for (int i = 0; i < threadnum; i++)
            {
                Thread thread = new Thread(() => EstimatePI(samplenum, ref hits));
                thread.Start();
                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            multiwatch.Stop();

            Console.WriteLine((double)hits / numberOfSamples * 4);
            Console.WriteLine(multiwatch.Elapsed);

            
            //debugger closes automatically for some reason so this line is to prevent that
            Console.ReadLine();

        }
        static double EstimatePI(long numberOfSamples, ref long hits)
        {
            //implement

            double prob;
            double[,] val = GenerateSamples(numberOfSamples);

            for (int i = 0; i < numberOfSamples; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (val[i, j] * val[i, j] + val[i, j + 1] * val[i, j + 1] <= 1)
                    {
                        Interlocked.Increment(ref hits);
                       
                    }

                }
            }
            prob = (double)hits / numberOfSamples;
            
            return prob * 4;
        }

        static double[,] GenerateSamples(long numberOfSamples)
        {
            // Implement  

            Random rnd = new Random();
            double[,] cord = new double[numberOfSamples, 2];

            for (int i = 0; i < numberOfSamples; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cord[i, j] = rnd.NextDouble() * 2 - 1;
                }

            }
            return cord;
        }
    }
}
