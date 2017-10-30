using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter writer = new XmlTextWriter(@"c:\temp\a\result.xml", null);
            string[] lines = System.IO.File.ReadAllLines(@"c:\temp\a\texto.txt");
            string header = lines.Where(x => x.Contains("#")).FirstOrDefault();
            header = header.Substring(1);
            string[] headers = header.Split('|').Select(x => x.Trim().TrimEnd().TrimStart()).ToArray();



            string[] values = lines.Where(x => !x.Contains("#")).ToArray();

            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("blooddonors");
            
            for (int j = 0; j < values.Length; j++)
            {
                string value = values[j];
                value = value.Substring(1);
                string[] v = value.Split('|').Select(x => x.Trim().TrimEnd().TrimStart()).ToArray();
                writer.WriteStartElement("donor");
                for (int i = 0; i < headers.Length; i++)
                {   
                    writer.WriteElementString(headers[i], v[i]);
                }
                writer.WriteEndElement();
            }            

            writer.WriteFullEndElement();
            writer.Close();
            writer.Dispose();
        }
    }
}
