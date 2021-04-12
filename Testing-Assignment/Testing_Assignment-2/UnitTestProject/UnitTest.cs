using Testing_Assignment_2;
using Xunit;
namespace UnitTestProject
{

    public class UnitTest
    {
        string input = string.Empty;
        string expected = string.Empty;

        [Theory]
        [InlineData("TestString", "tESTsTRING")]
        public void InvertsCase_BothCases_String_Input_Test(string input1, string expected1)
        {
            // Arrange
            
            // Act
            string output = input1.InvertsCase();

            // Assert
            Assert.Equal(expected1 ,output);
        }

        [Fact]
        public void InvertsCase_Integers_String_Input_Test()
        {
            // Arrange
            input = "1234";
            expected = "1234";

            // Act
            string output = input.ConvertToTitleCase();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ConvertToTitleCase_LowerCases_String_Input_Test()
        {
            // Arrange
            input = "unit test";
            expected = "Unit Test";

            // Act
            string output = input.ConvertToTitleCase();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ConvertToCapitalized_LowerCases_String_Input_Test()
        {
            // Arrange
            input = "unit";
            expected = "Unit";

            // Act
            string output = input.ConvertToCapitalized();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckForLowercase_LowerCases_String_Input_Test()
        {
            // Arrange
            input = "unittest";
            expected = "Success";

            // Act
            string output = input.CheckForLowercase();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckForUpparcase_UpparCases_String_Input_Test()
        {
            // Arrange
            input = "UNITTEST";
            expected = "Success";

            // Act
            string output = input.CheckForUpparcase();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckForInteger_Integers_String_Input_Test()
        {
            // Arrange
            input = "100";
            expected = "Success";

            // Act
            string output = input.CheckForInteger();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void RemoveLastCharacter_Alphanumeric_String_Input_Test()
        {
            // Arrange
            input = "Unit Test";
            expected = "Unit Tes";

            // Act
            string output = input.RemoveLastCharacter();

            // Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CountNoOfWords_Alphanumeric_String_Input_Test()
        {
            // Arrange
            input = "Unit Test";
            expected = "2";

            // Act
            string output = input.CountNoOfWords();

            // Assert
            Assert.Equal(expected, output);
        }


        [Fact]
        public void StringToInt_Integers_String_Input_Test()
        {
            // Arrange
            input = "100";
            expected = "100";

            // Act
            string output = input.StringToInt();

            // Assert
            Assert.Equal(expected, output);
        }
    }
}
