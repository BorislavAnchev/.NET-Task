using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

// DotNETInternTask.exe C:\Users\bobia_000\source\repos\DotNETInternTask\DotNETInternTask\bin\Debug\PlayersData.json 8 83 C:\Users\bobia_000\source\repos\DotNETInternTask\DotNETInternTask\bin\Debug\FilteredPlayers.csv

namespace DotNETInternTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = args[0];
            int yearCriteria = Convert.ToInt32(args[1]);
            double ratingCriteria = Convert.ToDouble(args[2]);
            string csvPath = args[3];

            string jsonFromFile;
            using (var reader = new StreamReader(jsonPath))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            List<Player> players = serializer.Deserialize<List<Player>>(jsonFromFile);

            WriteToCSV(yearCriteria, ratingCriteria, players, csvPath);

            Console.ReadLine();
        }

        static void WriteToCSV(int yearCriteria, double ratingCriteria, List<Player> players, string csvPath)
        {
            var filteredPlayers = players.Where(player => ((DateTime.Now.Year - player.PlayerSince) < yearCriteria) && (player.Rating > ratingCriteria))
                        .OrderByDescending(player => player.Rating).ThenBy(player => player.Name);

            using (var file = new StreamWriter(@csvPath, false))
            {
                file.WriteLine("Name, Rating");
            }

            foreach (var player in filteredPlayers)
            {
                using (StreamWriter file = new StreamWriter(@csvPath, true))
                {
                    file.WriteLine($"{player.Name}, {player.Rating}");
                }
            }
        }
    }
}
