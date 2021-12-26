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
        public static List<string> preferences = new();
        private int _id { get; set; }
        private string _userName { get; set; }
        private int _age;
        private string _password { get; set; }
        private string _country { get; set; }
        private string _preference { get; set; }

        public int ID
        { get { return _id; } }
        public string Password
        { get { return _password; } set { _password = value; } }
        public string Country
        { get { return _country; } }
        public int Age
        { get { return _age; } }
        public string UserName
        { get { return _userName; } set { _userName = value; } }
        public string Preference
        { get { return _preference; } }
        
        public static User CurrUser;

        public User (string username, int age, string password, string country,string preference)
        {
            this._userName = username;
            this._age = age;
            this._password = password;
            this._country = country;
            this._preference = preference;
            _id = Users.Count + 1;
            Users.Add(_id, this);
        }

        public static void CreateUser()
        {
            Console.Clear();
            Console.Write("Please enter desired username: ");
            string username= Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter desired password: ");
            string password = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Please enter your country: ");
           string country = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter your preference: ");
           string preferences = Console.ReadLine();
            Console.Clear();

          
            new User(username,age,password,country,preferences);
            User.preferences.Add(preferences);
            CurrUser = Users.Last().Value;
            Console.WriteLine("Redirecting you to menu, please wait...");
            Methods.Paus(2);
            LoginMenu.Introduction();
          
        }
        public static void TestUser()
        {
            new User("Funky", 28, "Blixten", "Sweden","Horror");
            new User("Guest", 0, "", "","");

        }

    }
}
