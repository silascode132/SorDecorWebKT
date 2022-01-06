using System;
using Xunit;


namespace PasswordValidatorTests
{
    public class ValidityTest
    {
        [Theory]
        [InlineData("Th1sIsapassword!")]
        [InlineData("thisIsapassword123!")]
        [InlineData("Abc$123456")]
        public void ValidPassword(string password)
        {
            //Arrange
            var passwordValidator = new UserController();

            //Act
            bool isValid = passwordValidator.IsValid(password);

            //Assert
            Assert.True(expectedResult);
        }

        [Theory]
        [InlineData("Th1s!")]
        [InlineData("thisIsAPassword")]
        [InlineData("thisisapassword#")]
        [InlineData("THISISAPASSWORD123!")]
        [InlineData("")]
        public void NotValidPassword(string password)
        {
            //Arrange
            var passwordValidator = new PasswordValidator();

            //Act
            bool isValid = passwordValidator.IsValid(password);

            //Assert
            Assert.False(expectedResult);
        }
    }
}