using ApiPruebaCrud.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace ApiPruebaCrud.Repositories
{
    public class ProductoRepository
    {
        private String conn;
        public ProductoRepository()
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

        public void Add(Producto producto)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"INSERT INTO productos(Descripcion, Precio, Stock) VALUES (@Descripcion, @Precio, @Stock)";
                dbConnection.Open();
                dbConnection.Execute(Query, producto);
            }
        }
        public IEnumerable<Producto> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM productos";
                dbConnection.Open();
                return dbConnection.Query<Producto>(Query);
            }
        }
        public Producto GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM productos where ProductoId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Producto>(Query, new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"DELETE FROM productos where ProductoId=@Id";
                dbConnection.Open();
                dbConnection.Execute(Query, new { Id = id });
            }
        }
        public void Update(Producto producto)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"UPDATE productos SET Descripcion=@Descripcion ,Precio=@Precio, Stock=@Stock where ProductoId=@ProductoId";
                dbConnection.Open();
                dbConnection.Query(Query, producto);
            }
        }
    }
}
