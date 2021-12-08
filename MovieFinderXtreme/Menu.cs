using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    public class Menu
    {
        public static int Introduction()
        {
            Console.WriteLine("Welcome To Snäll's Movie Finder Xtreme, peasant\n You may now choose to create a user or login as guest\n1.Create account\n2.Continue as guest");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
