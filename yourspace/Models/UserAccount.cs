using System;
using System.Collections.Generic;

namespace yourspace.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Posts = new HashSet<Posts>();
        }

        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }
        public string Biography { get; set; }
        public string ULocation { get; set; }
        public string Occupation { get; set; }
        public string FriendsList { get; set; }
        public string RelationStatus { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }


        public List<int> friendsList = new List<int>(); // For storing serialized objects
    }
}
