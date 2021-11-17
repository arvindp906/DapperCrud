using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperCrudOperation.Models
{
    public class VegetableRepository
    {
        private string connectionstring;

        public VegetableRepository()
            {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            }

        public List<Vegetable> ViewAll()
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
                return db.Query<Vegetable>("Vegetables_ViewAll", commandType: CommandType.StoredProcedure).ToList();
        }
        public Vegetable Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
                return db.Query<Vegetable>("Vegetables_Get",new { Id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public Vegetable Create(Vegetable vegetable)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
                db.Execute("Vegetables_Add",
                    vegetable,
                    commandType: CommandType.StoredProcedure);
            return vegetable;
        }
        public Vegetable Update(Vegetable vegetable)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
                db.Execute("Vegetables_Update",
                   vegetable, commandType: CommandType.StoredProcedure);
            return vegetable;
            
        }
        public Vegetable Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
                return db.Query<Vegetable>("Vegetables_Delete", new { Id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }

    
}