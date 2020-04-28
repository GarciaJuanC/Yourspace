using System;
using System.Collections.Generic;
using Newtonsoft.Json;


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

        // each comment on a post is itself a post
        public virtual ICollection<Posts> PostReactions { get; set; }
        // store this json string in comments column of posts table
        private string jsonString;

        public void SerializeObject()
        {
            jsonString = JsonConvert.SerializeObject(PostReactions);
        }

        public void DeserializeObject()
        {
            PostReactions = JsonConvert.DeserializeObject<ICollection<Posts>>(jsonString);
        }
    }
}
