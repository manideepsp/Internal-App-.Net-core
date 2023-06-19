using BusinessModel;

namespace BusinessLayer
{
    public interface IBLLAuthentication
    {
        public void Register(User user);
        public bool IsUserExist(User user);
        public bool Login(User user);
    }
}
