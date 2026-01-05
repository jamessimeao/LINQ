namespace LINQ
{
    internal class Program()
    {
        private static readonly int[] scores = { 97, 92, 81, 60 };

        public static void Main()
        {
            FirstExample();
            BasicQuery();
        }

        private static void FirstExample()
        {
            Console.WriteLine("-- First example --");

            // Select scores that are > 80
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach (var i in scoreQuery)
            {
                Console.Write($"{i} ");
            }
            Console.Write("\n");
        }

        private static void BasicQuery()
        {
            Console.WriteLine("-- Basic query --");
            // Data source
            int[] numbers = [0, 1, 2, 3, 4, 5, 6];

            // Query creation
            // Select even numbers
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // Query execution
            foreach (int num in numQuery)
            {
                Console.Write($"{num} ");
            }
            Console.Write("\n");
        }
    }
}