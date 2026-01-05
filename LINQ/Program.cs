namespace LINQ
{
    internal class Program()
    {
        private static readonly int[] scores = { 97, 92, 81, 60 };

        public static void Main()
        {
            FirstExample();
            BasicQuery();
            WhatAQueryDoes();
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

        private static void WhatAQueryDoes()
        {
            Console.WriteLine("-- What a query does --");

            // Retrieve a sequence without modifying individual elements
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;

            Console.WriteLine("\nhighScoresQuery:");
            foreach (int highScore in highScoresQuery)
            {
                Console.WriteLine(highScore);
            }

            // Retrieve and modify elements to a new object type
            IEnumerable<string> highScoresQuery2 =
                from score in scores
                where score > 80
                orderby score descending
                select $"The score is {score}";

            Console.WriteLine("\nhighScoresQuery2:");
            foreach(string str in highScoresQuery2)
            {
                Console.WriteLine(str); 
            }

            // Retrieve a single value from the source data
            int highScoreCount =
            (
                from score in scores
                where score > 80
                select score
            ).Count();

            Console.WriteLine($"\nhighScoreCount = {highScoreCount}");
            
            //-------------------------------------------------
            // Or you can store the query variable first, and then count
            IEnumerable<int> highScoreQuery3 =
                from score in scores
                where score > 80
                select score;

            int scoreCount = highScoreQuery3.Count();
            Console.WriteLine($"\nscoreCount = {scoreCount}");
        }
    }
}