using System;

namespace Rewards.Exceptions
{
    public class ElementNotFountException : Exception
    {
        public ElementNotFountException(string message) : base(message)
        {
        }
    }
}