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
    public partial class FDForm : Form
    {
        public FDForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();
        }
        private void loadmode()
        {
            comboBox1.Items.Add("현금");
            comboBox1.Items.Add("카드");
        }

        private void loaddate()
        {
            data1b1.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(accnotxt.Text);
            var accounts = dbe.userAccount.Where(x => x.Account_No == accno).SingleOrDefault();//SingleOrDefault()으로 시퀀스의 특정 단일 요소를 반환 합니다.
            FD fdform = new FD(); //FD fdform = new FD();
            fdform.Account_No = Convert.ToDecimal(accnotxt.Text);
            fdform.Mode = comboBox1.SelectedItem.ToString();
            fdform.Rupees = rupeestxt.Text;
            fdform.Period = Convert.ToInt32(periodtxt.Text);
            fdform.Interest_rate = Convert.ToDecimal(interesttxt.Text);
            fdform.Start_Date = DateTime.UtcNow.ToString("MM/dd/yyyy");
            fdform.Maturity_Date = (DateTime.UtcNow.AddDays(Convert.ToInt32(periodtxt.Text))).ToString("MM/dd/yyyy");
            fdform.Maturity_Amount = ((Convert.ToDecimal(rupeestxt.Text) * Convert.ToInt32(periodtxt.Text) * Convert.ToDecimal(interesttxt.Text)) /
                (100 * 12 * 30)) + (Convert.ToDecimal(rupeestxt.Text));
            dbe.FD.Add(fdform);
            decimal amount = Convert.ToDecimal(rupeestxt.Text);
            decimal totalamount = Convert.ToDecimal(accounts.balance);
            decimal fdammount = totalamount - amount;
            accounts.balance = fdammount;
           
            try
            {  
                dbe.SaveChanges();
                MessageBox.Show("FD Started Now");
            }
            catch
            {
              //  throw new NotImplementedException();
                MessageBox.Show("FD Started Now");

            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
