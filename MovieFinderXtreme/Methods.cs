using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieFinderXtreme
{
    public class Methods

    {
        public static HttpClient client = new HttpClient();

        public static void PrintUserInfo()
        {
            Title("Profile");
            Console.WriteLine("Username: {0}\nAge: {1}\nCountry of origin: {2}\nPreferences: {3}", User.CurrUser.UserName, User.CurrUser.Age, User.CurrUser.Country, User.CurrUser.Preference);
            Lines();
            Console.WriteLine("1.Edit username\n2.Edit password\n3.See list of added genres");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        EditUserName();
                        break;
                    }
                case 2:
                    {
                        EditPassWord();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Title("Genre favourites");
                        int k = 1;
                        for (int i = 0; i < User.preferences.Count; i++)
                        {
                            Console.WriteLine("{0}. {1}", k, User.preferences[i]);
                            k++;
                            Paus(1);
                        }
                        Lines();
                        return;
                    }
            }
        }
        public static void EditUserName()
        {
            Title("Edit Username");
            Console.WriteLine("You may now enter your new username {0}",User.CurrUser.UserName);
            User.CurrUser.UserName = Console.ReadLine();
            Lines();
            Console.WriteLine("You have now successfully changed username to: {0}", User.CurrUser.UserName);
            Lines();
            Paus(3);
            Console.Clear();
        }
        public static void EditPassWord()
        {
            Title("Edit Password");
            Console.WriteLine("You may now enter your new password {0}", User.CurrUser.UserName);
            User.CurrUser.Password = Console.ReadLine();
            Lines();
            Console.WriteLine("You have now successfully changed password to: {0}", User.CurrUser.Password);
            Lines();
            Paus(3);
            Console.Clear();
        }
        public static int Id()
        {
            Console.Write("Please enter the ID for the Movie you wish to search for: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public static void Lines()
        {
            Console.WriteLine("-----------------------------------------------------------");
        }

        public static void Paus(int paus)
        {
            Thread.Sleep(TimeSpan.FromSeconds(paus));
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }

        public static void Title(string title)
        {
            Lines();
            Console.WriteLine(title);
            Lines();
        }
        public static async Task GetTitle()
        {
            int i = 1;
            Title("Search by Title");
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API-KEY");

            Console.WriteLine("Enter title of the movie you'd like to search for: ");
            string search = Console.ReadLine();
            string title = $"https://api.themoviedb.org/3/search/movie?api_key={key}&query={search}";

            var response = await client.GetAsync(title);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            Result.Rootobject movietitle = JsonConvert.DeserializeObject<Result.Rootobject>(responseContent);

            Console.Clear();
            foreach (var item in movietitle.results)
            {
                Console.WriteLine("{0}.{1}----> Movie-Id: {2}", i, item.original_title, item.id);
                Lines();
                i++;

            }
            int id = Id();
            string urId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response1 = await client.GetAsync(urId);

            response1.EnsureSuccessStatusCode();

            var responseContent1 = await response1.Content.ReadAsStringAsync();

            Movie movie = JsonConvert.DeserializeObject<Movie>(responseContent1);
            Console.Clear();
            Console.WriteLine("Movie Id: {0}", movie.id);
            Console.WriteLine("Movie Title: {0}", movie.original_title);
            Lines();
            Console.WriteLine("Rating: {0}", movie.vote_average);
            Console.WriteLine("Movie Length: {0} min", movie.runtime);
            Console.WriteLine("Release date: {0}", movie.release_date);
            Console.WriteLine("Original langugage: {0}", movie.original_language);
            Console.WriteLine("Website Url: {0}", movie.homepage);
            Console.WriteLine("Poster Url: {0}", movie.poster_path);
            Lines();
            Console.WriteLine("About: {0}", movie.overview);
            Lines();
            Paus(2);
            Console.WriteLine("Would you like to do another search by title?\nY/N");
            Lines();
            string answer = Console.ReadLine().ToLower();
            while (true)
            {
                if (answer == "y")
                {
                    Console.Clear();
                    Methods.Lines();
                    await GetTitle();
                    break;
                }
                if (answer == "n")
                {
                    Console.Clear();
                    Lines();
                    Console.WriteLine("Returning to main menu...");
                    Paus(2);
                    await MainMenu.Mains();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input dummie, try again!");
                    continue;
                }

            }
        }
        public static async Task GetId()
        {
            Title("Search by movie ID");
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API-KEY");

            int id = Id();
            string urId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response = await client.GetAsync(urId);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            Movie movie = JsonConvert.DeserializeObject<Movie>(responseContent);
            Console.Clear();
            Console.WriteLine("Movie Id: {0}", movie.id);
            Console.WriteLine("Movie Title: {0}", movie.original_title);
            Lines();
            Console.WriteLine("Rating: {0}", movie.vote_average);
            Console.WriteLine("Movie Length: {0} min", movie.runtime);
            Console.WriteLine("Release date: {0}", movie.release_date);
            Console.WriteLine("Original langugage: {0}", movie.original_language);
            Console.WriteLine("Website Url: {0}", movie.homepage);
            Console.WriteLine("Poster Url: {0}", movie.poster_path);
            Lines();
            Console.WriteLine("About: {0}", movie.overview);
            Lines();
            Paus(2);
            Console.WriteLine("Would you like to do another search by ID?\nY/N");
            Lines();
            string answer = Console.ReadLine().ToLower();
            while (true)
            {
                if (answer == "y")
                {
                    Console.Clear();
                    Methods.Lines();
                    await GetId();
                    break;
                }
                if (answer == "n")
                {
                    Console.Clear();
                    Methods.Lines();
                    await MainMenu.Mains();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input dummie, try again!");
                    continue;
                }

            }

        }
        public static async Task GetGenre()
        {
            {

                int i = 1;
                DotNetEnv.Env.TraversePath().Load();
                string key = Environment.GetEnvironmentVariable("API-KEY");
                string Id = $"https://api.themoviedb.org/3/genre/movie/list?api_key={key}&language=en-US";

                var response2 = await client.GetAsync(Id);
                response2.EnsureSuccessStatusCode();
                var responseGenre = await response2.Content.ReadAsStringAsync();

                Movie allGenres = JsonConvert.DeserializeObject<Movie>(responseGenre);
                Title("Genres");
                foreach (var item in allGenres.genres)
                {

                    Console.Write("{0}. {1}\n", i, item.name);
                    i++;
                }

                Console.WriteLine("Please enter the number corresponding to your choice: ");
            

                    while (true)
                    {
                    try
                    {
                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {

                            switch (choice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Action has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Action");
                                    Console.WriteLine("Add another? Y/N");
                                    string answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;


                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Adventure has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Adventure");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;


                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Animation has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Animation");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Comedy has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Comedy");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Crime has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Crime");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;

                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("Documentary has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Documentary");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("Drama has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Drama");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 8:
                                    Console.Clear();
                                    Console.WriteLine("Family has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Family");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("Fantasy has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Fantasy");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 10:
                                    Console.Clear();
                                    Console.WriteLine("History has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("History");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 11:
                                    Console.Clear();
                                    Console.WriteLine("Horror has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Horror");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 12:
                                    Console.Clear();
                                    Console.WriteLine("Music has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Music");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 13:
                                    Console.Clear();
                                    Console.WriteLine("Mystery has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Mystery");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 14:
                                    Console.Clear();
                                    Console.WriteLine("Romance has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Romance");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 15:
                                    Console.Clear();
                                    Console.WriteLine("Science Fiction has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Science Fiction");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 16:
                                    Console.Clear();
                                    Console.WriteLine("TV Movie has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("TV Movie");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 17:
                                    Console.Clear();
                                    Console.WriteLine("Thriller has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Thriller");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 18:
                                    Console.Clear();
                                    Console.WriteLine("War has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("War");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    continue;
                                case 19:
                                    Console.Clear();
                                    Console.WriteLine("Western has been added to your list of preferences {0}.", User.CurrUser.UserName);
                                    Lines();
                                    User.preferences.Add("Western");
                                    Console.WriteLine("Add another? Y/N");
                                    answer = Console.ReadLine().ToLower();
                                    if (answer == "y")
                                    {
                                        await GetGenre();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Lines();
                                        Console.WriteLine("Returning to menu...");
                                        Lines();
                                        Paus(3);
                                        await MainMenu.Mains();
                                        break;
                                    }
                                    break;
                            }
                            continue;
                        }

                      
                    }
                    catch (FormatException e)
                    {
                        Lines();
                        Console.WriteLine("Nah braah, you did wrong!\nTry again!");
                        Lines();
                    }

                }

               
            }
        }
    }
}

