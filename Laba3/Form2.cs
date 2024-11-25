using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form2 : Form
    {

        Color cColor;// новые цвета фигуры
        //int size; // новый размер фигуры
        int speed; // новая скорость фигуры
        bool change = false;
        int cCombo;

        public Form2()
        {
            InitializeComponent();
            //button1.ForeColor = rcLColor = Properties.Settings.Default.rcLColor; // загрузка цвета фигуры
            //button2.ForeColor = rcRColor = Properties.Settings.Default.rcRColor; // при движении влево и вправо
            //rcSize = Properties.Settings.Default.rcSize; // загрузка размеров фигуры
            //trackBar2.Value = rcSize / 10; // установка ползунка, отвечающего за размер
            trackBar1.Value = rcSpeed = Properties.Settings.Default.rcSpeed;
            comboBox1.SelectedIndex = fCombo =  Properties.Settings.Default.fCombo;
            cCombo = Properties.Settings.Default.fCombo;// загрузка 




        }

        
        public bool Change // необходимость изменения фигуры
        {
            set
            {
                change = value;
            }
            get
            {
                return change;
            }
        }
        public int rcSpeed // скорость фигуры
        {
            set
            {
                speed = value;
                change = true;
            }
            get
            {
                return speed;
            }
        }
        //public int rcSize // размер фигуры
        //{
        //    set
        //    {
        //        size = value;
        //        change = true;
        //    }
        //    get
        //    {
        //        return size;
        //    }
        //}
        public Color fColor // цвет фигуры
        {
            set
            {
                cColor = value;
                change = true;
            }
            get
            {
                return cColor;
            }
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int Speed = trackBar1.Value;
            rcSpeed = Speed;

        }

        //private void trackBar2_Scroll(object sender, EventArgs e)
        //{
        //    rcSize = trackBar2.Value * 10;
        //}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                fColor = Color.Blue;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                fColor = Color.Red;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                fColor = Color.Yellow;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                fColor = Color.Violet;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                fColor = Color.Black;
            }
        }
            public int fCombo // обнуление combobox (работает плохо)
            { 
            set
            {
                cCombo = comboBox1.SelectedIndex;
                change = true;
            }
            get
            {
                return cCombo;
            }
        
    }
        private void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e) // сохранение изменений при закрытии окна с настройками
        {   
            
            Properties.Settings.Default.fColor = fColor;
            //Properties.Settings.Default.rcSize = rcSize;
            Properties.Settings.Default.rcSpeed = rcSpeed;
            Properties.Settings.Default.fCombo = fCombo;
            Properties.Settings.Default.Save();
            
        }
    }

}


        
    

