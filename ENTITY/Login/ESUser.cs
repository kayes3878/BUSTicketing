using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Login
{
    public class ESUser
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
        public long UserGroupId { get; set; }

        public string UserGroupName { get; set; }
    }
}
