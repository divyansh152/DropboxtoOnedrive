using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateApp.Models
{
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
