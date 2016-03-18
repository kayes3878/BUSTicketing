using DATA;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
  
    
    public class PreSetupGetWay
    {
        BUSTICKETINGEntities DbContext;

        public List<PreSetup> GetAllBusType()
        {
            DbContext = new BUSTICKETINGEntities();
            List<PreSetup> presetUpList = new List<PreSetup>();
            foreach (var p in (from j in DbContext.PRE_SETUP select j).Distinct())
            {
                PreSetup presetupObj = new PreSetup();
                presetupObj.ID = p.ID;
                presetupObj.BUSType = p.BusType;
                if (presetupObj.BUSType != null && presetupObj.BUSType != "")
                {
                    presetUpList.Add(presetupObj);
                }
            }

            return presetUpList;
        }

        public List<PreSetup> GetAllSift()
        {
            DbContext = new BUSTICKETINGEntities();
            List<PreSetup> presetUpList = new List<PreSetup>();
            foreach (var p in (from j in DbContext.PRE_SETUP select j).Distinct())
            {
                PreSetup presetupObj = new PreSetup();
                presetupObj.ID = p.ID;
                presetupObj.Sift = p.Sift;
                if (presetupObj.Sift != null && presetupObj.Sift != "")
                {
                    presetUpList.Add(presetupObj);
                }
            }

            return presetUpList;
        }

        public List<PreSetup> GetAllCounterName()
        {
            DbContext = new BUSTICKETINGEntities();
            List<PreSetup> presetUpList = new List<PreSetup>();
            foreach (var p in (from j in DbContext.PRE_SETUP select j).Distinct())
            {
                PreSetup presetupObj = new PreSetup();
                presetupObj.ID = p.ID;
                presetupObj.CounterName = p.TicketCounterName;
                if (presetupObj.CounterName != null && presetupObj.CounterName != "")
                {
                    presetUpList.Add(presetupObj);
                }
            }

            return presetUpList;
        }

        public List<PreSetup> GetAllTime()
        {
            DbContext = new BUSTICKETINGEntities();
            List<PreSetup> presetUpList = new List<PreSetup>();
            foreach (var p in (from j in DbContext.PRE_SETUP select j).Distinct())
            {
                PreSetup presetupObj = new PreSetup();
                presetupObj.ID = p.ID;
                presetupObj.TimeOfDiparture = p.Time;
                if (presetupObj.TimeOfDiparture != null && presetupObj.TimeOfDiparture != "")
                {
                    presetUpList.Add(presetupObj);
                }
            }

            return presetUpList;
        }

        public void SaveBusInfoForAssign(Ticketing TicketingObj)
        {
            var newTicketDetails = new BUS_ASSIGN
            {
                BusNumber = TicketingObj.BusNumber,
                DateOfDiparture = TicketingObj.DateOfDiparture,
                Sift = TicketingObj.Sift,
                TicketCounter = TicketingObj.CounterName,
                TicketPrice = TicketingObj.TicketPrice,
                TimeOfDiparture = TicketingObj.TimeOfDiparture,
                Type = TicketingObj.Type,
                UniqueId = TicketingObj.UniqueId,
                LastStop = TicketingObj.LastStop,
                ReportingTime = TicketingObj.ReportingTime,

                
            };
            DbContext.BUS_ASSIGN.Add(newTicketDetails);
            DbContext.SaveChanges();
        }

        public List<PreSetup> SaveBusInfoForAssign()
        {
            DbContext = new BUSTICKETINGEntities();
            List<PreSetup> presetUpList = new List<PreSetup>();
            foreach (var p in (from j in DbContext.PRE_SETUP select j).Distinct())
            {
                PreSetup presetupObj = new PreSetup();
                presetupObj.ID = p.ID;
                presetupObj.BusNumber = p.BusNumber;
                if (presetupObj.BusNumber != null && presetupObj.BusNumber != "")
                {
                    presetUpList.Add(presetupObj);
                }
            }

            return presetUpList;
        }
    }
}
