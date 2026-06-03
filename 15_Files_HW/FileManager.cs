using System;
using System.Collections.Generic;
using System.Text;

namespace _15_Files_HW
{
    public class FileManager
    {
        private string rootPath;
        private string currentPath;
        private int currentPos;

        private Stack<string> history = new Stack<string>();

        public FileManager()
        {
            rootPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            currentPath = rootPath;
            currentPos = 0;
        }

        public void Start()
        {
            Update();
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;

                int total =
                    GetDirectories().Count + GetFiles().Count;

                if (key == ConsoleKey.UpArrow &&
                    currentPos > 0)
                {
                    currentPos--;
                }
                else if (key == ConsoleKey.DownArrow &&
                         currentPos < total - 1)
                {
                    currentPos++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Open();
                }
                else if (key == ConsoleKey.Backspace)
                {
                    Back();
                }
                else if (key == ConsoleKey.Delete)
                {
                    Delete();
                }

                Update();

            } while (key != ConsoleKey.Escape);
        }

        private void Update()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Current path: {currentPath}");
            Console.WriteLine();
            Console.ResetColor();

            ShowItems();

            Console.WriteLine();
            Console.WriteLine("↑ ↓ - Navigation");
            Console.WriteLine("Enter - Open");
            Console.WriteLine("Backspace - Back");
            Console.WriteLine("Delete - Delete");
            Console.WriteLine("Esc - Exit");
        }

        public void ShowItems()
        {
            var dirs = GetDirectories();
            var files = GetFiles();

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < dirs.Count; i++)
            {
                string symbol = (i == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}[DIR] {dirs[i].Name}");
            }

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < files.Count; i++)
            {
                string symbol = (i + dirs.Count == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}[FILE] {files[i].Name}");
            }

            Console.ResetColor();
        }

        private void Open()
        {
            var dirs = GetDirectories();
            var files = GetFiles();

            if (currentPos < dirs.Count)
            {
                history.Push(currentPath);
                currentPath = dirs[currentPos].FullName;
                currentPos = 0;
            }
            else
            {
                int fileIndex = currentPos - dirs.Count;
                OpenFile(files[fileIndex]);
            }
        }

        private void OpenFile(FileInfo file)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(file.FullName);
            Console.WriteLine();

            Console.ResetColor();

            try
            {
                string text = File.ReadAllText(file.FullName);

                Console.WriteLine(text);
            }
            catch
            {
                Console.WriteLine("Cannot display file content");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }

        private void Back()
        {
            if (history.Count > 0)
            {
                currentPath = history.Pop();
                currentPos = 0;
            }
        }

        private void Delete()
        {
            var dirs = GetDirectories();
            var files = GetFiles();

            try
            {
                if (currentPos < dirs.Count)
                {
                    Directory.Delete(dirs[currentPos].FullName, true);
                }
                else
                {
                    int fileIndex = currentPos - dirs.Count;
                    File.Delete(files[fileIndex].FullName);
                }

                currentPos = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public List<DirectoryInfo> GetDirectories()
        {
            List<DirectoryInfo> result = new List<DirectoryInfo>();

            try
            {
                string[] dirs = Directory.GetDirectories(currentPath);

                foreach (string dir in dirs)
                {
                    result.Add(new DirectoryInfo(dir));
                }
            }
            catch
            {
            }

            return result;
        }

        public List<FileInfo> GetFiles()
        {
            List<FileInfo> result = new List<FileInfo>();

            try
            {
                string[] files = Directory.GetFiles(currentPath);

                foreach (string file in files)
                {
                    result.Add(new FileInfo(file));
                }
            }
            catch
            {
            }

            return result;
        }
    }
}
