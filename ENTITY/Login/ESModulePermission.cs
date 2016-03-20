using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Login
{
    public class ESModulePermission
    {
        public int Id { get; set; }

        public string ModuleName { get; set; }

        public long UserGroupId { get; set; }

        public string UserGroupName { get; set; }
    }
}
