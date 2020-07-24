using System;
using System.IO;

namespace ChangeScore
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentScore = "";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "score.txt";
            try
            {  
                currentScore = GetScore(directoryPath);
            }
            catch
            {
                using (StreamWriter sw = File.CreateText(directoryPath))
                {
                    sw.WriteLine("0 - 0");
                }
                currentScore = GetScore(directoryPath);
            }
            
            if(currentScore == "")
            {
                currentScore = "0 - 0";
            }
            if (currentScore != null)
            {
                string[] currentScoreSplit = currentScore.Split(" - ");
                int wins = Convert.ToInt32(currentScoreSplit[0]);
                int losses = Convert.ToInt32(currentScoreSplit[1]);

                string newScore = "";
                if (args.Length > 0)
                {
                    if (args[0] == "w")
                    {
                        wins += 1;
                        newScore = String.Format("{0} - {1}", wins, losses);
                    }
                    else if (args[0] == "l")
                    {
                        losses += 1;
                        newScore = String.Format("{0} - {1}", wins, losses);

                    }
                }
                else
                {
                    newScore = "0 - 0";
                }
                File.WriteAllText(directoryPath, newScore);
            }
        }
        static string GetScore(string directoryPath)
        {
             return File.ReadAllText(directoryPath);
        }
    }
}
