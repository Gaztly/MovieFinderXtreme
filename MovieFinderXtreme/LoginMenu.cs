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
            while(true)
            {

            Methods.Title("Movie Finder Xtreme");

            Console.WriteLine(@"Welcome To Snäll's Movie Finder Xtreme, peasant!
You may now choose how to continue.

1.Login
2.Continue as guest
3.Create Account
4.Exit program");
            try
            {

            int choice = Convert.ToInt32(Console.ReadLine());
             return choice;
            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("You really did NOT understand the assignment, try again....");
                    continue;
            }
            }
        }
       int choice = Introduction();

        public static async Task Menu(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        Methods.Lines();
                       await LoggingIn();
                        break;
                    }
                case 2:
        
                    {
                        User.CurrUser = User.Users[2];
                     await MainMenu.Mains();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        User.CreateUser();
                        Console.WriteLine("You will now be sent to the login page.");
                      await  LoggingIn();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Exiting program...");
                        Methods.Paus(2);
                        break;
                    }
            }
            
        }

        public static async Task LoggingIn ()
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
                Console.WriteLine("Username Incorrect! Try again");
                Methods.Lines();
                continue;
            }

            }
            while (true)
            {
            Console.WriteLine("You may now enter your Password: ");
            Methods.Lines();
            string pass = Console.ReadLine();
            if(pass == User.CurrUser.Password)
            {
                Console.Clear();
                Console.WriteLine("Password Confirmed!");
                Methods.Lines();
                Console.WriteLine("You will now be signed in...");
                Methods.Paus(3);
                break;
            }
            else
            {
                    Console.WriteLine("Incorrect password, try again!");
                    Methods.Lines();
                    continue;
            }
            }
            await MainMenu.Mains();
      
        }

    }
}
