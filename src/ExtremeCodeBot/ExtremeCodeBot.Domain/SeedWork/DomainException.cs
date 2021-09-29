using System;

namespace ExtremeCodeBot.Domain.SeedWork
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}