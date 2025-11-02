using AbstractionTask.service;
using System;

namespace AbstractionTask.entity
{
    public class Student : IPerson
    {
        private static int _idCounter;
        public int Id { get; }   
        public string FullName { get; set; }
        public double Point { get; set; }

        public Student(string fullname, double point)
        {
            Id = ++_idCounter;
            FullName = fullname;

            while (point < 0 || point > 100)
            {
                Console.WriteLine("Point 0 ile 100 arasinda olmalidir!");
                Console.Write("Yenidən daxil et: ");
                if (!double.TryParse(Console.ReadLine(), out point))
                {
                    point = -1; 
                }
            }

            Point = point;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id}, FullName: {FullName}, Point: {Point}");
        }
    }
}
