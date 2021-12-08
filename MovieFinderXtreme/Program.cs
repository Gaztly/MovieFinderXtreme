using System;
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
                        User.CreateUser();
                        break;
                    }
                case 2:
                    {
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

        }
    }
}

