using AbstractionTask.entity;

Console.WriteLine("Yeni User yaradin:");
Console.Write("Fullname: ");
string fullname = Console.ReadLine();

Console.Write("Email: ");
string email = Console.ReadLine();

Console.Write("Password: ");
string password = Console.ReadLine();

User user = new User(fullname, email, password);

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Show info");
    Console.WriteLine("2. Create new group");
    Console.Write("Seçim: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        user.ShowInfo();
    }
    else if (choice == "2")
    {
        Console.Write("Group No: ");
        string groupNo = Console.ReadLine();
        Console.Write("Student limit: ");
        int limit = int.Parse(Console.ReadLine());

        Group group = new Group(groupNo, limit);

        while (true)
        {
            Console.WriteLine("\nGroup Menu:");
            Console.WriteLine("1. Show all students");
            Console.WriteLine("2. Get student by id");
            Console.WriteLine("3. Add student");
            Console.WriteLine("0. Quit");
            Console.Write("Seçim: ");
            string groupChoice = Console.ReadLine();

            if (groupChoice == "1")
            {
                var students = group.GetAllStudents();
                if (students.Length == 0)
                {
                    Console.WriteLine("Qrupda hec bir student yoxdur.");
                }
                else
                {
                    Console.WriteLine("\nQrupdaki butun studentler:");
                    foreach (var s in students)
                        s.ShowInfo();
                }
            }
            else if (groupChoice == "2")
            {
                Console.Write("Id daxil edin: ");
                int id = int.Parse(Console.ReadLine());
                var student = group.GetStudent(id);
                if (student == null)
                    Console.WriteLine("Bu ID-li student tapilmadi.");
                else
                    student.ShowInfo();
            }
            else if (groupChoice == "3")
            {
                if (group.GetAllStudents().Length >= group.StudentLimit)
                {
                    Console.WriteLine("Qrup artiq doludur!");
                    continue;
                }

                Console.Write("Fullname: ");
                string sFullname = Console.ReadLine();
                Console.Write("Point: ");
                double sPoint = double.Parse(Console.ReadLine());

                Student student = new Student(sFullname, sPoint);
                group.AddStudent(student);
            }
            else if (groupChoice == "0")
            {
                Console.WriteLine("Qrup menyusundan cixildi.");
                break;
            }
            else
            {
                Console.WriteLine("Yanlis secim!");
            }
        }
    }
    else
    {
        Console.WriteLine("Yanlis secim!");
    }
}
