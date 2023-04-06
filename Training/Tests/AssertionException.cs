﻿using System.Runtime.Serialization;

namespace Training.Tests
{
    [Serializable]
    internal class AssertionException : Exception
    {
        public AssertionException()
        {
        }

        public AssertionException(string? message) : base(message)
        {
        }

        public AssertionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AssertionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}