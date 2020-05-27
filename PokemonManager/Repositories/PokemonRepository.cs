using Dapper;
using PokemonManager.Interfaces;
using PokemonManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonManager.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {

        private readonly string _dBAdress;

        public PokemonRepository()
        {
            _dBAdress = "Server=localhost;Database=PokemonDB;Trusted_Connection=True";
        }
        public void Delete(string name)
        {

            string delete = "DELETE FROM [dbo].[Pokemon] WHERE [Name] = @Name;";

            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
                sqlConnection.Open();

                sqlConnection.Execute(delete, new { Name = name });
            }

        }

        public void DeleteAllFromType(string type)
        {
            string delete = "DELETE FROM [dbo].[Pokemon] WHERE [Type] = @type;";
            int affectedRows = 0;


            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
                sqlConnection.Open();

                affectedRows = sqlConnection.Execute(delete, new { Type = type });
            }

            if (affectedRows > 0)
            {
                Ok(affectedRows);//Indicador"ActioResult" que indica se a operação foi ou não realizada devidamente
            }
            BadRequest();

        }

        private void BadRequest()
        {
            throw new NotImplementedException();
        }

        private void Ok(int affectedRows)
        {
            throw new NotImplementedException();
        }

        public Pokemon Get(int id)
        {
            //Using é usado para criar uma cena temporária que no fechar do using ele fecha, 
            // i.e o acesso da BD é fechado automáticamente quando o using fecha
            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
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

        public IEnumerable<Pokemon> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
                string select = "SELECT * FROM  [dbo].[Pokemon]";
                sqlConnection.Open();
                return sqlConnection.Query<Pokemon>(select);
            }
        }

        public void Insert(string name, string type)
        {

            string insert = "INSERT INTO [dbo].[Pokemon] ([Name],[Type],[IsLucky], [IsShiny]) Values (@Name, @Type, @IsLucky, @IsShiny);";

            Pokemon registry = new Pokemon()
            {
                Name = name,
                Type = type,
                IsLucky = false,
                IsShiny = false,
            };

            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
                sqlConnection.Open();

                sqlConnection.Execute(insert, registry);

            };



        }

        public void Update(string name, string type)
        {

            string update = "UPDATE [dbo].[Pokemon] SET [IsShiny] = @IsLucky WHERE [Name] = @Name;";

            using (var sqlConnection = new SqlConnection(_dBAdress))
            {
                sqlConnection.Open();

                sqlConnection.Execute(update, new { name = "Pikachu", IsShiny = true });

            }

        }
    }
}
