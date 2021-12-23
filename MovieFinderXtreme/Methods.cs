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
    public  class Methods

    {
        public static HttpClient client = new HttpClient();
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

        public static void Paus(int paus)
        {
            Thread.Sleep(TimeSpan.FromSeconds(paus));
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }

        public static bool VerifyPassword(string password)
        {
            return User.CurrUser.Password == password;
        }
 
        public static void Title(string title)
        {
            Methods.Lines();
            Console.WriteLine(title);
            Methods.Lines();
        }
       public static async Task GetId()
        {
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API-KEY");

            int id = Methods.Id();
            string urId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response = await client.GetAsync(urId);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            Movie movie = JsonConvert.DeserializeObject<Movie>(responseContent);
            Console.Clear();
            Console.WriteLine("Movie Id: {0}", movie.id);
            Console.WriteLine("Movie Title: {0}", movie.original_title);
            Console.WriteLine("Rating: {0}", movie.vote_average);
            Console.WriteLine("Movie Length: {0} min", movie.runtime);
            Console.WriteLine("Release date: {0}", movie.release_date);
            Console.WriteLine("Release date: {0}", movie.original_language);
            Console.WriteLine("Website Url: {0}", movie.homepage);
            Console.WriteLine("Poster Url: {0}", movie.poster_path);
            Console.WriteLine("About: {0}", movie.overview);
            Methods.Lines();
        }
        public static async Task GetGenre()
        {
            int i = 1;
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API-KEY");
            string Id = $"https://api.themoviedb.org/3/genre/movie/list?api_key={key}&language=en-US";

            var response2 = await client.GetAsync(Id);
            response2.EnsureSuccessStatusCode();
            var responseGenre = await response2.Content.ReadAsStringAsync();

            Movie allGenres = JsonConvert.DeserializeObject<Movie>(responseGenre);

            foreach (var item in allGenres.genres)
            {

                Console.Write("{0}. {1}", i, item.name);
                i++;
            }

            Console.WriteLine("You may choose from above genres, please enter the number corresponding to your choice: ");
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Action has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Action");
                            return;

                        case 2:
                            Console.WriteLine("Adventure has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Adventure");
                            return;

                        case 3:
                            Console.WriteLine("Animation has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Animation");
                            return;

                        case 4:
                            Console.WriteLine("Comedy has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Comedy");
                            return;

                        case 5:
                            Console.WriteLine("Crime has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Crime");
                            return;

                        case 6:
                            Console.WriteLine("Documentary has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Documentary");
                            return;
                        case 7:
                            Console.WriteLine("Drama has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Drama");
                            return;
                        case 8:
                            Console.WriteLine("Family has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Family");
                            return;
                        case 9:
                            Console.WriteLine("Fantasy has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Fantasy");
                            return;
                        case 10:
                            Console.WriteLine("History has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("History");
                            return;
                        case 11:
                            Console.WriteLine("Horror has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Horror");
                            return;
                        case 12:
                            Console.WriteLine("Music has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Music");
                            return;
                        case 13:
                            Console.WriteLine("Mystery has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Mystery");
                            return;
                        case 14:
                            Console.WriteLine("Romance has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Romance");
                            return;
                        case 15:
                            Console.WriteLine("Science Fiction has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Science Fiction");
                            return;
                        case 16:
                            Console.WriteLine("TV Movie has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("TV Movie");
                            return;
                        case 17:
                            Console.WriteLine("Thriller has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Thriller");
                            return;
                        case 18:
                            Console.WriteLine("War has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("War");
                            return;
                        case 19:
                            Console.WriteLine("Western has been added to your list of preferences {0}.", User.CurrUser.UserName);
                            User.preferences.Add("Western");
                            return;
                    }


                }
            }
        }
    }
}
