using System;
using System.Drawing;
using System.Text;

namespace _02_Array
{

    internal class Program
    {


        static void Main(string[] args)
        {
            #region One Demention Array


            //int[] == array - CSharp
            //-----------------1-----------------
            int[] array = new int[5];
            //int arr[20];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[3]);
            Console.WriteLine(array[4]);

            //-----------------2-----------------
            int[] array2 = new int[10];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = i * 2;
                Console.Write(array2[i] + " ");
            }
            Console.WriteLine();

            //-----------------3-----------------
            //int[] array3 = new int[5] { 1, 2, 3, 4, 5 };
            int[] array3 = [1, 2, 3, 4, 5];
            for (int i = 0; i < array3.Length; i++)
            {
                Console.Write(array3[i] + " ");
            }
            Console.WriteLine();

            //-----------------4-----------------
            int[] array4 = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12 }; // new int[] can be omitted
            for (int i = 0; i < array4.Length; i++)
            {
                Console.Write(array4[i] + " ");
            }
            Console.WriteLine();


            //-----------------5-----------------
            int[] array5 = new int[5];
            for (int i = 0; i < array5.Length; i++)
            {
                Console.Write(array5[i] + " ");
            }
            Console.WriteLine();

            array5[0] = 100;
            array5.SetValue(77, 3);
            //array5.SetValue(55, 5); // IndexOutOfRangeException

            for (int i = 0; i < array5.Length; i++)
            {
                Console.Write(array5[i] + " ");
            }
            Console.WriteLine();

            int a = 5;
            var b = 7; // implicit typing
            float c = 3.33f; // suffix f is required for float literals
            var g = 9.8f;


            foreach (int elem in array5) // read-only
            {
                //elem = 5; readonly
                Console.WriteLine(elem + " ");
            }
            Console.WriteLine();

            #endregion

            #region Double Demention Array

            int[,] arr1 = new int[3, 3]; // 3 rows, 3 columns
            arr1[0, 0] = 1;
            arr1[0, 1] = 2;
            arr1[0, 2] = 3;
            arr1[1, 0] = 4;
            arr1[1, 1] = 5;
            arr1[1, 2] = 6;
            arr1[2, 0] = 7;
            arr1[2, 1] = 8;
            arr1[2, 2] = 9;

            Console.WriteLine($"Length = {arr1.Length}");

            for (int i = 0; i < arr1.GetLength(0); i++) // rows
            {
                for (int j = 0; j < arr1.GetLength(1); j++) // columns
                {
                    Console.Write(arr1[i, j] + " ");
                }
                Console.WriteLine();
            }



            //-----------------2-----------------
            int[,] arr2 = new int[5, 7];

            for (int i = 0; i < arr2.GetLength(0); i++) // rows
            {
                for (int j = 0; j < arr2.GetLength(1); j++) // columns
                {
                    arr2[i, j] = i * j + 1;
                }
                Console.WriteLine();
            }


            for (int i = 0; i <= arr2.GetUpperBound(0); i++) // 4 index
            {
                for (int j = 0; j <= arr2.GetUpperBound(1); j++) // 6 index
                {
                    Console.Write($"{arr2[i, j],4}");
                }
                Console.WriteLine();
            }

            //-----------------3-----------------
            int[,] arr4 =
            {
                  {1,2,3},
                  {4,5,6},
                  {7,8,9}
            };
            Console.WriteLine(arr4.Length);
            Console.WriteLine(arr4); //Отримуємо тип даних
            Console.WriteLine(arr4.ToString()); //Отримуємо тип даних
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{arr4[i, j]} ");
                }
                Console.WriteLine();
            }

            #endregion


            #region _3D Array


            /*
              //1
            int[,,] array = new int[3, 3, 3];

            array[0, 0, 0] = 1;
            array[0, 0, 1] = 2;
            array[0, 0, 2] = 3;
            array[0, 1, 0] = 4;
            array[0, 1, 1] = 5;
            array[0, 1, 2] = 6;
            array[0, 2, 0] = 7;
            array[0, 2, 1] = 8;
            array[0, 2, 2] = 9;

            array[1, 0, 0] = 1;
            array[1, 0, 1] = 2;
            array[1, 0, 2] = 3;
            array[1, 1, 0] = 4;
            array[1, 1, 1] = 5;
            array[1, 1, 2] = 6;
            array[1, 2, 0] = 7;
            array[1, 2, 1] = 8;
            array[1, 2, 2] = 9;

            array[2, 0, 0] = 1;
            array[2, 0, 1] = 2;
            array[2, 0, 2] = 3;
            array[2, 1, 0] = 4;
            array[2, 1, 1] = 5;
            array[2, 1, 2] = 6;
            array[2, 2, 0] = 7;
            array[2, 2, 1] = 8;
            array[2, 2, 2] = 9;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write("{0} ", array[i, j, k]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }


            //2
            int[,,] array2 =
            {
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                },
                { { 1, 2, 3 }, { 4, 5, 6 }, {7, 8, 9} },
                { { 1, 2, 3 }, { 4, 5, 6 }, {7, 8, 9} }
            };


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write("{0} ", array2[i, j, k]);
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
             */
            #endregion

            #region _4D_Arrays
            /*
             int[,,,] array = new int[2, 2, 2, 2];

            array[0, 0, 0, 0] = 0x0;
            array[0, 0, 0, 1] = 0x1;
            array[0, 0, 1, 0] = 0x2;
            array[0, 0, 1, 1] = 0x3;

            array[0, 1, 0, 0] = 0x4;
            array[0, 1, 0, 1] = 0x5;
            array[0, 1, 1, 0] = 0x6;
            array[0, 1, 1, 1] = 0x7;

            array[1, 0, 0, 0] = 0x8;
            array[1, 0, 0, 1] = 0x9;
            array[1, 0, 1, 0] = 0xA;
            array[1, 0, 1, 1] = 0xB;

            array[1, 1, 0, 0] = 0xC;
            array[1, 1, 0, 1] = 0xD;
            array[1, 1, 1, 0] = 0xE;
            array[1, 1, 1, 1] = 0xF;


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < 2; l++)
                        {
                            Console.Write("{0:X} ", array[i, j, k, l]);
                        }
                        Console.Write('\n');
                    }
                    Console.WriteLine();
                }
                Console.Write("\n");
            }

            //2
            int[,,,] array2 =
             {
              {
                { { 0x0, 0x1 }, {0x2, 0x3 } },
                { { 0x4, 0x5 }, {0x6, 0x7 } }
              },
              {
                { { 0x8, 0x9 }, {0xA, 0xB } },
                { { 0xC, 0xD }, {0xE, 0xF } }
              }
            };


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < 2; l++)
                        {
                            Console.Write("{0:X} ", array2[i, j, k, l]);
                        }
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
            */
            #endregion


            #region Jagged_array

            // зубчастий масив
            int[][] jagged = new int[3][];

            jagged[0] = new int[8]; //{ 1, 2 };
            jagged[1] = new int[3];// { 1, 2, 3, 4, 5 };
            jagged[2] = new int[4]; //{ 1, 2, 3 };

            Console.WriteLine(jagged.Length);

            // перебор с помощью цикла for
            for (int i = 0; i < jagged.Length; ++i)//3
            {
                for (int j = 0; j < jagged[i].Length; ++j)
                {
                    jagged[i][j] = new Random().Next(20);
                    // Console.Write($"{i};{j}={     jagged[i][j]     }  ");
                    Console.Write($" {jagged[i][j]}  ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
            Console.ReadKey();

            foreach (int[] item in jagged)
            {
                foreach (int i in item)
                {
                    Console.Write(i + "\t");
                }
                Console.WriteLine();
            }

            #endregion


            #region ArrayMethods


            Console.OutputEncoding = Encoding.UTF8;

            int[] myArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            PrintArr("Масив myArr1", myArr1);


            int[] tempArr = (int[])myArr1.Clone(); // shallow copy
            PrintArr("Clone", tempArr);

            //_ = myArr1.Reverse();// cw        
            Array.Reverse(myArr1, 5, 3);
            PrintArr("Масив myArr1 післе реверсу", myArr1);
            myArr1 = tempArr;
            PrintArr("Масив myArr1 післе відновлення", myArr1);
            int[] myArr2 = new int[20];
            PrintArr("Масив myArr2 до копіювання", myArr2);
            myArr1.CopyTo(myArr2, 10);
            PrintArr("Масив myArr2 післе копіювання", myArr2);
            Console.WriteLine(myArr2.Length);
            Console.WriteLine(myArr2.GetLength(0));
            Array.Clear(myArr2, 8, 3);
            PrintArr("Масив myArr2 післе очистки: ", myArr2);
            Array.Resize(ref myArr2, 5);
            PrintArr("Масив myArr2 післе зміни розміру:", myArr2);
            myArr2 = new[] { 1, 5, 3, 2, 8, 9, 6, 10, 7, 4 };
            PrintArr("Несортований масив myArr2: ", myArr2);
            Array.Sort(myArr2);
            PrintArr("Масив myArr2 післе сортування: ", myArr2);
            Console.WriteLine(Array.IndexOf(myArr1, 5));
            Console.WriteLine("Число 5 знаходится в масиве на " +
                Array.BinarySearch(myArr2, 5) + " позиції");

            Console.WriteLine("Максимальный елемент в масиві myArr2: " + myArr2.Max());
            Console.WriteLine("Мінимальный елемент в масиві myArr2: " + myArr2.Min());
            Console.WriteLine("Середнє арифметичне елементів myArr2: " +
                myArr2.Average());

            Console.WriteLine("Кількість вимірів масиву myArr3: " + myArr2.Rank);
            int[,] myArr3 = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine("Количество измерений массива myArr3: " + myArr3.Rank);

            #endregion

            #region MethodsWithArray

            int[] myArray = { 1, 2, 3, 4, 5 };

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine();
            myArray = ModifyArray(myArray, 5);

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + ", ");
            }

            Console.ReadKey();

            int[] arr10 = { 11, 12, 13, 14, 15, 17, 18, 19, 20 };
            ShowArray(100, arr10);
            ShowArrayNew(10, 20, 30, arr10);
            //params == initializer_list
            ShowArrayNew(10, 20, 30, 44, 55, 66, 77, 88, 99, 100, 101, 102, 14, 12, 13, 6);

            Random random = new Random();
            double[] arr20 = new double[10];
            for (int i = 0; i < arr20.Length; i++)
            {
                arr20[i] = Math.Round(random.Next(100) + random.NextDouble(), 2);
                Console.WriteLine(arr20[i]);
            }


            //Practice
            //Task 1
            Console.WriteLine();
            int[] array_12 = new int[30];
            for (int i = 0; i < array_12.Length; i++)
            {
                array_12[i] = random.Next(1, 165);
            }

            ShowArray(1, array_12);
            int evenNumbers = 0;
            int oddNumbers = 0;

            for (int i = 0; i < array_12.Length; i++)
            {
                if (array_12[i] % 2 == 0)
                    evenNumbers++;
                else
                    oddNumbers++;
            }

            int uniqueNumbers = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j && array[i] == array[j])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                    uniqueNumbers++;
            }

            Console.WriteLine($"Even numbers: {evenNumbers}");
            Console.WriteLine($"Odd numbers: {oddNumbers}");
            Console.WriteLine($"Unique numbers: {uniqueNumbers}");
            Console.WriteLine();

            //Task 2

            int[] array_13 = new int[40];
            for (int i = 0; i < array_13.Length; i++)
            {
                array_13[i] = random.Next(-50, 165);
            }
            ShowArray(2, array_13);

            Console.Write("Enter number: ");
            int userValue = int.Parse(Console.ReadLine()!);

            int count = 0;
            for (int i = 0; i < array_13.Length; i++)
            {
                if (array_13[i] < userValue)
                {
                    count++;
                }
            }

            Console.WriteLine($"Numbers less than {userValue} : {count}");
            Console.WriteLine();


            //Task 3
            double[] A = new double[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Enter 5 numbers for array 'A': ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Number {i+1} = ");
                A[i] = double.Parse(Console.ReadLine()!);
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = Math.Round(random.Next(100) + random.NextDouble(), 2);
                }
            }

            Console.Write("Array 'A': ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nArray 'B': ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j],-8}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            double max = A[0];
            double min = A[0];
            double sum = 0;
            double product = 1;

            foreach (double num in A)
            {
                if (num > max) max = num;
                if (num < min) min = num;
                sum += num;
                product *= num;
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double num = B[i, j];
                    if (num > max) max = num;
                    if (num < min) min = num;
                    sum += num;
                    product *= num;
                }
            }
                        
            double evenSumA = 0;
            foreach (double num in A)
            {
                if (num % 2 == 0)
                {
                    evenSumA += num;
                }
            }

            double oddColSumB = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (j % 2 != 0)
                    {
                        oddColSumB += B[i, j];
                    }
                }
            }

            Console.WriteLine($"Max number in arrays: {max}");
            Console.WriteLine($"Min number in arrays: {min}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Sum of even numbers in A: {evenSumA}");
            Console.WriteLine($"Sum of odd-indexed columns in B: {oddColSumB}");
           








            #endregion

        }
        static int[] ModifyArray(int[] array, int modifier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //array[i] = array[i] * modifier;
                array[i] *= modifier;
            }

            return array;
        }
        static void ShowArray(int num, int[] array)
        {
            Console.WriteLine("Number of arr : " + num);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        static void ShowArrayNew(int num, int a, int b, params int[] array)
        {
            Console.WriteLine("Number of arr : " + num);
            Console.WriteLine("a of arr : " + a);
            Console.WriteLine("b of arr : " + b);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

        static void PrintArr(string text, int[] arr)
        {
            Console.Write(text + ": ");
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }


        












    }
}
