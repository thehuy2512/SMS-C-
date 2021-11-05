using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_SMS;
using System.Data;

namespace BUS_SMS
{
    public class BUS_Subject
    {
        DAL_Subject dalSubject = new DAL_Subject();

        public DataTable getSubject(string id)
        {
            return dalSubject.getSubject(id);
        }

        public bool insertSubject(string id, string Subject_name, String Subject_mark)
        {
            return dalSubject.insertSubject(id, Subject_name, Subject_mark);
        }
        public bool updateSubject(string id, string Subject_id, string Subject_name, String Subject_mark)
        {
            return dalSubject.updateSubject(id, Subject_id, Subject_name, Subject_mark);
        }
        public bool deleteSubject(String id, String Subject_id)
        {
            return dalSubject.deleteSubject(id, Subject_id);
        }
    }
}
