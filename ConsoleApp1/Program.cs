using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private const string KEY = "{YOUR KEY HERE}";
        private const string SECRET = "{YOUR SECRET HERE}";

        static void Main(string[] args)
        {
            var fetch = new FetchSharp.FetchClient(KEY, SECRET);

            // get user info - gets your own uid although it could return ids
            // of all users that have trusted this app
            var user = fetch.GetUsers();
            Console.WriteLine($"Uid: {user.Response[0].Uid}");

            Console.WriteLine();
            Console.WriteLine();

            // get all entries from start of the year
            var entries = fetch.GetTrainingEntries(user.Response[0].Uid, DateTime.Parse("2018-01-01"));
            entries.Response.ForEach(te => Console.WriteLine($"Date: {te.Date.ToShortDateString()} Category: {te.Category} Distance: {te.Miles.ToString("#.##")}m"));

            Console.WriteLine();
            Console.WriteLine();

            // get all forum threads
            var threads = fetch.GetForumThreads();
            threads.Response.ForEach(t => Console.WriteLine($"Category: {t.Category} Title: {t.Title} Last Post: {t.LastPost.ToShortDateString()}"));

            Console.ReadLine();
        }
    }
}
