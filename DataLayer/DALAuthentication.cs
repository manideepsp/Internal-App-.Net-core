using BusinessModel;

namespace DataLayer
{
    internal class DALAuthentication : IDAL
    {
        /// <summary>
        /// adds the user details to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Register(User user)
        {
            DALDataSources.UserData.Add(user);
        }
        /// <summary>
        /// checks if the username, overloaded with another method with similar functionality
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUserExist(User user)
        {
            User obj = DALDataSources.UserData.Find(obj => obj.Username == user.Username);
            if (obj != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks if username and password pair exist in database or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsLoginExist(User user)
        {
            User obj = DALDataSources.UserData.Find(obj => obj.Username == user.Username);
            if (obj != null)
            {
                if(obj.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
