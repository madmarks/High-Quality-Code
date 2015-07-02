using System;

public class Program
{
    private const int MaxCount = 6;

    public static void Main()
    {
        Program.Converter obj = new Program.Converter();

        obj.BooleanToString(true);
    }

    protected class Converter
    {
        internal void BooleanToString(bool booleanVariable)
        {
            string result = booleanVariable.ToString();

            Console.WriteLine(result);
        }
    }
}