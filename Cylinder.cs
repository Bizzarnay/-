using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ball
{
    class Cylinder : _3d
    {
        private double radius;
        private double height;

        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
            this.name = "Cylinder";
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a cylinder with radius {radius} and height {height} and name '{name}'.");

        }

        public void Draw(Graphics g, float x, float y)
        {
            // Центры верхней и нижней окружностей
            PointF centerBottom = new PointF(x, y + (float)height / 2);
            PointF centerTop = new PointF(x, y - (float)height / 2);

            // Радиус круга
            float r = (float)radius;

            // Нарисовать нижнюю поверхность цилиндра
            g.FillEllipse(Brushes.Green, centerBottom.X - r, centerBottom.Y - r, 2 * r, 2 * r);
            g.DrawEllipse(Pens.Black, centerBottom.X - r, centerBottom.Y - r, 2 * r, 2 * r);

            // Нарисовать верхнюю поверхность цилиндра
            g.FillEllipse(Brushes.LightGreen, centerTop.X - r, centerTop.Y - r, 2 * r, 2 * r);
            g.DrawEllipse(Pens.Black, centerTop.X - r, centerTop.Y - r, 2 * r, 2 * r);

            // Линия соединения между верхним и нижним кругом
            g.DrawLine(Pens.Black, centerBottom.X - r, centerBottom.Y, centerTop.X - r, centerTop.Y);
            g.DrawLine(Pens.Black, centerBottom.X + r, centerBottom.Y, centerTop.X + r, centerTop.Y);
        }
    }
}
