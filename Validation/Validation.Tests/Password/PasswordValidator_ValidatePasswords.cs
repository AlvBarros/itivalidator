using System;
using Validation.Password;
using Xunit;

namespace Validation.Tests.Password
{
    public class PasswordValidator_ValidatePasswords
    {
        private static string VALID_PASSWORD = "AbTp9!fok";
        private static string LONG_PASSWORD = "AbTp9!fokZxcNM$@%";
        private static string SHORT_PASSWORD = "AbTp9!fo";
        private static string NO_UPPERCASE = "abtp8!fok";
        private static string NO_LOWERCASE = "ABTP9!FOK";
        private static string NO_SPECIAL = "AbTp91fok";
        private static string REPEATED_CHARACTERS = "AbTp9!foA";
        private static string CONTAINS_WHITESPACE = "AbTp9 fok";

        private PasswordValidator BuildPasswordValidator() {
            return new PasswordValidator();
        }

        [Fact]
        public void ValidatePasswords_ValidPassword()
        {
            var passwordValidator = BuildPasswordValidator();
            Assert.True(passwordValidator.Validate(VALID_PASSWORD), "Valid password");
            Assert.True(passwordValidator.Validate(LONG_PASSWORD), "Longer valid password");
        }

        [Fact]
        public void ValidatePasswords_InvalidPasswords()
        {
            var passwordValidator = BuildPasswordValidator();
            Assert.False(passwordValidator.Validate(SHORT_PASSWORD), "Password too short");
            Assert.False(passwordValidator.Validate(NO_UPPERCASE), "Password must have at least one uppercase letter");
            Assert.False(passwordValidator.Validate(NO_LOWERCASE), "Password must have at least one lowercase letter");
            Assert.False(passwordValidator.Validate(NO_SPECIAL), "Password must have at least one special character");
            Assert.False(passwordValidator.Validate(REPEATED_CHARACTERS), "Password must not have any repeated characters");
            Assert.False(passwordValidator.Validate(CONTAINS_WHITESPACE), "Password must not contain any whitespace");
        }
    }
}
