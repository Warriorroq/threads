using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treads
{
    public static class Fabric
    {
        private static Random rand = new Random();
        public static Team CreateTeam()
        {
            Console.WriteLine("name:");
            string name = Console.ReadLine();
            int wins = InputValue("pobedi");
            int loses = InputValue("poragenia");
            int draws = InputValue("nichi");
            float mins = InputValue("vremia igri v min")/60f;
            return new Team(name,wins,loses,draws,mins);
        }
        public static Team CreateRandomTeam()
        {
            string name = CreateName();
            int wins = rand.Next(0, 20);
            int loses = rand.Next(0, 20);
            int draws = rand.Next(0, 20);
            float mins = rand.Next(20, 120)/60f;
            return new Team(name, wins, loses, draws, mins);
        }
        private static int InputValue(string predlog = "")
        {
            Console.WriteLine(predlog);
            int value = 0;
            int.TryParse(Console.ReadLine().ToString(), out value);
            return value;
        }
        private static string CreateName()
        {
            int length = rand.Next(4,10);

            // creating a StringBuilder object()
            StringBuilder strBuild = new StringBuilder();

            for (int i = 0; i < length; i++)
            {                
                strBuild.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(25 * rand.NextDouble())) + 65));
            }

            return strBuild.ToString();
        }
    }
}
