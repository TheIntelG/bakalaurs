using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bakalaurs.Models
{
    public partial class ElementData
    {
        public List<Element> ReadElementDataFile()
        {
            DirectoryInfo rootDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            rootDir = rootDir.Parent.Parent.Parent.Parent.Parent;

            string elementJsonFile;
            using (var reader = new StreamReader(rootDir + "\\Data\\data.json"))
            {
                elementJsonFile = reader.ReadToEnd();
            }

            var elementListFromJson = JsonConvert.DeserializeObject<List<Element>>(elementJsonFile);

            return elementListFromJson;
        }
    }
    
    public class Element
    {
        public string Name { get; set; }
        public List<Vertice> Vertices { get; set; }
    }

    public class Vertice
    {
        public string Location { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double ReactionTime { get; set; }
    }
}
