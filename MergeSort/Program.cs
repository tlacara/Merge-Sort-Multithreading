using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int ARRAY_SIZE = 100;
            int NUM_THREADS = 4;

            int[] arraySingleThread = new int[ARRAY_SIZE];

            int min = 0;
            int max = ARRAY_SIZE;



            Stopwatch stopwatch = new Stopwatch();

            // TODO : Use the "Random" class in a for loop to initialize an array
            Random rand = new Random();

            for (int i = 0; i < arraySingleThread.Length; i++)
            {
                arraySingleThread[i] = rand.Next(min, max);
            }


            // copy array by value.. You can also use array.copy()
            int[] arrayMultiThread = new int[ARRAY_SIZE];

            Array.Copy(arraySingleThread, arrayMultiThread, arraySingleThread.Length);

            /*TODO : Use the  "Stopwatch" class to measure the duration of time that
               it takes to sort an array using one-thread merge sort and
               multi-thead merge sort
            */


            //TODO :start the stopwatch
            stopwatch.Start();
            MergeSort(arraySingleThread);

            PrintArray(arraySingleThread);
            Console.WriteLine(IsSorted(arraySingleThread));

            //TODO :Stop the stopwatch
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            string elapsedTime = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);


            //TODO: Multi Threading Merge Sort

            //splits array into subarrays

            int num_array = ARRAY_SIZE / NUM_THREADS;

            List<int[]> subarrays = new List<int[]>();
            Thread[] th = new Thread[NUM_THREADS];

            for (int i = 0; i < arrayMultiThread.Length; i = i + num_array)
            {
                int[] sub = new int[num_array];
                if (arrayMultiThread.Length < i + num_array)
                {
                    NUM_THREADS = arrayMultiThread.Length - i;
                }
                Array.Copy(arrayMultiThread, i, sub, 0, num_array);
                subarrays.Add(sub);
            }

            for (int i = 0; i < NUM_THREADS; i++)
            {
                int j = i;
                th[j] = new Thread(() => MergeSort(subarrays[j]));
                th[j].Start();
                th[i].Join();
            }

            //for (int i=0;i<NUM_THREADS;i++)
            //{
            //    Merge(th[i],th[i+1],arrayMultiThread)
            //}
           
            //for (int i = 0; i < NUM_THREADS; i++)
            //{
                
            //}










            /*********************** Methods **********************
             *****************************************************/
            /*
            implement Merge method. This method takes two sorted array and
            and constructs a sorted array in the size of combined arrays
            */

            static int[] Merge(int[] LA, int[] RA, int[] A)
            {
                // TODO :implement
                int i = 0;
                int j = 0;
                int k = 0;

                while (i < LA.Length && j < RA.Length)
                {
                    if (LA[i] <= RA[j])
                    {
                        A[k] = LA[i];
                        i++;
                    }
                    else
                    {
                        A[k] = RA[j];
                        j++;
                    }
                    k++; ;
                }
                while (i < LA.Length)
                {
                    A[k] = LA[i];
                    i++;
                    k++;
                }
                while (j < RA.Length)
                {
                    A[k] = RA[j];
                    j++;
                    k++;
                }
                return A;
            }


            /*
            implement MergeSort method: takes an integer array by reference
            and makes some recursive calls to intself and then sorts the array
            */
            static int[] MergeSort(int[] A)
            {

                // TODO :implement
                if (A.Length < 2)
                {
                    return A;
                }

                int mid = A.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[A.Length - mid];

                for (int i = 0; i < mid; i++)
                {
                    left[i] = A[i];
                }

                for (int i = mid; i < A.Length; i++)
                {
                    right[i - mid] = A[i];
                }

                MergeSort(left);
                MergeSort(right);
                Merge(left, right, A);

                return A;
            }


            // a helper function to print your array
            static void PrintArray(int[] myArray)
            {
                Console.Write("[");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write("{0} ", myArray[i]);

                }
                Console.Write("]");
                Console.WriteLine();

            }

            // a helper function to confirm your array is sorted
            // returns boolean True if the array is sorted
            static bool IsSorted(int[] a)
            {
                int j = a.Length - 1;
                if (j < 1) return true;
                int ai = a[0], i = 1;
                while (i <= j && ai <= (ai = a[i])) i++;
                return i > j;
            }


        }


    }
}
