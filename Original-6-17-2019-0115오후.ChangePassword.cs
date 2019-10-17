using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bankingapp
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }


        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();

            if (textBox2.Text != string.Empty || Password.Text != string.Empty || repass.Text != string.Empty)
            {
                userTable user1 = dbe.userTables.FirstOrDefault(a => a. UserName.Equals(usrtxt.Text));
            if (user1 != null)     
            {
                if (user1.Password.Equals(oldpass.Test))
                {
                    user1.Password = Password.Text;
                    dbe.SaveChanges();
                    MessageBox.Show("Password Change Successfully");
                }
                else
                {
                    MessageBox.Show("Password Incorrect");
                }
            }
        }
    }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }
    }
}
