using System;
using Xunit;

namespace HelloWorld.Tests
{
    public class Person {

    }

    public struct Point {

    }

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogCanMethod(){
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello");
            Assert.Equal("Hello", result);
        }

        string IncrementCount(string message){   
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message){   
            count++;
            return message;
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref Int32 x){
            x = 42;
        }

        private int GetInt(){
            return 3;
        }

        [Fact]
        public void StringsBehaveLike(){
            string name = "Scott";
            var getname = MakeUpperCase(name);

            Assert.Equal("SCOTT",getname);
        }

        private string MakeUpperCase(string param){
            return param.ToUpper();
        }

        [Fact]
        public void CanSetNameForRefer()
        {
            var book1 = GetBook("Book 1");
            SetName(out book1, "New Name");
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(out Book book, string name){
            //book.Name = name;
            book = new Book(name);
        }

        [Fact]
        public void GetBookReturnDiffObj() {
            var book1 = GetBook("1");
            var book2 = GetBook("2");

            Assert.Equal("1",book1.Name);
            Assert.Equal("2",book2.Name);
            Assert.NotSame(book1,book2);
        }

        [Fact]
        public void TwoVarRefer() {
            var book1 = GetBook("1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        Book GetBook(string name) {
            return new Book(name);
        }   
    }
}