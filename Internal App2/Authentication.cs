using BusinessLayer;
using BusinessModel;

namespace ConsoleApp
{
    /// <summary>
    /// Class that does authentication in Presentation layer
    /// </summary>
    public class Authentication
    {
        private BALAuthentication balAuth;
        private BALValidations validate;

        public Authentication()
        {
            validate = new BALValidations();
            balAuth = new BALAuthentication();
        }

        /// <summary>
        /// Implements login authentication signature
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lit"></param>
        /// <returns></returns>
        public Redirect Login(User user)
        {
            Console.WriteLine(Literal.login);
            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            Console.WriteLine(Literal.password);
            user.Password = Console.ReadLine();

            if (balAuth.Login(user))
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

        //Implements logout authentication signature
        public Redirect Logout()
        {
            Console.WriteLine(Literal.logout);
            if (balAuth.Logout())
            {
                Console.WriteLine(Literal.successLogout);
                return Redirect.login;
            }
            return Redirect.logout;
        }

        //Implements Register authentication signature
        public Redirect Register(User user)
        {
            bool flag = true;
            Console.WriteLine(Literal.register);
            Console.Write(Literal.username);
            user.Username = Console.ReadLine();
            flag = validate.IsValidUsername(user.Username); //returns true if username is valid, not already exist
            if (!flag)
            {
                Console.WriteLine(Literal.userExist);
                return Redirect.login;
            }
            Console.WriteLine(Literal.validPassword);
            Console.Write(Literal.password);
            user.Password = Console.ReadLine();
            flag = validate.IsValidPassword(user.Password); //returns true if password is valid
            while (!flag)
            {
                Console.Write(Literal.passwordAgain);
                user.Password = Console.ReadLine();
                flag = validate.IsValidPassword(user.Password);
            }
            Console.Write(Literal.confirmPassword);
            user.ConfirmPassword = Console.ReadLine();
            flag = validate.IsPasswordEquals(user.Password, user.ConfirmPassword); //returns true if password mathces
            while (!flag)
            {
                Console.Write(Literal.confirmPassword);
                user.ConfirmPassword = Console.ReadLine();
                flag = validate.IsPasswordEquals(user.Password, user.ConfirmPassword);
            }

            Console.Write(Literal.mobile);
            user.Mobile = Console.ReadLine();
            flag = validate.IsValidMobile(user.Mobile); //returns true if mobile is valid
            while (!flag)
            {
                Console.Write(Literal.mobileAgain);
                user.Mobile = Console.ReadLine();
                flag = validate.IsValidMobile(user.Mobile);
            }

            Console.Write(Literal.email);
            user.Email = Console.ReadLine();
            flag = validate.IsValidEmail(user.Email); //returns true if email is valid
            while (!flag)
            {
                Console.Write(Literal.emailAgain);
                user.Email = Console.ReadLine();
                flag = validate.IsValidEmail(user.Email);
            }
            balAuth.Register(user);
            return Redirect.login;
        }

        //Implements SwitchDefault signature
        public Redirect SwitchDefault()
        {
            Console.WriteLine(Literal.switchDefault);
            if (balAuth.SwitchDefault())
            {
                return Redirect.exit;
            }
            return Redirect.login;
        }
    }
}
