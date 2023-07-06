using AutoMapper;
using BusinessModel;
using DataModel;

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
        /// <param name="businessModelUser"></param>
        /// <returns></returns>
        public void Register(BusinessUser businessModelUser)
        {
            // Auto Mapper Initialization and Mapping businessModelUesr to dataModelUser
            IMapper mapper = DataLayer.AutoMapperConfig.Initialize();
            DataUser dataModelUser = mapper.Map<DataUser>(businessModelUser);

            DALDataSources.UserData.Add(dataModelUser);
        }

        /// <summary>
        /// Updates the user password
        /// </summary>
        /// <param name="businessModelUser"></param>
        public void UpdatePassword(BusinessUser businessModelUser)
        {
            DataUser? obj = DALDataSources.UserData.Find(obj => obj.Username == businessModelUser.Username);
            if (obj != null)
            {
                obj.Password = businessModelUser.Password;
            }
        }

        /// <summary>
        /// checks if the username, overloaded with another method with similar functionality
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUserExist(BusinessUser businessModelUser)
        {
            DataUser? obj = DALDataSources.UserData.Find(obj => obj.Username == businessModelUser.Username);
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
        public bool IsLoginExist(BusinessUser businessModelUser)
        {
            DataUser? obj = DALDataSources.UserData.Find(obj => obj.Username == businessModelUser.Username);
            if (obj != null)
            {
                if (obj.Password == businessModelUser.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
