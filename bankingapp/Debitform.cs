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
using System.Data.Sql;
namespace bankingapp
{
    public  partial class Debitform : Form
    {  
   
        public Debitform()  
        {
            InitializeComponent();  

            loadcombo();
            loaddate();
        }

        private void loadcombo()
        {
            //throw new NotImplementedException();
            comboBox1.Items.Add("현금");
            comboBox1.Items.Add("카드");
            comboBox1.Items.Add("수표");
        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            date1b1.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void Debitform_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {  
                          
            banking_dbEntities dbe = new banking_dbEntities();
            newAccount nacc = new newAccount();
            debit dp = new debit();//debit dp
            dp.Date = date1b1.Text;
            dp.Account = Convert.ToDecimal(acctxt.Text);
            dp.Name = nametxt.Text;
            dp.OldBalance = Convert.ToDecimal(oldbaltxt.Text);
            dp.Mode = comboBox1.SelectedItem.ToString();
            dp.DebAmount = Convert.ToDecimal(DebAmount1.Text);
            dbe.debit.Add(dp);
           
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in dbe.userAccount where u.Account_No == b select u).FirstOrDefault();
            item.balance = item.balance - Convert.ToDecimal(DebAmount1.Text);
          
            try
            {
                dbe.SaveChanges();
                MessageBox.Show("Debit Money");
            }
            catch
            {
                //  throw new NotImplementedException();
                MessageBox.Show("Debit Money");

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in dbe.userAccount where u.Account_No == b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            oldbaltxt.Text = Convert.ToString(item.balance);  
        }
    }   
}
