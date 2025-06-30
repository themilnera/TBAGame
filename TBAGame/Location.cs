using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Landmark> Landmarks { get; set; }
        public Location(string name, string desc, List<Landmark> landmarks)
        {
            Name = name;
            Description = desc;
            Landmarks = landmarks;
        }
    }
}
