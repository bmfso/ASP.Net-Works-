using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonManager.Models
{
    public class Pokemon
    {
  
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string ImgUrl{ get; set; }

        public bool IsLucky { get; set; }
        public bool IsShiny { get; set; }
    }
}
