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
    class Program
    {
        private static string path = "../../output.xml";
        static void Main(string[] args)
        {
            List<Team> group = new List<Team>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Team>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                group = (List<Team>)formatter.Deserialize(fs);
                foreach (Team p in group)
                    p.WriteDownInfo();
            }

            while (true)
            {
                Console.WriteLine("1 - create random : 2 - create yours : 3 - save table :-num - show team info : 4 - end : 5 - clear");
                int command = 0;
                int.TryParse(Console.ReadLine().ToString(),out command);
                Console.Clear();
                if (command == 1)
                {
                    group.Add(Fabric.CreateRandomTeam());
                    group.Last().WriteDownInfo();
                }
                else if (command == 2)
                {
                    group.Add(Fabric.CreateTeam());
                    group.Last().WriteDownInfo();
                }
                else if (command == 3)
                {
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, group);
                    }
                }
                else if (command == 4)
                    break;
                else if (command <= 0)
                {
                    command *= -1;
                    if (group.Count >= command && command != 0)
                        group[command - 1].WriteDownInfo();
                }
            }
        }
    }
}
