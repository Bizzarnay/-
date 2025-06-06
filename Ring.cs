using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ball
{
    class Ring : _3d
    {
        private double innerRadius;
        private double outerRadius;

        public Ring(double innerRadius, double outerRadius)
        {
            this.innerRadius = innerRadius;
            this.outerRadius = outerRadius;
            this.name = "Ring";
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a ring with inner radius {innerRadius}, outer radius {outerRadius} and name '{name}'.");
        }

        public void Draw(Graphics g, float x, float y)
        {
            // Рисуем внешний круг
            g.FillEllipse(Brushes.LightGray, x - (float)outerRadius, y - (float)outerRadius, (float)(2 * outerRadius), (float)(2 * outerRadius));
            g.DrawEllipse(Pens.Black, x - (float)outerRadius, y - (float)outerRadius, (float)(2 * outerRadius), (float)(2 * outerRadius));

            // Рисуем внутренний круг
            g.FillEllipse(Brushes.White, x - (float)innerRadius, y - (float)innerRadius, (float)(2 * innerRadius), (float)(2 * innerRadius));
            g.DrawEllipse(Pens.Black, x - (float)innerRadius, y - (float)innerRadius, (float)(2 * innerRadius), (float)(2 * innerRadius));
        }
    }
}
