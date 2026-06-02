using System.Text;

namespace _13_Generic_HW
{

    public class EnglishUkrainianDictionary
    {
        private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        public void AddWord(string word, List<string> translations)
        {
            if (!dict.ContainsKey(word))
            {
                dict[word] = translations;
                Console.WriteLine("Added");
            }
            else
            {
                Console.WriteLine("Word exists");
            }
        }

        public void RemoveWord(string word)
        {
            if (dict.Remove(word))
                Console.WriteLine("Deleted");
            else
                Console.WriteLine("Not found");
        }

        public void RemoveTranslation(string word, string translation)
        {
            if (dict.ContainsKey(word))
            {
                dict[word].Remove(translation);

                if (dict[word].Count == 0)
                    dict.Remove(word);

                Console.WriteLine("Translation removed");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public void EditWord(string oldWord, string newWord)
        {
            if (dict.ContainsKey(oldWord))
            {
                dict[newWord] = dict[oldWord];
                dict.Remove(oldWord);

                Console.WriteLine("Word changed");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public void EditTranslation(string word, string oldTr, string newTr)
        {
            if (dict.ContainsKey(word))
            {
                int index = dict[word].IndexOf(oldTr);

                if (index != -1)
                {
                    dict[word][index] = newTr;
                    Console.WriteLine("Translation changed");
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }

        public void ShowAll()
        {
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " - " + string.Join(", ", item.Value));
            }
        }

        public void Find(string word)
        {
            if (dict.ContainsKey(word))
                Console.WriteLine(word + " - " + string.Join(", ", dict[word]));
            else
                Console.WriteLine("Not found");
        }
    }


    internal class Program
    {
        static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        static void Main(string[] args)
        {

            //Swap 
            int a = 18, b = 16;

            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}");

            string s1 = "Hello";
            string s2 = "World";

            Console.WriteLine();
            Console.WriteLine($"Before swap: s1 = {s1}, s2 = {s2}");
            Swap(ref s1, ref s2);
            Console.WriteLine($"After swap: s1 = {s1}, s2 = {s2}");

            //Dictionary
            EnglishUkrainianDictionary dict = new EnglishUkrainianDictionary();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-----Dictionary-----");
                Console.WriteLine("1 - Add");
                Console.WriteLine("2 - Remove word");
                Console.WriteLine("3 - Remove translation");
                Console.WriteLine("4 - Edit word");
                Console.WriteLine("5 - Edit translation");
                Console.WriteLine("6 - Find");
                Console.WriteLine("7 - Show all");
                Console.WriteLine("0 - Exit");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                if (choice == "1")
                {
                    Console.Write("Word: ");
                    string word = Console.ReadLine();

                    Console.Write("Translations (comma): ");
                    string input = Console.ReadLine();

                    string[] parts = input.Split(',');

                    List<string> list = new List<string>();

                    foreach (string p in parts)
                    {
                        string t = p.Trim();
                        if (t != "")
                            list.Add(t);
                    }

                    dict.AddWord(word, list);
                }

                else if (choice == "2")
                {
                    Console.Write("Word: ");
                    dict.RemoveWord(Console.ReadLine());
                }

                else if (choice == "3")
                {
                    Console.Write("Word: ");
                    string w = Console.ReadLine();

                    Console.Write("Translation: ");
                    string t = Console.ReadLine();

                    dict.RemoveTranslation(w, t);
                }

                else if (choice == "4")
                {
                    Console.Write("Old word: ");
                    string oldW = Console.ReadLine();

                    Console.Write("New word: ");
                    string newW = Console.ReadLine();

                    dict.EditWord(oldW, newW);
                }

                else if (choice == "5")
                {
                    Console.Write("Word: ");
                    string w = Console.ReadLine();

                    Console.Write("Old translation: ");
                    string ot = Console.ReadLine();

                    Console.Write("New translation: ");
                    string nt = Console.ReadLine();

                    dict.EditTranslation(w, ot, nt);
                }

                else if (choice == "6")
                {
                    Console.Write("Word: ");
                    dict.Find(Console.ReadLine());
                }

                else if (choice == "7")
                {
                    dict.ShowAll();
                }
            }
        }
    }
}
