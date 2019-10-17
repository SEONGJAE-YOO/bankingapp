using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankingapp
{
    public partial class ViewFD : Form
    {
        BindingList<FDForm> b1;
        banking_dbEntities dbe;

        public ViewFD()                    
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            b1 = new BindingList<FDForm>();
            dbe = new banking_dbEntities();
            string date = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            MessageBox.Show(date);
            var item = dbe.FD.Where(a => a.Start_Date.Equals(date));
            dataGridView1.DataSource = item.ToList();//커넥터가 바인딩된 데이터 소스를 가져오거나 설정합니다.
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            b1 = new BindingList<FDForm>();
            dbe = new banking_dbEntities();
            string date = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            MessageBox.Show(date);
            var item = dbe.FD.Where(a => a.Start_Date.Equals(date));
            dataGridView1.DataSource = item.ToList();//커넥터가 바인딩된 데이터 소스를 가져오거나 설정합니다.
        }
    }
}
