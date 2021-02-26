using Validation.Interfaces;

namespace Validation.Password
{
    /// <summary>
    /// Password model for validation
    /// </summary>
    public class Password : IValidated<string>
    {
        /// <summary>
        /// Instantiate new Password object with given value
        /// </summary>
        /// <param name="value">The value of the password</param>
        public Password(string value)
        {
            base.Validator = new PasswordValidator();
            base.Value = value;
        }
        
    }
}