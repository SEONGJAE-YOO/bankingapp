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
    public partial class CustomerList : Form
    {  
        public CustomerList()
        {
            
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;//AutoGenerateColumns으로 열을 자동으로 만들지 여부를 나타내는 값을 가져오거나 설정 합니다.
            banking_dbEntities bs = new banking_dbEntities();    
            var item = bs.userAccount.ToList();
            dataGridView1.DataSource = item;
        }
    }
}
