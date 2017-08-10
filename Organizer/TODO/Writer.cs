using System;

namespace TODO
{
    public class Writer
    {
        public static void WriteLine(string message,
            ConsoleColor background = default(ConsoleColor),    
            ConsoleColor foreground = default(ConsoleColor))
        {
            Console.WriteLine(message);
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public static void ClearHistory()
        {
            Console.Clear();
        }

        public static void NoUserLogged()
        {
            Console.WriteLine("no user logged");
        }

        public static void RemindText(string message)
        {
            int oldSize = Console.CursorSize;
            Console.CursorSize = 50;           
            Console.WriteLine($"Time for {message}!");
            Console.CursorSize = oldSize;
        }
    }
}
