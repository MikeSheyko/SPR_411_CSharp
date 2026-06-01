namespace _12_1_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine("------Task 1------");
            int[] numbers = { 1, 5, 6, 8, 7, 18, 21, 17, 36, 41, 86, 17 };

            var arrayOps = new ArrayOperations();

            NumberFilter filter;

            filter = arrayOps.GetEven;
            Console.WriteLine("Even: " + string.Join(", ", filter(numbers)));

            filter = arrayOps.GetOdd;
            Console.WriteLine("Odd: " + string.Join(", ", filter(numbers)));

            filter = arrayOps.GetPrime;
            Console.WriteLine("Prime: " + string.Join(", ", filter(numbers)));

            filter = arrayOps.GetFibonacci;
            Console.WriteLine("Fibonacci: " + string.Join(", ", filter(numbers)));

            //Task 2
            Console.WriteLine();
            Console.WriteLine("------Task 2------");

            var service = new TimeService();

            Action showTime = service.ShowTime;
            Action showDate = service.ShowDate;
            Action showDay = service.ShowDay;

            showTime();
            showDate();
            showDay();

            Func<double, double, double> triangle = service.TriangleArea;
            Func<double, double, double> rectangle = service.RectangleArea;

            Console.WriteLine("Triangle area: " + triangle(10, 5));
            Console.WriteLine("Rectangle area: " + rectangle(10, 5));

            Predicate<int> isPositive = x => x > 0;
            Console.WriteLine("Is 10 positive? " + isPositive(10));

            //Task 3
            Console.WriteLine();
            Console.WriteLine("------Task 3------");

            Func<string, (int R, int G, int B)> getRainbowColor;

            getRainbowColor = delegate (string color)
            {
                switch (color.ToLower())
                {
                    case "red": return (255, 0, 0);
                    case "orange": return (255, 165, 0);
                    case "yellow": return (255, 255, 0);
                    case "green": return (0, 255, 0);
                    case "blue": return (0, 0, 255);
                    case "indigo": return (75, 0, 130);
                    case "violet": return (238, 130, 238);
                    default: return (0, 0, 0);
                }
            };
            Console.WriteLine($"Red: {getRainbowColor("red")}");
            Console.WriteLine($"Blue: {getRainbowColor("blue")}");
            Console.WriteLine($"Violet: {getRainbowColor("violet")}");
            
            //Task 4
            Console.WriteLine();
            Console.WriteLine("------Task 4------");

            int[] Numbers = { -5, -3, 1, 2, 3, 10, 12, 14, 15, 20, 21, 25, 29, 30, 33, 35 };

            Func<int[], int, int, int> countInRange = (arr, min, max) => arr.Count(x => x >= min && x <= max);

            Console.WriteLine("1..10: " + countInRange(Numbers, 1, 10));
            Console.WriteLine("10..30: " + countInRange(Numbers, 10, 30));
            Console.WriteLine("Negative..5: " + countInRange(Numbers, -10, 5));


            //Task 5
            Console.WriteLine();
            Console.WriteLine("------Task 5------");

            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua, enim ad minim veniam.";

            Func<string, string, bool> containsWord = (t, word) => t.Contains(word);

            Func<string, string, int> countWordOccurrences = (t, word) => t.Split(' ', '.', ',', '!', '?').Count(w => w == word);

            Console.WriteLine("Contains 'Lorem': " + containsWord(text, "Lorem"));
            Console.WriteLine("Occurrences of 'Lorem': " + countWordOccurrences(text, "Lorem"));

            Console.WriteLine("Contains 'dolor': " + containsWord(text, "dolor"));
            Console.WriteLine("Occurrences of 'dolor': " + countWordOccurrences(text, "dolor"));

            Console.WriteLine("Contains 'elit': " + containsWord(text, "elit"));
            Console.WriteLine("Occurrences of 'elit': " + countWordOccurrences(text, "elit"));

            Console.WriteLine("Contains 'veniam': " + containsWord(text, "veniam"));
            Console.WriteLine("Occurrences of 'veniam': " + countWordOccurrences(text, "veniam"));

        }
    }
}
