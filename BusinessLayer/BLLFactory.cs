namespace BusinessLayer
{
    public class BLLFactory
    {
        BLLAuthentication balAuthObj = new BLLAuthentication();
        BLLValidation balValidationObj = new BLLValidation();

        public IBLLAuthentication GetBalAuthObj()
        {
            return balAuthObj;
        }
        public IBLLValidation GetBalValidationObj()
        {
            return balValidationObj;
        }
    }
}
