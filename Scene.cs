using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_adventure
{
    internal class Scene
    {
        public string Id { get; set; } = "";
        public string Beschrijving { get; set; } = "";
        public string Hint { get; set; } = "";
        public int Akt { get; set; } = 1;
        public Dictionary<string, string> Keuzes { get; set; } = new();
        public Dictionary<string, string> ItemBijKeuze { get; set; } = new();
    }
}
