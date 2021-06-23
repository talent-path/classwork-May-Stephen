using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CourseManager.Models;

namespace CourseManager.Repos
{

    
    public class DbTeachersRepo : ITeacherRepo
    {
        string _connectionString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";

        private DataSet ExecuteQuery(string sql)
        {
            // data set is a container for the data
            DataSet set = new DataSet();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //adapter fills data set
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(set);
            }
            return set;
        }

        public Teacher GetById(int id)
        {
            DataSet set = ExecuteQuery("SELECT Id, Name FROM Teachers WHERE Id =" + id);
            var table = set.Tables[0];
            Teacher toReturn = null;

            if (table.Rows.Count == 1)
            {
                toReturn = new Teacher();
                var setId = int.Parse(table.Rows[0]["Id"].ToString());
                var name = table.Rows[0].Field<string>("Name");

                toReturn.Id = setId;
                toReturn.Name = name;

                //TODO Add list of courses
            }

            return toReturn;
        }
    }
}
