using System;


namespace ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// Creates an instance of the Program class and calls the Run method to start the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>

        static void Main(string[] args)
        {
            App app = new App();
            app.Run();
        }
    }
}
