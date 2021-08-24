using ProdStore;
using System;
using Xunit;

namespace Tests
{
    public class ProductTests
    {
        [Fact]
        public void IsCode_WithNull_ReturnsFalse()
        {
            bool actual = Product.IsCode(null);
            Assert.False(actual);
        }
        [Fact]
        public void IsCode_WithInvalidCode_ReturnsFalse()
        {
            bool actual = Product.IsCode("1335");
            Assert.False(actual);
        }
        [Fact]
        public void IsCode_WithEmptyString_ReturnsFalse()
        {
            bool actual = Product.IsCode("");
            Assert.False(actual);
        }
        [Fact]
        public void IsCode_WithArticul7_ReturnsTrue()
        {
            var actual = Product.IsCode("1234567");
            Assert.True(actual);
        }
    }
}
