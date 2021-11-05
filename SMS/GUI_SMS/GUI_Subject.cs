using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_SMS;
using System.Data;

namespace GUI_SMS
{
    public partial class GUI_Subject : Form
    {
        BUS_Student busStudent = new BUS_Student();
        BUS_Subject busSubject = new BUS_Subject();
        bool tf, tf1;
        String idSubject;
        DataTable dtbStudent;
        public GUI_Subject()
        {
            InitializeComponent();
            tf = tf1 = true;
            Lock_unlock(tf);
            Lock_unlock1(tf1);
            dtbStudent = busStudent.getStudent();
        }

        void Lock_unlock(bool tf)
        {
            btnNew.Enabled = tf;
            btnAdd.Enabled = txtSubjectName.Enabled = txtSubjectMark.Enabled = !tf;

        }
        void Lock_unlock1(bool tf1)
        {
            dgvSubject.Enabled = tf1;
            btnUpdate.Enabled = btnDelete.Enabled = txtSubjectName.Enabled = txtSubjectMark.Enabled = !tf1;

        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tf1)
            {
                tf = !tf;
                Lock_unlock(tf);
                txtSubjectName.Text = txtSubjectMark.Text = "";
                txtSubjectName.Focus();
            }
            else MessageBox.Show("Updating or Deleting!\nClick Reset to do another thing.", "Information");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           if (txtSubjectName.Text != "" && txtSubjectMark.Text != "")
            {
                String id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
                if (busSubject.insertSubject(id,txtSubjectName.Text, txtSubjectMark.Text))
                {
                    MessageBox.Show("Insert successful", "Info");
                    tf = !tf;
                    Lock_unlock(tf);
                    dgvSubject.DataSource = busSubject.getSubject(id);
                }
                else MessageBox.Show("Insert fall!", "Info");
            }
            else MessageBox.Show("Subject_name or Subject_mark is empty!\nInput data again, please.", "Info");

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {   
            if (txtSubjectName.Text != "" && txtSubjectMark.Text != "")
            {
                String id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
                if (busSubject.updateSubject(id,idSubject, txtSubjectName.Text, txtSubjectMark.Text))
                {
                    MessageBox.Show("Update successful", "Info");
                    tf1 = !tf1;
                    Lock_unlock1(tf1);
                    dgvSubject.DataSource = busSubject.getSubject(id);
                    // van in ra so diem cac mon của TK student có id
                   // dgvSubject.DataSource = busSubject.getSubjectbySubject_id(idSubject);  saiiiiiiiiiiiiiiiiiii
                }
                else MessageBox.Show("Update fall!", "Info");
            }
            else MessageBox.Show("Student Name or Email is empty!\nInput data again, please.", "Info");

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            if (busSubject.deleteSubject(id,idSubject))
            {
                MessageBox.Show("Delete successful", "Info");
                tf1 = !tf1;
                Lock_unlock1(tf1);
                dgvSubject.DataSource = busSubject.getSubject(id);
            }
            else MessageBox.Show("Delete fall!", "Info");   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {
            tf = tf1 = true;
            Lock_unlock(tf);
            Lock_unlock1(tf1);
            txtSubjectName.Text = "";
            txtSubjectMark.Text = "";
        }
        private void GUI_Subject_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dtbStudent.Rows.Count; i++)
            {
                cmbStudentName.Items.Add(dtbStudent.Rows[i]["name"].ToString());
                cmbStudentName.Text = dtbStudent.Rows[0]["name"].ToString();
            }
            String id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }

        private void dgvSubject_Click_1(object sender, EventArgs e)
        {
            if (tf)
            {
                int i = dgvSubject.CurrentRow.Index;
                //idSubject = int.Parse(dgvSubject[0, i].Value.ToString());
                idSubject = dgvSubject[0, i].Value.ToString();
                txtSubjectName.Text = dgvSubject[2, i].Value.ToString();
                txtSubjectMark.Text = dgvSubject[3, i].Value.ToString();
                txtSubjectName.Focus();

                tf1 = !tf1;
                Lock_unlock1(tf1);
            }
            else MessageBox.Show("Inserting!\nClick Reset to do another thing.", "Information");
        }

        private void cmbStudentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = dtbStudent.Rows[int.Parse(cmbStudentName.SelectedIndex.ToString())]["id"].ToString();
            dgvSubject.DataSource = busSubject.getSubject(id);
        }
    }
}
