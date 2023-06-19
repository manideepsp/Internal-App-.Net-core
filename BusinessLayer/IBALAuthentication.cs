using BusinessModel;

namespace BusinessLayer
{
    public interface IBALAuthentication
    {
        public void Register(User user);
        public bool IsUserExist(User user);
        public bool Login(User user);
    }
}
