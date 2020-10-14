using System;
using System.Drawing;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Инициализация Form1
            gp = panel1.CreateGraphics(); // Указываем полотно для рисования треугольника
        }

        Graphics gp; // Экземпляр класса Graphics
        Pen p = new Pen(Brushes.Black, 2); // Экземпляр класса Pen cо свойствами черный цвет и ширина 2

        Triangle tri = new Triangle(); // Экземпляр класса Triangle

        bool h_check = true; // Переменная типа bool для проверки состояния checkBox1

        private void button1_Click(object sender, EventArgs e)
        {
            double r; // временная переменная типа double для метода TryParse

            listView1.Items.Clear(); // Убираем лишние элементы в listView1
            gp.Clear(Color.White); // Убираем лишние точки, линии, фигуры на полотне

            listView1.Items.Add("Сторона: a"); // Добавляем в Поле listView1 сторону a
            listView1.Items.Add("Сторона: b"); // Добавляем в Поле listView1 сторону b
            listView1.Items.Add("Сторона: c"); // Добавляем в Поле listView1 сторону c

            if (double.TryParse(textBox1.Text, out r)) // Проверка на корректный ввод стороны a
            {
                tri.a = Convert.ToDouble(textBox1.Text); // Добавляем значение переменной a экземпляра tri введенного пользователя
                listView1.Items[0].SubItems.Add(tri.outputA()); // Добавляем в Значение listView1 стороны a значение переменной a экземпляра tri
            }

            if (double.TryParse(textBox2.Text, out r)) // Проверка на корректный ввод стороны b
            {
                tri.b = Convert.ToDouble(textBox2.Text); // Добавляем значение переменной b экземпляра tri введенного пользователя
                listView1.Items[1].SubItems.Add(tri.outputB()); // Добавляем в Значение listView1 стороны b значение переменной a экземпляра tri
            }

            if (double.TryParse(textBox3.Text, out r)) // Проверка на корректный ввод стороны c
            {
                tri.c = Convert.ToDouble(textBox3.Text); // Добавляем значение переменной c экземпляра tri введенного пользователя
                listView1.Items[2].SubItems.Add(tri.outputC()); // Добавляем в Значение listView1 стороны c значение переменной a экземпляра tri
            }

            tri.ha = tri.GetH(tri.a);
            tri.hb = tri.GetH(tri.b);
            tri.hc = tri.GetH(tri.c); // Добавляем значение переменной h экземпляра tri полученный результатом метода GetH в качестве стороны задаем c

            tri.alpha = tri.GetAngle(tri.b, tri.a);
            tri.beta = tri.GetAngle(tri.a, tri.b);
            tri.gamma = 180 - tri.alpha - tri.beta;

            if (textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                textBox4.Text = tri.ha.ToString();
                textBox5.Text = tri.hb.ToString();
                textBox6.Text = tri.hc.ToString();
            }

            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                textBox1.Text = tri.a.ToString();
                textBox2.Text = tri.b.ToString();
                textBox3.Text = tri.c.ToString();
            }

            double a_ = tri.a;
            double b_ = tri.b;
            double c_ = tri.c;

            double alpha_ = tri.alpha;
            double beta_ = tri.beta;
            double gamma_ = tri.gamma;


            if (a_ == tri.getBiggest()) { tri.c = a_; tri.a = b_; tri.b = c_; } // Перестановка значений для удобства по принципу c равно большей стороне а остальные меньшей
            else if (b_ == tri.getBiggest()) { tri.c = b_; tri.a = c_; tri.b = a_; }

            if (h_check) // Проверка состояния checkBox1 при помощи переменной h_check
            {
                listView1.Items.Add("Высота: h(a)"); // Добавляем в Поле listView1 высоту h
                listView1.Items.Add("Высота: h(b)");
                listView1.Items.Add("Высота: h(c)");
                listView1.Items.Add("Площадь: s"); // Добавляем в Поле listView1 площадь s
                listView1.Items.Add("Периметр: p"); // Добавляем в Поле listView1 периметр p
                listView1.Items.Add("Синус: ");
                listView1.Items.Add("Косинус: ");
                listView1.Items.Add("Тангенс: ");
                listView1.Items.Add("Альфа: ");
                listView1.Items.Add("Бета: ");
                listView1.Items.Add("Гамма: ");
                listView1.Items.Add("Существует ?"); // Добавляем в Поле listView1 правильность треугольника
                listView1.Items.Add("Тип"); // Добавляем в Поле listView1 тип треугольника

                if (tri.ExistTriangle) { listView1.Items[14].SubItems.Add("Да"); } // Проверка на наличие правильности треугольника методом экземпляра tri ExistTriangle. В случае истинны добавляем в Значение listView1 "Существует"
                else listView1.Items[14].SubItems.Add("Нет"); // В ином случае добавляем в Значение listView1 "Не существует"

                if (tri.ExistTriangle) // Проверка на правильность треугольника
                {
                    listView1.Items[3].SubItems.Add(Convert.ToString(tri.outputH(tri.ha))); // Добавляем в Значение listView1 высоты h значение переменной h экземпляра tri
                    listView1.Items[4].SubItems.Add(Convert.ToString(tri.outputH(tri.hb)));
                    listView1.Items[5].SubItems.Add(Convert.ToString(tri.outputH(tri.hc)));
                    listView1.Items[7].SubItems.Add(Convert.ToString(tri.Perimeter())); // Добавляем в Значение listView1 периметра его значение экземпляра tri
                    listView1.Items[6].SubItems.Add(Convert.ToString(tri.Surface())); // Добавляем в Значение listView1 площади его значение экземпляра tri

                    listView1.Items[8].SubItems.Add(Convert.ToString(tri.sin));
                    listView1.Items[9].SubItems.Add(Convert.ToString(tri.cos));
                    listView1.Items[10].SubItems.Add(Convert.ToString(tri.tan));
                    listView1.Items[11].SubItems.Add(Convert.ToString(tri.alpha));
                    listView1.Items[12].SubItems.Add(Convert.ToString(tri.beta));
                    listView1.Items[13].SubItems.Add(Convert.ToString(tri.gamma));

                    if (tri.c * tri.c == tri.a * tri.a + tri.b * tri.b) { listView1.Items[15].SubItems.Add("Прямоугольный"); } // Добавляем в Значение listView1 тип "Прямоугольный" если квадрат большей стороны равно суммы квадратов остальных сторон
                    else if (tri.c * tri.c < tri.a * tri.a + tri.b * tri.b) { listView1.Items[15].SubItems.Add("Остроугольный"); } // Добавляем в Значение listView1 тип "Остроугольный" если квадрат большей стороны меньше суммы квадратов остальных сторон
                    else if (tri.c * tri.c > tri.a * tri.a + tri.b * tri.b) { listView1.Items[15].SubItems.Add("Тупоугольный"); } // Добавляем в Значение listView1 тип "Тупоугольный" если квадрат большей стороны больше суммы квадратов остальных сторон
                }
            }

            if (tri.ExistTriangle) // Проверка правильности треугольника для отрисовки на полотне
            {
                int a = Convert.ToInt32(tri.a); // Создаем переменную стороны a типа int 
                int b = Convert.ToInt32(tri.b); // Создаем переменную стороны b типа int 
                int c = Convert.ToInt32(tri.c); // Создаем переменную стороны c типа int 

                Point p1 = new Point(5, 5); // Задаем первую точку с координатами x равно 5 y равно 5
                Point p2 = new Point(5 + c * 50, 5); // Задаем второу точку с координатами x равно сумме 5 и произведения стороны c и 50 y равно 5

                bool equal_sides = false; // Создаем переменную типа bool для проверки равнобедренного треугольника

                bool check_equal = false;
                if (b == a)
                {
                    check_equal = true;
                }

                if (c < b && c < a) { equal_sides = true; } // Задаем значение переменной equal_sides на true в случае если стороны не равны
                if (check_equal) { if (c > a && c > b) { equal_sides = true; } }

                int temp_a_x = 5; // Создаем переменную типа int условной точки a как значение его координаты x
                int temp_a_y = 5 + a * 50; // Создаем переменную типа int условной точки a как значение его координаты y

                int temp_b_x = 5 + c * 50; // Создаем переменную типа int условной точки b как значение его координаты x
                int temp_b_y = 5; // Создаем переменную типа int условной точки b как значение его координаты y

                if (equal_sides == false) { temp_b_x = temp_b_x - b * 50; } else { temp_b_y = temp_b_y + b * 50; } // Меняем координаты точки temp_b в случае если треугольник равнобедренный

                Point p_a = new Point(5, 5 + a * 50); // Дополнительная незадействованная точка a для проверки длины стороны
                Point p_b = new Point(5 + c * 50, 5 + b * 50); // Дополнительная незадействованная b точка для проверки длины стороны 

                /* Тут будет отступление для объяснения как работает нахождение точки соприкосновения сторон треугольника для его построения на полотне
                 * Условные точки a и b нужны для нахождения точки соприкосновения сторон треугольника
                 * За каждый тик цикла приведенного ниже координаты x у точек a и b увеличивается на 1 и уменьшается на 1 соответсвенно
                 * За каждый тик цикла приведенного ниже координаты y у точки a уменьшается на 1
                 * А у точки b в случае равнобедренного уменьшается на 1 в ином увеличивается на 1
                 */

                while (temp_a_x != temp_b_x) { temp_a_x++; temp_b_x--; }
                while (temp_a_y != temp_b_y) { temp_a_y--; if (equal_sides) { temp_b_y--; } else temp_b_y++; }

                Point p3 = new Point(temp_a_x, temp_a_y); // Задаем третью точку которая является точкой соприкосновения меньших сторон треугольника с координатами равными условной точки temp_a

                gp.DrawLine(p, p1, p2); // Рисуем Основание треугольника
                gp.DrawLine(p, p2, p3); // Рисуем Вторую сторону тругольника
                gp.DrawLine(p, p3, p1); // Рисуем третью сторону тругольника

                //gp.DrawLine(p, p1, p_a); // Для отрисовки дополнительных отрезков сторон треугольника
                //gp.DrawLine(p, p2, p_b); // Для отрисовки дополнительных отрезков сторон треугольника
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Даровеньки!", "Приветствие");
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
            h_check = checkBox1.Checked; // Передает состояние checkBox1 переменной h_check
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нужно ввести: \n- Значение трех сторон\n- Пока все", "Помощник");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
