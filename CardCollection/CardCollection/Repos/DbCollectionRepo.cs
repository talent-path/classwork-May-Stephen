using CardCollection.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbCollectionRepo : ICollectionRepo
    {
        string _connectionString = "Server=localhost; Database=CourseManager; Trusted_Connection=true;";

        private DataSet ExecuteQuery(string query)
        {
            DataSet set = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(set);
            }
            return set;
        }

        public int Add(Card toAdd)
        {
            throw new NotImplementedException();
        }

        
    }
}
