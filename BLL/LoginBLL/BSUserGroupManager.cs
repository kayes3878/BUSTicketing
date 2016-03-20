using DAL.LoginDAL;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoginBLL
{
    public class BSUserGroupManager
    {
        private SUserGroupGateway _sUserGroupGatewayObj = new SUserGroupGateway();

        public bool SaveUserGroup(ESUserGroup objEuserGroup)
        {
            return _sUserGroupGatewayObj.SaveUserGroup(objEuserGroup);
        }

        public bool DoesExistGroupinSaveMode(string groupName)
        {
            foreach (var anUserGroup in GetAllUserGroup())
            {
                if (anUserGroup.GroupName.ToLower() == groupName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool DoesExistGroupinUpdateMode(string groupName, long userGroupId)
        {
            foreach (var anUserGroup in GetAllUserGroup())
            {
                if (anUserGroup.Id != userGroupId && anUserGroup.GroupName.ToLower() == groupName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserGroup(ESUserGroup anUserGroup)
        {
            return _sUserGroupGatewayObj.UpdateUserGroup(anUserGroup);
        }

        public bool DeleteUserGroup(long userGroupId)
        {
            return _sUserGroupGatewayObj.DeleteUserGroup(userGroupId);
        }

        public List<ESUserGroup> GetAllUserGroup()
        {
            return _sUserGroupGatewayObj.GetAllUserGroup();
        }

        public bool DoesExistAnyUserUnderThisGroup(long groupId)
        {
            return _sUserGroupGatewayObj.DoesExistAnyUserUnderThisGroup(groupId);
        }
    }
}
