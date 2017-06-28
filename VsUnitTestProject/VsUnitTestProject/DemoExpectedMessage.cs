using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FabioTheLight;

namespace VsUnitTestProject
{
    [TestClass]
    public class DemoExpectedMessage
    {
        
        [TestMethod]
        [ExpectedExceptionWithMessage(typeof(MyException), "my message")]
        public void ExactText()
        {
            throw new MyException("my message");
        }

        [TestMethod]
        [ExpectedExceptionWithMessage(typeof(MyException), "part")]
        public void PartOfText()
        {
            throw new MyException("my part of message");
        }
    }
}
