using System;

namespace UTurista.FCMessaging
{
    public class FcmException : Exception
    {

        public Error Error { get; }
        public FcmException(Error error):base(error.Message)
        {
            Error = error;
        }

        public override string ToString()
        {
            return Error.Message;
        }
    }
}
