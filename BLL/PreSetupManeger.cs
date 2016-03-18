using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PreSetupManeger
    {
        PreSetupGetWay preSetupGetWayObj = new PreSetupGetWay();
        public List<PreSetup> GetAllBusType()
        {
            return preSetupGetWayObj.GetAllBusType();
        }

        public List<PreSetup> GetAllSift()
        {
            return preSetupGetWayObj.GetAllSift();
        }

        public List<PreSetup> GetAllCounterName()
        {
            return preSetupGetWayObj.GetAllCounterName();
        }

        public List<PreSetup> GetAllTime()
        {
            return preSetupGetWayObj.GetAllTime();
        }

        public void SaveBusInfoForAssign(Ticketing TicketingObj)
        {
            preSetupGetWayObj.SaveBusInfoForAssign(TicketingObj);
        }

        public List<PreSetup> GetAllbusNumber()
        {
            return preSetupGetWayObj.SaveBusInfoForAssign();
        }
    }
}
