using DATA;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LoginDAL
{
    public class MenuPermissionGateway
    {
        private BUSTICKETINGEntities _hasanSecurityDataContextObj;
        public bool SaveMenuUserGroupWise(EMenuPermission objMenu)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            var newMenu = new ROLEWISE_MENU
            {
                MODULE_ID = objMenu.ModuleId,
                USER_GROUP_ID = objMenu.UserGroupId,
                PARENT_MENU_NAME = objMenu.ParentMenuName,
                PARENT_MENU_CONTENT = objMenu.ParentMenuContent,
                CHILD_MENU_NAME = objMenu.ChildMenuName,
                CHILD_MENU_CONTENT = objMenu.ChildMenuContent
            };
            _hasanSecurityDataContextObj.ROLEWISE_MENU.Add(newMenu);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;

        }

        public List<EMenuPermission> GetAccParentMenuGroupWise(EMenuPermission objEMenu)
        {
            List<EMenuPermission> listAccParentMenu = new List<EMenuPermission>();

            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            var query = (from j in _hasanSecurityDataContextObj.ROLEWISE_MENU where j.USER_GROUP_ID == objEMenu.UserGroupId && j.MODULE_ID == objEMenu.ModuleId select new { j.PARENT_MENU_NAME, j.PARENT_MENU_CONTENT }).Distinct();
            foreach (var c in query)
            {
                EMenuPermission objAccMenu = new EMenuPermission();
                objAccMenu.ParentMenuName = c.PARENT_MENU_NAME;
                objAccMenu.ParentMenuContent = c.PARENT_MENU_CONTENT;
                listAccParentMenu.Add(objAccMenu);
            }

            return listAccParentMenu;
        }

        public List<EMenuPermission> GetAccChildMenuGroupWise(EMenuPermission objEMenu)
        {
            List<EMenuPermission> listAccChildMenu = new List<EMenuPermission>();

            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            var query = from j in _hasanSecurityDataContextObj.ROLEWISE_MENU where (j.PARENT_MENU_NAME == objEMenu.ParentMenuName && j.USER_GROUP_ID == objEMenu.UserGroupId && j.MODULE_ID == objEMenu.ModuleId) select j;
            foreach (var c in query)
            {
                EMenuPermission objAccMenu = new EMenuPermission();
                objAccMenu.Id = Convert.ToInt64(c.ID);
                objAccMenu.ChildMenuName = c.CHILD_MENU_NAME;
                objAccMenu.ChildMenuContent = c.CHILD_MENU_CONTENT;
                listAccChildMenu.Add(objAccMenu);
            }
            return listAccChildMenu;
        }

        public bool DeleteUserRole(long groupId, long moduleId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            ROLEWISE_MENU query = (ROLEWISE_MENU)from r in _hasanSecurityDataContextObj.ROLEWISE_MENU where r.USER_GROUP_ID == groupId && r.MODULE_ID == moduleId select r;
            _hasanSecurityDataContextObj.ROLEWISE_MENU.Remove(query);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }
        public bool IsExistParentMenu(string menuName, long UserGroupId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            return _hasanSecurityDataContextObj.ROLEWISE_MENU.Any(RM => RM.PARENT_MENU_NAME == menuName && RM.USER_GROUP_ID == UserGroupId);
        }
        public bool IsExistChildMenu(string menuName, long UserGroupId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            return _hasanSecurityDataContextObj.ROLEWISE_MENU.Any(RM => RM.CHILD_MENU_NAME == menuName && RM.USER_GROUP_ID == UserGroupId);
        }
    }
}
