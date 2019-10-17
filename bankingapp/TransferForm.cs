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
    public partial class TransferForm : Form
    {   
      

        public TransferForm()
        {
            InitializeComponent();
            loaddate();
        }

        private void loaddate()
        {
            date1b1.Text = DateTime.UtcNow.ToString("MM/dd/yyyy"); //현재날짜 가져온다
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(fromacctxt.Text);
            var item = (from u in dbe.userAccount where u.Account_No == b select u).FirstOrDefault();
            decimal b1 = Convert.ToDecimal(item.balance);
            decimal totalbal = Convert.ToDecimal(transfertxt.Text);//이체금액
            decimal transferacc = Convert.ToDecimal(desaccounttxt.Text);
            if (b1 > totalbal)                              
            {
                userAccount item2 = (from u in dbe.userAccount where u.Account_No == transferacc select u).FirstOrDefault();

                item2.balance = item2.balance + totalbal;
                item.balance = item.balance - totalbal;
                  //dbe.SaveChanged();
                Transfer transfer = new Transfer(); //Transfer transfer = new
                transfer.Account_No = Convert.ToDecimal(fromacctxt.Text);
                transfer.ToTransfer = Convert.ToDecimal(desaccounttxt.Text);//입금계좌번호
                transfer.Date = DateTime.UtcNow.ToString();
                transfer.Name = nametxt.Text;  
                transfer.balance = Convert.ToDecimal(amounttxt.Text);//db에 있는잔액을 가져온다

                dbe.Transfer.Add(transfer);
                dbe.SaveChanges();
                try
                {
                    dbe.SaveChanges();
                    MessageBox.Show("Transfer Money Successfully");
                }
                catch
                {
                    //  throw new NotImplementedException();
                    MessageBox.Show("Transfer Money Successfully");

                }              

            }
        }                     

        private void Transfertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Amounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(fromacctxt.Text);
            var item = (from u in dbe.userAccount where u.
                        Account_No ==b select u).FirstOrDefault();
            nametxt.Text = item.Name;
            amounttxt.Text = Convert.ToString(item.balance);
        }

      
    }
}
