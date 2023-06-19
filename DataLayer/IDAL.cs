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
        void Register(User user);

        /// <summary>
        /// checks if the username, overloaded with another method with similar functionality
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool IsUserExist(User user);

        /// <summary>
        /// checks if username and password pair exist in database or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool IsLoginExist(User user);
    }
}
