using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6A
{
    class Shape
    {
        protected double _S;
        protected double _P;
        protected string _name;

        public Shape()
        {
            _S = 0;
            _P = 0;
            _name = "No name";
        }

        public void Show()
        {
            Console.WriteLine($"Shape:");
            Console.WriteLine($"\tName: {_name}");
            Console.WriteLine($"\tPerimetr: {_P}");
            Console.WriteLine($"\tSquare: {_S}");
        }

        public double S
        {
            get
            {
                return _S;
            }
        }

        public double P
        {
            get
            {
                return _P;
            }
        }

        public string NameShape
        {
            get
            {
                return _name;
            }
        }
    }
}

