namespace BusinessLayer
{
    public class BALFactory
    {
        BALAuthentication balAuthObj = new BALAuthentication();
        BALValidation balValidationObj = new BALValidation();

        public IBALAuthentication GetBalAuthObj()
        {
            return balAuthObj;
        }
        public IBALValidation GetBalValidationObj()
        {
            return balValidationObj;
        }
    }
}
