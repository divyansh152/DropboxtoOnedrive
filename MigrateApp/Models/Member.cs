using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateApp.Models
{

    public class MembersCollection
    {
        public Member[] members { get; set; }
        public Entities[] Entity { get; set; }
        public string cursor { get; set; }
        public bool has_more { get; set; }
    }

    public class Member
    {
        public Profile profile { get; set; }
        public Role role { get; set; }
    }

    public class Profile
    {
        public string team_member_id { get; set; }
        public string account_id { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public object[] secondary_emails { get; set; }
        public Status status { get; set; }
        public Name name { get; set; }
        public Membership_Type membership_type { get; set; }
        public DateTime joined_on { get; set; }
        public string[] groups { get; set; }
        public string member_folder_id { get; set; }
        public string profile_photo_url { get; set; }
        public DateTime suspended_on { get; set; }
        public DateTime invited_on { get; set; }
    }

    public class Status
    {
        public string tag { get; set; }
    }

    public class Name
    {
        public string given_name { get; set; }
        public string surname { get; set; }
        public string familiar_name { get; set; }
        public string display_name { get; set; }
        public string abbreviated_name { get; set; }
    }

    public class Membership_Type
    {
        public string tag { get; set; }
    }

    public class Role
    {
        public string tag { get; set; }
    }
    //public class Entities
    //{
    //    public string tag { get; set; }
    //    public string name { get; set; }
    //    public string path_lower { get; set; }
    //    public string path_display { get; set; }
    //    public string id { get; set; }

    //}

    public class Entities
    {
        public Entry[] entries { get; set; }
        public string cursor { get; set; }
        public bool has_more { get; set; }
    }

    public class Entry
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string path_lower { get; set; }
        public string path_display { get; set; }
        public string id { get; set; }
        public string shared_folder_id { get; set; }
        public Sharing_Info sharing_info { get; set; }
        public DateTime client_modified { get; set; }
        public DateTime server_modified { get; set; }
        public string rev { get; set; }
        public int size { get; set; }
        public bool is_downloadable { get; set; }
        public string content_hash { get; set; }
    }

    public class Sharing_Info
    {
        public bool read_only { get; set; }
        public string shared_folder_id { get; set; }
        public bool traverse_only { get; set; }
        public bool no_access { get; set; }
    }

}
