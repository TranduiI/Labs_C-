using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        int w = 40, h = 40; //размеры фигуры
        int x = 1, y = 1; // текущая позиция фигуры
        int dx = 2; // скорость движения фигуры
        int combo;
        bool stop = false; // флаг для остановки фигуры
        Form2 form2 = new Form2(); // форма с настройками фигуры
        enum STATUS { Left, Right};  //направления движения
        STATUS flag;
        enum STATUS2 { Smalling, Widing } // статус шарика - уменьшение/увеличение размера
        STATUS2 flagSize; // 

        bool right; 
        SolidBrush brush; // кисть
        Color color; // цвет для фигуры
        Rectangle rc; //прямоугольная область, в которой находиться фигура

        private void button1_Click(object sender, EventArgs e)
        {
            stop = !stop; // изменение значения флага для остановки фигуры
            if (stop) button1.Text = "Старт";
            else button1.Text = "Стоп";

        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) // метод для закрытия формы (фокус наведен на кнопках)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.rcSpeed = 0;
            //Properties.Settings.Default.rcSize = w;
            Properties.Settings.Default.fColor = Color.White;
            Properties.Settings.Default.fCombo = -1;
            Properties.Settings.Default.Save();
            form2.Close();
            form2 = new Form2();
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.rcSpeed = dx;
            //Properties.Settings.Default.rcSize = w;
            Properties.Settings.Default.fColor = color;
            Properties.Settings.Default.fCombo = combo;

            Properties.Settings.Default.Save();
            form2 = new Form2();
            form2.Show();
        }




        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(400, 400);  // установка () размеров по умолчанию
            x = 150;                             //изначальное
            y = 150;//положение фигуры

            //w = h = form2.rcSize; // загрузка размеров фигуры
            brush = new SolidBrush(form2.fColor); // назначение цвета по умолчанию (на старте фигура движется направо)
            dx = form2.rcSpeed; // загрузка скорости фигуры
            
            //button1.Location = new Point(this.ClientSize.Width / 2 - button1.Size.Width / 2, this.ClientSize.Height - 2 * button1.Height); // установка положения кнопки "Стоп"
            //button2.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height); // установка положения кнопки "Настройки"
            color = form2.fColor; // загрузка цветов для фигуры
            combo = form2.fCombo;
            right = true;

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) // сохранение всех изменений перед закрытием окна
        {   
            Properties.Settings.Default.rcSpeed = 0;
            //Properties.Settings.Default.rcSize = w;
            Properties.Settings.Default.fColor = Color.White;
            Properties.Settings.Default.fCombo = 4;
            Properties.Settings.Default.Save();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) // событие перерисовки формы
        {
            e.Graphics.FillEllipse(brush, rc);  // рисуем закрашенный эллипс
        }
        private void LoadSettings()
        {
            dx = form2.rcSpeed; // загрузка измененной скорости фигуры
            color = form2.fColor; // загрузка измененных цветов фигуры
            //w = h = form2.rcSize; // загрузка измененных размеров фигуры
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.rcSpeed = 0;
            Properties.Settings.Default.rcSize = w;
            color = Color.White;
            Properties.Settings.Default.fColor = Color.White;
            Properties.Settings.Default.fCombo = -1;
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e) // метод для реализации движения фигуры
        {
            if (stop && !form2.Change) return; // если фигура не движется и нет изменений в окне настроек, ничего не происходит
            rc = new Rectangle(x, y, w, h); // размер прямоугольной области
            this.Invalidate(rc, true); // вызываем прорисовку области
            LoadSettings(); // загрузка изменений фигуры
            if (!stop)
            {

                if(flagSize == STATUS2.Smalling)
                {
                    w -= 2; //form2.rcSize -= 2 ; 
                    h -= 2;
                    y += 1; //стабилизация для оси y
                    x += 1; //стабилизация для оси x
                       
                }
                else if (flagSize == STATUS2.Widing)
                {
                    w += 2; //form2.rcSize += 2 ;
                    h += 2;
                    y -= 1;
                    x -= 1;
                }
                if (w <= 20)
                {
                    flagSize = STATUS2.Widing;
                }
                else if(w>=80)
                {
                    flagSize = STATUS2.Smalling;
                }
                
                
                if (flag == STATUS.Left)
                {
                    x -= dx;
                } // движение влево
                else if(flag == STATUS.Right)
                {
                    x += dx;
                } // движение вправо
                
                if (x <= dx/2) // при попадании в левый край
                {
                    flag = STATUS.Right;
                }
                else if (x >= (this.ClientSize.Width - w) - dx / 2) // при попадании в правый край
                {
                    flag = STATUS.Left;
                }


            }
            brush = new SolidBrush(color); // выбор цвета

            if (x + w > this.ClientSize.Width) x = this.ClientSize.Width - w; // если при нахождении у края формы менялись размеры фигуры,
            if (y + h > this.ClientSize.Height) y = this.ClientSize.Height - h; // происходит сдвиг в сторону от края
            rc = new Rectangle(x, y, w, h); // новая прямоугольная область
            this.Invalidate(rc, true);  // вызываем прорисовку этой области
            form2.Change = false; // изменение завершено
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e) // событие изменения размеров формы
        {
            //int minSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
            //this.ClientSize = new Size(minSize, minSize); // сохранение формой квадратного вида
            //button1.Location = new Point(this.ClientSize.Width / 2 - button1.Size.Width / 2, this.ClientSize.Height - 2 * button1.Height); // изменение положения кнопки "Стоп" (по центру)
            //button2.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height); // изменение положения кнопки "Настройки" (по центру)
        }


    }
}

        
    

