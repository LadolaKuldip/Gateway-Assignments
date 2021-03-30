using Testing_Assignment_2;
using Xunit;
namespace UnitTestProject
{

    public class UnitTest
    {
        string input = "";
        string expected = "";

        [Theory]
        [InlineData("TestString", "tESTsTRING")]
        public void ChangeCase(string input1, string expected1)
        {
            //Arrange
            
            //Act
            string output = input1.ChangeCase();

            //Assert
            Assert.Equal(expected1 ,output);
        }

        [Fact]
        public void ConvertTitleCase()
        {
            //Arrange
            input = "unit test";
            expected = "Unit Test";
            //Act
            string output = input.ConvertTitleCase();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ConvertCapitalized()
        {
            //Arrange
            input = "unit test";
            expected = "Unit Test";
            //Act
            string output = input.ConvertCapitalized();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckForLower()
        {
            //Arrange
            input = "unittest";
            expected = "Success";
            //Act
            string output = input.CheckForLower();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckForUppar()
        {
            //Arrange
            input = "UNITTEST";
            expected = "Success";
            //Act
            string output = input.CheckForUppar();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CheckforInt()
        {
            //Arrange
            input = "100";
            expected = "Success";
            //Act
            string output = input.CheckforInt();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void RemoveLastChar()
        {
            //Arrange
            input = "Unit Test";
            expected = "Unit Tes";
            //Act
            string output = input.RemoveLastChar();

            //Assert
            Assert.Equal(expected, output);
        }

        [Fact]
        public void WordCount()
        {
            //Arrange
            input = "Unit Test";
            expected = "2";
            //Act
            string output = input.WordCount();

            //Assert
            Assert.Equal(expected, output);
        }


        [Fact]
        public void StringToInt()
        {
            //Arrange
            input = "100";
            expected = "100";
            //Act
            string output = input.StringToInt();

            //Assert
            Assert.Equal(expected, output);
        }
    }
}
