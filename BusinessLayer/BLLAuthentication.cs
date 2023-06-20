using BusinessModel;
using DataLayer;

namespace BusinessLayer
{
    /// <summary>
    /// Contains Authentication logic
    /// </summary>
    internal class BLLAuthentication : IBLLAuthentication
    {
        DALFactory dataFactory = new DALFactory();

        /// <summary>
        /// Implements Register user functionality, validates all the inputs given and calls method to write it to database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lit"></param>
        /// <returns></returns>
        public void Register(User user)
        {
            IDAL dal = dataFactory.GetDALAuthObj();

            dal.Register(user);
        }

        /// <summary>
        /// Checks if the user exists in the Data Source
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserExist(User user)
        {
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
            IDAL dal = dataFactory.GetDALAuthObj();

            if (dal.IsLoginExist(user))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the password in Datasource
        /// </summary>
        /// <param name="user"></param>
        public void UpdatePassword(User user)
        {
            IDAL dal = dataFactory.GetDALAuthObj();

            dal.UpdatePassword(user);
        }
    }
}
