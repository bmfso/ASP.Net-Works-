using Microsoft.AspNetCore.Mvc;
using PokemonManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PokemonManager.Interfaces
{
    public interface IPokemonService
    {
        public Pokemon Get(int id);
        public IEnumerable <Pokemon> GetAll();

        public void Add(string name, string type);// Post

        public void Update(string name, string type);//Update

        public void Delete(string name);

        public void DeleteAllFromType(string type);
    }
}
