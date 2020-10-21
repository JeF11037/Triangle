using System;
using System.Drawing;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form2 : Form
    {
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Panel panel1;
        private CheckBox checkBox1;
        private ListView listView1;
        private ColumnHeader Field;
        private ColumnHeader Value;
        private Label label5;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label6;
        private Label label7;
        private TextBox textBox7;
        private Label label8;
        private TextBox textBox8;
        private Label label9;
        private TextBox textBox9;
        private Label label10;
        private Button button2;
        private Label label11;
        private Label label12;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label13;
        private Button button3;

        Graphics gp; // Экземпляр класса Graphics
        Pen p = new Pen(Brushes.Black, 2); // Экземпляр класса Pen cо свойствами черный цвет и ширина 2

        Triangle tri = new Triangle(); // Экземпляр класса Triangle
        Triangle triabc = new Triangle();
        Triangle trisideh = new Triangle();

        bool h_check = true; // Переменная типа bool для проверки состояния checkBox1

        public Graphics Gp { get => gp; set => gp = value; }
        public Pen P { get => p; set => p = value; }
        internal Triangle Tri { get => tri; set => tri = value; }
        public bool H_check { get => h_check; set => h_check = value; }

        public Form2()
        {
            Elements();
        }

        private void ClearTheBoard(object sender, EventArgs e)
        {
            ClearTheBoard();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void ClearTheBoard()
        {
            listView1.Items.Clear(); // Убираем лишние элементы в listView1
            Gp.Clear(Color.White);
            tri.ClearValues();
            triabc.ClearValues();
            trisideh.ClearValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double r; // временная переменная типа double для метода TryParse

            ClearTheBoard();

            listView1.Items.Add("Сторона: a"); // Добавляем в Поле listView1 сторону a
            listView1.Items.Add("Сторона: b"); // Добавляем в Поле listView1 сторону b
            listView1.Items.Add("Сторона: c"); // Добавляем в Поле listView1 сторону c

            if (double.TryParse(textBox1.Text, out r)) // Проверка на корректный ввод стороны a
            {
                Tri.a = Convert.ToDouble(textBox1.Text); // Добавляем значение переменной a экземпляра tri введенного пользователя
                listView1.Items[0].SubItems.Add(Tri.outputA()); // Добавляем в Значение listView1 стороны a значение переменной a экземпляра tri
            }

            if (double.TryParse(textBox2.Text, out r)) // Проверка на корректный ввод стороны b
            {
                Tri.b = Convert.ToDouble(textBox2.Text); // Добавляем значение переменной b экземпляра tri введенного пользователя
                listView1.Items[1].SubItems.Add(Tri.outputB()); // Добавляем в Значение listView1 стороны b значение переменной a экземпляра tri
            }

            if (double.TryParse(textBox3.Text, out r)) // Проверка на корректный ввод стороны c
            {
                Tri.c = Convert.ToDouble(textBox3.Text); // Добавляем значение переменной c экземпляра tri введенного пользователя
                listView1.Items[2].SubItems.Add(Tri.outputC()); // Добавляем в Значение listView1 стороны c значение переменной a экземпляра tri
            }

            if (double.TryParse(textBox4.Text, out r))
            {
                Tri.ha = Convert.ToDouble(textBox4.Text);
            }

            if (double.TryParse(textBox5.Text, out r))
            {
                Tri.hb = Convert.ToDouble(textBox5.Text);
            }

            if (double.TryParse(textBox6.Text, out r))
            {
                Tri.hc = Convert.ToDouble(textBox6.Text);
            }

            if (Tri.a != 0 && Tri.b != 0 && Tri.c != 0)
            {
                triabc = new Triangle(Tri.a, Tri.b, Tri.c);
            } // Добавляем значение переменной h экземпляра tri полученный результатом метода GetH в качестве стороны задаем c

            if (textBox9.Text == "")
            {
                textBox9.Text = triabc.alpha.ToString();
            }
            if (textBox8.Text == "")
            {
                textBox8.Text = triabc.beta.ToString();
            }
            if (textBox7.Text == "")
            {
                textBox7.Text = triabc.gamma.ToString();
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = triabc.ha.ToString();
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = triabc.hb.ToString();
            }
            if (textBox6.Text == "")
            {
                textBox6.Text = triabc.hc.ToString();
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = triabc.a.ToString();
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = triabc.b.ToString();
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = triabc.c.ToString();
            }

            double a_ = triabc.a;
            double b_ = triabc.b;
            double c_ = triabc.c;

            double alpha_ = triabc.alpha;
            double beta_ = triabc.beta;
            double gamma_ = triabc.gamma;

            if (H_check) // Проверка состояния checkBox1 при помощи переменной h_check
            {
                listView1.Items.Add("Высота: H(a)"); // Добавляем в Поле listView1 высоту h
                listView1.Items.Add("Высота: H(b)");
                listView1.Items.Add("Высота: H(c)");
                listView1.Items.Add("Площадь: s"); // Добавляем в Поле listView1 площадь s
                listView1.Items.Add("Периметр: p"); // Добавляем в Поле listView1 периметр p
                listView1.Items.Add("Альфа: ");
                listView1.Items.Add("Бета: ");
                listView1.Items.Add("Гамма: ");
                listView1.Items.Add("Существует ?"); // Добавляем в Поле listView1 правильность треугольника
                listView1.Items.Add("Тип"); // Добавляем в Поле listView1 тип треугольника

                if (Tri.ExistTriangle) { listView1.Items[11].SubItems.Add("Да"); } // Проверка на наличие правильности треугольника методом экземпляра tri ExistTriangle. В случае истинны добавляем в Значение listView1 "Существует"
                else listView1.Items[11].SubItems.Add("Нет"); // В ином случае добавляем в Значение listView1 "Не существует"

                if (Tri.a != 0 && Tri.ha != 0)
                {
                    trisideh = new Triangle(Tri.a, Tri.ha, "a");
                    listView1.Items[3].SubItems.Add(Convert.ToString(Tri.outputH(Tri.ha)));
                    listView1.Items[6].SubItems.Add(Convert.ToString(Tri.SurfaceWithH(Tri.a, Tri.ha)));
                }
                if (Tri.b != 0 && Tri.hb != 0)
                {
                    trisideh = new Triangle(Tri.b, Tri.hb, "b");
                    listView1.Items[4].SubItems.Add(Convert.ToString(Tri.outputH(Tri.hb)));
                    listView1.Items[6].SubItems.Add(Convert.ToString(Tri.SurfaceWithH(Tri.b, Tri.hb)));
                }
                if (Tri.c != 0 && Tri.hc != 0)
                {
                    trisideh = new Triangle(Tri.c, Tri.hc, "c");
                    listView1.Items[5].SubItems.Add(Convert.ToString(Tri.outputH(Tri.hc)));
                    listView1.Items[6].SubItems.Add(Convert.ToString(Tri.SurfaceWithH(Tri.c, Tri.hc)));
                }

                if (Tri.ExistTriangle) // Проверка на правильность треугольника
                {
                    listView1.Items[3].SubItems.Add(Convert.ToString(triabc.outputH(triabc.ha))); // Добавляем в Значение listView1 высоты h значение переменной h экземпляра tri
                    listView1.Items[4].SubItems.Add(Convert.ToString(triabc.outputH(triabc.hb)));
                    listView1.Items[5].SubItems.Add(Convert.ToString(triabc.outputH(triabc.hc)));
                    listView1.Items[7].SubItems.Add(Convert.ToString(triabc.Perimeter())); // Добавляем в Значение listView1 периметра его значение экземпляра tri
                    listView1.Items[6].SubItems.Add(Convert.ToString(triabc.Surface())); // Добавляем в Значение listView1 площади его значение экземпляра tri

                    listView1.Items[8].SubItems.Add(Convert.ToString(triabc.alpha));
                    listView1.Items[9].SubItems.Add(Convert.ToString(triabc.beta));
                    listView1.Items[10].SubItems.Add(Convert.ToString(triabc.gamma));

                    if (Tri.c * Tri.c == Tri.a * Tri.a + Tri.b * Tri.b) { listView1.Items[12].SubItems.Add("Прямоугольный"); } // Добавляем в Значение listView1 тип "Прямоугольный" если квадрат большей стороны равно суммы квадратов остальных сторон
                    else if (Tri.c * Tri.c < Tri.a * Tri.a + Tri.b * Tri.b) { listView1.Items[12].SubItems.Add("Остроугольный"); } // Добавляем в Значение listView1 тип "Остроугольный" если квадрат большей стороны меньше суммы квадратов остальных сторон
                    else if (Tri.c * Tri.c > Tri.a * Tri.a + Tri.b * Tri.b) { listView1.Items[12].SubItems.Add("Тупоугольный"); } // Добавляем в Значение listView1 тип "Тупоугольный" если квадрат большей стороны больше суммы квадратов остальных сторон
                }
            }

            if (Tri.ExistTriangle) // Проверка правильности треугольника для отрисовки на полотне
            {
                if (a_ == Tri.getBiggest()) { Tri.c = a_; Tri.a = b_; Tri.b = c_; } // Перестановка значений для удобства по принципу c равно большей стороне а остальные меньшей
                else if (b_ == Tri.getBiggest()) { Tri.c = b_; Tri.a = c_; Tri.b = a_; }

                int a = Convert.ToInt32(Tri.a); // Создаем переменную стороны a типа int 
                int b = Convert.ToInt32(Tri.b); // Создаем переменную стороны b типа int 
                int c = Convert.ToInt32(Tri.c); // Создаем переменную стороны c типа int 

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

                Gp.DrawLine(P, p1, p2); // Рисуем Основание треугольника
                Gp.DrawLine(P, p2, p3); // Рисуем Вторую сторону тругольника
                Gp.DrawLine(P, p3, p1); // Рисуем третью сторону тругольника

                //gp.DrawLine(p, p1, p_a); // Для отрисовки дополнительных отрезков сторон треугольника
                //gp.DrawLine(p, p2, p_b); // Для отрисовки дополнительных отрезков сторон треугольника
            }
        }

        private void Elements()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            listView1 = new ListView();
            Field = new ColumnHeader();
            Value = new ColumnHeader();
            label5 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBox7 = new TextBox();
            label8 = new Label();
            textBox8 = new TextBox();
            label9 = new Label();
            textBox9 = new TextBox();
            label10 = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();



            button1.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            button1.FlatAppearance.BorderSize = 10;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Mongolian Baiti", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            button1.Location = new Point(694, 536);
            button1.Name = "button1";
            button1.Size = new Size(145, 61);
            button1.TabIndex = 0;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new EventHandler(button1_Click);



            label1.AutoSize = true;
            label1.Location = new Point(598, 50);
            label1.Name = "label1";
            label1.Size = new Size(14, 13);
            label1.TabIndex = 1;
            label1.Text = "A";
            label1.Click += new EventHandler(label1_Click);



            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(598, 79);
            label2.Name = "label2";
            label2.Size = new Size(14, 13);
            label2.TabIndex = 2;
            label2.Text = "B";



            label3.AutoSize = true;
            label3.Location = new Point(598, 107);
            label3.Name = "label3";
            label3.Size = new Size(14, 13);
            label3.TabIndex = 3;
            label3.Text = "C";



            label4.AutoSize = true;
            label4.Location = new Point(599, 142);
            label4.Name = "label4";
            label4.Size = new Size(60, 13);
            label4.TabIndex = 4;
            label4.Text = "Additionally";
            label4.Click += new EventHandler(label4_Click);



            textBox1.Location = new Point(618, 47);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(41, 20);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);



            textBox2.Location = new Point(618, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(41, 20);
            textBox2.TabIndex = 6;
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);



            textBox3.Location = new Point(618, 104);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(41, 20);
            textBox3.TabIndex = 7;
            textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);



            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(565, 585);
            panel1.TabIndex = 13;



            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(659, 141);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(59, 17);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "On/Off";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);



            listView1.Columns.AddRange(new ColumnHeader[] {
            Field,
            Value});
            listView1.HideSelection = false;
            listView1.Location = new Point(586, 166);
            listView1.Name = "listView1";
            listView1.Size = new Size(337, 364);
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);



            Field.Text = "Поле";
            Field.Width = 166;



            Value.Text = "Значение";
            Value.Width = 166;



            label5.AutoSize = true;
            label5.Location = new Point(707, 50);
            label5.Name = "label5";
            label5.Size = new Size(21, 13);
            label5.TabIndex = 16;
            label5.Text = "Ha";
            label5.Click += new EventHandler(label5_Click);



            textBox4.Location = new Point(734, 47);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(40, 20);
            textBox4.TabIndex = 17;
            textBox4.TextChanged += new EventHandler(textBox4_TextChanged_1);



            textBox5.Location = new Point(734, 76);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(40, 20);
            textBox5.TabIndex = 18;
            textBox5.TextChanged += new EventHandler(textBox5_TextChanged);



            textBox6.Location = new Point(734, 104);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(40, 20);
            textBox6.TabIndex = 19;
            textBox6.TextChanged += new EventHandler(textBox6_TextChanged);



            label6.AutoSize = true;
            label6.Location = new Point(707, 79);
            label6.Name = "label6";
            label6.Size = new Size(21, 13);
            label6.TabIndex = 20;
            label6.Text = "Hb";
            label6.Click += new EventHandler(label6_Click);



            label7.AutoSize = true;
            label7.Location = new Point(708, 107);
            label7.Name = "label7";
            label7.Size = new Size(21, 13);
            label7.TabIndex = 21;
            label7.Text = "Hc";
            label7.Click += new EventHandler(label7_Click);



            textBox7.Location = new Point(871, 49);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(40, 20);
            textBox7.TabIndex = 23;



            label8.AutoSize = true;
            label8.Location = new Point(827, 52);
            label8.Name = "label8";
            label8.Size = new Size(34, 13);
            label8.TabIndex = 22;
            label8.Text = "Alpha";



            textBox8.Location = new Point(871, 81);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(40, 20);
            textBox8.TabIndex = 25;



            label9.AutoSize = true;
            label9.Location = new Point(827, 84);
            label9.Name = "label9";
            label9.Size = new Size(29, 13);
            label9.TabIndex = 24;
            label9.Text = "Beta";



            textBox9.Location = new Point(871, 107);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(40, 20);
            textBox9.TabIndex = 27;



            label10.AutoSize = true;
            label10.Location = new Point(827, 110);
            label10.Name = "label10";
            label10.Size = new Size(43, 13);
            label10.TabIndex = 26;
            label10.Text = "Gamma";



            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(741, 12);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 28;
            button2.Text = "?";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new EventHandler(button2_Click);

            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(781, 12);
            button3.Name = "button2";
            button3.Size = new Size(27, 23);
            button3.TabIndex = 28;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = false;
            button3.Click += ClearTheBoard;



            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 609);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(textBox10);
            Controls.Add(textBox11);
            Controls.Add(textBox12);
            Controls.Add(label13);
            Controls.Add(button2);
            Controls.Add(textBox9);
            Controls.Add(label10);
            Controls.Add(textBox8);
            Controls.Add(label9);
            Controls.Add(textBox7);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(listView1);
            Controls.Add(checkBox1);
            Controls.Add(panel1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button3);
            Gp = panel1.CreateGraphics(); // Указываем полотно для рисования треугольника
            Name = "Form2";
            Text = "Triangle";
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);
            PerformLayout();
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
            H_check = checkBox1.Checked; // Передает состояние checkBox1 переменной h_check
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нужно ввести: \n- Значение трех сторон, чтобы получить все параметры\n- Значение стороны и ее высоту, чтобы получить площадь\n- Пока все", "Помощник");
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
