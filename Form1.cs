using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.AxHost;

namespace ball
{
    public partial class Form1 : Form
    {
        int x, y;
        private Ball ball;
        private cube cube;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            // Проверяем, что ввод не пустой и состоит только из цифр
            bool isValidInput = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
            int sideLength = isValidInput ? Convert.ToInt32(input) : 0;

            // Создаем куб и рисуем его только если ввод корректен и длина стороны положительная
            cube cube = isValidInput && sideLength > 0 ? new cube(sideLength) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // Очищаем предыдущие рисунки
                float startX = 50; // Начальная координата X для рисования куба
                float startY = 50; // Начальная координата Y для рисования куба
                if (cube != null)
                {
                    cube.Draw(g, startX, startY); // Рисуем куб с заданными координатами
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение для длины стороны куба.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            // Создаём шар с координатами и радиусом
            string input = textBox1.Text;
            // Проверяем, что ввод не пустой и состоит только из цифр
            bool isValidInput = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
            int radius = isValidInput ? Convert.ToInt32(input) : 0;

            // Создаем шар и рисуем его только если ввод корректен и радиус положительный
            Ball ball = isValidInput && radius > 0 ? new Ball(100, 100, radius) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // Очищаем предыдущие рисунки
                float startX = 200; 
                float startY = 200; 

                if (ball != null)
                {
                    ball.Draw(g); // Рисуем шар 
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение радиуса шара.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string baseLengthInput = textBox1.Text;
            string heightInput = textBox2.Text;

            // Проверяем, что ввод не пустой и преобразование прошло успешно
            bool isValidBaseLength = double.TryParse(baseLengthInput, out double baseLength) && baseLength > 0;
            bool isValidHeight = double.TryParse(heightInput, out double height) && height > 0;

            // Создание пирамиды и рисование её только если ввод корректен
            Pyramid pyramid = isValidBaseLength && isValidHeight ? new Pyramid(baseLength, height) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // Очистка предыдущего рисунка
                float startX = 200; // Начальная координата X для рисования куба
                float startY = 200; // Начальная координата Y для рисования куба
                if (pyramid != null)
                {
                    pyramid.Draw(g, startX, startY); 
                }
                else
                {
                    MessageBox.Show("Введите корректные значения длины основания и высоты пирамиды.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string radiusInput = textBox1.Text;
            string heightInput = textBox2.Text;

            // Проверяем ввод на корректность
            bool isValidRadius = double.TryParse(radiusInput, out double radius) && radius > 0;
            bool isValidHeight = double.TryParse(heightInput, out double height) && height > 0;

            // Создаем цилиндр и рисуем его только если ввод корректен и параметры положительные
            Cylinder cylinder = isValidRadius && isValidHeight ? new Cylinder(radius, height) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // Очистка предыдущих рисунков
                float startX = 200; // Начальная координата X для рисования куба
                float startY = 200; // Начальная координата Y для рисования куба
                if (cylinder != null)
                {
                    cylinder.Draw(g, startX, startY); 
                }
                else
                {
                    MessageBox.Show(
                        "Введите корректные значения радиуса и высоты цилиндра.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Получаем значения радиусов из текстовых полей
            string innerRadiusInput = textBox1.Text;
            string outerRadiusInput = textBox2.Text;

            // Проверяем ввод на корректность
            bool isValidInner = double.TryParse(innerRadiusInput, out double innerRadius) && innerRadius > 0;
            bool isValidOuter = double.TryParse(outerRadiusInput, out double outerRadius) && outerRadius > 0;

            // Создаем кольцо и рисуем его только если ввод корректен и внешний радиус больше внутреннего
            Ring ring = isValidInner && isValidOuter && outerRadius > innerRadius? new Ring(innerRadius, outerRadius): null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // Очищаем предыдущие рисунки

                if (ring != null)
                {
                    ring.Draw(g, 150, 200); 
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные значения внутреннего и внешнего радиусов кольца.\nВнешний радиус должен быть больше внутреннего.","Ошибка ввода",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }
    }
}


