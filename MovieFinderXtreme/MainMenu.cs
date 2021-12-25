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
            Console.WriteLine("Welcome {0}\n1.Search by movie ID\n2.Search by title\n3.Add genres to favourites\n4.View profile\n5.Logout", User.CurrUser.UserName);
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
                        Console.Clear();
                       await Methods.GetTitle();
                        break;
                    }
                     case 3:
                    {
                        Console.Clear();
                        Methods.Lines();
                        await Methods.GetGenre();
                        break;
                    }
                    case 4:
                        {
                            Console.Clear();
                            Methods.Lines();
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
                            LoginMenu.Introduction();
                            break;
                        }
                    }

                   
                

            }
        }

    }
}
