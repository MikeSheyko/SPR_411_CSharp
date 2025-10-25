using System.Globalization;
using System.Text;

namespace _03_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Roman";
            String lastname = "Ivanchuk";
            string str = null;

            string fullName = name + " " + lastname;
            Console.WriteLine(fullName);
            Console.WriteLine($"Fullname : {fullName,-20}, Age {20}");

            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string greeting = new string(letters);
            Console.WriteLine($"Greeting : {greeting}");

            string[] words = { "Hello", "from", "C#", "world!" };
            string res = string.Join(" - ", words);
            Console.WriteLine($"Res = {res}");

            string[] splitArr = res.Split(new string[] { " - " }, StringSplitOptions.None);

            foreach (var item in splitArr)
            {
                Console.WriteLine(item);
            }

            string htmlMessage = "HTML is a standardized document markup language for viewing " +
              "web pages in a browser. Browsers receive an HTML document from the " +
              "server using HTTP/HTTPS protocols or open it from a local disk, " +
              "then interpret the code into the interface that will be displayed " +
              "on the monitor screen. ";

            string []words2 = htmlMessage.Split(new char[] { ' ', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words2)
            {
                Console.WriteLine($"| {item}");
            }


            DateTime dateNow = DateTime.Now;
            Console.WriteLine(dateNow);
            Console.WriteLine(dateNow.ToString());
            Console.WriteLine(dateNow.ToLongDateString());
            Console.WriteLine(dateNow.ToShortDateString());
            Console.WriteLine(dateNow.ToLongTimeString());
            Console.WriteLine(dateNow.ToShortTimeString());
            Console.WriteLine(dateNow.ToString("yyyy-MM-dd"));

            DateTime vacations = new DateTime(2025, 12, 21);

            TimeSpan timeSpan = vacations - dateNow;

            Console.WriteLine($"Time Span {timeSpan} ");
            Console.WriteLine($"Time Span {timeSpan.ToString()} ");
            Console.WriteLine($"Milliseconds : {timeSpan.Milliseconds}");
            Console.WriteLine($"Seconds : {timeSpan.Seconds}");
            Console.WriteLine($"Minutes : {timeSpan.Minutes}");
            Console.WriteLine($"Hours : {timeSpan.Hours}");
            Console.WriteLine($"Days : {timeSpan.Days}");



            Console.WriteLine($"Total Milliseconds : {timeSpan.TotalMilliseconds}");
            Console.WriteLine($"Total Seconds : {timeSpan.TotalSeconds}");
            Console.WriteLine($"Total Minutes : {timeSpan.TotalMinutes}");
            Console.WriteLine($"Total Hours : {timeSpan.TotalHours}");
            Console.WriteLine($"Total Days : {timeSpan.TotalDays}");



            Console.OutputEncoding = Encoding.UTF8;
            decimal money = 41.90m;
            //CultureInfo us = new CultureInfo("PL-pl");
            //CultureInfo us = new CultureInfo("ka-GE");
            //CultureInfo us = new CultureInfo("UA-ua");
            //CultureInfo us = new CultureInfo("ko-KR");
            CultureInfo us = new CultureInfo("en-US");
            //CultureInfo us = new CultureInfo("fr-FR");
            string course = $"Today course of dollar is : {money.ToString("C2", us)}";
            Console.WriteLine(course);



        }


    }
}
