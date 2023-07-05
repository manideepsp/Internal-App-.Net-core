using BusinessModel;
using DataModel;
using System.Reflection;

namespace DataLayer
{
    /// <summary>
    /// Contains Data Authentication Implementation
    /// </summary>
    internal class DALAuthentication : IDAL
    {
        /// <summary>
        /// adds the user details to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Register(BusinessUser user)
        {
            DataUser dataModelUser = new DataUser();
            dataModelUser = Utils.ConvertUser.ConvertObject<BusinessUser, DataUser>(user, dataModelUser);

            Console.WriteLine("*****************  " + dataModelUser.Username); //debug purpose

            DALDataSources.UserData.Add(dataModelUser);
        }

        /// <summary>
        /// Converts BusinessModel object to DataModel object 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>DataModel object</returns>
        private static DataUser ConvertToDataModel(BusinessUser user)
        {
            DataUser dataUserObj = new DataUser
            {
                Username = user.Username,
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.Password
            };

            return dataUserObj;
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="user"></param>
        public void UpdatePassword(BusinessUser user)
        {
            DataUser obj = DALDataSources.UserData.Find(obj => obj.Username == user.Username);
            if (obj != null)
            {
                obj.Password = user.Password;
            }
        }

        /// <summary>
        /// checks if the username, overloaded with another method with similar functionality
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUserExist(BusinessUser user)
        {
            DataUser obj = DALDataSources.UserData.Find(obj => obj.Username == user.Username);
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
        public bool IsLoginExist(BusinessUser user)
        {
            DataUser obj = DALDataSources.UserData.Find(obj => obj.Username == user.Username);
            if (obj != null)
            {
                if (obj.Password == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
