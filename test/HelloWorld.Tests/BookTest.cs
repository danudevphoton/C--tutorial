using System;
using Xunit;

namespace HelloWorld.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculateAvg()
        {
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            var result = book.GetStatistics();
            Assert.Equal(85.6,result.average);
            Assert.Equal(90.5,result.high);
            Assert.Equal(77.3,result.low); 
        }
    }
}