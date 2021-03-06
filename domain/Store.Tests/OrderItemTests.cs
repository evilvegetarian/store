using System;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, 0, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, -1, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_SetsCount()
        {
            var orderItem = new OrderItem(1, 2, 3m);

            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);
        }

        [Fact]
        public void Count_WithNegtiveValue_throwsArgumentOutOfRangeException()
        {
            var orderItem = new OrderItem(1, 5, 0m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -1;
            });

        }

        [Fact]
        public void Count_WithZeroValue_throwsArgumentOutOfRangeException()
        {
            var orderItem = new OrderItem(1, 5, 0m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });

        }
        [Fact]
        public void Count_WithPositiveValue_SetsValue()
        {
            var orderItem = new OrderItem(1, 5, 0m);

            orderItem.Count = 10;
            Assert.Equal(10, orderItem.Count);

        }
    }
}
