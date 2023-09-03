﻿namespace CrowdisLab1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string fileName = projectRootFolder + "/videogames.csv";

            string data = File.ReadAllText(fileName);
           //Console.WriteLine(data);
           List<VideoGame> games = new List<VideoGame>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string row;

                reader.ReadLine();

                while (!reader.EndOfStream && (row = reader.ReadLine()) != null)
                {

                    string[] strings = row.Split(',');

                    string name = strings[0];
                    string platform = strings[1];
                    int year = int.Parse(strings[2]);
                    string genre = strings[3];
                    string publisher = strings[4];

                    VideoGame game = new VideoGame(name, platform, year, genre, publisher);
                    games.Add(game);
                }

                games.Sort();

                //list of all games sorted by name
                Console.WriteLine("+ List of all games in alphabetical order +");
                games.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------");

                //Choose a publisher (e.g., Nintendo) from the dataset and
                //create a list of games from that developer from the list created in the first step.
                //Then sort that list alphabetically and display each item inside.

                Console.Write("Enter the name of the publisher you would like to search for: ");
                string userPublisher = Console.ReadLine().Trim().ToLower();

                VideoGame.PublisherData(games, userPublisher);
                Console.WriteLine("------------------------------------------");

                //Choose a genre (e.g., Role-Playing) and create a list of games
                //of that genre from the list created in the first step.
                //Then sort that list alphabetically and display each item inside.

                Console.Write("Enter the name of the genre you would like to search for: ");
                string userGenre = Console.ReadLine().Trim().ToLower();

                VideoGame.GenreData(games, userGenre);
                Console.WriteLine("------------------------------------------");

                Console.WriteLine("Thank you for using :-)");

            }
        }
    }
}