using DATA;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LoginDAL
{
    public class SUserGroupGateway
    {
        private BUSTICKETINGEntities _hasanSecurityDataContextObj;
        public bool SaveUserGroup(ESUserGroup anEuserGroup)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            var newUserGroup = new USER_GROUP
            {
                GROUP_NAME = anEuserGroup.GroupName
            };
            _hasanSecurityDataContextObj.USER_GROUP.Add(newUserGroup);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }

        public bool UpdateUserGroup(ESUserGroup anUserGroup)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            var group = _hasanSecurityDataContextObj.USER_GROUP.FirstOrDefault(u => u.GROUP_ID == anUserGroup.Id);
            group.GROUP_NAME = anUserGroup.GroupName;
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }

        public bool DeleteUserGroup(long userGroupId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            USER_GROUP userGroupObj = _hasanSecurityDataContextObj.USER_GROUP.First(u => u.GROUP_ID == userGroupId);
            _hasanSecurityDataContextObj.USER_GROUP.Remove(userGroupObj);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }

        public List<ESUserGroup> GetAllUserGroup()
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            List<ESUserGroup> listUserGroup = new List<ESUserGroup>();
            var query = from j in _hasanSecurityDataContextObj.USER_GROUP select j;
            foreach (var userGroup in query)
            {
                ESUserGroup anUserGroup = new ESUserGroup();
                anUserGroup.Id = userGroup.GROUP_ID;
                anUserGroup.GroupName = userGroup.GROUP_NAME;
                listUserGroup.Add(anUserGroup);
            }
            return listUserGroup;
        }

        public bool DoesExistAnyUserUnderThisGroup(long groupId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            return (_hasanSecurityDataContextObj.DUSERs.Any(u => u.USER_GROUP_ID == groupId));
        }
    }
}
