using BusinessLayer;
using BusinessModel;

namespace ConsoleApp
{
    /// <summary>
    /// Class that does authentication in Presentation layer
    /// </summary>
    public class Authentication
    {
        BLLFactory balFactory = new BLLFactory();

        /// <summary>
        /// Implements login authentication signature
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lit"></param>
        /// <returns></returns>
        public Redirect Login(User user)
        {
            IBLLAuthentication balAuthentication = balFactory.GetBalAuthObj();
            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            Console.WriteLine(Literal.password);
            user.Password = Console.ReadLine();

            if (balAuthentication.Login(user))
            {
                Console.WriteLine(Literal.loginSuccess);
                return Redirect.logout;
            }
            else
            {
                Console.WriteLine(Literal.loginFail);
                return Redirect.login;
            }
        }

        /// <summary>
        /// Implements logout Functionality
        /// </summary>
        /// <returns></returns>
        public Redirect Logout()
        {
            Console.WriteLine(Literal.logout);

            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                Console.WriteLine(Literal.successLogout);
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
            IBLLAuthentication balAuthentication = balFactory.GetBalAuthObj();
            IBLLValidation bALValidation = balFactory.GetBalValidationObj();

            bool flag = true;
            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            flag = balAuthentication.IsUserExist(user); //returns true if username is valid, not already exist
            if (!flag)
            {
                Console.WriteLine(Literal.userExist);
                return Redirect.login;
            }

            Console.WriteLine(Literal.validPassword);
            Console.Write(Literal.password);
            user.Password = Console.ReadLine();
            flag = bALValidation.IsValidPassword(user.Password); //returns true if password is valid
            while (!flag)
            {
                Console.Write(Literal.passwordAgain);
                user.Password = Console.ReadLine();
                flag = bALValidation.IsValidPassword(user.Password);
            }
            Console.Write(Literal.confirmPassword);
            user.ConfirmPassword = Console.ReadLine();
            flag = bALValidation.IsPasswordEquals(user.Password, user.ConfirmPassword); //returns true if password mathces
            while (!flag)
            {
                Console.Write(Literal.confirmPassword);
                user.ConfirmPassword = Console.ReadLine();
                flag = bALValidation.IsPasswordEquals(user.Password, user.ConfirmPassword);
            }

            Console.Write(Literal.mobile);
            user.Mobile = Console.ReadLine();
            flag = bALValidation.IsValidMobile(user.Mobile); //returns true if mobile is valid
            while (!flag)
            {
                Console.Write(Literal.mobileAgain);
                user.Mobile = Console.ReadLine();
                flag = bALValidation.IsValidMobile(user.Mobile);
            }

            Console.Write(Literal.email);
            user.Email = Console.ReadLine();
            flag = bALValidation.IsValidEmail(user.Email); //returns true if email is valid
            while (!flag)
            {
                Console.Write(Literal.emailAgain);
                user.Email = Console.ReadLine();
                flag = bALValidation.IsValidEmail(user.Email);
            }
            balAuthentication.Register(user);
            return Redirect.login;
        }

        /// <summary>
        /// Implements SwitchDefault Functionality
        /// </summary>
        /// <returns></returns>
        public Redirect SwitchDefault()
        {
            Console.WriteLine(Literal.switchDefault);

            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                return Redirect.exit;
            }
            return Redirect.login;            
        }
    }
}
