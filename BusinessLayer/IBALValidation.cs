namespace BusinessLayer
{
    public interface IBALValidation
    {
        public bool IsValidPassword(string password);
        public bool IsPasswordEquals(string a, string b);
        public bool IsValidEmail(string email);
        public bool IsValidMobile(string mobileNumber);
    }
}
