using System;

namespace Service.Pattern
{
    public interface IErrorProvider
    {
        string ErrMsg { get; set; }
        string InnerErrMsg { get; set; }
    }

    public class ErrorProvider : IErrorProvider
    {
        public string ErrMsg { get; set; }
        public string InnerErrMsg { get; set; }

        protected void ThrowException(string message = null, string innerMessage = null)
        {
            try
            {
                ErrMsg = message;
                InnerErrMsg = innerMessage;
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}