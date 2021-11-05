using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL_SMS
{
    public class DAL_Student: DBConnection
    {
        public DataTable getStudent()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
            DataTable dtbStudent = new DataTable();
            da.Fill(dtbStudent);
            dtbStudent.Columns.Add("Ord");
            // ordinary : thu tu
            for (int i = 1; i <= dtbStudent.Rows.Count; i++)
                dtbStudent.Rows[i-1]["Ord"] = i.ToString();
            return dtbStudent;
            // id , name, email, Ord
        }
        public bool insertStudent(string name, string email)
        {
            string str = string.Format("insert into Student(name, email) values('{0}','{1}')",name,email);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        public bool updateStudent(int id, string name, string email)
        {
            string str = string.Format("update Student set name='{0}', email='{1}' where id = '{2}'", name, email,id);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        public bool deleteStudent(int id)
        {
            string str = string.Format("delete from Student where id = '{0}'",id);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
    }
}
