using System.IO.Pipes;
using System.Reflection;

namespace _04_IntroOOP
{

    /*
     * private (defaukt for all fields)
     * public
     * protected
     * internal - буде видно тільки в межах однієї збірки. Встановлено за замовчуванням для всіх типів (класів, інтерфейсів і т.д.)
     * protected internal   
    */


    
    class Point : Object // : Object - не обов'язково, оскільки всі класи неявно наслідують від Object
    {
        //private:
        //private int number;
        //private string name;
        //private const double PI = 3.14;
        //private readonly int id;

        //public Point()
        //{
        //    id = 10;
        //}

        //void setId(int id)
        //{
        //    this.id = id; // коректно
        //    id = id; // помилка, оскільки id - readonly
        //}



        static int count;
        static Point() //для ініціалізації статичної змінної потрібно створити статичний конструктор
        {
            count = 0;
        }


        public Point() : this(0, 0) { } 
        

        public Point(int x, int y)
        {
            XCoord = x; //setX(x);
            YCoord = y; //setY(y);
            count++;
        }


        public void setX(int newX)
        {
            if (newX > 0)
                _xCoord = newX;
            else
                _xCoord = 0;
        }


        public void setY(int newY)
        {
            if (newY > 0)
                _yCoord = newY;
            else
                _yCoord = 0;
        }


        public int getX() { return _xCoord; }
        public int getY() { return _yCoord; }

        //properties
        //propfull + Tab
        //private string name;

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        //prop auto
        //prop + Tab
        public string Name { get; set; }
        public string Color { get; set; }





        private int _xCoord; //змінні прийнято називати з маленької літери або з підкресленням спереду _xCoord
        public int XCoord // value - ключове слово, яке містить значення, що присвоюється властивості
        {
            get { return _xCoord; }
            set
            {
                if (value > 0)
                    _xCoord = value;
                else
                    _xCoord = 0;
            }
        }

        private int _yCoord;
        public int YCoord
        {
            get { return _yCoord; }
            set
            {
                if (value > 0)
                    _yCoord = value;
                else
                    _yCoord = 0;
            }
        }




        public void Print()
        {
            System.Console.WriteLine($"X: {_xCoord}, Y: {_yCoord}");
        }

        public override string ToString()
        {
            return $"X: {_xCoord}, Y: {_yCoord}";
        }

    }


    internal class DerivedPoint : Point // public inheritance by default
    {
        
    }


    //Practice

    class Freezer
    {
        static string _energyClass;
        static int _compartments;

        static Freezer()
        {
            _energyClass = "A++";
            _compartments = 2;
        }

        private string _brand;
        private string _model;
        private int _modelYear;
        private int _capacity;
        private double _minTemperature;
        private double _maxTemperature;
        




        public Freezer() : this("no brand", "no model", 2000, 1, -40, 10)
        {
        }

        public Freezer(string brand, string model, int modelYear, int capacity, double minTemperature, double maxTemperature)
        {
            Brand = brand;
            Model = model;
            ModelYear = modelYear;
            Capacity = capacity;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }

                
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int ModelYear
        {
            get { return _modelYear; }
            set
            {
                if (value > 1990)
                    _modelYear = value;
                else
                    Console.WriteLine("Error! Model year couldn't be less than 1990!");
            }
        }

        public int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value > 0)
                    _capacity = value;
                else
                    _capacity = 1;
            }
        }

        public double MinTemperature
        {
            get { return _minTemperature; }
            set
            {
                if (value <= 0)
                    _minTemperature = value;
                else
                    _minTemperature = 0;
            }
        }

        public double MaxTemperature
        {
            get { return _maxTemperature; }
            set
            {
                if (value > MinTemperature)
                    _maxTemperature = value;
                else
                    _maxTemperature = MinTemperature + 10;
            }
        }

        public static string EnergyClass
        {
            get { return _energyClass; }
            set { _energyClass = value; }
        }

        public static int DefaultCompartments
        {
            get { return _compartments; }
            set { _compartments = value; }
        }

        public void Print()
        {
            Console.WriteLine("============== Freezer Information ==============");
            Console.WriteLine($"{"Brand:",-35} {_brand}");
            Console.WriteLine($"{"Model:",-35} {_model}");
            Console.WriteLine($"{"Model Year:",-35} {_modelYear}");
            Console.WriteLine($"{"Capacity:",-35} {_capacity} L");
            Console.WriteLine($"{"Temperature Range:",-35} {_minTemperature}°C ... {_maxTemperature}°C");
            Console.WriteLine($"{"Energy Class:",-35} {_energyClass}");
            Console.WriteLine($"{"Default number of compartments:",-35} {_compartments}");
            Console.WriteLine("-------------------------------------------------");
        }


        public override string ToString()
        {
            return $"Brand: {_brand}, Model: {_model}, Capacity: {_capacity} L, " + $"Temperature: {_minTemperature}...{_maxTemperature}°C";
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            //Point @class = new Point(); // створення об'єкту класу Point

            Point point = new Point(74,9);
            point.Print();
            Console.WriteLine(point);
            Console.WriteLine(point.ToString());

            point.setY(-45);
            Console.WriteLine(point.getY());
            Console.WriteLine(point);

            point.XCoord = 150;
            int x = point.XCoord;
            Console.WriteLine(x);
            Console.WriteLine(point);


            //Practice

            Freezer.EnergyClass = "A+";

            Freezer freezer1 = new Freezer();
            freezer1.Print();
            Console.WriteLine();

            Freezer freezer2 = new Freezer("Gorenje", "FH25EAW", 2023, 248, -18, -5);
            freezer2.Print();
            Console.WriteLine();
         
            Freezer freezer3 = new Freezer("INDESIT", "OS 1A 300 H 2", 2024, 316, -20, -10);
            freezer3.Print();
            Console.WriteLine();

                      
            Console.WriteLine(freezer2.ToString());
            Console.WriteLine($"Energy class: {Freezer.EnergyClass}");
            Console.WriteLine($"Default compartments: {Freezer.DefaultCompartments}");
        }





    
    }
}
