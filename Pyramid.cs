using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ball
{
        class Pyramid : _3d
        {
            private double baseLength;
            private double height;

            public Pyramid(double baseLength, double height)
            {
                this.baseLength = baseLength;
                this.height = height;
                this.name = "Pyramid";
            }

            public override void Draw()
            {
                Console.WriteLine($"Drawing a pyramid with base length {baseLength} and height {height} and name '{name}'.");
              
            }

            public PointF[] BaseFace { get; private set; }
            public PointF[] FrontFace { get; private set; }
            public PointF[] LeftFace { get; private set; }
            public PointF[] RightFace { get; private set; }

            public void Draw(Graphics g, float x, float y)
            {
                // Определяем координаты вершин основания пирамиды
                PointF[] baseFace = new PointF[]
                {
                new PointF(x, y),                                   // Левый нижний угол
                new PointF(x + (float)baseLength, y),             // Правый нижний угол
                new PointF(x + (float)baseLength, y + (float)baseLength), // Правый верхний угол
                new PointF(x, y + (float)baseLength)              // Левый верхний угол
                };

                // Определяем координаты вершины пирамиды
                PointF apex = new PointF(x + (float)(baseLength / 2), y - (float)height);

                // Рисуем основание пирамиды
                g.FillPolygon(Brushes.Green, baseFace);
                g.DrawPolygon(Pens.Black, baseFace);

                // Рисуем боковые грани пирамиды
                DrawTriangle(g, apex, baseFace[0], baseFace[1], Brushes.LightBlue);  // Передняя грань
                DrawTriangle(g, apex, baseFace[1], baseFace[2], Brushes.LightCoral); // Правая грань
                DrawTriangle(g, apex, baseFace[2], baseFace[3], Brushes.LightGreen);  // Задняя грань
                DrawTriangle(g, apex, baseFace[3], baseFace[0], Brushes.LightYellow); // Левая грань

                // Соединяем вершину с углами основания
                for (int i = 0; i < baseFace.Length; i++)
                {
                    g.DrawLine(Pens.Black, apex, baseFace[i]);
                }
            // Соединяем вершину с углами основания
            for (int i = 0; i < baseFace.Length; i++)
            {
                g.DrawLine(Pens.Black, apex, baseFace[i]);
            }
        }

            private void DrawTriangle(Graphics g, PointF p1, PointF p2, PointF p3, Brush brush)
            {
                PointF[] triangle = new PointF[] { p1, p2, p3 };
                g.FillPolygon(brush, triangle);
                g.DrawPolygon(Pens.Black, triangle);
            }
        }
    }

