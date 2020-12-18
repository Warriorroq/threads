using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace treads
{
    class Program
    {
        private static string path = "../../output.xml";
        static void Main(string[] args)
        {
            List<Team> group = new List<Team>();
            
            if(false)
            {
                XmlSerializer xmlSerialaizer = new XmlSerializer(typeof(Team));
                Team bludaToRead = new Team();
                FileStream fr = new FileStream(path, FileMode.Open);
                bludaToRead = (Team)xmlSerialaizer.Deserialize(fr);
                group.Add(bludaToRead);
                fr.Close();
            }

            foreach (Team t in group)
                t.WriteDownInfo();

            while (true)
            {
                Console.WriteLine("1 - create random : 2 - create yours : 3 - save table :-num - show team info : 4 - end ");
                int command = 0;
                int.TryParse(Console.ReadLine().ToString(),out command);
                Console.Clear();
                if (command == 1)
                {
                    Team t = Fabric.CreateRandomTeam();
                    group.Add(t);
                    t.WriteDownInfo();
                }
                else if (command == 2)
                {
                    Team t = Fabric.CreateTeam();
                    group.Add(t);
                    t.WriteDownInfo();
                }
                else if (command == 3)
                {
                    XmlSerializer xmlSerialaizer = new XmlSerializer(typeof(Team));
                    FileStream fw = new FileStream(path, FileMode.Open);
                    foreach (Team t in group)
                        xmlSerialaizer.Serialize(fw, t);
                    //xmlSerialaizer.Serialize(fw, group[0]);
                    fw.Close();
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
