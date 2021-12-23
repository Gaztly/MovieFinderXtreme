using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    class LoginMenu
    {
        public static int Introduction()
        {
            Console.WriteLine("Welcome To Snäll's Movie Finder Xtreme, peasant\n You may now choose how to continue\n1.Login\n2.Continue as guest\n3.Create Account");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        int choice = Introduction();
         public static void Menu(int choice)
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
                        MainMenu.Mains();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
      

        }

        public static void LoggingIn ()
        {
            while (true)
            { 
            Console.WriteLine("Please enter your Username: ");
            string input = Console.ReadLine();
            if (input== User.CurrUser.UserName)
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




        }

    }
}
