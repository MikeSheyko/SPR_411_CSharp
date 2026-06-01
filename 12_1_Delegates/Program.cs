namespace _12_1_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine();

            Console.WriteLine("------Action, Predicate, Func------");

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
        }
    }
}
