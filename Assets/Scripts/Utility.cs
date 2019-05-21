using System;

namespace PSO_Console
{
    public class Utility
    {
        private static Random rand = new Random();
        /**
         * Generates a random float BETWEEN the two values
         */
        public static float GetRandom(float min, float max)
        {
            if (min > max)
            {
                throw new ArgumentException();
            }
            float newRand = (float) rand.NextDouble() * (max - min) + min;
            return newRand;
        }

        public static float ArrDistance(float[] a, float[] b)
        {
//            Console.WriteLine(String.Join(",", a));
//            Console.WriteLine(String.Join(",", b));
            float distance = -1;
            float[] diffs = new float[a.Length];
            for (int i = 0; i < diffs.Length; i++)
            {
                diffs[i] = (float)Math.Pow(b[i] - a[i], 2);
            }
            float sum = SumOfArray(diffs);
            distance = (float)Math.Sqrt(sum);
            return distance;
        }

        public static float SumOfArray(float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}