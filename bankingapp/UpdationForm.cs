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
using System.Data.SqlClient;

namespace bankingapp  
{
    public partial class UpdationForm : Form
    {
        banking_dbEntities dbe;  
        MemoryStream mss;
        BindingList<userAccount> bi;//데이터 바인딩을 지원하는 제네릭 컬렉션을 제공합니다.

        public UpdationForm()
        {
            InitializeComponent();
            loadstate();
        }
        private void loadstate()
        {
            comboBox1.Items.Add("한국");
            comboBox1.Items.Add("미국");
            comboBox1.Items.Add("중국");
            comboBox1.Items.Add("베트남");
            comboBox1.Items.Add("일본");
        }

        private void UpdationForm_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            bi = new BindingList<userAccount>();
            dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(acctxt.Text);
            var item = dbe.userAccount.Where(a => a.Account_No == accno);
            foreach (var item1 in item)
            {                   
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            bi = new BindingList<userAccount>();
            dbe = new banking_dbEntities();
            var item = dbe.userAccount.Where(a => a.Name == nametxt.Text);
            foreach (var item1 in item)
            {
                bi.Add(item1);  
            }
            dataGridView1.DataSource = bi;
        }    

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
          
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }  
          
        private void Button5_Click(object sender, EventArgs e)
        {  //이미지 불러올때 씀
            OpenFileDialog opebdlg = new OpenFileDialog();
            if (opebdlg.ShowDialog() == DialogResult.OK)//대화상자의 반환 값을 나타내는식별자를 지정 
            {
                Image img = Image.FromFile(opebdlg.FileName);
                pictureBox1.Image = img;
                mss = new MemoryStream();
                img.Save(mss, img.RawFormat);

            }
        }

        private void Statetxt_SelectedIndexChanged(object sender, EventArgs e)
        {  

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try

            {

                bi.RemoveAt(dataGridView1.SelectedRows[0].Index);  //RemoveAt으로 List<T>의 지정된 인덱스에 있는 요소를 제거합니다.
            dbe = new banking_dbEntities();
            decimal a = Convert.ToDecimal(acctxt.Text);
            userAccount acc = dbe.userAccount.First(s => s.Account_No.Equals(a));//db불러옴
            dbe.userAccount.Remove(acc);//db 제거 해준다
            dbe.SaveChanges();  //db 변경해준다
            //MessageBox.Show("file saved");
            
                // BSE = SaveChanges();
                MessageBox.Show("file saved");
            }

            catch

            {
                MessageBox.Show("file saved");
            }

        }

       

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = dbe.userAccount.Where(a => a.Account_No == accno).FirstOrDefault();
            acctxt.Text = item.Account_No.ToString();
            nametxt.Text = item.Name;
            phonetxt.Text = item.PhoneNo;
            addresstxt.Text = item.Address;
            byte[] img = item.Picture;
            MemoryStream mss = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(mss);
            disttxt.Text = item.District;
            comboBox1.Text = item.State;  
            dataGridView1.ForeColor = Color.Black;
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.White; this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            //다른 셀 스타일 속성이 설정되어 있지 않은 경우 DataGridView의 셀에 적용할 기본 셀 스타일을 가져오거나 설정합니다.
            //this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
            //this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            if (item.Gender == "male")
            {
                maleradio.Checked = true;
            }
            else if (item.Gender == "female")
            {
                famaeradio.Checked = true;
            }
            if (item.maritial_status == "married")
            {
                maleradio.Checked = true;
            }
            else if (item.maritial_status == "unmarried")
            {
                unmarriedradio.Checked = true;
            }
        }
    }
}
