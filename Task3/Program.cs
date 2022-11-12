using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;



namespace Task3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до каталога");
            string path = Console.ReadLine();
            long currenctSize = Task2.Program.getFolderVolume(path);
            Console.WriteLine("Исходный размер папки: {0}", currenctSize);
            Task1.Program.DeleteUnusedFiles(path);
            long newSize = Task2.Program.getFolderVolume(path);
            Console.WriteLine("Освобождено: {0}", newSize - currenctSize);
            Console.WriteLine("Текущий размер папки: {0}", newSize);
        }
    }
}
