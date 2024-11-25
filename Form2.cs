using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6
{
    public partial class Form2 : Form
    {
        public string Info
        // свойство для передачи буквы или слога в главную форму
        {
            get
            {
                return textBox1.Text;
            }
        }
        public string LabelText
        {
            set
            {
                label1.Text = value;
            }
        }
        public int LabelTag
        {
            set
            {
                label1.Tag = value; 
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back) // BackSpase разрешён
                    return;
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.PerformClick();
                }
            }

            
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsControl(e.KeyChar))
            {
                if(e.KeyChar == (char)Keys.Enter)
                {
                    button1.PerformClick();
                }
            }
        }
    }
}
