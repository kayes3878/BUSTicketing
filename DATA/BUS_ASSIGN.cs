//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class BUS_ASSIGN
    {
        public BUS_ASSIGN()
        {
            this.TICKET_DETAILS = new HashSet<TICKET_DETAILS>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> DateOfDiparture { get; set; }
        public string UniqueId { get; set; }
        public string TimeOfDiparture { get; set; }
        public string Sift { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string B1 { get; set; }
        public string B2 { get; set; }
        public string B3 { get; set; }
        public string B4 { get; set; }
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        public string D4 { get; set; }
        public string E1 { get; set; }
        public string E2 { get; set; }
        public string E3 { get; set; }
        public string E4 { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string G1 { get; set; }
        public string G2 { get; set; }
        public string G3 { get; set; }
        public string G4 { get; set; }
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string H3 { get; set; }
        public string H4 { get; set; }
        public string I1 { get; set; }
        public string I2 { get; set; }
        public string I3 { get; set; }
        public string I4 { get; set; }
        public string J1 { get; set; }
        public string J2 { get; set; }
        public string J3 { get; set; }
        public string J4 { get; set; }
        public string BusNumber { get; set; }
        public string Type { get; set; }
        public Nullable<int> TicketPrice { get; set; }
        public string TicketCounter { get; set; }
        public string LastStop { get; set; }
        public string ReportingTime { get; set; }
    
        public virtual ICollection<TICKET_DETAILS> TICKET_DETAILS { get; set; }
    }
}
