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
            Assert.True(passwordValidator.Validate(VALID_PASSWORD), "Valid password - PasswordValidator");
            Assert.True(new Validation.Password.Password(VALID_PASSWORD).IsValid, "Valid password - Password");
            Assert.True(passwordValidator.Validate(LONG_PASSWORD), "Long password - PasswordValidator");
            Assert.True(new Validation.Password.Password(LONG_PASSWORD).IsValid, "Long password - Password");
        }

        [Fact]
        public void ValidatePasswords_InvalidPasswords()
        {
            var passwordValidator = BuildPasswordValidator();
            // PasswordValidator
            Assert.False(passwordValidator.Validate(SHORT_PASSWORD), "Password too short - PasswordValidator");
            Assert.False(passwordValidator.Validate(NO_UPPERCASE), "Password must have at least one uppercase letter - PasswordValidator");
            Assert.False(passwordValidator.Validate(NO_LOWERCASE), "Password must have at least one lowercase letter - PasswordValidator");
            Assert.False(passwordValidator.Validate(NO_SPECIAL), "Password must have at least one special character - PasswordValidator");
            Assert.False(passwordValidator.Validate(REPEATED_CHARACTERS), "Password must not have any repeated characters - PasswordValidator");
            Assert.False(passwordValidator.Validate(CONTAINS_WHITESPACE), "Password must not contain any whitespace - PasswordValidator");
            // Password
            Assert.False(new Validation.Password.Password(SHORT_PASSWORD).IsValid, "Password too short - PasswordValidator");
            Assert.False(new Validation.Password.Password(NO_UPPERCASE).IsValid, "Password must have at least one uppercase letter - PasswordValidator");
            Assert.False(new Validation.Password.Password(NO_LOWERCASE).IsValid, "Password must have at least one lowercase letter - PasswordValidator");
            Assert.False(new Validation.Password.Password(NO_SPECIAL).IsValid, "Password must have at least one special character - PasswordValidator");
            Assert.False(new Validation.Password.Password(REPEATED_CHARACTERS).IsValid, "Password must not have any repeated characters - PasswordValidator");
            Assert.False(new Validation.Password.Password(CONTAINS_WHITESPACE).IsValid, "Password must not contain any whitespace - PasswordValidator");
        }
    }
}
