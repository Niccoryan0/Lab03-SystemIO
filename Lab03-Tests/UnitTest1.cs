using System;
using Xunit;
using static Lab03_SystemIO.Program;

namespace Lab03_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("3 2 4", 24)]
        [InlineData("2 8 3", 48)]

        public void CanCalculateProducts(string input, int expected)
        {
            int result = ProdString(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 2", 0)]
        [InlineData("5 2 3 4", 30)]
        public void CanHandleDifferentSizes(string input, int expected)
        {
            int result = ProdString(input);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void CanHandleEmpties()
        {
            int result = ProdString("");
            Assert.Equal(0, result);
        }
    }
}
