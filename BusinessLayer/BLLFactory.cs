namespace BusinessLayer
{
    public class BLLFactory
    {
        BLLAuthentication bllAuthObj = new BLLAuthentication();
        BLLValidation bllValidationObj = new BLLValidation();

        public IBLLAuthentication GetBllAuthObj()
        {
            return bllAuthObj;
        }
        public IBLLValidation GetBllValidationObj()
        {
            return bllValidationObj;
        }
    }
}
