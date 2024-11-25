﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Laba4fixLib //библиотека
{
    public class ArrayLab  //создаем шаблонный класс массива
    {
        int row; //переменная строк
        int column; //переменная столбцов
        
        
        double[,] a; // а - двумерный массив

        public ArrayLab() //конструктор по умолчанию двумерного массива
        {
            column = 1;
            row = 1;
            a = new double[row,column]; //создаем двумерный массив 1х1 
        }

        public ArrayLab(int row, int column) //конструктор с размером двумерного массива
        {
            if (column <= 0||row<=0) //проверяем на корректность размера - строки и столбцы не равны/меньше нуля
                throw new Exception("Ошибка: размерность массива д.б. больше нуля!");

            this.column = column; // присваеваем локальному количеству столбцов переданное количество столбцов
            this.row = row; // -//- строк переданное кол-во строк
            a = new double[row,column]; //создаем двумерный массив переданной величины
        }
        public ArrayLab(double[,] arr)  // конструктор в который передается двумерный double массив
        {
            row = arr.GetUpperBound(0) + 1; // GetUpperBound(0) передает последний индекс в первом измерении двумерного массива (т.к индекс начинается с 0 добавляем 1)
            column = arr.Length / row; // делим количество ВСЕХ элементов на количество строк и получаем количество столбцов

            a = new double[row,column]; // и создаем массив той же размерности, что и полученный

            for (int i = 0; i < row; ++i) // смотрим значения текущей строки i пока не дойдем до последней
            {
                for (int j = 0; j < column; ++i) // а потом и текущего столбца j пока не дойдем до последнего
                {
                    a[i,j] = arr[i,j]; // передаем значение этого конкретного элемента(i, j) двуерного массива
                }
                    
            }
        }

        public static ArrayLab ArrayRandom(int row, int column,  double a, double b) //в конструктор передаем размер двумерного массива и диапазон создания рандомных чисел
        {
            ArrayLab arr = new ArrayLab(row,column); // создаем массив этого размера

            //определяем нижнюю границу диапазона
            if (a > b) //если а большее значение
            {
                double t = a; // то сохраняем его в памяти
                a = b; //делаем а меньшим значением
                b = t; //b делаем большим значением присвая ему сохраненное в памяти а 
            }

            Random r = new Random(); //инициализируем рандомайзер

            for (int i = 0; i < row; i++)// смотрим значения текущей строки i пока не дойдем до последней
            {
                for (int j = 0; j < column; j++) //а потом и текущего столбца j пока не дойдем до последнего
                {
                    arr[i,j] = r.NextDouble() * (b - a) + a; //и присваевыем конкретному элементу(i,j) двумерного массива рандомное значение в указанном диапазоне
                }
                
            }
            return arr; //возвращаем полученный двумерный массив с рандомными значениями
        }

        public static ArrayLab ArrayFromFile(string path) //конструктор с путем к файлу
        {

            char[] doubleSep = new char[] { ' ', ';'}; //задаем символы которые отделяют числа друг от друга
            
            ArrayLab arr = new ArrayLab(); //создаем стандартный двумерный массив

            try
            {

                
                string[] lines = File.ReadAllLines(path); //создаем массив из строк
                

                arr = new ArrayLab(lines.Length, lines[0].Split(doubleSep, StringSplitOptions.RemoveEmptyEntries).Length);
                //задаем двумерный массив с количиством строк равному количеству строк (длине одномерного массива lines - .Length),
                //и столбцов равному количеству символов(.Length)(отделенных друг от друга с помощью "Split(doubleSep",
                //и исключая пустые строки и строки из пробелов с помощью ",StringSplitOptions.RemoveEmptyEntries") в каждом элементе массива lines

                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." }; //делаем дополнительный формат считывания с double - теперь он считывается и с точкой

                for (int i = 0; i < arr.Row; i++) // в текущей строке i пока не дойдем до последней
                {
                    string[] temp = lines[i].Split(doubleSep, StringSplitOptions.RemoveEmptyEntries);//делаем отдельный массив символов,
                                                                            //куда передаем символы из lines по такому же принципу что и выше
                    
                    for (int j = 0; j < arr.Column; j++) //в текущем столбце j пока не дойдем до последнего
                    {
                        try //
                        {
                            arr[i, j] = double.Parse(temp[j]); // пытаемся записать в двумерный массив в элемент(i,j) конкретный символ с индексом j из temp[] с запятой (стандартная запись)
                        }
                        catch //если не удалось с запятой
                        {
                            arr[i, j] = double.Parse(temp[j], formatter); //считываем с точкой 
                        }
                    }

                }

                return arr; //возвращем двумерный массив
            }
            catch
            {
                throw new Exception("Ошибка: не удалось загрузить массив из файла: " + path);
            }




        }

        public int Column // получение количества столбцов двумерного массива
        {
            get
            {
                return column;
            }
            
        }
        public int Row // получение количества строк двумерного массива
        {
            get
            {
                return row;
            }

        }
        public double this[int i, int j]  // индексатор
        {
            get //для получения конкретного элемента двумерного массива
            {
                if (i >= 0 && i < row) //проверяем что индекс строки существует в нашем двумерном массиве и больше 0
                {
                    if(j >= 0 && j < column) //проверяем что индекс столбца существует в нашем двумерном массиве и больше 0
                    {
                        return a[i,j];
                    }
                    else throw new IndexOutOfRangeException(); //исключение если нет
                }
                else throw new IndexOutOfRangeException();// исключение если нет
            }
            set //для установки значения конкертному элементу массива
            {
                // тоже самое что и при получении
                if (i >= 0 && i < row)
                {
                    if (j >= 0 && j < column)
                    {
                        a[i,j] = value; //но теперь устанавлием переданное значение в конретный элемент(i,j) двумерного массива
                    }
                    else throw new IndexOutOfRangeException();
                }
                else throw new IndexOutOfRangeException();// исключение
            }
        }

        
        public static ArrayLab SummCol(ArrayLab A) //метод считающий сумму элементов одного столбца
        {

            ArrayLab sum = new ArrayLab(1, A.Column); // создаем одномерный массив (двумерный массив с одной строкой)


            for (int j = 0; j < A.Column; j++) //смотрим значения текущего столбца пока не дойдем до последнего
            {
                for(int i = 0; i < A.Row; i++) //смотрим значения текущей строки пока не дойдем до последней
                {
                    sum[0,j] += A[i,j];// и в элемент(0,j) приплюсовываем элемент из переданного двумерного массива A
                }
                 
            }
            return sum; //возвращаем результат в виде одномерного массива хранящего в каждом элементе сумму столбца переданного массива A
        }

        

        


        public string Output() //метод вывода массива
        {
            string o = ""; //создаем пустую строку
            for (int i = 0; i < row; i++) //смотрим значения текущей строки пока не дойдем до последней
            {

                for ( int j = 0; j < column; j++) //смотрим значения текущего столбца пока не дойдем до последнего
                {
                    o += this[i,j].ToString() + "; "; //записываем в строку текущий элемент(i,j) двумерного массива и добавляем точку с запятой
                }
                o += "\n"; //после того как записали одну строку двумерного массива, добавляем "\n" к нашей строке вывода и
                           //переходим к следующей строке двумерного массива - i++ в главном for
            }
            return o; //вывод массива в виде получившейся строки
        }


        public static ArrayLab DevideByMax(ArrayLab A) //статический контсруктор для Задания 2 -
                                  //деления всех элементов массива на наибольший по модулю элемент и получения нового двумерного массива
        {
            
            double max = 0; //создаем переменную хранящую наибольший по модулю элемент двумерного массива

            for (int i = 0; i < A.Row; i++) //смотрим эту строку двумерного массива пока не дойдем до последней
            {
                for (int j = 0; j < A.Column; j++)//столбец пока не дойдем до последнего
                {
                    if(Math.Abs(A[i,j]) > max) //если модуль элемента(i,j) двумерного массива больше max
                    {
                        max = Math.Abs(A[i, j]); //то перезаписываем его
                    }
                }
            }
            ArrayLab devBeMax = A;// создаем новый двумерный массив - который будет хранить разделенные на max элементы переданного

            for (int i = 0; i < devBeMax.Row; i++) //смотрим эту строку двумерного массива пока не дойдем до последней
            {
                for (int j = 0; j < devBeMax.Column; j++) //столбец пока не дойдем до последнего
                {
                    devBeMax[i,j] = devBeMax[i,j] / max; //записываем в элемент(i,j) нового двумерного массива больше max
                }
            }

            return devBeMax; //и возвращаем новый массив

        }




        

        

    }
    
}




