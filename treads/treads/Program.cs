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
        static void Main(string[] args)
        {
            List<Team> group = new List<Team>();

            //reading
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../output.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Team t = new Team();
                XmlNode attr = xnode.Attributes.GetNamedItem("http://www.w3.org/2001/XMLSchema-instance");
                if (attr != null)
                    t.name = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {

                }
                group.Add(t);
            }
            //end 

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
                    FileStream fw = new FileStream("../../output.xml", FileMode.Create);
                    foreach (Team t in group)
                        xmlSerialaizer.Serialize(fw, t);
                    fw.Close();
                }
                else if (command == 4)
                    break;
                else if (command <= 0)
                {
                    command *= -1;
                    if (group.Count > command && command != 0)
                        group[command - 1].WriteDownInfo();
                }
            }
        }
    }
}
