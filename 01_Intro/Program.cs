using System.Data;
using System.Text;

namespace _01_Intro
{
    internal class Program
    {
        static void Test1()
        { 

        }

        static void Literals()
        {

            /*при помощи метода GetType() программа возвращает
            тип данных литералов, демонстрируя действие суффиксов*/
            Console.WriteLine((10).GetType());  /*выводит в консоль: System.Int32 что соответствует типу данных int*/
            Console.WriteLine((10D).GetType()); /*выводит в консоль: System.Double что соответствует типу данных double*/
            Console.WriteLine((10f).GetType()); /*выводит в консоль: System.Single что соответствует типу данных float*/
            Console.WriteLine((10m).GetType()); /*выводит в консоль: System.Decimal что соответствует типу данных decimal*/
            Console.WriteLine((10L).GetType()); /*выводит в консоль: System.Int64 что соответствует типу данных long*/
            Console.WriteLine((10UL).GetType());/*выводит в консоль: System.Uint64 что соответствует типу данных ulong*/
            Console.WriteLine(0xFF);            /*выводит в консоль: 255 шестнадцатиричное число 0xFF соответствуетa десятичному числу 255*/
        }

        static void FormatString()
        {
            Console.OutputEncoding = Encoding.Unicode;
            /////////////////////// Escape Sequences
            /*
                \'      – single quote, needed for character literals
                \"      – double quote, needed for string literals
                \\      – backslash
                \0      – Unicode character 0
                \a      – Alert (character 7)
                \b      – Backspace (character 8)
                \f      – Form feed (character 12)
                \n      – New line (character 10)
                \r      – Carriage return (character 13)
                \t      – Horizontal tab (character 9)
                \v      – Vertical quote (character 11)
                \uxxxx  – Unicode escape sequence for character with hex value xxxx                
            */
            Console.WriteLine("Некоторое простое сообщение\nИещё " +
                "одно простое сообщение на " +
                "новой строке" +
                "fjdsokghdklghksdl");
            /*выводит в консоль следующее сообщение:
            Некоторое простое сообщение
            И ещё одно простое сообщение на новой строке*/
            Console.WriteLine("Пример табуляции: " +
             "\n1\t2\t3\n4\t5\t6");
            /*выводит в консоль следующее сообщение:
            Пример табуляции:
            1. 2 3
            4. 5 6*/
            Console.WriteLine("kghfdkjgh" +
                "sdjfisdgiusgf" +
                "sdhfiusdgfuisd" +
                "dsihfsdigiusd" +
                "shdgoisdgh");
            Console.WriteLine(@"C:\Users\helen\Desktop\Work\C#\1"); //@ - ігнорує escape-послідовності
            /////////////////////// @ - litteral formatting
            Console.WriteLine(@"Пример буква        льного
         hhjfhf
                C:\Users\helen\Desktop\Work\C#\1
             kdfjgoihiodfhoihb
            строкового литерала:
ehoiweiowegtowei
            1 \t 3
            \n 5 6");


            /*выводит в консоль следующее сообщение:
            Пример буква        льного
            
            
            строкового литерала:
            1 \t 3
            \n 5 6*/

            /////////////////////// string concat
            string name = "Bob";
            int day = 29;
            bool isValid = true;

            Console.WriteLine("Hello " + name + " Day: " + day.ToString());
            Console.WriteLine("Hello " + name + " Day: " + day); // ToString() is called automatically
            // string interpolation: $ - operator
            Console.WriteLine($"Hello, {name}\tDay: {day}\nValid: {isValid}{{}}");
            // $ + @
            Console.WriteLine($@"Hello, {name}\tDay: {day}\nValid: {isValid}{{}}");
        }

        static void ConsoleMethods()
        {
            //изменяет заголовок окна консоли
            Console.Title = "Пример использования инструментов класса Console";
            //изменяет цвет фона
            Console.BackgroundColor = ConsoleColor.Green;
            //изменяет цвет текста                      
            Console.ForegroundColor = ConsoleColor.Magenta;
            //получаем размер самого длинного сообщения в рамках нашей программы
            //int length = ("Input Encoding: " + Console.InputEncoding.ToString()).Length + 1;
            Console.WriteLine("Input Encoding: dsnbfdjskjghdfjkghdfkjghdfjkhkjgbksdjghskghskdghkdsjgh");
            int length = ("Input Encoding: dsnbfdjsbsdjghdfjkghdfkjghdfjkhkjgbksdjghskghskdghkdsjgh ").Length + 1;
            Console.SetWindowSize(length, 8);
            //устанавливаем размер окна консоли
            /*устанавливаем размер буфера консоли
            (размер окна должен быть
            соответствующим и должен быть
            установлен до того, как мы изменим
            размер буфера)*/
            //Console.SetBufferSize(length, 8);
            //выводим информацию о кодировке потока ввода
            Console.WriteLine("Input Encoding: " + Console.InputEncoding.ToString());
            //выводим информацию о кодировке потока вывода
            Console.WriteLine("Output Encoding: " + Console.OutputEncoding.ToString());
            //устанавливает зеначение цвета текста в значение по умолчанию
            Console.ResetColor();
            //выводим информацию о том, нажат ли NUM LOCK
            Console.WriteLine("Is NUM LOCK turned on: " + Console.NumberLock.ToString());
            //выводим информацию о том, нажат ли CAPS LOCK
            Console.WriteLine("Is CAPS LOCK turned on: " + Console.CapsLock.ToString());
            /*выводим пользователю сообщение
            о том, что программа ожидает ввода
            некоторой информации*/
            Console.Write("Enter a simpe message: ");
            //получаем от пользователя текстовое сообщение
            string message = Console.ReadLine();
            //выводим сообщение, введённое пользователем
            Console.WriteLine("Your message is: " + message);
            //звук beep
            Console.Beep(300, 3000);
            //очистка консоли
            Console.Clear();
            Console.WriteLine("Your message is: " + message);
        }

        static void Main(string[] args)
        {
            
            Test1();

            //Literals();
            //FormatString();
            //ConsoleMethods();

            Console.WriteLine("Hello, World!");

            Console.Write("Hello\n");
            Console.Write("Hello\t");
            Console.Write("Hello");
            Console.WriteLine("Hello, World!");

            object obj = new object();
            
            int a = 5; // Наслідник типу System.ValueType
            Console.WriteLine(a);

            int b = 10; // System.Int32

            Int64 c = 58; // System.Int64

            //cw + TAB
            Console.WriteLine("Enter number ");
            string str = Console.ReadLine()!; // ! - null forgivness operator
            int number = int.Parse(str); // System.Int32.Parse(str)
            Console.WriteLine(str + 1000);
            Console.WriteLine(number + 1000);

            Console.WriteLine("You entered " + number + 1000 + "!!!!"); // Конкатенація рядків
            Console.WriteLine("You entered : " + (number + 1000) + "!!!!"); // Спрацює арифметика

            Console.WriteLine($"You entered : {number + 1000} !!!!"); // Інтерполяція рядків

            //Nullable data types(references)   -   Not nullable data types(value)
            int x = 0;
            int z; // Не ініціалізована змінна
            //int y = null; // Error бо це Stack memory

            Nullable<int> y = null; // Nullable value type
            int? y1 = null; // syntactic sugar for Nullable<int>

            string str1 = null;
            string str2 = "Hello";


            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine(now.ToLongDateString());
            Console.WriteLine(now.ToLongTimeString());
            Console.WriteLine(now.ToShortDateString());
            Console.WriteLine(now.ToShortTimeString());
            Console.WriteLine(now.ToString("yyyy-MM-dd"));

            bool myBool = true;
            short myShort = 6;
            int myInt = myShort; // short ----> int implicit conversion
            float myFloat = 1.35f; // double ----> float explicit conversion звужуюче перетворення заборонено
            //int x2 = myFloat; // Error
            int x3 = (int)myFloat; // explicit conversion явне перетворення



            Console.WriteLine("Enter digit : ");
            //string numberStr = Console.ReadLine()!;
            //int number_new = int.Parse(numberStr);



            try
            {
                int number_new = int.Parse(Console.ReadLine()!);
                //number_new = Convert.ToInt32(Console.ReadLine()!);
                Console.WriteLine($"You entered {number_new}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            
            Random random = new Random(); // псевдовипадкові числа
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(random.Next(100)); 
            }

            //Console.WriteLine(random.Next()); // [0;Int32.MaxValue)
            //Console.WriteLine(random.Next(50); // [0;50)
            //Console.WriteLine(random.Next(50, 100)); // [50;100)
            //Console.WriteLine(random.NextDouble()); // [0.0;1.0)






        }
    }
}


