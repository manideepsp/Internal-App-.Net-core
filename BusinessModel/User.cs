namespace BusinessModel
{
    /// <summary>
    /// This class contains all the properties of object
    /// </summary>
    public class User
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _email;
        private string _mobile;
        private int _input;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public string Mobile { get => _mobile; set => _mobile = value; }
        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value; }
        public int Input { get => _input; set => _input = value; }
    }
}
