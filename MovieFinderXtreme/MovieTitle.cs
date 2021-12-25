using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace MovieFinderXtreme
{
    public class Result
    {

        public class Rootobject
        {
            public int page { get; set; }
            public Result[] results { get; set; }
            public int total_pages { get; set; }
            public int total_results { get; set; }
        }

        
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public int?[] genre_ids { get; set; }
            public int id { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public float popularity { get; set; }
            public string poster_path { get; set; }
            public string release_date { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public float vote_average { get; set; }
            public int vote_count { get; set; }

            public Result(string name, string language, int id, string overview)
            {
                this.id = id;
                this.original_title = name;
                this.overview = overview;
                this.original_language = language;
            }

        
   
    }

}

