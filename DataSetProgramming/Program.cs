using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataSetProgramming
{
    class Tweet
    {
        private string[] data;
        private string location;
        private string content;

        public Tweet(string line)
        {
            data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            location = data[2];
            content = data[10];
        }

        public string getLocation()
        {
            return location;
        }
        public void setBlankLocation()
        {
            location = "No Location";
        }
        public string getContent()
        {
            return content;
        }

        public void outAll()
        {
            foreach(string s in data)
            {
                Console.WriteLine(s);
            }
        }

    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            StreamReader Reader = new StreamReader("vaccination_tweets.csv");

            List<Tweet> Tweets = new List<Tweet>();
            Tweet headers = new Tweet(Reader.ReadLine());
            //headers.outAll();
            while(!Reader.EndOfStream)
            {
                try
                {
                Tweets.Add(new Tweet(Reader.ReadLine()));
                }
                catch
                {

                }
            }
            Random random = new Random();
            while (true)
            {
                int chosen = random.Next(Tweets.Count - 1);
                if (Tweets[chosen].getLocation() == "")
                {
                    Tweets[chosen].setBlankLocation();
                }
                Console.WriteLine($"From {Tweets[chosen].getLocation()} we have this: {Tweets[chosen].getContent()}");

                Console.WriteLine("Press any key for a new tweet");
                Console.ReadKey();
            }
        }
    }
}
