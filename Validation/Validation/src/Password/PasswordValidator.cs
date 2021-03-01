using System;
using System.Linq;
using Validation.Interfaces;

namespace Validation.Password
{
    /// <summary>
    /// This class is used to validate a Validation.Password.Value
    /// </summary>
    public class PasswordValidator : IValidator<string>
    {
        /// <summary>
        /// Check if given value is accepted given every rule
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        public bool Validate(string value)
        {
            return 
                    ContainsCharacters(value) &&
                    ContainsOnlyValidCharacters(value) &&
                    ContainsNineOrMoreCharacters(value) &&
                    ContainsAtLeastOneDigit(value) &&
                    ContainsAtLeastOneLowercaseLetter(value) &&
                    ContainsAtLeastOneUppercaseLetter(value) &&
                    ContainsAtLeastOneSpecialCharacter(value) &&
                    ContainsNoRepeatedCharacters(value);
        }

        /// <summary>
        /// Default list of accepted special characters
        /// </summary>
        /// <returns>List of 12 special characters allowed in a password</returns>
        private static char[] SPECIAL_CHARACTERS = new char[12] {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'};
        
        /// <summary>
        /// Minimum Password size
        /// </summary>
        private static int MIN_LENGTH = 9;

        /// <summary>
        /// Validate a string to check if it contains any character
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsCharacters(string value) => !string.IsNullOrEmpty(value);

        /// <summary>
        /// Validate a string to check if it contains only valid characters
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsOnlyValidCharacters(string value) => value.All((char c) => char.IsLetterOrDigit(c) || SPECIAL_CHARACTERS.Contains(c));
        
        /// <summary>
        /// Validate a string to check if it contains at least the minimum specified value of characters
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsNineOrMoreCharacters(string value) => value.Length >= MIN_LENGTH;
        
        /// <summary>
        /// Validate a string to check if it contains any digit
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsAtLeastOneDigit(string value) => value.Any(char.IsDigit);
        
        /// <summary>
        /// Validate a string to check if it contains any lowercase letter
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsAtLeastOneLowercaseLetter(string value) => value.Any(char.IsLower);
        
        /// <summary>
        /// Validate a string to check if it contains any uppercase letter
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsAtLeastOneUppercaseLetter(string value) => value.Any(char.IsUpper);
        
        /// <summary>
        /// Validate a string to check if it contains any special character
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsAtLeastOneSpecialCharacter(string value) => value.Any((char c) => SPECIAL_CHARACTERS.Contains(c));
        
        /// <summary>
        /// Validate a string to check if it contains any repeated characters
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <returns>Either true or false</returns>
        private bool ContainsNoRepeatedCharacters(string value) => !value.Any((char x) => value.Count((char y) => x == y) > 1);
    }
}
