using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    public static class Methods

    {

        public static int Id()
        {
            Console.Write("Please enter the ID for the Movie you wish to search for: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public static void SearchGenre ()
            {
            Console.WriteLine("You may now choose the genre you'd prefer mate:");
            Lines();
            }
        public static void Lines()
        {
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
