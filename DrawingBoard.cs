// DrawingBoard.cs
using System;

namespace DrawingApp
{
    public class DrawingBoard
    {
        private int width;
        private int height;
        private bool isDrawing;

        public DrawingBoard(int initialWidth, int initialHeight)
        {
            if (initialWidth > 0 && initialHeight > 0)
            {
                width = initialWidth;
                height = initialHeight;
                isDrawing = false;
            }
            else
            {
                throw new ArgumentException("Platums un augstums jābūt lielākiem par 0.");
            }
        }

        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("Platumam jābūt lielākam par 0.");
                }
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("Augstumam jābūt lielākam par 0.");
                }
            }
        }

        public bool IsDrawing
        {
            get { return isDrawing; }
        }

        public void StartDrawing()
        {
            isDrawing = true;
        }

        public void StopDrawing()
        {
            isDrawing = false;
        }

        public void DrawOnBoard(string drawing)
        {
            if (IsDrawing)
            {
                Console.WriteLine($"Zīmēšana uz dēļa ar izmēriem {Width}x{Height}:");
                Console.WriteLine(drawing);
            }
            else
            {
                Console.WriteLine("Zīmēšana nav ieslēgta. Lūdzu, sāciet zīmēšanu.");
            }
        }

        public class Pencil
        {
            public void Draw(DrawingBoard board, string drawing)
            {
                board.StartDrawing();
                board.DrawOnBoard(drawing);
                board.StopDrawing();
            }
        }

        public class Eraser
        {
            public void Erase(DrawingBoard board)
            {
                board.StartDrawing();
                board.DrawOnBoard("Dēļa tīrīšana...");
                board.StopDrawing();
            }
        }

        public class Colors
        {
            private ConsoleColor drawingColor;

            public Colors(ConsoleColor initialColor)
            {
                drawingColor = initialColor;
            }

            public ConsoleColor DrawingColor
            {
                get { return drawingColor; }
                set { drawingColor = value; }
            }

            public void SetDefaultColor()
            {
                drawingColor = ConsoleColor.White;
            }
        }

        public class Shapes
        {
            public void DrawShape(DrawingBoard board, string shapeType)
            {
                board.StartDrawing();
                Console.WriteLine($"Zīmē {shapeType} uz dēļa ar izmēriem {board.Width}x{board.Height}:");

                switch (shapeType.ToLower())
                {
                    case "circle":
                        DrawCircle(board);
                        break;
                    case "rectangle":
                        DrawRectangle(board);
                        break;
                    default:
                        Console.WriteLine("Neatpazīts formas tips.");
                        break;
                }

                board.StopDrawing();
            }

            // DrawingBoard.cs (inside Shapes class)
            
            private void DrawCircle(DrawingBoard board)
            {
                int centerX = board.Width / 2;
                int centerY = board.Height / 2;
                int radius = Math.Min(board.Width, board.Height) / 4; // Set the radius as a quarter of the minimum dimension
            
                for (int i = 0; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width; j++)
                    {
                        double distanceToCenter = Math.Sqrt(Math.Pow(j - centerX, 2) + Math.Pow(i - centerY, 2));
            
                        // Check if the current point is within a certain distance from the center (the radius)
                        if (Math.Abs(distanceToCenter - radius) < 1.5)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }


            private void DrawRectangle(DrawingBoard board)
            {
                for (int i = 0; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
