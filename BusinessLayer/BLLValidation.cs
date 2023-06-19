using BusinessModel;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// contains the logic for the validations of the input given
    /// </summary>
    internal class BLLValidation : IBLLValidation
    {
        /// <summary>
        /// checks the validation for the password using regex
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if(Regex.IsMatch(password, Literal.passwordPattern) && password != null)
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
            if(Regex.IsMatch(email, Literal.emailPattern) && email != null)
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
            if (Regex.IsMatch(mobileNumber, Literal.mobilePattern) && mobileNumber != null)
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
