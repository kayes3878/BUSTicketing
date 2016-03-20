using DAL.LoginDAL;
using ENTITY.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LoginBLL
{
    public class BUserManager
    {
        UserGateway _userGatewayObj = new UserGateway();
        public bool DoesExistUserinLoginMode(EUser anUser)
        {
            if (_userGatewayObj.DoesExistUserinLoginMode(anUser))
            {
                GetAllInfoforSingleUser(anUser);
                return true;
            }
            else return false;
        }
        public EUser GetAllInfoforSingleUser(EUser anUser)
        {
            return _userGatewayObj.GetAllInfoforSingleUser(anUser);
        }

        
    }
}