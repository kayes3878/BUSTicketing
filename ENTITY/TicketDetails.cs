using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TicketDetails
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(System.String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public int Id {get; set;}
        public string Time { get; set; }
        public int BusAssingnPKId {get; set;}	
        public string BusUniqueCode	{get; set;}	
        public int ClintId {get; set;}	
        public string ClintName {get; set;}	
        public string ClintMobile {get; set;}
        public string ClintAddress { get; set; }
        public string Gender { get; set; }

        public string BusNo	{get; set;}	
        public string BusType {get; set;}	
        public string Sift {get; set;}	
        public string Status {get; set;}	
        public string SeatNo {get; set;}	
        public DateTime EntryDate {get; set;}
        public DateTime JournyDate { get; set; }	
        public int TicketPrice {get; set;}
        public int TotalTicketPrice { get; set; }	
        public int TicketPricePaid {get; set;}		
        public int TicketPriceDiscount {get; set;}		
        public int TicketPriceDue {get; set;}		
        public string TicketNo {get; set;}
        public string BookingNo { get; set; }

        public string ToJourny { get; set; }
        public string FromJourny { get; set; }
        public int Age { get; set; }
        public string ReportingTime { get; set; }

       
        public string UserName { get; set; }
        public int UserID { get; set; }	
		        
    }
}
