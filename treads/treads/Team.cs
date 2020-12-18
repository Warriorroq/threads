using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace treads
{
    public struct Team
    {
        public string name;
        public int wins;
        public int loses;
        public int draws;
        public float lastGameTime;
        public int totalGames;

        public Team(string name = "", int wins = 0, int loses = 0, int draws = 0, float lastGameTime = 0.0f)
        {
            if (name.ToLower() == "динамо" || name.ToLower() == "шахтер")
            {
                if (wins == 0 || wins <= loses)
                {
                    name = "I have a few questions for you ";
                }
            }

            this.wins = wins;
            this.loses = loses;
            this.draws = draws;
            this.lastGameTime = lastGameTime;
            this.name = name;

            totalGames = wins + loses + draws;
        }
        public void WriteDownInfo()
        {
            Console.WriteLine("name: " + name +
                "\n wins: " + wins.ToString() + " loses: " + loses.ToString() + " draws:" + draws.ToString() +
                "\n last played time: " + (int)lastGameTime + " hour " + lastGameTime%1*60 + " mins");
        }
        public static bool operator ==(Team op1, Team op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(Team op1, Team op2)
        {
            return !op1.Equals(op2);
        }
    }
}
