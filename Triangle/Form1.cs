using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gp = panel1.CreateGraphics();
        }

        Graphics gp;
        Pen p = new Pen(Brushes.Black, 2);

        Triangle tri = new Triangle();

        bool h_check = false;

        private void button1_Click(object sender, EventArgs e)
        {
            double r;

            listView1.Items.Clear();
            gp.Clear(Color.White);

            if (double.TryParse(textBox1.Text, out r))    
            {
                tri.a = Convert.ToDouble(textBox1.Text);
                listView1.Items.Add("Сторона: a");
                listView1.Items[0].SubItems.Add(tri.outputA());
            }

            if (double.TryParse(textBox2.Text, out r))
            {
                tri.b = Convert.ToDouble(textBox2.Text);
                listView1.Items.Add("Сторона: b");
                listView1.Items[1].SubItems.Add(tri.outputB());
            }

            if (double.TryParse(textBox3.Text, out r))
            {
                tri.c = Convert.ToDouble(textBox3.Text);
                listView1.Items.Add("Сторона: c");
                listView1.Items[2].SubItems.Add(tri.outputC());
            }

            tri.h = tri.GetH(tri.c);   

            if (h_check)
            {
                double c = tri.getBiggest();
                listView1.Items.Add("Высота: h");
                listView1.Items.Add("Площадь: s");
                listView1.Items.Add("Периметр: p");
                listView1.Items.Add("Существует ?");
                listView1.Items.Add("Тип");

                if (tri.ExistTriangle) { listView1.Items[6].SubItems.Add("Существует"); }
                else listView1.Items[6].SubItems.Add("Не существует");

                if (tri.ExistTriangle)
                {
                    listView1.Items[3].SubItems.Add(Convert.ToString(tri.outputH()));
                    listView1.Items[4].SubItems.Add(Convert.ToString(tri.Perimeter()));
                    listView1.Items[5].SubItems.Add(Convert.ToString(tri.Surface()));

                    if (c * c == tri.a * tri.a + tri.b * tri.b) { listView1.Items[7].SubItems.Add("Прямоугольный"); }
                    else if (c * c < tri.a * tri.a + tri.b * tri.b) { listView1.Items[7].SubItems.Add("Остроугольный"); }
                    else if (c * c > tri.a * tri.a + tri.b * tri.b) { listView1.Items[7].SubItems.Add("Тупоугольный"); }
                }
            }

            if (tri.ExistTriangle)
            {

                int a = Convert.ToInt32(tri.a);
                int b = Convert.ToInt32(tri.b);
                int c = Convert.ToInt32(tri.c);

                if (a == Convert.ToInt32(tri.getBiggest())) { a = Convert.ToInt32(tri.b); b = Convert.ToInt32(tri.c); c = Convert.ToInt32(tri.a); }
                else if (b == Convert.ToInt32(tri.getBiggest())) { a = Convert.ToInt32(tri.a); b = Convert.ToInt32(tri.c); c = Convert.ToInt32(tri.b); }

                Point p1 = new Point(5, 5);
                Point p2 = new Point(5 + c * 50, 5);

                bool equal_sides = false;

                if (c < b) { equal_sides = true; }

                int temp_a_x = 5;
                int temp_a_y = 5 + a * 50;

                int temp_b_x = 5 + c * 50;
                int temp_b_y = 5;

                if (equal_sides == false) { temp_b_x = temp_b_x - b * 50; } else { temp_b_y = temp_b_y + b * 50; }

                Point p_a = new Point(5, 5 + a * 50);
                Point p_b = new Point(5 + c * 50, 5 + b * 50);

                while (temp_a_x != temp_b_x) { temp_a_x++; temp_b_x--; }
                while (temp_a_y != temp_b_y) { temp_a_y--; if (equal_sides) { temp_b_y--; } else temp_b_y++; }

                Point p3 = new Point(temp_a_x, temp_a_y);

                gp.DrawLine(p, p1, p2);
                gp.DrawLine(p, p2, p3);
                gp.DrawLine(p, p3, p1);

                //gp.DrawLine(p, p1, p_a);
                //gp.DrawLine(p, p2, p_b);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            h_check = checkBox1.Checked;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
