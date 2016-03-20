using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketStatusManager
    {
        TicketingGetWay ticketingGetWayObj = new TicketingGetWay();
      

        public List<Ticketing> GetTicketStatus(DateTime dateOfDeparture)
        {
            return ticketingGetWayObj.GetTicketStatus(dateOfDeparture);
        }

        public List<Ticketing> GetTicketStatusID(int PkID)
        {
            return ticketingGetWayObj.GetTicketStatusID(PkID);

        }

        public void SaveTicketDetails(List<TicketDetails> ticketDetailsList)
        {
            ticketingGetWayObj.SaveTicketDetails(ticketDetailsList);
        }

        //public void UpdateTicketStatus(List<TicketDetails> ticketDetailsList)
        //{
        //    throw new NotImplementedException();
        //}

        public List<TicketDetails> GetTicketStatusIDAndSeatNo(int PkID, string seatNo)
        {
            return ticketingGetWayObj.GetTicketStatusIDAndSeatNo(PkID, seatNo);
        }

        public List<Ticketing> GetAllAssignedBus()
        {
            return ticketingGetWayObj.GetAllAssignedBus();

        }
        public List<TicketDetails> TicketListByTicketNo(string TicketNo)
        {
            return ticketingGetWayObj.TicketListByTicketNo(TicketNo);

        }

        public string GetTicketStatusIDAndSeatNoAllseat(string allseat)
        {
            return ticketingGetWayObj.GetTicketStatusIDAndSeatNoAllseat(allseat);
        }

        public List<TicketDetails> GetTicketAllTicket(int PkID)
        {
            return ticketingGetWayObj.GetTicketAllTicket(PkID);
            
        }
    }
}
