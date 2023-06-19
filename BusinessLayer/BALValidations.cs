using DataLayer;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// contains the logic for the validations of the input given
    /// </summary>
    public class BALValidations
    {
        /// <summary>
        /// checks the validation for the password using regex
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            // Regex pattern for password validation
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,}$";

            if(Regex.IsMatch(password, pattern) && password != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            #region "commented out old functionality"
            /*if (password == null || password.Length < 8 || Regex.IsMatch(password, "[a-z]") == false || Regex.IsMatch(password, "[A-Z]") == false || Regex.IsMatch(password, "[0-9]") == false)
              {
                  return false;
              }
              return true;*/
            #endregion
        }

        /// <summary>
        /// validates if the password and confirmpassword are equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsPasswordEquals(string a, string b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// validates the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            // Regex pattern for email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if(Regex.IsMatch(email, pattern) && email != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validates the mobile number
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public bool IsValidMobile(string mobileNumber)
        {
            // Regex pattern for validating Indian mobile numbers
            string pattern = @"^[6-9]\d{9}$";

            if (Regex.IsMatch(mobileNumber, pattern) && mobileNumber != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
