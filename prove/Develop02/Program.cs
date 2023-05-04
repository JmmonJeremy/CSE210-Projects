using System;

class Program
{
    static void Main(string[] args)
    {
        // while ()
        Prompt prompter = new Prompt();
       
        while (prompter._time == prompter.Clock())
        {
            Console.WriteLine($"{prompter._time} = {prompter.Clock()}");
        }
        Console.WriteLine(prompter.SelectPrompt());
        prompter.ListPrompts();
    }
}