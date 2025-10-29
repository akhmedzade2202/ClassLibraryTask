using Encapsulation;
using System;

namespace UserApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];

            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"\n{i + 1}. Istifadeci melumatlarini daxil edin:");

                Console.Write("Fullname: ");
                string fullname = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                string password;
                while (true)
                {
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    User tempUser = new User(email, password);
                    if (tempUser.PasswordChecker(password))
                    {
                        tempUser.Fullname = fullname;
                        users[i] = tempUser;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password is not valid");
                    }
                }
            }

            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n--- MENYU ---");
                Console.WriteLine("1. Show all users");
                Console.WriteLine("2. Get info by id");
                Console.WriteLine("0. Quit");
                Console.Write("Seciminiz: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)  //Muellim burani switch case ile de yaza bilerik
                {
                    Console.WriteLine("\n--- All users ---");
                    for (int i = 0; i < users.Length; i++)
                    {
                        Console.WriteLine(users[i].GetInfo());
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Axtardiginiz ID-ni daxil edin: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool found = false;

                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i].Id == id)
                        {
                            Console.WriteLine(users[i].GetInfo());
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Bu ID-li user tapılmadi.");
                    }
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Proqram sonlandirildi");
                }
                else
                {
                    Console.WriteLine("Yanlıs secim etdiniz!");
                }
            }
        }
    }
}
