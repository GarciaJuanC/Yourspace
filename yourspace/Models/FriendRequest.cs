using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class FriendRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime? DateSent { get; set; }

        public virtual Account Receiver { get; set; }
        public virtual Account Sender { get; set; }
    }
}
