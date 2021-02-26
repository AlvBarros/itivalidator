namespace Validation.Password
{
    public class Password
    {
        public bool IsValid { get; private set; }
        public string Value { get; private set; }

        public Password(string value)
        {
            PasswordValidator validator = new PasswordValidator();
            this.IsValid = validator.Validate(value);
            this.Value = value;
        }   
    }
}