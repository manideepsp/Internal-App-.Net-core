using BusinessModel;

namespace DataLayer
{
    /// <summary>
    /// Interface defining the methods that to be used with Factory pattern
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// adds the user details to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void Register(BusinessUser user);

        /// <summary>
        /// checks if the username, overloaded with another method with similar functionality
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsUserExist(BusinessUser user);

        /// <summary>
        /// checks if username and password pair exist in database or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsLoginExist(BusinessUser user);

        /// <summary>
        /// Updates the user details in the data source
        /// </summary>
        /// <param name="user"></param>
        public void UpdatePassword(BusinessUser user);
    }
}
