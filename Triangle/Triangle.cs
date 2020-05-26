using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Triangle
    {
        public double a;
        public double b;
        public double c;
        public double h;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        public Triangle(double A, double B, double C, double H)
        {
            a = A;
            b = B;
            c = C;
            h = H;
        }

        public Triangle()
        {

        }

        public string outputA()
        {
            return Convert.ToString(a);
        }

        public string outputB()
        {
            return Convert.ToString(b);
        }

        public string outputC()
        {
            return Convert.ToString(c);
        }

        public string outputH()
        {
            return Convert.ToString(h);
        }

        public double getBiggest()
        {
            double big;
            if (a > b && a > c) { big = a; }
            else if (b > a && b > c) { big = b; }
            else if (b == c) { big = a; }
            else if (a == c) { big = b; }
            else big = c;

            return big;
        }

        public double Perimeter()
        {
            double p = 0;
            p = a + b + c;
            return p;
        }

        public double Surface()
        {
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }

        public double SurfaceWithH()
        {
            double s = 0;
            s = (a * h) / 2;
            return s;
        }

        public double GetH(double par)
        {
            double res;
            res = Surface() * 2 / par;
            return res;
        }

        public double GetSetA
        {
            get
            { return a; }
            set
            { a = value; }
        }

        public double GetSetB
        {
            get
            { return b; }
            set
            { b = value; }
        }

        public double GetSetC
        {
            get
            { return c; }
            set
            { c = value; }
        }

        public bool ExistTriangle
        {
            get
            {
                if ((a + b > c) && (b + c > a) && (c + a > b))
                    return true;
                else return false;
            }
        }
    }
}
