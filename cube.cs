using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ball
{
    class cube : _3d
    {
        private double sideLength; 
        public cube(int sideLength)
        {
            this.sideLength = sideLength;
            this.name = "Cube";
        }
        public override void Draw()
        {
            Console.WriteLine($"Drawing a cube with side length {sideLength} and name '{name}'.");
        }

        public PointF[] FrontFace { get; private set; }
        public PointF[] BackFace { get; private set; }
        public PointF[] LeftFace { get; private set; }
        public PointF[] RightFace { get; private set; }
        public PointF[] DownFace { get; private set; }
        public float Size { get; private set; }

      


        public void Draw(Graphics g, float x, float y)
        {
            // Определяем координаты вершин передней грани
            PointF[] frontFace = new PointF[]
            {
                new PointF(x, y),               // Верхний левый угол
                new PointF(x + (float)sideLength, y),       // Верхний правый угол
                new PointF(x + (float)sideLength, y + (float)sideLength), // Нижний правый угол
                new PointF(x, y + (float)sideLength)         // Нижний левый угол
            };

            // Определяем координаты вершин задней грани с учетом смещения
            PointF[] backFace = new PointF[]
            {
                new PointF(x + (float)sideLength / 2, y + (float)sideLength / 2),               // Верхний левый угол задней грани
                new PointF(x + (float)sideLength + (float)sideLength / 2, y + (float)sideLength / 2),       // Верхний правый угол задней грани
                new PointF(x + (float)sideLength + (float)sideLength / 2, y + (float)sideLength + (float)sideLength / 2), // Нижний правый угол задней грани
                new PointF(x + (float)sideLength / 2, y + (float)sideLength + (float)sideLength / 2)         // Нижний левый угол задней грани
            };
            // Рисуем переднюю грань куба
            g.FillPolygon(Brushes.LightBlue, frontFace);
            g.DrawPolygon(Pens.Black, frontFace);
            // Рисуем переднюю грань куба
            g.FillPolygon(Brushes.LightBlue, frontFace);
            g.DrawPolygon(Pens.Black, frontFace);

            // Рисуем заднюю грань куба
            g.FillPolygon(Brushes.Blue, backFace);
            g.DrawPolygon(Pens.Black, backFace);
            // Соединяем переднюю и заднюю грани куба
            for (int i = 0; i < frontFace.Length; i++)
            {
                g.DrawLine(Pens.Black, frontFace[i], backFace[i]);
            }

        }
    }
}
