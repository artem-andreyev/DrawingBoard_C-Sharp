// Main.cs
using System;
using DrawingApp; // Ensure the correct namespace is imported

class MainProgram
{
    static void Main()
    {
        // Izveidojam jaunu DrawingBoard objektu
        DrawingBoard drawingBoard = new DrawingBoard(10, 5);

        // Izveidojam objektus no DrawingBoard.Pencil, DrawingBoard.Eraser, DrawingBoard.Colors, un DrawingBoard.Shapes klasēm
        DrawingBoard.Pencil pencil = new DrawingBoard.Pencil();
        DrawingBoard.Eraser eraser = new DrawingBoard.Eraser();
        DrawingBoard.Colors colors = new DrawingBoard.Colors(ConsoleColor.Green); // Set the initial drawing color to green
        DrawingBoard.Shapes shapes = new DrawingBoard.Shapes();

        // Pārbaudam klases metodes un īpašumus
        pencil.Draw(drawingBoard, "A\nB\nC\n");

        eraser.Erase(drawingBoard);

        // Zīmējam taisnstūri ar noklusēto krāsu (balta)
        shapes.DrawShape(drawingBoard, "rectangle");
        
        // DrawingBoard.IsDrawing = true;
        // Mainīgais "drawingBoard" izmanto klases metodes un īpašumus
        Console.WriteLine($"Dēļa izmēri: {drawingBoard.Width}x{drawingBoard.Height}");
        Console.WriteLine($"Zīmēšanas stāvoklis: {drawingBoard.IsDrawing}");

        // Mainīgais "colors" izmanto krāsas metodes
        Console.ForegroundColor = colors.DrawingColor;
        Console.WriteLine("Teksts ar pielietotu krāsu (figuras - taisnstūris krāsa).");
        Console.ForegroundColor = ConsoleColor.White;
        
        // DrawingBoard.Colors colorsCircle = new DrawingBoard.Colors(ConsoleColor.Yellow);
        // Console.ForegroundColor = colorsCircle.DrawingColor;
        
        shapes.DrawShape(drawingBoard, "circle");
        Console.ForegroundColor = ConsoleColor.White;

        // Console.ReadLine(); // neaizver programmu
    }
}
