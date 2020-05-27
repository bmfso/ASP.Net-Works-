using Microsoft.AspNetCore.Mvc;
using PokemonManager.Interfaces;
using PokemonManager.Models;
using PokemonManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonManager.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;
        public PokemonService()
        {
            _repository = new PokemonRepository();
        }
        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllFromType(string type)
        {
            throw new NotImplementedException();
        }

        public Pokemon Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pokemon> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(string name, string type)
        {
           _repository.Insert( name, type);
        }

        public void Update(string name, string type)
        {
            _repository.Update(name, type);
        }
    }
}
