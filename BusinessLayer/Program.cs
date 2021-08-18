using System;
using System.Collections.Generic;
using RestSharp;
using System.IO;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://imdb-internet-movie-database-unofficial.p.rapidapi.com/search/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "452ef9741bmsh3a830c9056849c9p18e359jsnbe3490c4de29");
            request.AddHeader("x-rapidapi-host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");

            request.AddParameter("title", "Harry Potter");
            IRestResponse response = client.Execute(request);

            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Program.SerializableToFile($"{_path}/apiFile.json", response.Content.ToString());

            Console.WriteLine(response.Content.ToString());
            Console.Read();
        }

        private static void SerializableToFile(string s, string response)
        {
            string jsonString = JsonConvert.SerializeObject(response);
            File.WriteAllText(s, jsonString);
        }
    }
    
}
