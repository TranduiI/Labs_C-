using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace laba6
{
    public partial class Form1 : Form
    {
        string fn = string.Empty; //глобальная переменная
        public Form1()
        {
            InitializeComponent();
            
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открытие файла";
            openFileDialog1.Multiselect = false;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранение файла";
        }
        private void SaveDocument() // сохранение информации из текстового редактора
        {
            
            try
            {
                StreamWriter sw = new StreamWriter(fn, false, Encoding.UTF8); //Запись символов в определенной кодировке (UTF8),
                                                                              //в путь fn который объявляется похже
                sw.Write(richTextBox1.Text); //записываем прочитанные из richTextBox1 символы
                sw.Close(); //закрываем стримрайтер
                
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла!", "Error", //обработка ошибок
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e) //Метод открытия файла
        {
            toolStripLabelStatus.Text = "Состояние: Открытие файла"; //пишем в статус баре то, что мы открываем файл 
            richTextBox2.Clear(); //очищаем вторую форму хранящую переведенные из двоичной кодировки символы или поиск слов
            openFileDialog1.FileName = String.Empty; // +++методичка
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //если файл выбран
            {
                fn = openFileDialog1.FileName; //записываем в глобальную переменную путь к нашему файлу
                try
                {
                    StreamReader sr = new StreamReader(fn, Encoding.UTF8); //чтение файлов в кодировке UTF8 из файла по пути fn
                    richTextBox1.Text = sr.ReadToEnd(); //читаем до конца
                    sr.Close(); //закрываем форму
                    this.Text = fn; // выведем имя файла в заголовок формы
                }
                catch 
                {
                    MessageBox.Show("Ошибка доступа к файлу!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//если не удалось прочитать файл
                }
            }
        }
        private void ToolStripMenuItemSave_Click(object sender, EventArgs e) //действия при нажатии кнопки сохранить
        {
            toolStripLabelStatus.Text = "Состояние: Сохранение файла"; //состояние - сохранение файла
            if (fn == string.Empty) //если файл был создан напрямую в форме/либо нет пути к файлу
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) //открываем окно выбора места для сохранения
                {
                    fn = saveFileDialog1.FileName; //и присываевыем глобальной переменной fn - место для сохрания файла
                }
            SaveDocument(); //сохраняем файл
        }
        private void ToolStripMenuItemSaveAs_Click(object sender, EventArgs e) //действия при нажатии сохранить как
        {
            //то же самое что и при обычном сохранении, но окно для выбора места показывается всегда
            toolStripLabelStatus.Text = "Состояние: Сохранить как ..."; //состояние - сохранить как,,,
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = saveFileDialog1.FileName;
                SaveDocument();
            }
        }
 
        private void Poisk(string sl, int param) //поиск по слову или сочетанию букв +++Из методички - доработанное
        {
            string slovo = ""; //слово считанное из richTextBox2
            bool flag; // переменная-флажок
            if (sl == "") //sl - слово или сочетание букв
            {
                return; // если  не задан, завершаем работу функции
            }
               
            richTextBox2.Clear(); //очищаем richTextBox2
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            // перебирает текст посимвольно
            {
                if (richTextBox1.Text[i] == ' ' ||
                richTextBox1.Text[i] == ',' ||
                richTextBox1.Text[i] == '!' ||
                richTextBox1.Text[i] == '?' ||
                richTextBox1.Text[i] == '.' ||
                richTextBox1.Text[i] == ':' ||
                richTextBox1.Text[i] == ';' ||
                richTextBox1.Text[i] == '-' ||
                richTextBox1.Text[i] == '(' ||
                richTextBox1.Text[i] == ')' ||
                richTextBox1.Text[i] == '\n')
                // если встретился разделитель
                {   
                    if (param == 1) //если ищем сочетание букв
                    {
                        if (slovo != "" && slovo.Length >= sl.Length) //то длинна сочетания букв не должна быть больше длины считанного слова
                        {
                            flag = true; //если да - устанавливаем флаг true
                            for (int j = 0; j < sl.Length; j++) //перебираем по длинне sl
                            {
                                if (slovo[j] != sl[j])// проверим, совпадают ли все буквы переданного сочетания и начала слова
                                {
                                    flag = false; //если нет - то флаг false
                                }

                            }
                            if (flag == true) richTextBox2.Text += slovo + "\n"; // если да, добавляем во второй редактор это слово
                        }
                        slovo = ""; // стираем слово
                    }
                    if(param == 2) //если ищем конкретное слово
                    {
                        if (slovo != "" && slovo.Length == sl.Length) //переданное слово должно быть того же размера что и считанное из richTextBox1
                        {
                            flag = true; //если да - устанавливаем флаг true
                            for (int j = 0; j < sl.Length; j++) //перебираем по длинне переданного слова
                            {
                                if (slovo[j] != sl[j]) // проверим, совпадают ли все буквы переданного слова и начала слова
                                {
                                    flag = false; //если нет - то флаг false
                                }
                                
                            }
                            if (flag == true) richTextBox2.Text += slovo + "\n"; // если да, добавляем во второй редактор это слово
                        }
                        slovo = ""; // стираем слово
                    }
                    
                }
                else //если разделитель не встретился
                {
                    slovo += richTextBox1.Text[i]; // то добавляем его в считанное слово
                }
            }
            // после выхода из цикла проверим последнее слово
            if (slovo != "" && slovo.Length >= sl.Length) //переданное слово или сочетание должно быть того же размера что и считанное из richTextBox1
            {
                flag = true; //если да - устанавливаем флаг true
                for (int j = 0; j < sl.Length; j++)//перебираем по длинне переданного слова
                {
                    if (slovo[j] != sl[j])// проверим, совпадают ли все буквы слога и начала слова
                    {
                        flag = false; //если нет то флаг false
                    }
                }
                if (flag == true) richTextBox2.Text += slovo + "\n"; // если да, добавляем во второй редактор это слово
            }


        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e) //при добавлении/убирании символа
        {
            toolStripLabelSymbols.Text = "Число знаков: " + richTextBox1.Text.Length; //выводим число знаков richTextBox1
            toolStripLabelLines.Text = "Строк: " + richTextBox1.Lines.Count(); //выводим число строк richTextBox1
        }


        private void ToolStripMenuItemBySymbols_Click(object sender, EventArgs e) //действия при нажатии на кнопку поиск по сочетанию букв
        {
            Form2 form2 = new Form2(); //открываем форму2
            form2.LabelText = "Введите сочетание букв: "; //задаем лэйбл на второй форме
            int param = 1; //параметр поиска по буквам (1) из Poisk
            form2.ShowDialog(); // вызов второй формы
            string b = form2.Info; // сочетание букв для поиска передаётся из второй формы
            Poisk(b, param); //и производим поиск по введенной строке и параметру
        }
        private void ToolStripMenuItemByWord_Click(object sender, EventArgs e) //поиск по слову
        {
            Form2 form2 = new Form2(); //открываем форму2
            form2.LabelText = "Введите слово: "; //задаем лэйбл на второй форме
            int param = 2;//параметр поиска - по слову (2) из Poisk
            form2.ShowDialog(); // вызов второй формы
            string sl = form2.Info; // слово для поиска передаётся из второй формы
            Poisk(sl,param);//и производим поиск по введенному слову и параметру
        }

        private void toolStripButtonConverter_Click(object sender, EventArgs e) //конвертер из двоичного кода в десятичный
        {
            richTextBox2.Clear(); //очищаем richTextBox2
            string rTS; // строка которая будет хранить считанное из richTextBox1 //если сломается - приравнять к "0"
                       

            int dec; //переменная которая будет хранить число в десятичной системе счисления
            bool flag = true; //флажок устанавливаем на true
            
            for(int i = 0; i< richTextBox1.Lines.Length; i++) //прогоняем по всем строкам richTextBox1
            {
                rTS = richTextBox1.Lines[i]; //присываевыем rTS значение конкретной строки 
                rTS = rTS.Trim(); //.Trim() - убирает все пробелы в начале и конце строки, а внутренние пробелы не трогает
                for (int j = 0; j < rTS.Length; j++) //прогоняем конкретную строку
                {   
                    if (rTS[j] != '0' && rTS[j] != '1') //если символ[j] НЕ 0 и НЕ 1
                    {
                        richTextBox2.Text += "-"+" \n"; //тогда выводим прочерк в richTextBox2
                        flag = false; //устанавливаем флаг на false
                        break; //и выходим из цикла - так как эта строка нас более не интересует (по условию задания)
                    }

                }
                if (flag == true) //если флаг остался true - значит все символы это 1 или 0
                {
                    //
                    if (rTS != string.Empty)
                    {
                        dec = Convert.ToInt32(rTS, 2); //конвертируем из двоичной системы счисления в десятичную
                        richTextBox2.Text += dec + " \n";
                    }
                    else
                    {
                        richTextBox2.Text += "-" + " \n"; //ставим прочерк
                    }
                    //



                    //try //дабы избежать ошибок при конвертации, если например строка пуста
                    //{
                    //  dec = Convert.ToInt32(rTS, 2); //конвертируем из двоичной системы счисления в десятичную
                    //  richTextBox2.Text += dec + " \n"; //выводим в richTextBox2
                    //
                    //}
                    //catch //
                    //{
                    //    if( rTS.Length >= 0 || rTS == string.Empty) //если строка пуста - то //
                    //    {
                    //        richTextBox2.Text += "-" + " \n"; //ставим прочерк
                    //    }
                    //
                    //}
                    //Раскомитить и заменить if-else блок этим, если не работает
                }
                flag = true; // и устанавливаем флаг обратно в true
            }
        }
    }
}
