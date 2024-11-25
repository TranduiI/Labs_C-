using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6A
{
    class Rectangle : Shape
    {
        protected double _side1, _side2;

        public Rectangle() : base()
        {
            _side1 = 0;
            _side2 = 0;
            _name = "Rectangle";
        }

        public Rectangle(double size1, double size2) : base()
        {
            _side1 = size1;
            _side2 = size2;
            _name = "Rectangle";
            _P = GetP();
            _S = GetS();
        }

        protected double GetP()
        {
            return (_side1 + _side2) * 2;
        }

        protected double GetS()
        {
            return _side1 * _side2;
        }
    }
}
