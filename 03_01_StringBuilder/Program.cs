using System.Text;

namespace _03_01_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello"; //5 chars
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            str += "Hello!";
            Console.WriteLine(str);


            StringBuilder builder = new StringBuilder();
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);

            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            builder.Append("bla");
            builder.Append("bla");
            builder.AppendLine();
            Console.WriteLine(builder);


        }
    }
}
