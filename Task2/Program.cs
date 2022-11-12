using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Program
    {
        private static long size = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до каталога");
            string path = Console.ReadLine();
            Console.WriteLine("Размер каталога - {0}", getFolderVolume(path));
        }

        public static long getFolderVolume(string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                
                foreach (string file in files)
                {
                    FileInfo fl = new FileInfo(file);
                    size = size + fl.Length;
                }

                var dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                    {
                        try
                        {
                            getFolderVolume(dir);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Не удалось вычислить размер каталога по причине {0}", e);
                        }
                    }
                }
                return size;
            }
            else
            {
                Console.WriteLine("Путь не найден");
                return 0;
            } 
        }

    }
    
}
