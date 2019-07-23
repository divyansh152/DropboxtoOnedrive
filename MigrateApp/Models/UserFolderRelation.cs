using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateApp.Models
{

    class UserFolderRelation
    {
        public Name UserName { get; set; }
        public string MemberID { get; set; }
        public string EmailID { get; set; }
        public Entities UFCorrelation { get; set; }
    }
}
