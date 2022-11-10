using Dapper;
using ProyectoFinal.Models;
using System.Data.SqlClient;

namespace ProyectoFinal.Rules {
    public class PublicacionRule {

        private readonly IConfiguration _configuration;
        public PublicacionRule( IConfiguration configuration ) {
            _configuration = configuration;
        }


        public Publicacion GetOnePostRandom( ) {

            var connectionString = _configuration.GetConnectionString("BlogDatabase");
            using var connection = new SqlConnection(connectionString);
            {   connection.Open( );
                var posts = connection.Query<Publicacion>("Select TOP 1 * FROM Publicacion ORDER BY NEWID()");
                return posts.First();     
            }

        }

        public List<Publicacion> GetPostHome( ) {

            var connectionString = _configuration.GetConnectionString("BlogDatabase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open( );
                var posts = connection.Query<Publicacion>("Select TOP 4 * FROM Publicacion ORDER BY Creacion DESC").ToList();
                
                return posts;
            }

        }

        public Publicacion GetPostById( int id) {

            var connectionString = _configuration.GetConnectionString("BlogDatabase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open( );
                var query = "Select * FROM Publicacion WHERE Id=@id";
                var posts = connection.QueryFirstOrDefault<Publicacion>( query, new{ id }  );
                return posts;
            }

        }

    }
}
