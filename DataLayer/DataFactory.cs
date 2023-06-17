namespace DataLayer
{
    public class DataFactory
    {
        DALAuthentication obj = new DALAuthentication();
        public IDAL CreateObject()
        {
            return obj;
        }
    }
}
