using BusinessModel;

namespace ConsoleApp
{

    /// <summary>
    /// Represents the main program logic for user authentication.
    /// </summary>
    public class App
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
            Redirect redirect;

            Console.WriteLine(Literal.div);
            Console.WriteLine(Literal.menu);

            try
            {
                redirect = (Redirect)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                redirect = Redirect.exit;
            }

            bool flag = true;
            while (flag)
            {
                user = new User();
                switch (redirect)
                {
                    // Exit
                    case Redirect.exit:
                        //flag = false;
                        Console.WriteLine(Literal.div + Literal.exit);
                        Environment.Exit(0);
                        break;
                    // Login
                    case Redirect.login:
                        Console.WriteLine(Literal.div + Literal.login);
                        redirect = auth.Login(user);
                        break;
                    // Register
                    case Redirect.register:
                        Console.WriteLine(Literal.div + Literal.register);
                        redirect = auth.Register(user);
                        break;
                    // Logout
                    case Redirect.logout:
                        Console.WriteLine(Literal.div, Literal.loginSuccess, Literal.logout);
                        redirect = auth.Logout();
                        break;
                    // Forgot password / Change password
                    case Redirect.ForgotPassword:
                        Console.WriteLine(Literal.forgotPassword);
                        redirect = auth.forgotPassword(user);
                        break;
                }
            }
        }
    }
}
