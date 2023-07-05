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
        /// <returns></returns>
        public void Register(BusinessUser user)
        {
            IDAL dalAuth = dataFactory.GetDALAuthObj();

            dalAuth.Register(user);
        }

        /// <summary>
        /// Checks if the user exists in the Data Source
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserExist(BusinessUser user)
        {
            IDAL dalAuth = dataFactory.GetDALAuthObj();

            if (!dalAuth.IsUserExist(user))
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
        public bool Login(BusinessUser user)
        {
            IDAL dalAuth = dataFactory.GetDALAuthObj();

            if (dalAuth.IsLoginExist(user))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the password in Datasource
        /// </summary>
        /// <param name="user"></param>
        public void UpdatePassword(BusinessUser user)
        {
            IDAL dalAuth = dataFactory.GetDALAuthObj();

            dalAuth.UpdatePassword(user);
        }
    }
}
