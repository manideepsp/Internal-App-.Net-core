using BusinessLayer;
using BusinessModel;

namespace ConsoleApp
{
    /// <summary>
    /// Class that does authentication in Presentation layer
    /// </summary>
    public class Authentication
    {
        BLLFactory bllFactory = new BLLFactory();
        ConsoleKeyInfo inputKey;


        /// <summary>
        /// Implements login authentication signature
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lit"></param>
        /// <returns></returns>
        public Redirect Login(User user)
        {
            IBLLAuthentication bllAuthentication = bllFactory.GetBllAuthObj();

            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            Console.Write(Literal.password);
            user.Password = Console.ReadLine();

            if (bllAuthentication.Login(user))
            {
                Console.WriteLine(Literal.loginSuccess);
                return Redirect.logout;
            }
            else
            {
                Console.WriteLine(Literal.loginFail);
                inputKey= Console.ReadKey();
                if (inputKey.Key == ConsoleKey.D1)
                {
                    return Redirect.register;
                }
                else if (inputKey.Key == ConsoleKey.D2)
                {
                    return Redirect.ForgotPassword;
                }
                else if (inputKey.Key == ConsoleKey.D3)
                {
                    return Redirect.login;
                }
                return Redirect.exit;
            }
        }

        /// <summary>
        /// Implements logout Functionality
        /// </summary>
        /// <returns></returns>
        public Redirect Logout()
        {
            Console.WriteLine(Literal.logout);
            inputKey= Console.ReadKey();
            if (inputKey.Key == ConsoleKey.Y)
            {
                Console.WriteLine(Literal.logoutSuccess);
                return Redirect.login;
            }
            return Redirect.logout;
        }

        /// <summary>
        /// Implements Register authentication signature
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Redirect Register(User user)
        {
            IBLLAuthentication bllAuthentication = bllFactory.GetBllAuthObj();
            IBLLValidation bllValidation = bllFactory.GetBllValidationObj();

            bool flag = true;

            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            flag = bllAuthentication.IsUserExist(user); //returns true if username is valid, not already exist
            if (!flag)
            {
                Console.WriteLine(Literal.userExist);
                return Redirect.login;
            }

            Console.WriteLine(Literal.validPassword);
            Console.Write(Literal.password);
            user.Password = Console.ReadLine();
            flag = bllValidation.IsValidPassword(user.Password); //returns true if password is valid
            while (!flag)
            {
                Console.Write(Literal.passwordAgain);
                user.Password = Console.ReadLine();
                flag = bllValidation.IsValidPassword(user.Password);
            }
            Console.Write(Literal.confirmPassword);
            user.ConfirmPassword = Console.ReadLine();
            flag = bllValidation.IsPasswordEquals(user.Password, user.ConfirmPassword); //returns true if password mathces
            while (!flag)
            {
                Console.Write(Literal.confirmPassword);
                user.ConfirmPassword = Console.ReadLine();
                flag = bllValidation.IsPasswordEquals(user.Password, user.ConfirmPassword);
            }

            Console.Write(Literal.mobile);
            user.Mobile = Console.ReadLine();
            flag = bllValidation.IsValidMobile(user.Mobile); //returns true if mobile is valid
            while (!flag)
            {
                Console.Write(Literal.mobileAgain);
                user.Mobile = Console.ReadLine();
                flag = bllValidation.IsValidMobile(user.Mobile);
            }

            Console.Write(Literal.email);
            user.Email = Console.ReadLine();
            flag = bllValidation.IsValidEmail(user.Email); //returns true if email is valid
            while (!flag)
            {
                Console.Write(Literal.emailAgain);
                user.Email = Console.ReadLine();
                flag = bllValidation.IsValidEmail(user.Email);
            }
            bllAuthentication.Register(user);
            Console.WriteLine(Literal.div + Literal.registrationSuccess);

            inputKey= Console.ReadKey();
            if (inputKey.Key == ConsoleKey.D1)
            {
                return Redirect.login;
            }
            return Redirect.exit;
        }

        /// <summary>
        /// Implements Forgot password functionality
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Redirect forgotPassword(User user)
        {
            IBLLAuthentication bllAuthentication = bllFactory.GetBllAuthObj();
            IBLLValidation bllValidation = bllFactory.GetBllValidationObj();

            bool flag = true;

            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            flag = bllAuthentication.IsUserExist(user); //returns true if username doesnot exist
            if (!flag)
            {
                Console.WriteLine(Literal.validPassword);
                Console.Write(Literal.password);
                user.Password = Console.ReadLine();
                flag = bllValidation.IsValidPassword(user.Password); //returns true if password is valid
                while (!flag)
                {
                    Console.Write(Literal.passwordAgain);
                    user.Password = Console.ReadLine();
                    flag = bllValidation.IsValidPassword(user.Password);
                }
                Console.Write(Literal.confirmPassword);
                user.ConfirmPassword = Console.ReadLine();
                flag = bllValidation.IsPasswordEquals(user.Password, user.ConfirmPassword); //returns true if password mathces
                while (!flag)
                {
                    Console.Write(Literal.confirmPassword);
                    user.ConfirmPassword = Console.ReadLine();
                    flag = bllValidation.IsPasswordEquals(user.Password, user.ConfirmPassword);
                }
                bllAuthentication.UpdatePassword(user);
                Console.WriteLine(Literal.forgotPasswordSuccess);
                return Redirect.login;
            }
            else
            {
                Console.WriteLine(Literal.forgotPasswordFail);
                inputKey= Console.ReadKey();
                if (inputKey.Key == ConsoleKey.D1)
                {
                    return Redirect.ForgotPassword;
                }
                else if (inputKey.Key == ConsoleKey.D2)
                {
                    return Redirect.login;
                }
                else if (inputKey.Key == ConsoleKey.D3)
                {
                    return Redirect.register;
                }
                return Redirect.exit;
            }
        }
    }
}
