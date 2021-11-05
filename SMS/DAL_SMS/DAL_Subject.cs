using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SMS
{
    public class DAL_Subject :DBConnection
    {
        public DataTable getSubject(string id)
        {   
            string str = string.Format("select * from subject where id='{0}'",id);
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dtbSubject = new DataTable();
            da.Fill(dtbSubject);
            dtbSubject.Columns.Add("Ord");
            // ordinary : thu tu
            for (int i = 1; i <= dtbSubject.Rows.Count; i++)
                dtbSubject.Rows[i - 1]["Ord"] = i.ToString();
            return dtbSubject;
            // id , name, email, Ord
        }
        
        public bool insertSubject(string id, string Subject_name,String Subject_mark)
        {
            string str = string.Format("insert into Subject(id,Subject_name,Subject_mark) values('{0}','{1}','{2}')",id,Subject_name,Subject_mark);
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
        public bool updateSubject(string id,string Subject_id, string Subject_name, String Subject_mark)
        {
            string str = string.Format("update Subject set Subject_name='{0}', Subject_mark='{1}' where Subject_id = '{2}' and id = '{3}'", Subject_name, Subject_mark,Subject_id,id);
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
        public bool deleteSubject(String id,String Subject_id)
        {
            string str = string.Format("delete from Subject where id = '{0}' and Subject_id='{1}'", id,Subject_id);
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
