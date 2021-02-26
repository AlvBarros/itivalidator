namespace Validation.Interfaces
{
    public interface IValidator<T>
    {
        bool Validate(T value);
    }
}