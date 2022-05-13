using ApiPruebaCrud.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ApiPruebaCrud.Repositories
{
    public class CompraRepository
    {
        private String conn;
        public CompraRepository()
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

        public void Add(Compra compra)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"INSERT INTO Compras(Userid, ProductoId, FechaCompra, Cantidad) VALUES (@Userid, @ProductoId, @FechaCompra, @Cantidad)";
                dbConnection.Open();
                dbConnection.Execute(Query, compra);
            }

        }
        public IEnumerable<Compra> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM Compras";
                dbConnection.Open();
                return dbConnection.Query<Compra>(Query);
            }
        }
        public Compra GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"SELECT * FROM Compras where CompraId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Compra>(Query, new { Id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<Compra> GetByUserId(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Compra>("SeleccionarUsuario", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"DELETE FROM Compras where CompraId=@Id";
                dbConnection.Open();
                dbConnection.Execute(Query, new { Id = id });
            }
        }
        public void Update(Compra compra)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = @"UPDATE Compras SET UserId=@UserId ,ProductoId=@ProductoId, FechaCompra=@FechaCompra, Cantidad=@Cantidad where CompraId=@CompraId";
                dbConnection.Open();
                dbConnection.Query(Query, compra);
            }
        }
    }
}
