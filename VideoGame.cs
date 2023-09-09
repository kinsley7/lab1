/**       
 *--------------------------------------------------------------------
 * 	   File name: Program
 * 	Project name: CrowdisLab2
 *--------------------------------------------------------------------
 * Author’s name and email:	 kinsley crowdis crowdis@etsu.edu			
 *          Course-Section: CSCI 2910-800
 *           Creation Date:	09/01/2023
 * -------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrowdisLab1
{
    internal class VideoGame : IComparable<VideoGame>
    {
        string Name { get; set; }
        string Platform { get; set; }
        int Year { get; set; }
        string Genre { get; set; }
        string Publisher { get; set; }

        public VideoGame(string name, string platform, int year, string genre, string publisher)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\n " + "Platform: " + Platform + "\n " + "Year: " + Year + "\n " + "Genre: " + Genre + "\n "
                + "Publisher: " + Publisher + " \n ----------------- \n ";
        }

        //sorts by name
        public int CompareTo(VideoGame other)
        {
            return Name.CompareTo(other.Name);
        }


        public static void PublisherData(List<VideoGame> videogame, string userInput)
        {
           //total video games # (used later to calculate %)
            var gameNumber = videogame.Count;


            //search for what the user enters.. get that.. put it in list
            List<VideoGame> publisherGames = videogame.Where(x => x.Publisher.ToLower().Equals(userInput.ToLower())).ToList<VideoGame>();

            // this is the # of total video games by the publisher that is being searched for
            float numPublisher = publisherGames.Count;

            // the amount of games the publisher has out of all of the games in the list
            var percent = numPublisher / gameNumber * 100;

            //writes out all of the publisher's games
            publisherGames.ForEach(Console.WriteLine);

            Console.WriteLine($"There are {numPublisher} {userInput} games out of {gameNumber} total games. {Math.Round(percent, 2)}% of games are published by {userInput}.");

        }

        //same thing as above but for genre
        public static void GenreData(List<VideoGame> videogame, string userInput)
        {
            //total video games # (used later to calculate %)
            var gameNumber = videogame.Count;


            //search for what the user enters.. get that.. put it in list
            List<VideoGame> genreGames = videogame.Where(x => x.Genre.ToLower().Equals(userInput.ToLower())).ToList<VideoGame>();

            float numGenre = genreGames.Count;
            var percent = numGenre / gameNumber * 100;

            genreGames.ForEach(Console.WriteLine);



            Console.WriteLine($"There are {numGenre} {userInput} games out of {gameNumber} total games. {Math.Round(percent, 2)}% of games are {userInput}.");


        }
    }
}
