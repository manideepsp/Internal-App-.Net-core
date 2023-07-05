namespace DataModel
{
    public class DataUser
    {
        public string Username;
        public string Password;
        public string Email;
        public string Mobile;

        public DataUser(string Username,  string Password, String Email, string Mobile)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Mobile = Mobile;
        }
    }
}