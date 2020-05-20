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

            if (double.TryParse(textBox1.Text, out r))    
            {
                tri.a = Convert.ToDouble(textBox1.Text);
                label5.Text = tri.a.ToString();
            }

            if (double.TryParse(textBox2.Text, out r))
            {
                tri.b = Convert.ToDouble(textBox2.Text);
                label6.Text = tri.b.ToString();
            }

            if (double.TryParse(textBox3.Text, out r))
            {
                tri.c = Convert.ToDouble(textBox3.Text);
                label7.Text = tri.c.ToString();
            }

            tri.h = tri.Surface() * 2 / tri.c;

            if (h_check)
            {
                label8.Text = "S: "+tri.Surface()+" | P: "+ tri.Perimeter()+" | h: "+tri.h.ToString();
            }

            if (tri.ExistTriangle)
            {
                gp.Clear(Color.White);

                int a = Convert.ToInt32(tri.a);
                int b = Convert.ToInt32(tri.b);
                int c = Convert.ToInt32(tri.c);

                Point p1 = new Point(5, 5);
                Point p2 = new Point(c * 50, 5);

                int temp_a_x = 5;
                int temp_a_y = a * 50;

                int temp_b_x = c * 50 - b * 5;
                int temp_b_y = 50;

                while (temp_a_x != temp_b_x && temp_a_y != temp_b_y)
                {
                    temp_a_x++;
                    temp_a_y--;

                    temp_b_x--;
                    temp_b_y++;
                }

                Point p3 = new Point(temp_a_x, temp_a_y);

                gp.DrawLine(p, p1, p2);
                gp.DrawLine(p, p2, p3);
                gp.DrawLine(p, p3, p1);
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
    }
}
