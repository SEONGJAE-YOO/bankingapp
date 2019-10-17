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
    public partial class Form1 : Form
    {
        bool isBold = false;      
        bool isltalic = false;              
        bool isUnderline = false;               

        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (isBold)
            {
                this.isBold = false;

                normalize();//이진 표현의 형식이 특정 유니코드 정규화 형식인 새 문자열을 반환합니다.
            }
            else
            {
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Bold | this.textRich.SelectionFont.Style);

                this.isBold = true;
            }
        }
          
        

        private void CopyItem_Click(object sender, EventArgs e)
        {
            this.textRich.Copy();
        }

        private void CutItem_Click(object sender, EventArgs e)
        {
            this.textRich.Cut();
        }

        private void PasteItem_Click(object sender, EventArgs e)
        {
            this.textRich.Paste();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            if (isltalic)
            {
                this.isltalic = false;

                normalize();
            }
            else
            {
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Italic | this.textRich.SelectionFont.Style);
                this.isltalic = true;
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            if (isUnderline)
            {                            //false이면
                this.isUnderline = false;// this.textRich.SelectionFont = new Font(textRich.SelectionFont,FontStyle.Regular);

                normalize();
            }      //SelectionFont으로
            else  //현재 텍스트 선택 영역 또는 삽입 지점의 글꼴을 가져오거나 설정 합니다.
            {  
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Underline | this.textRich.SelectionFont.Style);
                this.isUnderline = true;
            }
        }
        private void normalize()
        {
            this.textRich.SelectionFont = new Font(textRich.SelectionFont,FontStyle.Regular);
            //textRich으로 서식 있는 텍스트 상자의 현재 텍스트를 가져오거나 설정 합니다.
            if (isBold)
            {
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Bold |this.textRich.SelectionFont.Style);
            }
              
            if (isltalic)
            {
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Italic | this.textRich.SelectionFont.Style);
            }
            if (isUnderline)
            {
                this.textRich.SelectionFont = new Font(textRich.SelectionFont, FontStyle.Underline | this.textRich.SelectionFont.Style);
            }
        }
    }
}
