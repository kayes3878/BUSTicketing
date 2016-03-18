using DATA;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LoginDAL
{
    public class UserGateway
    {
        private BUSTICKETINGEntities hasanMainDataContectObj;
        public EUser GetAllInfoforSingleUser(EUser anUser)
        {
            hasanMainDataContectObj = new BUSTICKETINGEntities();
            var query = from j in hasanMainDataContectObj.DUSERs
                        where j.USER_NAME == anUser.UserName.ToLower()
                        select j;
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

        public bool DoesExistUserinLoginMode(EUser anUser)
        {
            hasanMainDataContectObj = new BUSTICKETINGEntities();
            return (hasanMainDataContectObj.DUSERs.Any(user => user.USER_NAME.Equals(anUser.UserName) && user.USER_PASSWORD.Equals(anUser.UserPassword)));
        }
    }
}
