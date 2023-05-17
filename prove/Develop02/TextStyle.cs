using System;
using System.Runtime.InteropServices;

// ### CLASS ################################################ //
// class to decorate text in the console
public class TextStyles
{
// ### VARIABLE ATTRIBUTES ################################## //
const int STD_OUTPUT_HANDLE = -11;
const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

[DllImport("kernel32.dll", SetLastError = true)]
static extern IntPtr GetStdHandle(int nStdHandle);

[DllImport("kernel32.dll")]
static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

[DllImport("kernel32.dll")]
static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

// ### METHODS ############################################## //
// this method underlines the text without a newline at the end
// so yo can underline words in the middle of sentences as well
// got this from https://stackoverflow.com/questions/3381952/how-to-remove-all-white-space-from-the-beginning-or-end-of-a-string
    public static void WriteUnderline(string s)
    {   
        var handle = GetStdHandle(STD_OUTPUT_HANDLE);
        uint mode;
        GetConsoleMode(handle, out mode);
        mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
        SetConsoleMode(handle, mode);
        Console.Write($"\x1B[4m{s}\x1B[24m");
    }
}  