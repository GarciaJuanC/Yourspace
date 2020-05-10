using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class Posts
    {
        public int AccountId { get; set; }
        public string PhotoPath { get; set; }
        public string TextPost { get; set; }
        public DateTime PostTime { get; set; }
        public string Comments { get; set; }

        public virtual UserAccount Account { get; set; }
    }
}
