using DAL.LoginDAL;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoginBLL
{
    public class BMenuPermissionManager
    {
        MenuPermissionGateway _objMenuGateway = new MenuPermissionGateway();

        public bool SaveMenuUserGroupWise(EMenuPermission objMenu)
        {
            return _objMenuGateway.SaveMenuUserGroupWise(objMenu);
        }
        public bool DeleteUserRole(long groupId, long moduleId)
        {
            return _objMenuGateway.DeleteUserRole(groupId, moduleId);
        }

        public List<EMenuPermission> GetAccParentMenuGroupWise(EMenuPermission objEMP)
        {
            return _objMenuGateway.GetAccParentMenuGroupWise(objEMP);
        }

        public List<EMenuPermission> GetAccChildMenuGroupWise(EMenuPermission objEMP)
        {
            return _objMenuGateway.GetAccChildMenuGroupWise(objEMP);
        }
        public bool IsExistParentMenu(string menuName, long UserGroupId)
        {
            return _objMenuGateway.IsExistParentMenu(menuName, UserGroupId);
        }
        public bool IsExistChildMenu(string menuName, long UserGroupId)
        {
            return _objMenuGateway.IsExistChildMenu(menuName, UserGroupId);
        }
    }
}
