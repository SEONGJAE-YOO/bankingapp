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
    public partial class balanceSheet : Form
    {  
        public balanceSheet()
        {
            InitializeComponent();
        }    

        private void Button1_Click(object sender, EventArgs e)
        {    
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(textBox1.Text);
            var item = (from u in dbe.debit where u.Account == b select u);
           DataGridView1.DataSource = item.ToList();
            var item1 = (from u in dbe.Deposit where u.AccountNo == b select u);
            DataGridView2.DataSource = item1.ToList();
            var item2 = (from u in dbe.Transfer where u.Account_No == b select u);
            DataGridView3.DataSource = item2.ToList();
        }
    }  
}
