using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    static class MainMenu
    {
       public static async Task Mains()
        {
            Methods.Title("Main Menu");
            Console.WriteLine("You can now choose how to search after movies {0}\n1. Search by movie ID\n2.Search by title\n3.Sort by genre", User.CurrUser.UserName);
            int number = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
            switch (number)
            {
                case 1:
                    {
                        Console.Clear();
                        Methods.Lines();
                        await Methods.GetId();
                        return;
                    }
                case 2:
                    {
                        return;
                    }
                case 3:
                    {
                        Console.Clear();
                        Methods.Lines();
                        await Methods.GetGenre();
                        return;
                    }

                        Console.WriteLine("Would you like to do another search? Y/N");
                        string answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                        int x = LoginMenu.Introduction();
                        await LoginMenu.Menu(x);
            }

            }
        }

    }
}
