using System;

namespace MultiThreadPi
{
    class MainClass
    {
        static void Main(string[] args)
        {
            long numberOfSamples = 1000;
            long hits=0;
            
            double pi = EstimatePI(numberOfSamples, ref hits);

            Console.WriteLine(pi);

           
        }
         static double EstimatePI(long numberOfSamples, ref long hits)
        {
            //implement
            hits = 0;
            double prob;
            double[,] val = new double[numberOfSamples,2];
            val = GenerateSamples(numberOfSamples);

            for(int i = 0; i < numberOfSamples; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (val[i, j] * val[i, j] + val[i, j + 1] * val[i, j + 1] <= 1)
                    {
                        hits++;
                    }
                    
                }
            }
            prob = hits / numberOfSamples;
            return prob * 4;
        }

        static double[,] GenerateSamples(long numberOfSamples)
        {
            // Implement  
          
            Random rnd = new Random();
            double[,] cord = new double[numberOfSamples,2];

            for (int i = 0; i < numberOfSamples; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    cord[i,j] =  rnd.NextDouble() * 2 - 1;
                }
                
            }
            return cord;
        }
    }
}
