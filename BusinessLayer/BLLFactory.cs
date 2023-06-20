namespace BusinessLayer
{
    /// <summary>
    /// Factory class for creating Business Logic Layer (BLL) objects.
    /// </summary>
    public class BLLFactory
    {
        private readonly IBLLAuthentication bllAuthObj;
        private readonly IBLLValidation bllValidationObj;

        /// <summary>
        /// Initializes a new instance of the BLLFactory class.
        /// </summary>
        public BLLFactory()
        {
            // Create an instance of BLLAuthentication
            bllAuthObj = new BLLAuthentication();

            // Create an instance of BLLValidation
            bllValidationObj = new BLLValidation();
        }

        /// <summary>
        /// Returns an instance of IBLLAuthentication.
        /// </summary>
        /// <returns>An instance of IBLLAuthentication.</returns>
        public IBLLAuthentication GetBllAuthObj()
        {
            return bllAuthObj;
        }

        /// <summary>
        /// Returns an instance of IBLLValidation.
        /// </summary>
        /// <returns>An instance of IBLLValidation.</returns>
        public IBLLValidation GetBllValidationObj()
        {
            return bllValidationObj;
        }
    }
}
