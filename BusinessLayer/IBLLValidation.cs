using BusinessModel;

namespace BusinessLayer
{
    /// <summary>
    /// Interface contains Bll Validation method signatures
    /// </summary>
    public interface IBLLValidation
    {
        /// <summary>
        /// Method signature of IsValidPassword in Bll Validation
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password);

        /// <summary>
        /// Method signature of IsPasswordEquals in Bll Validation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsPasswordEquals(string a, string b);

        /// <summary>
        /// Method signature of IsValidEmail in Bll Validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email);

        /// <summary>
        /// Method signature of IsValidMobile in Bll Validation
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public bool IsValidMobile(string mobileNumber);

        /// <summary>
        /// Method signature of IsValidUsername in Bll Validation
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValidUsername(User user);

    }
}
