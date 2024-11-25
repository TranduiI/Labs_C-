using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;


namespace Laba1
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

            if (textBox1.Text == "" || textBox2.Text == "")
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
                if (e.KeyChar == '0' && textBox1.Text.Length == 0) //Если в поле еще ничего не введено
                {
                    e.Handled = true; //то запрещаем вводить 0
                }
                else //если уже что-то есть
                {
                    return; //разрешаем

                }
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
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '0' && textBox2.Text.Length == 0) //
                {
                    e.Handled = true;
                }
                else
                {
                    return;

                }
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
            if (textBox1.Text == "" || textBox2.Text == "")
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
                if (e.KeyChar == '0' && textBox3.Text.Length == 0) //
                {
                    e.Handled = true;
                }
                else
                {
                    return;
                    
                }
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
            //if(Convert.ToDouble(textBox3.Text) >= 180)        //Заготовка проверки на то, что в поле Угла - нельзя ввести значение больше 180 градусов #Не работает
            //{
            //    e.Handled = true;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                MessageBox.Show("Вы выбрали " + radioButton.Text);
                return;
            };
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                MessageBox.Show("Вы выбрали " + radioButton.Text);
                return;
            };
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        public class Figura
        {
            double a;
            double b;
            double angle;
            double perim;
            double sq;


            public Figura(double A, double B, double ANGLE, bool rb1, bool rb2)
            {
                a = A;
                b = B;
                angle = Math.PI * ANGLE / 180.0;
                if(rb1 == true && rb2 == false)
                {
                    double d = Math.Cos(angle) * A;
                    double h = Math.Sin(angle) * A;
                    double c = (2 * d) + B;
                    perim = (2 * A) + B + c;
                    sq = ((B + c) / 2) * h;

                }
                else if (rb1 == false && rb2 == true)
                {
                    perim = (2 * A) + (2 * B);

                    sq = A * B * Math.Sin(angle);
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ни один из вариантов");
                    perim = 0;
                    sq = 0;
                }
            }
            public double A { get { return a; } }
            public double B { get { return b; } }
            public double ANGLE { get { return angle; } }
            public double PERIMETR { get { return perim; } }
            public double SQUARE { get { return sq; } }



        }
        //private Double PerSqTrap(Figura figura, out Double sq) /*Функция расчёта суммы ряда*/
        //{
           

           
        //   // double angle = Math.PI * alfa / 180.0;
        //    double d = Math.Cos(figura.ANGLE) * figura.A;
        //    double h = Math.Sin(figura.ANGLE) * figura.A;
        //    double c = (2 * d) + figura.B;
        //    double perim = (2* figura.A) +figura.B +c;
            
        //    sq = ((figura.B + c) / 2) * h;
            
        //    return perim;
        //}


        //private Double Square(Double a, Double b, Double alfa)
        //{
        //    double angle = Math.PI * alfa / 180.0;
        //    double d = Math.Cos(angle) * a;
        //    double h = Math.Sin(angle) * a;
        //    double c = (2 * d) + b;

        //    double square = ((b + c) / 2) * h;

        //    return square;
        //}

        //private Double PerSqPar(Figura figura, out Double sq) /*Функция расчёта суммы ряда*/
        //{ 
        //    double perim = (2 * figura.A) + (2 * figura.B);

        //    sq = figura.A * figura.B* Math.Sin(figura.ANGLE);

        //    return perim;
        //}



        private void button1_Click(object sender, EventArgs e)
        {

            Figura fig = new Figura(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), radioButton1.Checked, radioButton2.Checked == true);


            label3.Text = "Периметр: " + fig.PERIMETR + "\n" + "Площадь: " + fig.SQUARE;

            // Задаем значения для передачи методу Taylor и создаем переменную для контрольной проверки 
            //double perim, sq;
            //if (radioButton1.Checked == true)
            //{
            //    perim = PerSqTrap(fig, out sq);
            //    label3.Text = "Периметр: " + perim + "\n" + "Площадь: " + sq;
            //}


            //else if (radioButton2.Checked == true)
            //{
            //    perim = PerSqPar(fig, out sq);
            //    label3.Text = "Периметр: " + perim + "\n" + "Площадь: " + sq;
            //}
            //else
            //{
            //    MessageBox.Show("Вы не выбрали ни один из вариантов");
            //}







            //Альтернативный метод округления

            //int c = -(int)math.log10(acc);
            //string f = "g" + c.tostring();

            //label3.text = string.format("ответ:\n" + "cos(x) = {1:" + f + "}", arg, cos) + string.format("\n сумма ряда = {0:" + f + "}", sum) + "\nколичество членов ряда = " + n;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

