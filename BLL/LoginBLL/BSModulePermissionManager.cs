using DAL.LoginDAL;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoginBLL
{
    public class BSModulePermissionManager
    {
        private SModulePermissionGateway _objMpGateway = new SModulePermissionGateway();

        public bool SaveModulePermission(ESModulePermission objEsModPer)
        {
            return _objMpGateway.SaveModulePermission(objEsModPer);
        }

        public bool DeleteModulePermission(long userGroupId)
        {
            return _objMpGateway.DeleteModulePermission(userGroupId);
        }

        public List<ESModulePermission> GetPermittedModule(long groupId)
        {
            return _objMpGateway.GetPermittedModule(groupId);
        }

        public List<string> GetNOTPermittedModule(List<string> listAvailablemodule, List<string> listPermitted)
        {
            return _objMpGateway.GetNOTPermittedModule(listAvailablemodule, listPermitted);
        }

        public bool DeleteSingleModulePermission(ESModulePermission objEmodule)
        {
            return _objMpGateway.DeleteSingleModulePermission(objEmodule);
        }
    }
}
