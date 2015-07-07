namespace Kitchen
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Part 1 

            Potato potato = new Potato();
            //... 
            if (potato == null)
            {
                throw new Exception("Object potato is null!");
            }

            if (!potato.IsPeeled || potato.IsRotten)
            {
                throw new Exception("Potato is not peeled or is rotten!");
            }

            Cook(potato);

            // Part 2

            const int MIN_X = 0;
            const int MAX_X = 100;
            const int MIN_Y = 0;
            const int MAX_Y = 100;

            Random random = new Random();

            int x = random.Next(0, 105);
            int y = random.Next(0, 105);

            bool shouldVisitCell = random.Next(2) == 0;

            bool isXinRange = (MIN_X <= x) && (x <= MAX_X);
            bool isYinRange = (MIN_Y <= y) && (y <= MAX_Y);

            if (isXinRange && isYinRange && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }

        private static void Cook(Potato potato)
        {
            // ...
        }

        private static void VisitCell(int x, int y)
        {
            // ...
        }
    }
}