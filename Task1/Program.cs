using System;
using System.IO;
using System.Xml.Linq;

namespace Task1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до каталога");
            string path = Console.ReadLine();
            DeleteUnusedFiles(path);
        }

        public static void DeleteUnusedFiles(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                List<string> usedFilePath = new List<string>();

                foreach (string file in files)
                {
                    DateTime dt = File.GetLastAccessTime(file);
                    FileAttributes atr = File.GetAttributes(file);
                    if (dt < (DateTime.Now).AddMinutes(-30))
                    {
                        try
                        {
                            if ((atr & FileAttributes.ReadOnly) != FileAttributes.ReadOnly) File.Delete(file);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Не удалось удалить файл по адресу {0} по причине {1}", file, e);
                        }

                    }
                    else
                    {
                        usedFilePath.Add(file);
                    }
                }

                var dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                    {
                        DeleteUnusedFiles(dir);
                    }
                }
                else
                {
                    if (usedFilePath.Count == 0)
                    {
                        try
                        {
                            Directory.Delete(path);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Не удалось удалить папку по адресу {0} по причине {1}", path, e);
                        }
                    }
                }
            }
            else Console.WriteLine("Путь не найден");
        }
    }
}

