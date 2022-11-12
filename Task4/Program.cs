using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students;
            string path = @"C:\Store\Students.dat";
            BinaryFormatter frt = new BinaryFormatter();

            using (var fs = new FileStream(path, FileMode.Open))
            {
               students = (Student[])frt.Deserialize(fs);                
            }

            string pathToDir = @"C:\Users\xiaomi\Desktop\Students";
            DirectoryInfo dir = Directory.CreateDirectory(pathToDir);

            foreach (Student student in students)
            {
                string pathToFile = pathToDir + '\\' + student.Group + ".txt";
                FileInfo fi = new FileInfo(pathToFile);
                if (!fi.Exists)
                {
                    //fi.Create();
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine(student.Name + ", " + student.DateOfBirth);                        
                    }

                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(pathToFile))
                    {
                        sw.WriteLine(student.Name + ", " + student.DateOfBirth);
                    }
                }
            }
        }

    }
    [Serializable]
    public class Student
    {
        public String name; 
        public String group;
        public DateTime dateOfBirth;

        public String Name { get; set; }
        public String Group { get; set; }
        public DateTime DateOfBirth { get; set; }


        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}
