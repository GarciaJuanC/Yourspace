using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yourspace.Models
{
    [Serializable]
    public class FriendList
    {
        readonly List<UserAccount> friends = new List<UserAccount>();

        public FriendList()
        {

        }

        public FriendList(UserAccount acct)
        {
            friends.Add(acct);
        }

        public void AddFriend(UserAccount acct)
        {
            friends.Add(acct);
        }
    }
}