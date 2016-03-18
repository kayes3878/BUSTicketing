using DATA;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LoginDAL
{
    public class SUserGateway
    {
        private BUSTICKETINGEntities _hasanSecurityDataContextObj;
        public bool SaveUserInfo(ESUser anUser)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            var newUser = new DUSER
            {
                USER_NAME = anUser.UserName,
                USER_PASSWORD = anUser.UserPassword,
                USER_GROUP_ID = anUser.UserGroupId
            };
            _hasanSecurityDataContextObj.DUSERs.Add(newUser);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }
        public bool DoesExistUserinSaveMode(string userName)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            return (_hasanSecurityDataContextObj.DUSERs.Any(user => user.USER_NAME.Equals(userName)));
        }
        public bool UpdateUserInfo(ESUser anUser)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            var user = _hasanSecurityDataContextObj.DUSERs.FirstOrDefault(u => u.USER_ID == anUser.UserId);
            user.USER_NAME = anUser.UserName;
            user.USER_PASSWORD = anUser.UserPassword;
            user.USER_GROUP_ID = anUser.UserGroupId;
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }
        public bool DeleteUser(long userId)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            DUSER userObj = _hasanSecurityDataContextObj.DUSERs.First(u => u.USER_ID == userId);
            _hasanSecurityDataContextObj.DUSERs.Remove(userObj);
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }
        public List<ESUser> GetAllUser()
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            List<ESUser> listUser = new List<ESUser>();
            foreach (var user in _hasanSecurityDataContextObj.DUSERs)
            {
                ESUser anUser = new ESUser();
                anUser.UserId = user.USER_ID;
                anUser.UserName = user.USER_NAME;
                anUser.UserPassword = user.USER_PASSWORD;
                anUser.UserGroupId = user.USER_GROUP_ID;
                anUser.UserGroupName = user.USER_GROUP.GROUP_NAME;
                listUser.Add(anUser);
            }
            return listUser;
        }
        public ESUser GetAllInfoforSingleUser(ESUser anUser)
        {

            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            var query = from j in _hasanSecurityDataContextObj.DUSERs where j.USER_NAME == anUser.UserName.ToLower() select j;
            foreach (var user in query)
            {
                anUser.UserId = user.USER_ID;
                anUser.UserName = user.USER_NAME;
                anUser.UserPassword = user.USER_PASSWORD;
                anUser.UserGroupId = user.USER_GROUP_ID;
                anUser.UserGroupName = user.USER_GROUP.GROUP_NAME;
            }
            return anUser;
        }
        public bool UpdateUserPassword(ESUser anUser)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();

            var user = _hasanSecurityDataContextObj.DUSERs.FirstOrDefault(u => u.USER_ID == anUser.UserId);
            user.USER_PASSWORD = anUser.UserPassword;
            _hasanSecurityDataContextObj.SaveChanges();
            return true;
        }
        /******************Login Purpose*****************/
        public bool DoesExistUserinLoginMode(ESUser anUser)
        {
            _hasanSecurityDataContextObj = new BUSTICKETINGEntities();
            return (_hasanSecurityDataContextObj.DUSERs.Any(user => user.USER_NAME.Equals(anUser.UserName) && user.USER_PASSWORD.Equals(anUser.UserPassword)));
        }
    }
}
