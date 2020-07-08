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
        public void CanConvertArray()
        {
            string[] arr = new string[] { "1", "2", "3" };
            int[] result = ConvertArray(arr);
            Assert.Equal(new int[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void CanHandleAllZeroes()
        {
            int[] test = new int[] { 0, 0, 0, 0 };
            decimal result = GetAverage(test);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 4, 5, 6, 1, 5, 5 }, 5)]
        [InlineData(new int[] { 10, 15, 34, 3, 5, 6, 8, 10, 11, 1, 1, 3 }, 10)]
        [InlineData(new int[] { 3, 1, 3 }, 3)]
        public void CanGetMostCommon(int[] arr, int expected)
        {
            int result = GetMostFrequent(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 3, 3, 3, 3, 3 }, 3)]
        [InlineData(new int[] { 14, 14, 14 }, 14)]
        public void MostCommonAllSameNumber(int[] arr, int expected)
        {
            int result = GetMostFrequent(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 4, 6, 5 }, 1)]
        [InlineData(new int[] { 7, 3, 9, 10, 15 }, 7)]
        public void MostCommonNoDuplicates(int[] arr, int expected)
        {
            int result = GetMostFrequent(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 4, 5, 6, 1, 1, 5, 5 }, 1)]
        [InlineData(new int[] { 3, 4, 5, 6, 1, 5, 5, 1, 1 }, 5)]
        public void MostCommonMultipleWinners(int[] arr, int expected)
        {
            int result = GetMostFrequent(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 }, 555)]
        [InlineData(new int[] { 467, 40, 433, 223, 2 }, 467)]
        public void CanCalculateMax(int[] arr, int expected)
        {
            int result = GetMax(arr);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HighestOfNegatives()
        {
            int[] arr = new int[] { -5, -25, -99, -123, -78, -96, -555, -108, -4 };
            int result = GetMax(arr);
            Assert.Equal(-4, result);
        }

        [Fact]
        public void HighestOfAllSameValues()
        {
            int[] arr = new int[] { 100, 100, 100, 100, 100 };
            int result = GetMax(arr);
            Assert.Equal(100, result);
        }

        [Theory]
        [InlineData("This.is a test:string", new string[] { "This: 4", "is: 2", "a: 1", "test: 4", "string: 6" })]
        [InlineData("The quick brown", new string[] { "The: 3", "quick: 5", "brown: 5" })]
        [InlineData("", new string[] { ": 0" })]

        public void CanCountLetters(string input, string[] expected)
        {
            string[] result = SentenceCounter(input);
            Assert.Equal(expected, result);
        }
    }
}
