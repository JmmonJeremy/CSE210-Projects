using System;

class Program
{
    static void Main(string[] args)
    {
        // welcome C# learners with an empty line afterwards
        Console.WriteLine("Welcome to the Learning05 demonstration C# learners!\n");

        // test the square class object creation
        Square square = new Square("blue", 2);
        // make sure the correct color is returned for the square object
        Console.WriteLine($"The color of the square is {square.GetColor()}.");
        // make sure the correct area is returned for the square object with an empty line after it
        Console.WriteLine($"The area of the square is {square.GetArea()}.\n");

        // test the rectangle class object creation
        Rectangle rectangle = new Rectangle("green", 4, 2);
        // make sure the correct color is returned for the rectangle object
        Console.WriteLine($"The color of the rectangle is {rectangle.GetColor()}.");
        // make sure the correct area is returned for the rectangle object with an empty line after it
        Console.WriteLine($"The area of the rectangle is {rectangle.GetArea()}.\n");

        // test the circle class object creation
        Circle circle = new Circle("red", 3);
        // make sure the correct color is returned for the circle object
        Console.WriteLine($"The color of the circle is {circle.GetColor()}.");
        // make sure the correct area is returned for the circle object with an empty line after it
        Console.WriteLine($"The area of the circle is {circle.GetArea()}.\n");

        // create list to hold the shapes
        List<Shape> shapes = new List<Shape>();
        // add the square, rectangle, and cirlce shape objects to the list
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);
        // iterate through the list and display the GetColor() & GetArea methods
        foreach(Shape shape in shapes)
        {
            // reference source: https://www.techiedelight.com/get-the-class-name-csharp/ & https://www.programiz.com/csharp-programming/library/string/tolower#:~:text=The%20String%20ToLower()%20method,in%20the%20string%20to%20lowercase.             
            // display the color and area of the shape
            Console.WriteLine($"The color of the {shape.GetType().ToString().ToLower()} is {shape.GetColor()}.");      
            Console.WriteLine($"The area of the {shape.GetType().ToString().ToLower()} is {shape.GetArea()}.");
        }
    }
}