using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    class User

    {
        public static Dictionary<int, User> Users = new();
        private string _preferences;
        private int _id;
        private string _userName;
        private int _age;
        private string _password { get; set; }
        private string _country { get; set; }
      
        public string Password
        { get { return _password; } }
        public string Country
        { get { return _country; } }
        public string Preferences
        { get { return _preferences; } }
        public int Age
        { get { return _age; } }
        public string UserName
        { get { return _userName; } }

        public User (string username, int age, string password, string country,string preferences)
        {
            this._userName = username;
            this._age = age;
            this._password = password;
            this._country = country;
            this._preferences = preferences;
            _id = Users.Count + 1;
            Users.Add(_id, this);
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
            Console.Clear();
            Console.Write("Please select your preferences: ");
            string preferences = Console.ReadLine();
        }
    }
}
