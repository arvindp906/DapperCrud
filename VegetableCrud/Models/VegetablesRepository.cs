using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace VegetableCrud.Models
{
    public class VegetablesRepository
    {
        private string connectionstring;

        public VegetablesRepository()
        {
            connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public List<Vegetable> GetAll(RequestModel request)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                    .Query<Vegetable>("Vegetables_GetAll",
                    request,
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public Vegetable Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                        .Query<Vegetable>("Vegetables_Get", 
                            new { Id }, 
                            commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
            }
        }
        public int Create(Vegetable vegetable)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                int lastInsertedId = 
                    db.Query<int>("Vegetables_Create",
                    vegetable,
                    commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
                return lastInsertedId;
            }
        }
        public int Update(Vegetable vegetable)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db
                    .Execute("Vegetables_Update",
                       vegetable, 
                       commandType: CommandType.StoredProcedure);
            }            
        }
        public int Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                return db.Execute(
                        "Vegetables_Delete", 
                        new { Id },
                        commandType: CommandType.StoredProcedure);
            }
        }
    }

    
}