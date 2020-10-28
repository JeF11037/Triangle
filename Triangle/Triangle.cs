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
        public double s;
        public double p;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
            p = Perimeter();
            s = Surface();
            ha = GetH(a);
            hb = GetH(b);
            hc = GetH(c);
            alpha = GetAngle(a, b, c);
            beta = GetAngle(a, c, b);
            gamma = GetAngle(c, b, a);
            
        }

        public Triangle(double side, double anglef, double angles, int none)
        {
            a = side;
            b = GetSideBySideAndTwoAngles(side, (180 - anglef - angles), anglef);
            c = GetSideBySideAndTwoAngles(a, angles, anglef);

        }

        public Triangle(double side, double h, string name)
        {
            switch (name)
            {
                case "a":
                    a = side;
                    ha = GetH(a);
                    s = SurfaceWithH(a, ha);
                    break;
                case "b":
                    b = side;
                    hb = GetH(b);
                    s = SurfaceWithH(b, hb);
                    break;
                case "c":
                    c = side;
                    ha = GetH(c);
                    s = SurfaceWithH(c, hc);
                    break;

            }
        }

        public Triangle()
        {
        }

        public void ClearValues()
        {
            a = 0;
            b = 0;
            c = 0;
            ha = 0;
            hb = 0;
            hc = 0;
            alpha = 0;
            beta = 0;
            gamma = 0;
            s = 0;
            p = 0;
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

        public double GetSideBySideAndTwoAngles(double side, double anglef, double angles)
        {
            double result = 0;

            result = (side * Math.Sin(anglef)) / Math.Sin(angles);

            return result;
        }

        public double Perimeter()
        {
            p = a + b + c;
            return Math.Round(p, 2);
        }

        public double Surface()
        {
            p = (a + b + c) / 2;
            s = Math.Round(Math.Sqrt((p * (p - a) * (p - b) * (p - c))), 2);
            return s;
        }

        public double SurfaceWithH(double side, double h)
        {
            return Math.Round(((side * h) / 2), 2);
        }

        public double GetH(double side) // Метод для получения значения высоты на основе данной стороны
        {
            return Math.Round((Surface() * 2 / side), 2);
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
