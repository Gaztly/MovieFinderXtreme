using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MovieFinderXtreme
{
    public static class Program
    
    {
       
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)

        {
            int x = LoginMenu.Introduction();
            LoginMenu.Menu(x);
           
        }
    }
}

