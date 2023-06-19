namespace DataLayer
{
    /// <summary>
    /// Factory class used for object creation of DALAuthentication
    /// </summary>
    public class DataFactory
    {
        DALAuthentication obj = new DALAuthentication();
        /// <summary>
        /// Retruns created object of DALAuthentication as a type of IDAL
        /// </summary>
        /// <returns></returns>
        public IDAL GetDALAuthObj()
        {
            return obj;
        }
    }
}
