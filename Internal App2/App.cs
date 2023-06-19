using BusinessModel;
using System;
//using DataLayer;

namespace ConsoleApp
{
    /// <summary>
    /// Represents the main program logic for user authentication.
    /// </summary>
    struct App
    {
        private Authentication auth;  // Object to handle authentication operations
        private User user;  // Object representing user information

        /// <summary>
        /// Initializes a new instance of the App struct.
        /// Creates and initializes the auth and user objects.
        /// </summary>
        public App()
        {
            auth = new Authentication();
            user = new User();
        }

        /// <summary>
        /// Runs the main program logic.
        /// Displays a menu, takes user input, and performs the corresponding actions.
        /// </summary>
        public void Run()
        {
            Console.WriteLine(Literal.div);
            Console.WriteLine(Literal.menu);

            int input;
            try
            { 
                input = Convert.ToInt32(Console.ReadLine()); 
            }
            catch (FormatException)
            {
                input = 0;
            }

            int redirect = input;
            bool flag = true;
            while (flag)
            {
                switch (redirect)
                {
                    // Exit
                    case 0:
                        flag = false;
                        Console.WriteLine(Literal.div, Literal.exit);
                        Environment.Exit(0);
                        break;
                    // Login
                    case 1:
                        Console.WriteLine(Literal.div, Literal.login);
                        redirect = auth.Login(user);
                        break;
                    // Register
                    case 2:
                        Console.WriteLine(Literal.div, Literal.register);
                        redirect = auth.Register(user);
                        break;
                    // Logout
                    case 3:
                        Console.WriteLine(Literal.div, Literal.loginSuccess, Literal.logout);
                        redirect = auth.Logout();
                        break;
                    // Default
                    default:
                        Console.WriteLine(Literal.div, Literal.switchDefault);
                        redirect = auth.SwitchDefault();
                        break;
                }
            }
        }
    }
    //class App
    //{
    //    private Authentication auth;  // Object to handle authentication operations
    //    private User user;  // Object representing user information

    //    /// <summary>
    //    /// Constructor for the Program class.
    //    /// Initializes the auth and user objects.
    //    /// </summary>
    //    public App()
    //    {
    //        auth = new Authentication();
    //        user = new User();
    //    }

    //    /// <summary>
    //    /// Runs the main program logic.
    //    /// Displays a menu, takes user input, and performs the corresponding actions.
    //    /// </summary>
    //    public void Run()
    //    {
    //        Console.WriteLine(Literal.div);
    //        Console.WriteLine(Literal.menu);
    //        int input = Convert.ToInt32(Console.ReadLine());
    //        int redirect = input;
    //        bool flag = true;
    //        while (flag)
    //        {
    //            switch (redirect)
    //            {
    //                // Exit
    //                case 0:
    //                    flag = false;
    //                    break;
    //                // Login
    //                case 1:
    //                    Console.WriteLine(Literal.div, Literal.login);
    //                    redirect = auth.Login(user);
    //                    break;
    //                // Register
    //                case 2:
    //                    Console.WriteLine(Literal.div, Literal.register);
    //                    redirect = auth.Register(user);
    //                    break;
    //                // Logout
    //                case 3:
    //                    Console.WriteLine(Literal.div, Literal.loginSuccess, Literal.logout);
    //                    redirect = auth.Logout();
    //                    break;
    //                // Default
    //                default:
    //                    Console.WriteLine(Literal.div, Literal.switchDefault);
    //                    redirect = auth.SwitchDefault();
    //                    break;
    //            }
    //        }
    //    }
    //}
}
