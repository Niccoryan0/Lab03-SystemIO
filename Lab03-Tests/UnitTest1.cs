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
        public void ProductCanHandleDifferentSizes(string input, int expected)
        {
            int result = ProdString(input);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void ProductCanHandleEmpties()
        {
            int result = ProdString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 18, 15, 16 }, 13.25)]
        [InlineData(new int[] { 10, 4, 13 }, 9)]
        public void CanGetAverages(int[] arr, decimal expected)
        {
            decimal result = GetAverage(arr);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void CanHandleAllZeroes()
        {
            int[] test = new int[] { 0, 0, 0, 0 };
            decimal result = GetAverage(test);
            Assert.Equal(0, result);
        }
    }
}
