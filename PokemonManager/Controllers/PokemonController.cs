using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonManager.Interfaces;
using PokemonManager.Models;
using PokemonManager.Services;

namespace PokemonManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PokemonController : ControllerBase
    {
        private string _dBAdress;

        private readonly IPokemonService _service;
        public PokemonController()
        {
            _dBAdress = "Server=localhost;Database=PokemonDB;Trusted_Connection=True";
            _service = new PokemonService();
 
        }
                
        [HttpGet("{id}")]
        public Pokemon Get(int id)
        {
            //Using é usado para criar uma cena temporária que no fechar do using ele fecha, 
            // i.e o acesso da BD é fechado automáticamente quando o using fecha
            using (var sqlConnection = new SqlConnection(_dBAdress)) { 
                string getId = "SELECT * FROM  [dbo].[Pokemon] WHERE [Id] = @id ";
                sqlConnection.Open();

                //Retorna um Pokemon, pq se eu não tivesse o método "First(), ele me devolveria um array com um elemento
                return sqlConnection.Query<Pokemon>(getId, new { Id = id }).First(); 
            }

          
            //Função Lambda (cena do where)- i.e estou iterar cada pokemon "p"
            //" => " significa Go To
            //Where significa que entro num loop em analisa cada pokemon p
            //return _pokeList.Where(p => p.Id == id);
        }

        [HttpGet]
        public IEnumerable<Pokemon> GetAll()
        {
            return _service.GetAll();
        }


        [HttpPost]
        public void Post(string name, string type)
        {
            _service.Add(name, type);

        }

        [HttpPut]
        public void Put(string name, string type)
        {
            _service.Update(name, type);


        }



        [HttpDelete("{name}")]
        public void Delete(string name)
        {

            _service.Delete(name);

        }

        [HttpDelete("DeleteFromType/{type}")]
        //ActionResult DeleteAllFromType(string type)
        public void DeleteAllFromType(string type)
        {
            _service.DeleteAllFromType(type);     

        }

    }

}