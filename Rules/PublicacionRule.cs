using Dapper;
using ProyectoFinal.Models;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoFinal.Rules {
    public class PublicacionRule {

        private readonly IConfiguration _configuration;
        public PublicacionRule( IConfiguration configuration ) {
            _configuration = configuration;
        }


        public List<Publicacion> GetPublicaciones(int cant , int pagina ) {
            var connectionString = _configuration.GetConnectionString("BlogDatabase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open( );
                var query = @$"SELECT * FROM Publicacion
                                ORDER BY Creacion DESC
                                OFFSET {cant * pagina} ROWS
                                FETCH NEXT {cant} ROWS ONLY";
                var posts = connection.Query<Publicacion>(query).ToList();

                return posts;
            }

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

        public void InsertPost(Publicacion data ) {
            var connectionString = _configuration.GetConnectionString("BlogDatabase");
            using var connection = new SqlConnection(connectionString);
            {
                connection.Open( );
                var queryInsert = "INSERT INTO Publicacion(Titulo, SubTtitulo, Creador, Cuerpo, Creacion, Imagen) Values(@Titulo, @SubTtitulo, @Creador, @Cuerpo, @Creacion, @Imagen) ";
                var result = connection.Execute( queryInsert, new{
                    titulo= data.Titulo, 
                    subttitulo=data.SubTitulo,
                    creador=data.Creador, 
                    cuerpo=data.Cuerpo, 
                    creacion=data.Creacion, 
                    imagen= data.Imagen
                }  );
                
            }
        }

    }
}
