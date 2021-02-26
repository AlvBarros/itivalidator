using System;
using System.Linq;
using Validation.Interfaces;

namespace Validation.Password
{
    public class PasswordValidator : IValidator<string>
    {
        private static char[] SPECIAL_CHARACTERS = new char[12] {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'};
        private bool ContainsCharacters(string value) => !string.IsNullOrEmpty(value);
        private bool ContainsOnlyValidCharacters(string value) => value.All((char c) => char.IsLetterOrDigit(c) || SPECIAL_CHARACTERS.Contains(c));
        private bool ContainsNineOrMoreCharacters(string value) => value.Length >= 9;
        private bool ContainsAtLeastOneDigit(string value) => value.Any(char.IsDigit);
        private bool ContainsAtLeastOneLowercaseLetter(string value) => value.Any(char.IsLower);
        private bool ContainsAtLeastOneUppercaseLetter(string value) => value.Any(char.IsUpper);
        private bool ContainsAtLeastOneSpecialCharacter(string value) => value.Any((char c) => SPECIAL_CHARACTERS.Contains(c));
        private bool ContainsNoRepeatedCharacters(string value) => !value.Any((char x) => value.Count((char y) => x == y) > 1);

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
    }
}
