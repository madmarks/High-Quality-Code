[assembly: System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
namespace Methods
{
    using System;
    using System.Linq;

    internal class Methods
    {
        internal static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, StringFormatOtions.TwoDecimalDigits);
            PrintAsNumber(0.75, StringFormatOtions.PercentNoDecimalDigits);
            PrintAsNumber(2.30, StringFormatOtions.EightCharsFixedWidth);

            bool isHorizontalLine = IsHorizontalLine(-1, 2.5);
            bool isVerticalLine = IsVerticalLine(3, 3);

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? : " + isHorizontalLine.ToString());
            Console.WriteLine("Vertical? : " + isVerticalLine.ToString());

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "From Vidin, gamer, high results");

            Console.WriteLine("{0} is older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella).ToString());
        }

        private static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if ((sideA + sideB <= sideC) || (sideB + sideC <= sideA) || (sideC + sideA <= sideB))
            {
                throw new ArgumentException("Invalid Triangle");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;

            // Heron's Formula for the area of a triangle when you know the lengths of all three sides.
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        private static string NumberToDigit(int number)
        {
            string digit;

            switch (number)
            {
                case 0:
                    digit = "zero";
                    break;
                case 1:
                    digit = "one";
                    break;
                case 2:
                    digit = "two";
                    break;
                case 3:
                    digit = "three";
                    break;
                case 4:
                    digit = "four";
                    break;
                case 5:
                    digit = "five";
                    break;
                case 6:
                    digit = "six";
                    break;
                case 7:
                    digit = "seven";
                    break;
                case 8:
                    digit = "eight";
                    break;
                case 9:
                    digit = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid number!");
            }

            return digit;
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Argument 'elements' cannot be null.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Argument 'elements' must have at least one element.");
            }

            int maxNumber = elements.Max();

            return maxNumber;
        }

        private static void PrintAsNumber(object number, StringFormatOtions format)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Argument 'number' cannot be null.");
            }

            switch (format)
            {
                case StringFormatOtions.TwoDecimalDigits:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case StringFormatOtions.PercentNoDecimalDigits:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case StringFormatOtions.EightCharsFixedWidth:
                    Console.WriteLine("{0,8}", number);
                    break;
                default: 
                    throw new NotImplementedException("Not supported operation");
            }
        }

        private static double CalculateDistance(
            double x1,
            double y1,
            double x2,
            double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        private static bool IsHorizontalLine(double y1, double y2)
        {
            bool isHorizontalLine = y1 == y2;
            
            return isHorizontalLine;
        }

        private static bool IsVerticalLine(double x1, double x2)
        {
            bool isVerticalLine = x1 == x2;
            
            return isVerticalLine;
        }
    }
}
