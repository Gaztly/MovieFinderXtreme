using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MovieFinderXtreme
{
    static class Program

    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)

        {
            

            int choice = Menu.Introduction();

            switch (choice)
            {
                case 1:
                    {
                        Methods.Lines();
                        User.CreateUser();
                        break;
                    }
                case 2:
                    {
                        Methods.Lines();
                        Console.WriteLine("You are now logged in as a guest, enjoy!");
                        break;
                    }

            }
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API-KEY");

            int id = Methods.Id();
            string urId = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            var response = await client.GetAsync(urId);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            
            Movie movie = JsonConvert.DeserializeObject<Movie>(responseContent);

            Console.WriteLine("Movie Title: {0}", movie.original_title);
            Console.WriteLine("Movie Id: {0}",movie.id);
            Console.WriteLine("Movie Length: {0} min", movie.runtime);
            Console.WriteLine("About: {0}", movie.overview);
            Methods.Lines();

            Methods.SearchGenre();
            await GetGenre();
            static async Task GetGenre()
            {
                DotNetEnv.Env.TraversePath().Load();
                string key = Environment.GetEnvironmentVariable("API-KEY");
                string Id = $"https://api.themoviedb.org/3/genre/movie/list?api_key={key}&language=en-US";

                var response2 = await client.GetAsync(Id);
                response2.EnsureSuccessStatusCode();
                var responseGenre = await response2.Content.ReadAsStringAsync();

                ListOfGenre allGenres = JsonConvert.DeserializeObject<ListOfGenre>(responseGenre);

                foreach (var item in allGenres.allG)
                {
                    Console.WriteLine(item.horror);
                }
            }
        }
    }
}

