using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ball
{
    class Ball : _3d
    {
        public int X { get; set; }  // Координата X центра шара
        public int Y { get; set; }  // Координата Y центра шара
        public int Radius { get; set; }  // Радиус шара

        public Ball(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            name = "Ball";
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a ball with radius {Radius} and name '{name}'.");
          
        }

        public void Draw(Graphics g)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(X - Radius, Y - Radius, Radius * 2, Radius * 2),
                Color.LightBlue,
                Color.DarkBlue,
                LinearGradientMode.Vertical))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }

            Console.WriteLine($"Drawing a ball with radius {Radius} and name '{name}'.");
        }
    }

}
