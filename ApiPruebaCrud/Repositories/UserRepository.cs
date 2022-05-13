using ApiPruebaCrud.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BC = BCrypt.Net.BCrypt;
namespace ApiPruebaCrud.Repositories
{
    public class UserRepository
    {
        private String conn;
        public UserRepository()
        {
            conn = "Server=localhost;Database=ApiPruebaCrud;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conn);
            }
        }

        public void Add(Usuario usuario)
        {
            using(IDbConnection dbConnection = Connection)
            {
                usuario.Clave = BC.HashPassword(usuario.Clave);
                string Query = @"INSERT INTO Usuarios(Nombre, Email, Clave) VALUES (@Nombre, @Email, @Clave)";
                dbConnection.Open();
                dbConnection.Execute(Query, usuario);
            }
        }
        public IEnumerable<Usuario> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM Usuarios";
                dbConnection.Open();
                return dbConnection.Query<Usuario>(Query);
            }
        }
        public Usuario GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM Usuarios where UserId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Usuario>(Query, new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"DELETE FROM Usuarios where UserId=@Id";
                dbConnection.Open();
                dbConnection.Execute(Query, new { Id=id });
            }
        }
        public void Update(Usuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                usuario.Clave = BC.HashPassword(usuario.Clave);
                string Query = @"UPDATE Usuarios SET Nombre=@Nombre ,Email=@Email, Clave=@Clave where UserId=@UserId";
                dbConnection.Open();
                dbConnection.Query(Query, usuario);
            }
        }
    }
}
