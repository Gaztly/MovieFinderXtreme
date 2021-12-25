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
            Console.Clear();
            Methods.Title("Main Menu");
            while (true)
            {

           try
            {

            Console.WriteLine("Welcome {0}\n\n1.Search by movie ID\n2.Search by title\n3.Add genres to favourites\n4.View profile\n5.Logout", User.CurrUser.UserName);
            int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                     case 1:
                    {
                        Console.Clear();
                        await Methods.GetId();
                        break;
                    }
                     case 2:
                    {
                        Console.Clear();
                       await Methods.GetTitle();
                        break;
                    }
                     case 3:
                    {
                        Console.Clear();
                        await Methods.GetGenre();
                        break;
                    }
                    case 4:
                        {
                            Console.Clear();
                            Methods.PrintUserInfo();
                            break;
                        }
                case 5:
                    {
                        {
                            Console.Clear();
                            Methods.Lines();
                            Console.WriteLine("Logging out..");
                            Methods.Lines();
                            Methods.Paus(3);
                            int x = LoginMenu.Introduction();
                            await LoginMenu.Menu(x);
                            break;
                        }
                    }
                          

                }
            }
                catch (FormatException e)
                {
                    Methods.Lines();
                    Console.WriteLine("Wrrrrrrrooooooong input");
                    Console.WriteLine("Try again dummie!");
                    Methods.Lines();
                    continue;
                }
           }
       }

    }
}
