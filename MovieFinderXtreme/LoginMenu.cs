using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    public class LoginMenu
    {
        public static int Introduction()
        {
            Methods.Title("Movie Finder Xtreme");

            Console.WriteLine(@"Welcome To Snäll's Movie Finder Xtreme, peasant!
You may now choose how to continue
1.Login
2.Continue as guest
3.Create Account");


            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        int choice = Introduction();
         public static async Task Menu(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        Methods.Lines();
                        LoggingIn();
                        break;
                    }
                case 2:
                    {
                     await MainMenu.Mains();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        User.CreateUser();
                        Console.WriteLine("You will now be sent to the login page.");
                        LoggingIn();
                        break;
                    }
            }
      

        }

        public static void LoggingIn ()
        {
            while (true)
            {
                User.CurrUser = User.Users[1];
                Console.WriteLine("Please enter your Username: ");
                string input = Console.ReadLine();
                if (User.CurrUser.UserName == input)
            {
                Console.Clear();
                Console.WriteLine("Username Confirmed!");
                Methods.Lines();
                Methods.Paus(2);
                break;
            }
            else
            {
                Console.WriteLine("Password Incorrect! Try again");
                return;
            }

            }
            while (true)
            {

            Console.Clear();
            Console.WriteLine("You may now enter your Password: ");
            Methods.Lines();
            string pass = Console.ReadLine();
            if(pass == User.CurrUser.Password)
            {
                Console.Clear();
                Console.WriteLine("Password Confirmed!\nYou will now be signed in");
                Methods.Paus(3);
                break;
            }
            else
            {
                    Console.WriteLine("Incorrect password, try again!");
                    return;
            }
            }

            MainMenu.Mains();
        }

    }
}
