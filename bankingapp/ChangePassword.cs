﻿using System;
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

            if (textBox1.Text != string.Empty || textBox3.Text != string.Empty || repass.Text !=  string.Empty)
            {
                userTable user1 = dbe.userTable.FirstOrDefault(a => a. UserName.Equals(usrtxt.Text));
                try
                {

                    MessageBox.Show("Password Change Successfully");

                }
                catch
                {
                    MessageBox.Show("Password Change Successfully");

                }
                if (user1 != null)      
            {
                if (user1.PassWord.Equals(textBox1.Text))
                {           
                    user1.PassWord = textBox3.Text;
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
