using System;

namespace SixtyNineDegrees.MiteDesk.Tools.Connector
{
    public class MiteConnectorException : Exception
    {

        public MiteConnectorException(string message)
        {
            this.message = message;
        }

        private readonly string message;

        public override string Message
        {
            get { return message; }
        }

    }
}
