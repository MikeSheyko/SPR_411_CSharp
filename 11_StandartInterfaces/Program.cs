using System.Collections;

namespace _11_StandartInterfaces
{
    class StudentCard : ICloneable
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Students Card : {Number} . {Series}";
        }
    }
    class Student : IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }//0c147    = 0c147 
        public string LastName { get; set; }//02c58c8c  = 02c58c8c
        public DateTime Birthdate { get; set; }//02/02/2000  = 01.01.2001
        public StudentCard StudentCard { get; set; }//d033699  = d033699

        public object Clone()
        {
            //поверхневе копіювання об*єкта
            Student copy = (Student)this.MemberwiseClone();
            //якщо ви маєте ссилочні типи даних - 
            //то для них потрібно робити глибоке копіювання
            //copy.StudentCard = new StudentCard
            //{
            //    Number = this.StudentCard.Number,
            //    Series = this.StudentCard.Series
            //};
            copy.StudentCard = (StudentCard)this.StudentCard.Clone();
            return copy;
        }

        public int CompareTo(Student? other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        //public int CompareTo(object? obj)
        //{
        //    if (obj is Student)
        //    {
        //        return LastName.CompareTo((obj as Student).LastName);
        //    }
        //    throw new NotImplementedException();
        //}

        public override string ToString()
        {
            return $"Fullname : {FirstName} {LastName}. Birthdate : " +
                $"{Birthdate.ToLongDateString()}. {StudentCard.ToString()}";
        }

    }
    class Auditory : IEnumerable
    {
        //Array
        Student[] students;//null
        public Auditory()
        {
            students = [
              new Student
                {
                     FirstName = "Ivan",
                     LastName = "Popchuk",
                     Birthdate = new DateTime(2000,12,7),
                     StudentCard = new StudentCard { Number = 123456, Series = "AAA" }
                },
                 new Student
                {
                     FirstName = "Olga",
                     LastName = "Oliunuk",
                     Birthdate = new DateTime(2005,12,7),
                     StudentCard = new StudentCard { Number = 111111, Series = "BB" }
                },
                  new Student
                {
                     FirstName = "Mukola",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(1999,8,17),
                     StudentCard = new StudentCard { Number = 222222, Series = "CC" }
                },
                   new Student
                {
                     FirstName = "Mira",
                     LastName = "Polishuk",
                     Birthdate = new DateTime(2002,12,7),
                     StudentCard = new StudentCard { Number = 333333, Series = "DD" }
                },
                    new Student
                {
                     FirstName = "Yura",
                     LastName = "Popchuk",
                     Birthdate = new DateTime(2001,12,7),
                     StudentCard = new StudentCard { Number = 444444, Series = "FF" }
                }
          ];
        }

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Print()
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students, comparer);
        }
    }
    class FirstNameComparer : IComparer<Student>
    {
        //public int Compare(object? x, object? y)
        //{
        //    if (x is Student && y is Student)
        //    {
        //        return (x as Student)!.LastName.CompareTo((y as Student)!.LastName);
        //    }
        //    throw new NotImplementedException();
        //}
        public int Compare(Student? x, Student? y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
    class BirthdateComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birthdate.CompareTo(y.Birthdate);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Auditory auditory = new Auditory();
            //foreach (var student in auditory)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("-----------------Sort Last name-----------");
            //auditory.Sort();
            //foreach (var student in auditory)
            //{
            //    Console.WriteLine(student);
            //}

            //Console.WriteLine("-----------------Sort First name-----------");
            //auditory.Sort(new FirstNameComparer());
            //foreach (var student in auditory)
            //{
            //    Console.WriteLine(student);
            //}

            //Console.WriteLine("-----------------Sort Birthdate-----------");
            //auditory.Sort(new BirthdateComparer());
            //foreach (var student in auditory)
            //{
            //    Console.WriteLine(student);
            //}
            Student student_original = new Student
            {
                FirstName = "Ivan",
                LastName = "Popchuk",
                Birthdate = new DateTime(2000, 12, 7),
                StudentCard = new StudentCard { Number = 123456, Series = "AAA" }
            };


            Student copy = (Student)student_original.Clone();//0x1478   =  0x1478 
            Console.WriteLine("--------Original ----------------");
            Console.WriteLine(student_original);

            Console.WriteLine("--------Copy ----------------");
            Console.WriteLine(copy);
            copy.Birthdate = new DateTime(2025, 1, 1);
            copy.StudentCard.Number = 777777;
            Console.WriteLine();
            Console.WriteLine("--------Original ----------------");
            Console.WriteLine(student_original);

            Console.WriteLine("--------Copy ----------------");
            Console.WriteLine(copy);

        }
    }

}