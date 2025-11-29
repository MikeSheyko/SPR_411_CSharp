namespace _09_Inheritance
{
    //protected : allow access from inherit class
    //protected internal : allow access from inherit class only this project

    #region Lesson
    abstract class Person //: Object
    {
        protected string name;
        private readonly DateTime birthdate;
        public Person()
        {
            name = "no name";
            birthdate = new DateTime();
        }
        public Person(string n, DateTime date)
        {
            name = n;
            if (date < DateTime.Now)
                birthdate = date;
            else
                birthdate = new DateTime();
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name {name}. Birthdate : {birthdate.ToShortDateString()}\n");
        }
        public abstract void DoWork();
        public override string ToString()
        {
            return $"Name {name}. Birthdate : {birthdate.ToShortDateString()}";
        }
    }
    class Person2 { }
    //Inheritance public
    //class Name : BaseClass, Interface1,Interface2


    class Worker : Person
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            private set { this.salary = value > 0 ? value : 0; }
        }
        public Worker() : base()
        {
            Salary = 0;
        }
        public Worker(string n, DateTime b, decimal s) : base(n, b)
        {
            Salary = s;
        }
        public override void DoWork()
        {
            Console.WriteLine("Doing some work!");
        }
        // new = create new member and stop virtual
        //public new void Print()
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Salary : {Salary}");
        }

    }
    //  //sealed  - заборонений до наслідування
    sealed class Programmer : Worker
    {
        public int CountLines { get; set; }
        public Programmer() : base()
        {
            CountLines = 0;
        }
        public Programmer(string n, DateTime b, decimal s) : base(n, b, s)
        {
            CountLines = 0;
        }
        //sealed  - заборонений до перевизначення
        public sealed override void DoWork()
        {
            Console.WriteLine("Write C# code!");
        }
        public void WriteLine()
        {
            CountLines++;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"CountLines : {CountLines}");
        }
    }
    class TeamLead : Worker
    {
        public int ProjectCount { get; set; }
        //public override void DoWork()
        //{
        //    Console.WriteLine("Manage team project");
        //}

    }
    class CompouseWorkers
    {
        Person[] workers;
        public CompouseWorkers(params Person[] workers)
        {
            this.workers = workers;
        }

    }

    #endregion



    #region Practice
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();

        public virtual void Print()
        {
            Console.WriteLine($"Area = {GetArea()}, Perimeter = {GetPerimeter()}");
        }
    }

    class Triangle : GeometricFigure
    {
        private double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }


        public override double GetPerimeter()
        {
            return a + b + c;
        }

        public override void Print()
        {
            Console.WriteLine($"Triangle: a = {a}, b = {b}, c = {c}");
            base.Print();
        }
    }


    class Square : GeometricFigure
    {
        private double side;
        public Square(double side)
        {
            this.side = side;
        }
        public override double GetArea()
        {
            return side * side;
        }
        public override double GetPerimeter()
        {
            return side * 4;
        }

        public override void Print()
        {
            Console.WriteLine($"Square: side = {side}");
            base.Print();
        }
    }

    class Rhombus : GeometricFigure
    {
        private double side;
        private double height;
        public Rhombus(double side, double height)
        {
            this.side = side;
            this.height = height;
        }
        public override double GetArea()
        {
            return side * height;
        }
        public override double GetPerimeter()
        {
            return side * 4;
        }

        public override void Print()
        {
            Console.WriteLine($"Rhombus: side = {side}, height = {height}");
            base.Print();
        }
    }

    class Rectangle : GeometricFigure
    {
        private double width, height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double GetArea()
        {
            return width * height;
        }
        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
        public override void Print()
        {
            Console.WriteLine($"Rectangle: width = {width}, height = {height}");
            base.Print();
        }   
    }

    class CompositeFigure
    {
        private GeometricFigure[] figures;
        public CompositeFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }
        
        public GeometricFigure this[int index]
        {
            get
            {
                if (index < 0 || index >= figures.Length)
                {
                    throw new IndexOutOfRangeException("Error! Invalid index!");
                }
                else
                    return figures[index];
            }
            set
            {
                if (index < 0 || index >= figures.Length)
                {
                    throw new IndexOutOfRangeException("Error! Invalid index!");
                }
                else
                {
                    figures[index] = value;
                }
            }
        }

        public int Count
        {
            get { return figures.Length; }
        }
       
        public void Print()
        {
            Console.WriteLine("--------------Composite Figure--------------");
            for (int i = 0; i < figures.Length; i++)
            {
                Console.WriteLine($"\t Figure {i+1} ");
                figures[i].Print();
                Console.WriteLine();
            }

            
        }
    }

    #endregion










    public class Program
    {
        static void Main(string[] args)
        {
            CompouseWorkers compouse = new CompouseWorkers(new Worker(),
                new Programmer(), new TeamLead(), new Worker());
            //Person person = new Person("Bob", new DateTime(2000,5,15));
            //person.Print();
            //Console.WriteLine(person);
            Worker worker = new Worker("Oleg", new DateTime(1995, 2, 2), 10000);
            worker.Print();
            worker.DoWork();

            Person[] workers = new Person[] {
                //new Person(),
                worker,
                worker,
                new Programmer("Olga",new DateTime(1998,12,12),50000)
            };
            Console.WriteLine("-------------------------");
            foreach (Person item in workers)
            {
                item.Print();
            }
            

            Programmer pr = null;
            //--- 1 ----------- use cast()
            try
            {
                pr = (Programmer)workers[2];
                pr.DoWork();
                pr.WriteLine();
                pr.WriteLine();
                pr.WriteLine();
                pr.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("----------use as --------------");
            // - 2 ---------------- use as 
            pr = (workers[2] as Programmer)!;
            if (pr != null)
            {
                pr.DoWork();
            }
            else
                Console.WriteLine("Incorrect type");

            // - 3 ---------------- use as and is 
            if (workers[2] is Programmer)
            {
                pr = (workers[2] as Programmer)!;
                pr.DoWork();
            }
            else
                Console.WriteLine("Incorrect type");

            //Practice
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------PRACTICE------------------\n");
            Console.ResetColor();
            Triangle t = new Triangle(3, 4, 5);
            Square s = new Square(4);
            Rhombus r = new Rhombus(5, 3);
            Rectangle rec = new Rectangle(2, 6);


            CompositeFigure comp = new CompositeFigure(t, s, r, rec);

            comp.Print();

            Console.WriteLine("-------------Indexers-------------");
            comp[0].Print();
            Console.WriteLine();
            comp[1].Print();
            Console.WriteLine();
            comp[2].Print();
            Console.WriteLine();
            comp[3].Print();
            




        }
    }
}