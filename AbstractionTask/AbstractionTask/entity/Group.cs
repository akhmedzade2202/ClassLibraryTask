using System;

namespace AbstractionTask.entity
{
    public class Group
    {
        public string GroupNo { get; private set; }
        public int StudentLimit { get; private set; }
        private Student[] Students;

        public Group(string groupNo, int studentLimit)
        {
            while (!CheckGroupNo(groupNo))
            {
                Console.WriteLine("GroupNo formati duzgun deyil! (Meselen: AB123)");
                Console.Write("Yeniden daxil edin: ");
                groupNo = Console.ReadLine();
            }

            GroupNo = groupNo;

            while (studentLimit < 5 || studentLimit > 18)
            {
                Console.WriteLine("StudentLimit 5 ile 18 arasinda olmalidir!");
                Console.Write("Yeniden daxil edin: ");
                studentLimit = int.Parse(Console.ReadLine());
            }

            StudentLimit = studentLimit;
            Students = new Student[0];
        }

        public bool CheckGroupNo(string groupNo)
        {
            if (string.IsNullOrEmpty(groupNo)) return false;
            if (groupNo.Length != 5 && groupNo.Length != 6) return false;

            string letters = groupNo.Substring(0, groupNo.Length - 3);
            string digits = groupNo.Substring(groupNo.Length - 3);

            if (letters.Length < 2 || letters.Length > 3) return false;
            foreach (char c in letters)
                if (!char.IsUpper(c))
                    return false;

            foreach (char c in digits)
                if (!char.IsDigit(c))
                    return false;

            return true;
        }

        public void AddStudent(Student student)
        {
            if (Students.Length >= StudentLimit)
            {
                Console.WriteLine("Qrup doludur!");
                return;
            }

            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length - 1] = student;
            Console.WriteLine($"{student.FullName} qrupa elave edildi.");
        }

        public Student GetStudent(int id)
        {
            foreach (var s in Students)
            {
                if (s.Id == id)
                    return s;
            }
            return null;
        }

        public Student[] GetAllStudents()
        {
            return Students;
        }
    }
}
