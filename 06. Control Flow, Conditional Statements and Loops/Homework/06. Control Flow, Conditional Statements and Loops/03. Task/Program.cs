namespace _03.Task
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (new Random(i)).Next(0, 100);
            }

            int expectedValue = (new Random()).Next(0, 100);

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                    }
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
