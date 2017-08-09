using System;

namespace TODO
{
    public class Writer
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void NoUserLogged()
        {
            Console.WriteLine("no user logged");
        }
        public static void RemindText(string message)
        {
            Console.WriteLine($"Time for {message}!");
        }
    }
}
