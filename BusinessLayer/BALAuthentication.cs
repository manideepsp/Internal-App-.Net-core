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
            DALFactory dataFactory = new DALFactory();
            IDAL dal = dataFactory.GetDALAuthObj();

            dal.Register(user);
            Console.WriteLine(Literal.successRegistration);
        }

        public bool IsUserExist(User user)
        {
            DALFactory dataFactory = new DALFactory();
            IDAL dal = dataFactory.GetDALAuthObj();

            if (!dal.IsUserExist(user))
            {
                return true;
            }
            return false;
        }

        public bool IsLoginExist(User user)
        {
            DALFactory dataFactory = new DALFactory();
            IDAL dal = dataFactory.GetDALAuthObj();
            if (dal.IsLoginExist(user))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(User user)
        {
            DALFactory dataFactory = new DALFactory();
            IDAL dal = dataFactory.GetDALAuthObj();

            if (dal.IsLoginExist(user))
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
