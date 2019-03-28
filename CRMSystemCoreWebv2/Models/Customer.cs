using System;

namespace Yokogawa.Libraries.Models
{
    public class Customer
    {
        private static Random randomObject = new Random();
        private const int MIN_CREDIT = 10000;
        private const int MAX_CREDIT = 50000;
        private const bool DEFAULT_STATUS = false;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int Credit { get; set; } = randomObject.Next(MIN_CREDIT, MAX_CREDIT);
        public bool Status { get; set; } = DEFAULT_STATUS;
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }

        public override string ToString() =>
            $"{CustomerId}, {CustomerName}, {Address}, {Credit}, {Status}, {Email}, {Phone}, {Remarks}";
    }
}
