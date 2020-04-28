using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class Account
    {
        public Account()
        {
            FriendRequestReceiver = new HashSet<FriendRequest>();
            FriendRequestSender = new HashSet<FriendRequest>();
        }

        public int AccountId { get; set; }
        public string Email { get; set; }
        public string SaltValue { get; set; }
        public string HashedPass { get; set; }

        public virtual AdminAccount AdminAccount { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestReceiver { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestSender { get; set; }
    }
}
