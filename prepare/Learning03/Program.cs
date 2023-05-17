using System;

class Program
{
    static void Main(string[] args)
    {
        // set text color to yellow
        Console.ForegroundColor = ConsoleColor.Yellow;
        // say hello world
        Console.WriteLine("Hello Learning03 World!\n");
        // reset text color to original settings
        Console.ResetColor();

        // created instance of 1/1
        Fraction set = new Fraction();
        // created instance of 6/1
        Fraction bottomSet = new Fraction(6);
        // created instance of 6/7
        Fraction noneSet = new Fraction(6,7);

        // testing setters on set object
        set.SetTop(3);
        set.SetBottom(9);
        // testing getters & displaying to console for set object
        Console.WriteLine($"set object's top number is {set.GetTop()}");
        Console.WriteLine($"set object's bottom number is {set.GetBottom()}\n");
        // testing setters on set object
        bottomSet.SetTop(5);
        bottomSet.SetBottom(25);
        // testing getters & displaying to console for bottomSet object
        Console.WriteLine($"bottomSet object's top number is {bottomSet.GetTop()}");
        Console.WriteLine($"bottomSet object's bottom number is {bottomSet.GetBottom()}\n");
        noneSet.SetTop(7);
        noneSet.SetBottom(49);
        // testing getters & displaying to console for noneSet object
        Console.WriteLine($"noneSet object's top number is {noneSet.GetTop()}");
        Console.WriteLine($"noneSet object's bottom number is {noneSet.GetBottom()}\n");

        // verifying I can call each constructor and recieve the different representations
         // created instance of constructor as 1/1
        Fraction set2 = new Fraction();
        // created instance of constructor as 5/1
        Fraction bottomSet2 = new Fraction(5);
        // created instance of constructor as 3/4
        Fraction noneSet2 = new Fraction(3,4);
         // created instance of constructor as 1/3
        Fraction noneSet3 = new Fraction(1,3);
        // showing the fractional representation of set2 object
        Console.WriteLine($"set2 object's fraction representation: {set2.GetFractionString()}");
        // showing the decimal representation of set2 object
        Console.WriteLine($"set2 object's decimal representation: {set2.GetDecimalValue()}");
        // showing the fractional representation of bottomSet2 object
        Console.WriteLine($"bottomSet2 object's fraction representation: {bottomSet2.GetFractionString()}");
        // showing the decimal representation of bottomSet2 object
        Console.WriteLine($"bottomSet2 object's decimal representation: {bottomSet2.GetDecimalValue()}");
        // showing the fractional representation of noneSet2 object
        Console.WriteLine($"noneSet2 object's decimal representation: {noneSet2.GetFractionString()}");
        // showing the decimal representation of noneSet2 object
        Console.WriteLine($"noneSet2 object's decimal representation: {noneSet2.GetDecimalValue()}");
        // showing the fractional representation of noneSet3 object
        Console.WriteLine($"noneSet3 object's decimal representation: {noneSet3.GetFractionString()}");
        // showing the decimal representation of noneSet3 object
        Console.WriteLine($"noneSet3 object's decimal representation: {noneSet3.GetDecimalValue()}");

        
    }
}