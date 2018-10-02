using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<Question> list = null;
        public Staff user = null;
        private bool addflag = false;
        private bool addCheck = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginform lg = new loginform();
            lg.ShowDialog();
            user = lg.currentUser;
            if(user!=null)
              this.Text = "WELCOME TO : " + user.UserName;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            AdminModel ad = new AdminModel();
            if(ad.CheckExist(id)==false)
            {
                MessageBox.Show("Id question Existed");
            }
            else
            {
                addCheck = true;
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if(!addflag)
            {
                ResetControl();
                btnADD.Text = "Save";
            }
            else
            {
                if(addCheck)
                {
                    string id = txtID.Text;
                    string A = txtA.Text;
                    string B = txtB.Text;
                    string C = txtC.Text;
                    string D = txtD.Text;
                    string sid = cbSubject.SelectedItem.ToString();
                    string crr = "";
                    string content = RtxtContent.Text;
                    if (sid.Equals("english"))
                        sid = "TN1";
                    if (sid.Equals("match"))
                        sid = "TN2";
                    if (sid.Equals("history"))
                        sid = "TN3";
                    if (rdA.Checked)
                        crr = "_a";
                    if (rdB.Checked)
                        crr = "_b";
                    if (rdC.Checked)
                        crr = "_c";
                    if (rdD.Checked)
                        crr = "_d";
                    AdminModel dt = new AdminModel();
                    if (dt.Addquestion(id, content, A, B, C, D, crr, sid))
                        MessageBox.Show("Add new success");
                    else
                        MessageBox.Show("FAILED");
                    btnADD.Text = "Add";
                    ResetControl();
                }
            }
            addflag = !addflag;
        }
        private void ResetControl()
        {
            txtID.Text = "";
            txtID.ReadOnly = false;
            RtxtContent.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            cbSubject.Text = "";
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            AdminModel ad = new AdminModel();
            if (ad.DeleteQuestion(id) == true)
            {
                dataGridView1.DataSource = ad.GetQuestions();
                resetGUI();
                MessageBox.Show("delete question sucess");

            }
            else
                MessageBox.Show("failed");
        }

        private void resetGUI()
        {
            txtID.Text = "";
            RtxtContent.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            cbSubject.Text = "";
            rdA.Checked = false;
            rdB.Checked = false;
            rdC.Checked = false;
            rdD.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string subject = cbSubject.Text;
            string content = RtxtContent.Text;
            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;
            string d = txtD.Text;
            string correct = "";
            if (rdA.Checked)
                correct = "_a";
            if (rdB.Checked)
                correct = "_b";
            if (rdC.Checked)
                correct = "_c";
            if (rdD.Checked)
                correct = "_d";
            AdminModel ad = new AdminModel();
            if (ad.UpdateQuestion(id, subject, content, correct, a, b, c, d))
            {
                dataGridView1.DataSource = ad.GetQuestions();
                resetGUI();
                MessageBox.Show("UPDATE QUESTION SUCCES", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
                MessageBox.Show("Update fail");
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            AdminModel ad = new AdminModel();
            dataGridView1.DataSource = ad.GetQuestions();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtID.ReadOnly = true;
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            RtxtContent.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtA.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtC.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtD.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string asw = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (asw.Equals("_a"))
            {
                rdA.Checked = true;
            }
            if (asw.Equals("_b"))
            {
                rdA.Checked = true;
            }
            if (asw.Equals("_c"))
            {
                rdA.Checked = true;
            }
            if (asw.Equals("_d"))
            {
                rdA.Checked = true;
            }
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreatExam_Click(object sender, EventArgs e)
        {
            string examcode = txtExamcode.Text;
            string date = dtDate.Text;
            ManageExam model = new ManageExam();
            if (model.AddNewExam(examcode, date))
            {
                foreach (var item in list)
                {
                    model.AddExamDetail(examcode, item.ID);
                }
                MessageBox.Show("Add New Success");
            }
            else
                MessageBox.Show("Add Failed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageExam md = new ManageExam();
            string type = cbSubjec1.SelectedItem.ToString();
            if (type.Equals("english"))
                type = "TN1";
            if (type.Equals("macth"))
                type = "TN2";
            if (type.Equals("history"))
                type = "TN3";
            list = md.GetQuestions(type);
            MessageBox.Show("Load Questions Success");
            btnCreatExam.Enabled = true;


        }

        private void btncheck_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
