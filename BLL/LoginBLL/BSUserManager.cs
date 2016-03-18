using DAL.LoginDAL;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoginBLL
{
    public class BSUserManager
    {
        SUserGateway anUserDAL = new SUserGateway();
        public bool SaveUserInfo(ESUser anUser)
        {
            return anUserDAL.SaveUserInfo(anUser);
        }
        public List<ESUser> GetAllUser()
        {
            return anUserDAL.GetAllUser();
        }
        public bool DeleteUser(long userId)
        {
            return anUserDAL.DeleteUser(userId);
        }
        public bool DoesExistUserinSaveMode(string userName)
        {
            return anUserDAL.DoesExistUserinSaveMode(userName);
        }
        public bool DoesExistUserinLoginMode(ESUser anUser)
        {
            if (anUserDAL.DoesExistUserinLoginMode(anUser))
            {
                GetAllInfoforSingleUser(anUser);
                return true;
            }
            else return false;
        }
        public ESUser GetAllInfoforSingleUser(ESUser anUser)
        {
            return anUserDAL.GetAllInfoforSingleUser(anUser);
        }
        public bool UpdateUserPassword(ESUser anUser)
        {
            return anUserDAL.UpdateUserPassword(anUser);
        }
        public bool UpdateUserInfo(ESUser anUser)
        {
            return anUserDAL.UpdateUserInfo(anUser);
        }
        public bool DoesExistUserinUpdateMode(string userName, long userId)
        {
            foreach (var anUser in anUserDAL.GetAllUser())
            {
                if (anUser.UserId != userId && anUser.UserName.ToLower() == userName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
