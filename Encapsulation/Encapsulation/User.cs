using System;

namespace Encapsulation
{
    internal class User
    {
        private static int _idCounter = 0;
        private int _id;
        private string _fullname;
        private string _email;
        private string _password;
        private byte _age;

        public int Id
        {
            get { return _id; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _fullname = value;
                }
                else
                {
                    Console.WriteLine("Fullname bos ola bilmez!");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Contains("@") && value.Contains("."))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine("Email duzgun formatda deyil!");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
                else
                {
                    Console.WriteLine("Sifre teleblere cavab vermir!");
                }
            }
        }

        public byte Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public User(string email, string password)
        {
            _idCounter++;
            _id = _idCounter;

            _email = email;
            _password = password;
        }

        public bool PasswordChecker(string password)
        {
            if (password.Length < 8) return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }

        public string GetInfo()
        {
            return $"ID: {Id}, Fullname: {Fullname}, Email: {Email}";
        }
    }
}
