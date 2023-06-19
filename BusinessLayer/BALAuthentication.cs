using BusinessModel;
using DataLayer;

namespace BusinessLayer
{
    public class BALAuthentication
    {
        /// <summary>
        /// Implements Register user functionality, validates all the inputs given and calls method to write it to database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lit"></param>
        /// <returns></returns>
        public void Register(User user)
        {
            DataFactory dataFactory = new DataFactory();
            IDAL dal = dataFactory.CreateObject();

            dal.Register(user);
            Console.WriteLine(Literal.successRegistration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(User user)
        {
            DataFactory dataFactory = new DataFactory();
            IDAL dal = dataFactory.CreateObject();

            if (dal.IsLoginExist(user.Username, user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Implements the logout functionality
        /// </summary>
        /// <param name="lit"></param>
        /// <returns></returns>
        public bool Logout()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Implements the Switch default functionality
        /// </summary>
        /// <param name="lit"></param>
        /// <returns></returns>
        public bool SwitchDefault()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
