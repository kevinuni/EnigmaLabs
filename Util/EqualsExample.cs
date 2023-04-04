using System;

namespace Util.Patterns
{
    /// <summary>
    /// Good implementation of Equals() GetHashCode() and == and != operators
    /// details can be read at http://www.loganfranken.com/blog/687/overriding-equals-in-c-part-1/
    /// </summary>
    public class EqualsExample
    {
        public override bool Equals(object value)
        {
            // Is null?
            if (Object.ReferenceEquals(null, value))
            {
                return false;
            }

            // Is the same object?
            if (Object.ReferenceEquals(this, value))
            {
                return true;
            }

            // Is the same type?
            if (value.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((EqualsExample)value);
        }

        public bool Equals(EqualsExample number)
        {
            // Is null?
            if (Object.ReferenceEquals(null, number))
            {
                return false;
            }

            // Is the same object?
            if (Object.ReferenceEquals(this, number))
            {
                return true;
            }

            return IsEqual(number);
        }

        private bool IsEqual(EqualsExample number)
        {
            // A pure implementation of value equality that avoids the routine checks above
            // We use String.Equals to really drive home our fear of an improperly overridden "=="
            return String.Equals(AreaCode, number.AreaCode)
                && String.Equals(Exchange, number.Exchange)
                && String.Equals(SubscriberNumber, number.SubscriberNumber);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, SubscriberNumber) ? SubscriberNumber.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(EqualsExample numberA, EqualsExample numberB)
        {
            if (Object.ReferenceEquals(numberA, numberB))
            {
                return true;
            }

            // Ensure that "numberA" isn't null
            if (Object.ReferenceEquals(null, numberA))
            {
                return false;
            }

            return (numberA.Equals(numberB));
        }

        public static bool operator !=(EqualsExample numberA, EqualsExample numberB)
        {
            return !(numberA == numberB);
        }

        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }

        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }

        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }
    }
}