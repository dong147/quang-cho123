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
    public partial class loginform : System.Windows.Forms.Form
    {
        public Staff currentUser = null;//khai bao tai khoan dang online 
        public loginform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string user = txtUsername.Text;
            //string pass = txtPassword.Text;
            //AdminModel model = new AdminModel();
            //currentUser = model.CheckLogin(user, pass);
            //if(currentUser==null)
            //{
            //    MessageBox.Show("login sai");
            //}
            //else
            //{
            //    MessageBox.Show("login success");
            //    this.Dispose();
              
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            AdminModel model = new AdminModel();
            currentUser = model.CheckLogin(user, pass);
            if (currentUser == null)
            {
                MessageBox.Show("login sai");
            }
            else
            {
                MessageBox.Show("login success");
                this.Dispose();

            }
        }
    }
}
