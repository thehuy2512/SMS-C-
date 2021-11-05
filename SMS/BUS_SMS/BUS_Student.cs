using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;
using System.Data;
using System.Data.SqlClient;

namespace BUS_SMS
{
    public class BUS_Student
    {
        DAL_Student daStudent = new DAL_Student();
        public DataTable getStudent()
        {
            return daStudent.getStudent();
        }
        public bool insertStudent(string name, string email)
        {
            return daStudent.insertStudent(name, email);
        }
        public bool updateStudent(int id, string name, string email)
        {
            return daStudent.updateStudent(id, name, email);
        }
        public bool deleteStudent(int id)
        {
            return daStudent.deleteStudent(id);
        }
    }
}
