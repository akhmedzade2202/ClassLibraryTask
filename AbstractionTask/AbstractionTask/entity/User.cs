using AbstractionTask.service;
using System;

namespace AbstractionTask.entity
{
    public class User : Account, IPerson
    {
        private static int _idCounter;
        public int Id { get; }
        public string FullName { get; set; }
        public string Email { get; set; }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                while (!PasswordChecker(value))
                {
                    Console.WriteLine("\n Sifre teleblere uygun deyil!");
                    Console.WriteLine("Sertler:");
                    Console.WriteLine("- Minimum 8 simvol");
                    Console.WriteLine("- En az 1 boyuk herf");
                    Console.WriteLine("- En az 1 kicik herf");
                    Console.WriteLine("- En az 1 reqem");
                    Console.Write("\nYeni sifre daxil edin: ");
                    value = Console.ReadLine();
                }
                _password = value;
            }
        }

        public User(string fullname, string email, string password)
        {
            Id = ++_idCounter;
            FullName = fullname;
            Email = email;
            Password = password;
        }

        public override bool PasswordChecker(string password)
        {
            bool hasUpper = false, hasLower = false, hasDigit = false;

            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\nİstifadeci melumatlari:");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"FullName: {FullName}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
