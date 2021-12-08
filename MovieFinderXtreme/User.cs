using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
     class User
    {
        string Username { get; set; }
        int Age { get; set; }
        string Password { get; set; }
        string Country { get; set; }

        public User (string username, int age, string password, string country)
        {
            this.Username = username;
            this.Age = age;
            this.Password = password;
            this.Country = country;
        }
        public static void CreateUser()
        {
            Console.Clear();
            Console.Write("Please enter desired username: ");
            string Username = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter desired password: ");
            string password = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter your country: ");
            string country = Console.ReadLine();
        }
    }
}
