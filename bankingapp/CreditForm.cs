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
    public partial class CreditForm : Form
    {  


        public CreditForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }
        private void loadmode()
        {
            //throw new NotImplementedException();
            ComboBox.Items.Add("현금");
            ComboBox.Items.Add("카드");
            ComboBox.Items.Add("수표");

        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            date1b1.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities context = new banking_dbEntities();
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.userAccount where u.Account_No == b select u).FirstOrDefault();//FirstOrDefault으로 시퀀스의 첫 번째 요소를 반환 합니다.

            nametxt.Text = item.Name;
            oldbaltxt.Text = Convert.ToString(item.balance);
        }  
                      
        private void Button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities context = new banking_dbEntities();
            newAccount acc = new newAccount();
            Deposit dp = new Deposit();
            dp.Date = date1b1.Text;
            dp.AccountNo = Convert.ToDecimal(acctxt.Text);
            dp.Name = nametxt.Text;
            dp.OldBalance = Convert.ToDecimal(oldbaltxt.Text);
            dp.Mode = ComboBox.SelectedItem.ToString();    
            dp.DipAmount = Convert.ToDecimal(amounttxt.Text);
            context.Deposit.Add(dp);
              
            decimal b = Convert.ToDecimal(acctxt.Text);
            var item = (from u in context.userAccount where u.Account_No == b select u).FirstOrDefault();
             
            item.balance = item.balance + Convert.ToDecimal(amounttxt.Text);
          
            try
            {
                context.SaveChanges();
                MessageBox.Show("Deposit Money Sucessfully");
            }
            catch
            {  
              //  throw new NotImplementedException();
                MessageBox.Show("Deposit Money Sucessfully");

            }

           // MessageBox.Show("Deposit Money Sucessfully");
        }

    }  
}    
