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
            // ���������, ��� ���� �� ������ � ������� ������ �� ����
            bool isValidInput = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
            int sideLength = isValidInput ? Convert.ToInt32(input) : 0;

            // ������� ��� � ������ ��� ������ ���� ���� ��������� � ����� ������� �������������
            cube cube = isValidInput && sideLength > 0 ? new cube(sideLength) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // ������� ���������� �������
                float startX = 50; // ��������� ���������� X ��� ��������� ����
                float startY = 50; // ��������� ���������� Y ��� ��������� ����
                if (cube != null)
                {
                    cube.Draw(g, startX, startY); // ������ ��� � ��������� ������������
                }
                else
                {
                    MessageBox.Show("����������, ������� ���������� �������� ��� ����� ������� ����.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            // ������ ��� � ������������ � ��������
            string input = textBox1.Text;
            // ���������, ��� ���� �� ������ � ������� ������ �� ����
            bool isValidInput = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
            int radius = isValidInput ? Convert.ToInt32(input) : 0;

            // ������� ��� � ������ ��� ������ ���� ���� ��������� � ������ �������������
            Ball ball = isValidInput && radius > 0 ? new Ball(100, 100, radius) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // ������� ���������� �������
                float startX = 200; 
                float startY = 200; 

                if (ball != null)
                {
                    ball.Draw(g); // ������ ��� 
                }
                else
                {
                    MessageBox.Show("����������, ������� ���������� �������� ������� ����.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            // �������� �������� �� ��������� �����
            string baseLengthInput = textBox1.Text;
            string heightInput = textBox2.Text;

            // ���������, ��� ���� �� ������ � �������������� ������ �������
            bool isValidBaseLength = double.TryParse(baseLengthInput, out double baseLength) && baseLength > 0;
            bool isValidHeight = double.TryParse(heightInput, out double height) && height > 0;

            // �������� �������� � ��������� � ������ ���� ���� ���������
            Pyramid pyramid = isValidBaseLength && isValidHeight ? new Pyramid(baseLength, height) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // ������� ����������� �������
                float startX = 200; // ��������� ���������� X ��� ��������� ����
                float startY = 200; // ��������� ���������� Y ��� ��������� ����
                if (pyramid != null)
                {
                    pyramid.Draw(g, startX, startY); 
                }
                else
                {
                    MessageBox.Show("������� ���������� �������� ����� ��������� � ������ ��������.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // �������� �������� �� ��������� �����
            string radiusInput = textBox1.Text;
            string heightInput = textBox2.Text;

            // ��������� ���� �� ������������
            bool isValidRadius = double.TryParse(radiusInput, out double radius) && radius > 0;
            bool isValidHeight = double.TryParse(heightInput, out double height) && height > 0;

            // ������� ������� � ������ ��� ������ ���� ���� ��������� � ��������� �������������
            Cylinder cylinder = isValidRadius && isValidHeight ? new Cylinder(radius, height) : null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // ������� ���������� ��������
                float startX = 200; // ��������� ���������� X ��� ��������� ����
                float startY = 200; // ��������� ���������� Y ��� ��������� ����
                if (cylinder != null)
                {
                    cylinder.Draw(g, startX, startY); 
                }
                else
                {
                    MessageBox.Show(
                        "������� ���������� �������� ������� � ������ ��������.", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // �������� �������� �������� �� ��������� �����
            string innerRadiusInput = textBox1.Text;
            string outerRadiusInput = textBox2.Text;

            // ��������� ���� �� ������������
            bool isValidInner = double.TryParse(innerRadiusInput, out double innerRadius) && innerRadius > 0;
            bool isValidOuter = double.TryParse(outerRadiusInput, out double outerRadius) && outerRadius > 0;

            // ������� ������ � ������ ��� ������ ���� ���� ��������� � ������� ������ ������ �����������
            Ring ring = isValidInner && isValidOuter && outerRadius > innerRadius? new Ring(innerRadius, outerRadius): null;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(pictureBox1.BackColor); // ������� ���������� �������

                if (ring != null)
                {
                    ring.Draw(g, 150, 200); 
                }
                else
                {
                    MessageBox.Show("����������, ������� ���������� �������� ����������� � �������� �������� ������.\n������� ������ ������ ���� ������ �����������.","������ �����",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }
    }
}


