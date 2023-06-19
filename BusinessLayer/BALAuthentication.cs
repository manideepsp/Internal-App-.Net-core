using BusinessModel;
using DataLayer;

namespace BusinessLayer
{
    internal class BALAuthentication : IBALAuthentication
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

        /// <summary>
        /// Checks if the user exists in the Data Source
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if user and password pair exist in the DataSource
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
            return false;
        }
    }
}
