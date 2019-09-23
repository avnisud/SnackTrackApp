using System;
using System.Runtime.Serialization;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// Framework exception class.
    /// </summary>
    [Serializable]
    class SnackAttAppFrameworkException : Exception
    {
        public SnackAttAppFrameworkException()
        {
        }

        public SnackAttAppFrameworkException(string message) : base(message)
        {
        }

        public SnackAttAppFrameworkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        private SnackAttAppFrameworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
