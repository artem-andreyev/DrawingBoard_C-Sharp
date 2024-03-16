// Main.cs
using System;
using DrawingApp;

class MainProgram
{
    static void Main()
    {
        try
        {
            // Создаем экземпляр (переменную) DrawingBoard с начальными данными
            DrawingBoard drawingBoard = new DrawingBoard(10, 5);

            // Из классов в переменную
            DrawingBoard.Pencil pencil = new DrawingBoard.Pencil();
            DrawingBoard.DrawingColors colors = drawingBoard.Colors;
            DrawingBoard.Shapes shapes = new DrawingBoard.Shapes();

            pencil.Draw(drawingBoard, "Im currently drawing by method\nA\nB\nC\n");
            
            // Рисуем прямоугольник с цветом по умолчанию (белый)
            shapes.DrawShape(drawingBoard, "rectangle", $"Colour of the figure: {colors.DrawingColor}");
            Console.WriteLine();

            // Рисуем круг с цветом: желтый
            colors.DrawingColor = ConsoleColor.Yellow;
            shapes.DrawShape(drawingBoard, "circle", $"Colour of the figure: {colors.DrawingColor}");

            // Возвращаем цвет по умолчанию (белый)
            colors.SetDefaultColor();
            Console.WriteLine();

            // Рисуем случайный рисунок
            colors.ApplyColor(); // Применяем белый цвет
            Console.WriteLine("Random figure (10 rows, 5 columns):");
            drawingBoard.DrawRandomPattern(colors);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
