using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string SaltValue { get; set; }
        public string HashedPass { get; set; }

        public virtual AdminAccount AdminAccount { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
