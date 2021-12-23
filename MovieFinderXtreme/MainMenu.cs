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
            switch (number)
            {
                case 1:
                    {
                        Console.Clear();
                        Methods.Lines();
                        await Methods.GetId();
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Methods.Lines();
                        await Methods.GetGenre();
                        break;
                    }
            }
        }

    }
}
