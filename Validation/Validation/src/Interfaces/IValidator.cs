namespace Validation.Interfaces
{
    /// <summary>
    /// This interface wraps around validation of a specific type
    /// </summary>
    /// <typeparam name="T">Type to be validated</typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Validate an object
        /// </summary>
        /// <param name="value">Object to be validated</param>
        /// <returns>Either true or false</returns>
        bool Validate(T value);
    }
}