using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace bankingapp
{
    public partial class newAccount : Form
    {
        string gender = string.Empty;
        string m_status = string.Empty;
        decimal no;
        banking_dbEntities BSE;
        MemoryStream ms;

        public newAccount()
        {
            InitializeComponent();
            loaddate();

            loadaccount();
            loadstate();
        }

        private void loaddate()
        {
            date1b1.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void loadaccount()
        {
            BSE = new banking_dbEntities();
            var item = BSE.userAccount.ToArray();
            no = item.LastOrDefault().Account_No + 1;
            accnotext.Text = Convert.ToString(no);
        }

        private void loadstate()
        {
            comboBox1.Items.Add("한국");
            comboBox1.Items.Add("미국");
            comboBox1.Items.Add("중국");
            comboBox1.Items.Add("베트남");
            comboBox1.Items.Add("일본");
        }


        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loaddate(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            date1b1.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opebdlg = new OpenFileDialog();
            if (opebdlg.ShowDialog() == DialogResult.OK)//대화상자의 반환 값을 나타내는식별자를 지정 
            {
                Image img = Image.FromFile(opebdlg.FileName);//지정된 파일에서 Image를 만듭니다.
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (maleradio.Checked)
            {
                gender = "male";
            }
            else if (femalereadio.Checked)
            {
                gender = "female";
            }
            if (marriedradio.Checked)
            {
                m_status = "married";
            }
            else if (unmarriedradio.Checked)
            {
                m_status = "Un-Married";
            }

            BSE = new banking_dbEntities();
            userAccount acc = new userAccount();
            acc.Account_No = Convert.ToDecimal(accnotext.Text);
            acc.Name = nametxt.Text;
            acc.DOB = dateTimePicker1.Value.ToString();
            acc.PhoneNo = phonetxt.Text;
            acc.Address = addtxt.Text;
            acc.District = disttxt.Text;
            acc.State = comboBox1.SelectedItem.ToString();
            acc.Gender = gender;
            acc.maritial_status = m_status;
            acc.balance = Convert.ToDecimal(balancetxt.Text);
            acc.Date = date1b1.Text;
            acc.Picture = ms.ToArray();
            // BSE = SaveChanges();
            BSE.userAccount.Add(acc);
           // MessageBox.Show("file saved");

              try

            {

               // BSE = SaveChanges();
                MessageBox.Show("file saved");
            }

            catch

            {
                MessageBox.Show("file saved");
            }

        }      
           
       
        }
    }

