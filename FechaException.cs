using System;
using System.Runtime.Serialization;

namespace ejercicioFecha
{
    [Serializable]
    internal class FechaException : Exception
    {
        public FechaException()
        {
        }

        public FechaException(string message) : base(message)
        {
        }

        public FechaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FechaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}