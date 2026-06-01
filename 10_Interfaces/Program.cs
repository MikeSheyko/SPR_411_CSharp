namespace _10_Interfaces
{
    //implementation
    interface IWorker
    {
        //public 
        bool IsWorking { get; }//empty properties
        void Print();//empty methods
        event EventHandler Working;
    }
    class Animal
    {
        // private

    }
    class Lion : Animal
    {

    }
    abstract class Human// :Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public override string ToString()
        {
            return $"Fullname : {FirstName} {LastName}. " +
                $"Birthdate : {Birthdate.ToShortDateString()}\n";
        }

    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"Position : {Position}. Salary : {Salary}";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }//false
        string Work();//empty
    }
    interface IManager
    {
        List<IWorkable> ListOfWorker { get; set; }//null
        void Organize();//empty
        void MakeBudgect();//empty
        void Control();//empty
    }
    class Director : Employee, IManager//implement/realize
    {
        public List<IWorkable> ListOfWorker { get; set; }//null

        public void Control()
        {
            Console.WriteLine("I am director! I control all work");
        }

        public void MakeBudgect()
        {
            Console.WriteLine("I count money!!!");
        }

        public void Organize()
        {
            Console.WriteLine("I organize work");
        }
    }
    class Seller : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "I selling product!";
        }
    }
    class Storekeeper : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "Organize product store";
        }
    }
    class Administrator : Employee, IManager, IWorkable
    {
        public List<IWorkable> ListOfWorker { get; set; }

        public bool IsWorking => true;

        public void Control()
        {
            Console.WriteLine("I am manager. I control work");
        }

        public void MakeBudgect()
        {
            Console.WriteLine("I have many money !!!!!!Xaxaxaxaxa");
        }

        public void Organize()
        {
            Console.WriteLine("I am manager. I organize work!");
        }

        public string Work()
        {
            return "I do my work((((((";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Director director = new Director()//Human, Emplyee, IManager
            IManager director = new Director()//interface references
            {
                FirstName = "Ivan",
                LastName = "Polishchuk",
                Birthdate = new DateTime(1995, 5, 14),
                Position = "Director",
                Salary = 35000
            };

            //Seller seller = new Seller()
            IWorkable seller = new Seller()
            {
                FirstName = "Olga",
                LastName = "Ivanchul",
                Birthdate = new DateTime(2005, 5, 14),
                Position = "Seller",
                Salary = 8300
            };
            //Console.WriteLine(seller.Salary);
            //seller.Salary = 40000;
            //Console.WriteLine(seller.Salary);
            Console.WriteLine(seller.Work()); ;

            // is as
            if (seller is Seller)
            {
                Console.WriteLine($"Seller salary : {(seller as Seller)!.Salary}");
            }

            director.ListOfWorker = new List<IWorkable>
            {
                seller,
                new Seller()
            {
                FirstName = "Katerina",
                LastName = "Ivanchul",
                Birthdate = new DateTime(2005, 5, 14),
                Position = "Seller",
                Salary = 9300
            },
                new Storekeeper()
            {
                FirstName = "Oleg",
                LastName = "Popchuk",
                Birthdate = new DateTime(1990, 5, 14),
                Position = "Storekeeper",
                Salary = 8300
            }

            };

            foreach (var item in director.ListOfWorker)
            {
                if (item is Seller)
                    Console.WriteLine((item as Seller)!.Work());
                if (item is Storekeeper)
                    Console.WriteLine((item as Storekeeper)!.Work());
            }

            //Multiple Interfaces
            Administrator admin = new Administrator();//admin = 

            IWorkable worker = admin;
            Console.WriteLine(worker.Work()); ;
            Console.WriteLine(worker.IsWorking);

            IManager manager = admin;
            manager.Organize();
            manager.Control();
            manager.MakeBudgect();

        }
    }
}