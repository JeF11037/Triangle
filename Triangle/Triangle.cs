using System;
using System.Windows.Forms;

namespace Triangle
{
    class Triangle
    {
        public double a;
        public double b;
        public double c;
        public double ha;
        public double hb;
        public double hc;
        public double alpha;
        public double beta;
        public double gamma;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        public Triangle(double A, double B, double C, double Ha, double Hb, double Hc)
        {
            a = A;
            b = B;
            c = C;
            ha = Ha;
            hb = Hb;
            hc = Hc;

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

        public string outputH(double h)
        {
            return Convert.ToString(h);
        }

        public double getBiggest() // Метод для получения наибольшей стороны
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

        public double SurfaceWithH(double h)
        {
            double s = 0;
            s = (a * h) / 2;
            return s;
        }

        public double GetH(double par) // Метод для получения значения высоты на основе данной стороны
        {
            double res;
            res = Surface() * 2 / par;
            return res;
        }

        public double GetAngle(double fside, double sside, double tside)
        {
            return Math.Round(Math.Acos((Math.Pow(fside, 2) + Math.Pow(sside, 2) - Math.Pow(tside, 2)) / (2 * fside * sside)) * (180 / Math.PI), 2);
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
                if ((a + b > c) && (b + c > a) && (c + a > b)) // Поменял формулу
                    return true;
                else return false;
            }
        }
    }
}
