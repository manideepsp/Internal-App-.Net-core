using DataLayer;
using System.Linq;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// contains the logic for the validations of the input given
    /// </summary>
    public class BALValidations
    {
        /// <summary>
        /// Calls data method to check if user name is valid, passes the username and checks if the username exist in the database or not
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsValidUsername(string userName)
        {
            DataFactory dataFactory = new DataFactory();
            IDAL dal = dataFactory.CreateObject();

            if (!dal.IsUserExist(userName))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calls data method to check if the username and password is present in the database or not
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidLogin(string userName, string password)
        {
            DataFactory dataFactory = new DataFactory();
            IDAL dal = dataFactory.CreateObject();
            if (dal.IsLoginExist(userName, password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks the validation for the password using regex
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            if (password == null || password.Length < 8 || Regex.IsMatch(password, "[a-z]") == false || Regex.IsMatch(password, "[A-Z]") == false || Regex.IsMatch(password, "[0-9]") == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// validates if the password and confirmpassword are equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsPasswordEquals(string a, string b)
        {
            if (a.Equals(b)) return true;
            else return false;
        }

        /// <summary>
        /// validates the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            if (email.Contains("@") && email.Contains(".") && email.IndexOf("@") < email.IndexOf("."))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// validates the mobile number
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public bool IsValidMobile(string mobileNumber)
        {
            if (mobileNumber.Count() == 10 && IsDigitsOnly(mobileNumber))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// snippet checks if the given string contains all numbers or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
