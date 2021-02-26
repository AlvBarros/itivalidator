namespace Validation.Interfaces
{
    /// <summary>
    /// Abstract class based around the validation of a T model
    /// </summary>
    /// <typeparam name="T">The type to be validated</typeparam>
    public abstract class IValidated<T>
    {
        /// <summary>
        /// Validator to be used to validate IValidated.Value
        /// </summary>
        /// <value>IValidator instance</value>
        public IValidator<T> Validator { get; set; }

        /// <summary>
        /// Value of given type T to be validated
        /// </summary>
        /// <value>Value of given type T</value>
        public T Value { get; set; }

        /// <summary>
        /// Valid status based around IValidated.Validator
        /// </summary>
        /// <returns>Either true or false</returns>
        public bool IsValid => this.Validator.Validate(Value);
    }
}