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
    public partial class Menu : Form
    {
        public Menu()         
        {  
            InitializeComponent();
        }
           
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
             newAccount newacc = new newAccount();
            newacc.ShowDialog();  
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UpdationForm up = new UpdationForm();
            up.ShowDialog();
         
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CustomerList C1 = new CustomerList();
            C1.ShowDialog();
       
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CreditForm crdfrm = new CreditForm();
            crdfrm.ShowDialog();
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Debitform dpf = new Debitform();
            dpf.ShowDialog();
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            TransferForm Tf = new TransferForm();
            Tf.ShowDialog();
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FDForm fds = new FDForm();
            fds.ShowDialog();
        }  

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            balanceSheet bls = new balanceSheet();
            bls.ShowDialog();
        }

        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ViewFD viewFD = new ViewFD();
            viewFD.ShowDialog();
        }

        private void ToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();  
        }

        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TransferForm t1 = new TransferForm();
            t1.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Calculator c1 = new Calculator();
            c1.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)     
        {
            CustomerList c2 = new CustomerList();
            c2.ShowDialog();
        }

      

       private void Button2_Click_1(object sender, EventArgs e)
        {
            Form1 n1 = new Form1();
            n1.ShowDialog();
        }
    }
}
  