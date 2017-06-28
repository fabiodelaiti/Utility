using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FabioTheLight
{
    public class ExpectedExceptionWithMessageAttribute : ExpectedExceptionBaseAttribute
    {
        public Type ExceptionType { get; set; }
        public string ExpectedMessage { get; set; }
        public bool JustPartOfMessage { get; private set; }

        public ExpectedExceptionWithMessageAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }

        public ExpectedExceptionWithMessageAttribute(Type exceptionType, string expectedMessage, bool justPartOfMessage = false)
        {
            this.ExceptionType = exceptionType;
            this.JustPartOfMessage = justPartOfMessage;
            this.ExpectedMessage = expectedMessage;
        }

        protected override void Verify(Exception e)
        {
            if (e.GetType() != this.ExceptionType)
            {
                Assert.Fail(String.Format(
                                "ExpectedExceptionWithMessageAttribute failed. Expected exception type: {0}. Actual exception type: {1}. Exception message: {2}",
                                this.ExceptionType.FullName,
                                e.GetType().FullName,
                                e.Message
                                )
                            );
            }

            var actualMessage = e.Message.Trim();

            if (this.ExpectedMessage != null)
            {
                if (JustPartOfMessage)
                {
                    if (!actualMessage.Contains(ExpectedMessage))
                        Assert.Fail($"Exception message \"{actualMessage}\" does not contain \"{ExpectedMessage}\"");
                }
                else
                {
                    if (actualMessage != ExpectedMessage)
                        Assert.Fail($"Expected exception message \"{actualMessage}\" but was \"{ExpectedMessage}\"");

                }
            }
        }
    }

}
