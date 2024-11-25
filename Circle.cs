using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6A
{
    class Circle : Shape
    {
        private double _radius;

        public Circle() : base()
        {
            _radius = 0;
            _name = "Circle";
        }

        public Circle(double radius) : base()
        {
            _radius = radius;
            _name = "Circle";
            _P = GetP();
            _S = GetS();
        }

        protected double GetP()
        {
            return Math.PI * _radius * 2;
        }

        protected double GetS()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
