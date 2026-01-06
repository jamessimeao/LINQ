namespace LINQ
{
    internal record City(string Name, long Population);
    internal record Country(string Name, double Area, long Population, List<City> Cities);
    internal record Product(string Name, string Category);

    internal class Program()
    {
        private static readonly int[] scores = { 97, 92, 81, 60 };

        // More data
        private static readonly City[] cities = [
            new City("Tokyo", 37_833_000),
            new City("Delhi", 30_290_000),
            new City("Shanghai", 27_110_000),
            new City("São Paulo", 22_043_000),
            new City("Mumbai", 20_412_000),
            new City("Beijing", 20_384_000),
            new City("Cairo", 18_772_000),
            new City("Dhaka", 17_598_000),
            new City("Osaka", 19_281_000),
            new City("New York-Newark", 18_604_000),
            new City("Karachi", 16_094_000),
            new City("Chongqing", 15_872_000),
            new City("Istanbul", 15_029_000),
            new City("Buenos Aires", 15_024_000),
            new City("Kolkata", 14_850_000),
            new City("Lagos", 14_368_000),
            new City("Kinshasa", 14_342_000),
            new City("Manila", 13_923_000),
            new City("Rio de Janeiro", 13_374_000),
            new City("Tianjin", 13_215_000)
        ];

        private static readonly Country[] countries = [
            new Country ("Vatican City", 0.44, 526, [new City("Vatican City", 826)]),
            new Country ("Monaco", 2.02, 38_000, [new City("Monte Carlo", 38_000)]),
            new Country ("Nauru", 21, 10_900, [new City("Yaren", 1_100)]),
            new Country ("Tuvalu", 26, 11_600, [new City("Funafuti", 6_200)]),
            new Country ("San Marino", 61, 33_900, [new City("San Marino", 4_500)]),
            new Country ("Liechtenstein", 160, 38_000, [new City("Vaduz", 5_200)]),
            new Country ("Marshall Islands", 181, 58_000, [new City("Majuro", 28_000)]),
            new Country ("Saint Kitts & Nevis", 261, 53_000, [new City("Basseterre", 13_000)])
        ];


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