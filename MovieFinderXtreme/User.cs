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
        public static List <string> preferences= new ();
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
        { get { return _age; }  }
        public string UserName
        { get { return _userName; } }

        public static User CurrUser;

        public User (string username, int age, string password, string country)
        {
            this._userName = username;
            this._age = age;
            this._password = password;
            this._country = country;
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
            Console.WriteLine("Please enter your age: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Please enter your country: ");
            string country = Console.ReadLine();
            Console.Clear();
            Console.Write("Please select your preferences: ");
            string preferences = Console.ReadLine();

            int i = 0;
            i++;
            CurrUser = User.Users[i];
            User user = new User(Username, Age, password, country);
        }
        

        public static void TestUser()
        {
            new User("Funky", 28, "Blixten", "Sweden");
        }

    }
}
