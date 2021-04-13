using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BooksCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Avarage, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
