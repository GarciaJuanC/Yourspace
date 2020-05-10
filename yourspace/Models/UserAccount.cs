using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

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

        public HttpPostedFile ImageFile { get; set; }
        public string Biography { get; set; }
        public string ULocation { get; set; }
        public string Occupation { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }

        public FriendList friendList = new FriendList();
        private string jsonString;

        public void SerializeObject()
        {
            jsonString = JsonConvert.SerializeObject(friendList);
        }

        public void DeserializeObject()
        {
            friendList = JsonConvert.DeserializeObject<FriendList>(jsonString);
        }
    }
}
