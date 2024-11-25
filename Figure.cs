using System;

namespace Figure1
{
    
    public class Figure
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
        public static void Main()
        {
            Figure fig = new Figure(4, 0, 1);
            Console.WriteLine(fig.ANGLE);
        }
    }
}






