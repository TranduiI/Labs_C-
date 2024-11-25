using System;
using System.Windows.Forms;


namespace Laba2
{
    
    public partial class Form1 : Form
    {

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e) //Метод для выведения ошибок (исключений) в отдельном окне
        {
            string errorMsg = e.Message + "\n"; //Тело ошибки 
            
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.OK, 
                MessageBoxIcon.Stop); //Вывод окна ошибки / title - заголовок 
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Метод реагирующий на изменение содержания в textBox1
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // Метод реагирующий на нажатие клавиши в поле textBox1
        {
            if (char.IsDigit(e.KeyChar)) // Если клавиша является цифрой то
            {
                //if (e.KeyChar == '0' && textBox1.Text.Length == 0) //Если в поле еще ничего не введено
                //{
                //    e.Handled = true; //то запрещаем вводить 0
                //}
                //else //если уже что-то есть
                //{
                return; //разрешаем

                //}
            }
            
            char aDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; // Создаем переменную aDecimalSeparator которой присваем значение точки '.' 
                if (e.KeyChar == '.' || e.KeyChar == ',') // Если кнопкой будет '.' или ',' то приравниваем ее к переменной aDecimalSeparator - '.'
                {
                    e.KeyChar = aDecimalSeparator;
                }
                if (e.KeyChar == aDecimalSeparator) //если кнопка равняется aDecimalSeparator - '.' то
                {
                    if (((TextBox)sender).Text.IndexOf(aDecimalSeparator) != -1) //если в поле textBox1 уже есть символ который подходит под aDecimalSeparator ('.' или ',') то
                    {
                        e.Handled = true; //его нельзя ввести
                    }//
                    
                    return; // можно ввести если его нет
                }
                if (Char.IsControl(e.KeyChar))
                {
                    if (e.KeyChar == (char)Keys.Enter) textBox2.Focus();
                    return;
                }
                e.Handled = true;
                   
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                //if (e.KeyChar == '0' && textBox2.Text.Length == 0) //
                //{
                //    e.Handled = true;
                //}
                //else
                //{
                return;
                //}
            }
            char aDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; // Создаем переменную aDecimalSeparator которой присваем значение точки '.' 
            if (e.KeyChar == '.' || e.KeyChar == ',') // Если кнопкой будет '.' или ',' то приравниваем ее к переменной aDecimalSeparator - '.'
            {
                e.KeyChar = aDecimalSeparator;
            }
            if (e.KeyChar == aDecimalSeparator) //если кнопка равняется aDecimalSeparator - '.' то
            {
                if (((TextBox)sender).Text.IndexOf(aDecimalSeparator) != -1) //если в поле textBox2 уже есть символ который подходит под aDecimalSeparator ('.' или ',') то
                {
                    e.Handled = true; //нельзя ввести 
                }//

                return; // можно ввести
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) textBox3.Focus();
                return;
            }
            e.Handled = true;

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                    return;
              
            }

            char aDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; // Создаем переменную aDecimalSeparator которой присваем значение точки '.' 
            if (e.KeyChar == '.' || e.KeyChar == ',') // Если кнопкой будет '.' или ',' то приравниваем ее к переменной aDecimalSeparator - '.'
            {
                e.KeyChar = aDecimalSeparator;
            }
            if (e.KeyChar == aDecimalSeparator) //если кнопка равняется aDecimalSeparator - '.' то
            {
                if (((TextBox)sender).Text.IndexOf(aDecimalSeparator) != -1) //если в поле textBox1 уже есть символ который подходит под aDecimalSeparator ('.' или ',') то
                {
                    e.Handled = true; //его нельзя ввести
                }//

                return; // если в поле его нет, то его ввести можно
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter) textBox3.Focus();
                return;
            }
            e.Handled = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
                DialogResult dialog = MessageBox.Show(
                 "Вы действительно хотите выйти из программы?",
                 "Завершение программы",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                );//вывод окна с предупреждением о закрытие формы
                if (dialog == DialogResult.Yes)
                {
                    this.Close();
                    //закрытие формы;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            double perim, sq;
            try
            {
                if (radioButton1.Checked == true)
                {
                    Trapezia T = new Trapezia(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    perim = T.Perimeter();
                    sq = T.Area();
                }
                else
                {
                    Parallelogram P = new Parallelogram(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                    perim = P.Perimeter();
                    sq = P.Area();
                }

                label3.Text = "Периметр: " + perim + "\n" + "Площадь: " + sq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
     
    }
    public abstract class Figure
    {
        double a,    //боковая сторона
                b,   //меньшее основание
            angle;   //острый угол

        public Figure(double a, double b, double angle)
        {
            A = a;
            B = b;
            ANGLE = angle;
        }

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value > 0) a = value;
                else
                {
                    throw new Exception("Ошибка: Боковая сторона задана неверно");
                }
            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (value > 0) b = value;
                else
                {
                    throw new Exception("Ошибка: Основание задано неверно.");
                }
            }

        }
        public double ANGLE
        {
            get
            {
                return angle;
            }
            set
            {
                if (value > 0 && value <= 90)
                    angle = Math.PI * value / 180.0;
                else
                    throw new Exception("Ошибка: Угол задан неверно.");
            }
        }

        public abstract double Area();
        public abstract double Perimeter();
    }

    class Parallelogram : Figure
    {
        public Parallelogram(double a, double b, double angle) : base(a, b, angle)
        { }
        public override double Area()
        {
            return A * B * Math.Sin(ANGLE);

        }

        public override double Perimeter()
        {
            return (2 * A) + (2 * B);

        }
    }
    class Trapezia : Figure
    {
        public Trapezia(double a, double b, double angle) : base(a, b, angle)
        { }
        public override double Area()
        {
            double d = Math.Cos(ANGLE) * A;
            double h = Math.Sin(ANGLE) * A;
            double c = (2 * d) + B;
            return h * (B + c) / 2;
        }

        public override double Perimeter()
        {
            double d = Math.Cos(ANGLE) * A;
            double c = (2 * d) + B;
            return (2 * A) + B + c;
        }
    }
}

