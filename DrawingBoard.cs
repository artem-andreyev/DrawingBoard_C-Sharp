// DrawingBoard.cs
using System;

namespace DrawingApp
{
    public class DrawingBoard
    {
        private int width;
        private int height;
        private DrawingColors colors;
        private static int counter;

        public DrawingBoard(int initialWidth, int initialHeight)
        {
            if (initialWidth > 0 && initialHeight > 0)
            {
                width = initialWidth;
                height = initialHeight;
                colors = new DrawingColors(ConsoleColor.White);
                counter++;
                Console.WriteLine($"Drawing board created. Total boards created: {Counter}");
            }
            else
            {
                throw new ArgumentException("Width and height must be greater than 0.");
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
                    throw new ArgumentException("Width must be greater than 0.");
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
                    throw new ArgumentException("Height must be greater than 0.");
                }
            }
        }

        public static int Counter
        {
            get { return counter; }
        }

        public DrawingColors Colors
        {
            get { return colors; }
        }

        public class Pencil
        {
            public void Draw(DrawingBoard board, string drawing)
            {
                Console.WriteLine($"Drawing on the board with dimensions {board.Width}x{board.Height}:");
                Console.WriteLine(drawing);
            }
        }

        public class Eraser
        {
            public void Erase(DrawingBoard board)
            {
                Console.WriteLine("Board erasing...");
            }
        }

        public class DrawingColors
        {
            private ConsoleColor drawingColor;

            public DrawingColors(ConsoleColor initialColor)
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

            public void ApplyColor()
            {
                Console.ForegroundColor = drawingColor;
            }
        }

        public class Shapes
        {
            public void DrawShape(DrawingBoard board, string shapeType, string colorInfo)
            {
                Console.WriteLine($"Drawing {shapeType} on the board with dimensions {board.Width}x{board.Height}:");
                Console.WriteLine(colorInfo); // Вывод информации о цвете фигуры
            
                switch (shapeType.ToLower())
                {
                    case "circle":
                        DrawCircle(board);
                        break;
                    case "rectangle":
                        DrawRectangle(board);
                        break;
                    default:
                        Console.WriteLine("Unrecognized shape type.");
                        break;
                }
            }
            private void DrawCircle(DrawingBoard board)
            {
                int centerX = board.Width / 2;
                int centerY = board.Height / 2;
                int radius = Math.Min(board.Width, board.Height) / 4;

                for (int i = 0; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width; j++)
                    {
                        double distanceToCenter = Math.Sqrt(Math.Pow(j - centerX, 2) + Math.Pow(i - centerY, 2));

                        if (Math.Abs(distanceToCenter - radius) < 1.5)
                        {
                            board.Colors.ApplyColor();
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
                        board.Colors.ApplyColor();
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
