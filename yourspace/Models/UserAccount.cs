using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class UserAccount
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
