using CourseManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Repos
{
    public class DbStudentCoursesRepo : IStudentCourseRepo
    {

        string _connectionString = "Server=localhost;Database=CourseManager;Trusted_Connection=True;";
        private DataSet ExecuteQuery(string sql)
        {
            DataSet set = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(set);
            }

            return set;
        }
        public void Add(StudentCourse toAdd)
        {
            
            DataSet set = ExecuteQuery("insert into StudentCourses (CourseId, StudentId) values (" +toAdd.CourseId + ", " + toAdd.StudentId + ")");

        }

     
       

        public void DeleteByStudentId(StudentCourse toDelete)
        {
            DataSet set = ExecuteQuery("DELETE FROM StudentCourses WHERE StudentId = " + toDelete.StudentId + "");
        }

        public void DeleteByCourseId(StudentCourse toDelete)
        {
            DataSet set = ExecuteQuery("DELETE FROM StudentCourses WHERE CourseId = " + toDelete.CourseId + "");
        }

        public List<StudentCourse> GetStudentCoursesByCourseId(int value)
        {
            List<StudentCourse> toReturn = new List<StudentCourse>();

            DataSet set = ExecuteQuery("select StudentId from StudentCourses where CourseId = " + value);
            var table = set.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                StudentCourse toAdd = new StudentCourse();
                var studentId = int.Parse(table.Rows[i]["StudentId"].ToString());
                

                toAdd.StudentId = studentId;
                toAdd.CourseId = value;
                //TODO need list of courses

                toReturn.Add(toAdd);
            }
            return toReturn;
        }
    }
}
