using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class AdminAccount
    {
        public int AccountId { get; set; }
        public int? AccessLevel { get; set; }

        public virtual Account Account { get; set; }
    }
}
