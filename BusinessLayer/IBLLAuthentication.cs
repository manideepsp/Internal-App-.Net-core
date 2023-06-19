using BusinessModel;

namespace BusinessLayer
{
    public interface IBLLAuthentication
    {
        public void Register(User user);
        public bool Login(User user);
        public void UpdatePassword(User user);
        public bool IsUserExist(User user);
    }
}
