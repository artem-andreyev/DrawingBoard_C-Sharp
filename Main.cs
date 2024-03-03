// Main.cs
using System;
using DrawingApp;

class MainProgram
{
    static void Main()
    {
        try
        {
            // Создаем экземпляр DrawingBoard с начальными данными
            DrawingBoard drawingBoard = new DrawingBoard(10, 5);

            // Создаем объекты из классов DrawingBoard.Pencil, DrawingBoard.Eraser, DrawingBoard.DrawingColors, и DrawingBoard.Shapes
            DrawingBoard.Pencil pencil = new DrawingBoard.Pencil();
            DrawingBoard.Eraser eraser = new DrawingBoard.Eraser();
            DrawingBoard.DrawingColors colors = drawingBoard.Colors; // Получаем объект DrawingColors из DrawingBoard
            DrawingBoard.Shapes shapes = new DrawingBoard.Shapes();

            // Проверяем методы и свойства класса
            pencil.Draw(drawingBoard, "A\nB\nC\n");

            eraser.Erase(drawingBoard);

            // Рисуем прямоугольник с цветом по умолчанию (белый)
            shapes.DrawShape(drawingBoard, "rectangle", $"Цвет фигуры: {colors.DrawingColor}");
            Console.WriteLine($"Размеры доски: {drawingBoard.Width}x{drawingBoard.Height}");

            // Рисуем круг с цветом желтый
            colors.DrawingColor = ConsoleColor.Yellow;
            shapes.DrawShape(drawingBoard, "circle", $"Цвет фигуры: {colors.DrawingColor}");

            // Возвращаем цвет по умолчанию (белый)
            colors.SetDefaultColor();

            // Console.ReadLine(); // Для того чтобы программа не закрылась сразу
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
