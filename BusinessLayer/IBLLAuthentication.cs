using BusinessModel;

namespace BusinessLayer
{
    /// <summary>
    /// Interface that contains Authentication method signatures
    /// </summary>
    public interface IBLLAuthentication
    {
        /// <summary>
        /// Method signature for Register method in Bll Authentication
        /// </summary>
        /// <param name="user"></param>
        public void Register(User user);

        /// <summary>
        /// method signature for Login method in Bll Authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(User user);

        /// <summary>
        /// method signature for UpdatePassword method in Bll Authentication
        /// </summary>
        /// <param name="user"></param>
        public void UpdatePassword(User user);

        /// <summary>
        /// method signature for IsUserExist method in Bll Authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserExist(User user);
    }
}
