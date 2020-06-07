using System;

namespace console_snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine en = new Engine();
            en.Init();
            en.Run();

            Console.ReadLine();
        }
    }
}
