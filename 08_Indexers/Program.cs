using System.Reflection;

namespace _08_Indexers
{

    class Laptop
    {
        public string Model { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"Model: {Model}, Price: {Price}";
        }

        

    }

    class Shop
    {
        Laptop[] laptops;
        public Shop(int size) // size = 5
        {
            laptops = new Laptop[size];
        }

        public int Length
        {
            get { return laptops.Length; }
        }

        public void SetLaptop(Laptop laptop, int index) //index = -100
        {
            if (index >= 0 && index < laptops.Length)
            {
                laptops[index] = laptop;
            }
            else 
            { 
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        public Laptop GetLaptop(int index) //index = -100
        {
            if (index >= 0 && index < laptops.Length)
            {
                return laptops[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        // Indexers
        public Laptop this[int index] //Laptop = value
        {
            get
            {
                if (index >= 0 && index < laptops.Length)
                {
                    return laptops[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
            set
            {
                if (index >= 0 && index < laptops.Length)
                {
                    laptops[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }

        public Laptop this[string model]
        {
            get
            {
                foreach (var laptop in laptops)
                {
                    if (laptop != null && laptop.Model == model)
                    {
                        return laptop;
                    }
                }
                return null;
            }

            set //нелогічно робити сеттер за моделлю, але для прикладу зробимо
            {
                for (int i = 0; i < laptops.Length; i++)
                {
                    if (laptops[i] != null && laptops[i].Model == model)
                    {
                        laptops[i] = value;
                        break;
                    }
                }
                //readonly indexer
                //foreach (var l in laptops)
                //{
                //    if (l.Model == model)
                //        l = value;
                //    break;
                //}
            }

        }

        private int FindByPrice(double price)
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i] != null && laptops[i].Price == price)
                {
                    return i;
                }
            }
            return -1;
        }

        public Laptop this[double price]
        {
            get
            {
                int index = FindByPrice(price);
                if (index != -1)
                {
                    return laptops[index];
                }
                throw new Exception("Incorrect price");
            }

            set
            {
                int index = FindByPrice(price);
                if (index != -1)
                {
                    this[index] = value;
                }
                
            }

        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {

            Shop shop = new Shop(3);
            shop.SetLaptop(new Laptop() { Model = "HP", Price = 25000 }, 0);
            var laptop = shop.GetLaptop(0);
            Console.WriteLine(laptop);

            shop[1] = new Laptop() { Model = "Dell", Price = 30000 };
            shop[1] = new Laptop() { Model = "Asus", Price = 10000 };
            Console.WriteLine(shop[1]); //get

            try
            {
                for (int i = 0; i < shop.Length + 1; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Index is out of range.");
            }



            Console.WriteLine("--------------[string model]--------------");
            shop["Asus"] = new Laptop() { Model = "MacBook", Price = 1220000 };

            Console.WriteLine(shop["Asus"]);
            Console.WriteLine(shop["MacBook"]);


            Console.WriteLine("--------------[string price]--------------");
            shop[1220000.0] = new Laptop() { Model = "MacBook Pro", Price = 2220000 };
            //Console.WriteLine(shop[1220000.0]);
            Console.WriteLine(shop[2220000.0]);


        }
    }
}
