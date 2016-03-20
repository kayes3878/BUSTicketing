using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;

namespace DAL
{
    public class TicketingGetWay
    {
        BUSTICKETINGEntities DbContext = new BUSTICKETINGEntities();
        //public List<Ticketing> GetTicketStatus()
        //{
        //    List<Ticketing> busTicketingList = new List<Ticketing>();
        //    foreach (var p in (from j in DbContext.BUS_ASSIGN select j).Distinct())
        //    {
        //        Ticketing ticketInfoObj = new Ticketing();
        //        ticketInfoObj.ID = p.ID;
        //        ticketInfoObj.TimeOfDiparture = p.TimeOfDiparture;
        //        ticketInfoObj.Sift = p.Sift;
        //        ticketInfoObj.DateOfDiparture = (DateTime)p.DateOfDiparture;

        //        ticketInfoObj.A1 = p.A1;
        //        ticketInfoObj.A2 = p.A2;
        //        ticketInfoObj.A3 = p.A3;
        //        ticketInfoObj.A4 = p.A4;

        //        ticketInfoObj.B1 = p.B1;
        //        ticketInfoObj.B2 = p.B2;
        //        ticketInfoObj.B3 = p.B3;
        //        ticketInfoObj.B4 = p.B4;

        //        ticketInfoObj.C1 = p.C1;
        //        ticketInfoObj.C2 = p.C2;
        //        ticketInfoObj.C3 = p.C3;
        //        ticketInfoObj.C4 = p.C4;

        //        ticketInfoObj.D1 = p.D1;
        //        ticketInfoObj.D2 = p.D2;
        //        ticketInfoObj.D3 = p.D3;
        //        ticketInfoObj.D4 = p.D4;

        //        ticketInfoObj.E1 = p.E1;
        //        ticketInfoObj.E2 = p.E2;
        //        ticketInfoObj.E3 = p.E3;
        //        ticketInfoObj.E4 = p.E4;

        //        ticketInfoObj.F1 = p.F1;
        //        ticketInfoObj.F2 = p.F2;
        //        ticketInfoObj.F3 = p.F3;
        //        ticketInfoObj.F4 = p.F4;

        //        ticketInfoObj.G1 = p.G1;
        //        ticketInfoObj.G2 = p.G2;
        //        ticketInfoObj.G3 = p.G3;
        //        ticketInfoObj.G4 = p.G4;

        //        ticketInfoObj.H1 = p.H1;
        //        ticketInfoObj.H2 = p.H2;
        //        ticketInfoObj.H3 = p.H3;
        //        ticketInfoObj.H4 = p.H4;

        //        ticketInfoObj.I1 = p.I1;
        //        ticketInfoObj.I2 = p.I2;
        //        ticketInfoObj.I3 = p.I3;
        //        ticketInfoObj.I4 = p.I4;

        //        ticketInfoObj.J1 = p.J1;
        //        ticketInfoObj.J2 = p.J2;
        //        ticketInfoObj.J3 = p.J3;
        //        ticketInfoObj.J4 = p.J4;


        //    }
        //    return busTicketingList;
        //}


        public List<Ticketing> GetTicketStatus(DateTime dateOfDeparture)
        {
            List<Ticketing> busTicketingList = new List<Ticketing>();
            foreach (var p in (from j in DbContext.BUS_ASSIGN 
                               where j.DateOfDiparture ==(DateTime) dateOfDeparture
                               select j).Distinct())
            {
                Ticketing ticketInfoObj = new Ticketing();
                ticketInfoObj.ID = p.ID;
                ticketInfoObj.TimeOfDiparture = p.TimeOfDiparture;
                ticketInfoObj.Sift = p.Sift;
                ticketInfoObj.DateOfDiparture = (DateTime)p.DateOfDiparture;
                ticketInfoObj.UniqueId =p.UniqueId;
                ticketInfoObj.Type = p.Type;
                ticketInfoObj.BusNumber = p.BusNumber;
                ticketInfoObj.TicketPrice = p.TicketPrice;
                ticketInfoObj.CounterName = p.TicketCounter;


                ticketInfoObj.A1 = p.A1;
                ticketInfoObj.A2 = p.A2;
                ticketInfoObj.A3 = p.A3;
                ticketInfoObj.A4 = p.A4;

                ticketInfoObj.B1 = p.B1;
                ticketInfoObj.B2 = p.B2;
                ticketInfoObj.B3 = p.B3;
                ticketInfoObj.B4 = p.B4;

                ticketInfoObj.C1 = p.C1;
                ticketInfoObj.C2 = p.C2;
                ticketInfoObj.C3 = p.C3;
                ticketInfoObj.C4 = p.C4;

                ticketInfoObj.D1 = p.D1;
                ticketInfoObj.D2 = p.D2;
                ticketInfoObj.D3 = p.D3;
                ticketInfoObj.D4 = p.D4;

                ticketInfoObj.E1 = p.E1;
                ticketInfoObj.E2 = p.E2;
                ticketInfoObj.E3 = p.E3;
                ticketInfoObj.E4 = p.E4;

                ticketInfoObj.F1 = p.F1;
                ticketInfoObj.F2 = p.F2;
                ticketInfoObj.F3 = p.F3;
                ticketInfoObj.F4 = p.F4;

                ticketInfoObj.G1 = p.G1;
                ticketInfoObj.G2 = p.G2;
                ticketInfoObj.G3 = p.G3;
                ticketInfoObj.G4 = p.G4;

                ticketInfoObj.H1 = p.H1;
                ticketInfoObj.H2 = p.H2;
                ticketInfoObj.H3 = p.H3;
                ticketInfoObj.H4 = p.H4;

                ticketInfoObj.I1 = p.I1;
                ticketInfoObj.I2 = p.I2;
                ticketInfoObj.I3 = p.I3;
                ticketInfoObj.I4 = p.I4;

                ticketInfoObj.J1 = p.J1;
                ticketInfoObj.J2 = p.J2;
                ticketInfoObj.J3 = p.J3;
                ticketInfoObj.J4 = p.J4;

                busTicketingList.Add(ticketInfoObj);
            }
            return busTicketingList;
        }

        public List<Ticketing> GetTicketStatusID(int PkID)
        {
            List<Ticketing> busTicketingList = new List<Ticketing>();
            foreach (var p in (from j in DbContext.BUS_ASSIGN
                               where j.ID == PkID
                               select j).Distinct())
            {
                Ticketing ticketInfoObj = new Ticketing();
                ticketInfoObj.ID = p.ID;
                ticketInfoObj.TimeOfDiparture = p.TimeOfDiparture;
                ticketInfoObj.Sift = p.Sift;
                ticketInfoObj.DateOfDiparture = (DateTime)p.DateOfDiparture;
                ticketInfoObj.UniqueId = p.UniqueId;
                ticketInfoObj.Type = p.Type;
                ticketInfoObj.BusNumber = p.BusNumber;
                ticketInfoObj.CounterName = p.TicketCounter;
                ticketInfoObj.TicketPrice = p.TicketPrice;



                ticketInfoObj.A1 = p.A1;
                ticketInfoObj.A2 = p.A2;
                ticketInfoObj.A3 = p.A3;
                ticketInfoObj.A4 = p.A4;

                ticketInfoObj.B1 = p.B1;
                ticketInfoObj.B2 = p.B2;
                ticketInfoObj.B3 = p.B3;
                ticketInfoObj.B4 = p.B4;

                ticketInfoObj.C1 = p.C1;
                ticketInfoObj.C2 = p.C2;
                ticketInfoObj.C3 = p.C3;
                ticketInfoObj.C4 = p.C4;

                ticketInfoObj.D1 = p.D1;
                ticketInfoObj.D2 = p.D2;
                ticketInfoObj.D3 = p.D3;
                ticketInfoObj.D4 = p.D4;

                ticketInfoObj.E1 = p.E1;
                ticketInfoObj.E2 = p.E2;
                ticketInfoObj.E3 = p.E3;
                ticketInfoObj.E4 = p.E4;

                ticketInfoObj.F1 = p.F1;
                ticketInfoObj.F2 = p.F2;
                ticketInfoObj.F3 = p.F3;
                ticketInfoObj.F4 = p.F4;

                ticketInfoObj.G1 = p.G1;
                ticketInfoObj.G2 = p.G2;
                ticketInfoObj.G3 = p.G3;
                ticketInfoObj.G4 = p.G4;

                ticketInfoObj.H1 = p.H1;
                ticketInfoObj.H2 = p.H2;
                ticketInfoObj.H3 = p.H3;
                ticketInfoObj.H4 = p.H4;

                ticketInfoObj.I1 = p.I1;
                ticketInfoObj.I2 = p.I2;
                ticketInfoObj.I3 = p.I3;
                ticketInfoObj.I4 = p.I4;

                ticketInfoObj.J1 = p.J1;
                ticketInfoObj.J2 = p.J2;
                ticketInfoObj.J3 = p.J3;
                ticketInfoObj.J4 = p.J4;

                busTicketingList.Add(ticketInfoObj);
            }
            return busTicketingList;
        }

        public void SaveTicketDetails(List<TicketDetails> ticketDetailsList)
        {
            foreach (TicketDetails item in ticketDetailsList)
            {
                var newTicketDetails = new TICKET_DETAILS
                {
                    BusAssingnPKId = item.BusAssingnPKId,
                    BusNo = item.BusNo,
                    BusType = item.BusType,
                    BusUniqueCode = item.BusUniqueCode,
                    ClintMobile = item.ClintMobile,
                    ClintName = item.ClintName,
                    ClintAddress = item.ClintAddress,
                    EntryDate = item.EntryDate,
                    SeatNo = item.SeatNo,
                    Sift = item.Sift,
                    Status = item.Status,
                    TicketPrice = item.TicketPrice,
                    TicketPriceDiscount = item.TicketPriceDiscount,

                    TicketPriceDue = item.TicketPriceDue,
                    TicketPricePaid = item.TicketPricePaid,
                    BookingNo = item.BookingNo,
                    Gender = item.Gender,
                    JournyDate = item.JournyDate,
                    JournyFrom = item.FromJourny,

                    JournyTo = item.ToJourny,
                    TicketNo = item.TicketNo,
                    Time = item.Time,
                    UserID = item.UserID,
                    UserName = item.UserName,
                    Age = item.Age,


                 };
                DbContext.TICKET_DETAILS.Add(newTicketDetails);
                DbContext.SaveChanges();
            }
            foreach (TicketDetails item in ticketDetailsList)
            {
                var SeatStatusUpdate = DbContext.BUS_ASSIGN.First(c => c.ID == item.BusAssingnPKId);
                if (item.Status == "Sold")
                {
                    if (item.SeatNo == "A1")
                    {
                        SeatStatusUpdate.A1 = "Sold";
                    }
                    if (item.SeatNo == "A2")
                    {
                        SeatStatusUpdate.A2 = "Sold";
                    }
                    if (item.SeatNo == "A3")
                    {
                        SeatStatusUpdate.A3 = "Sold";
                    }
                    if (item.SeatNo == "A4")
                    {
                        SeatStatusUpdate.A4 = "Sold";
                    }
                    if (item.SeatNo == "B1")
                    {
                        SeatStatusUpdate.B1 = "Sold";
                    }
                    if (item.SeatNo == "B2")
                    {
                        SeatStatusUpdate.B2 = "Sold";
                    }
                    if (item.SeatNo == "B3")
                    {
                        SeatStatusUpdate.B3 = "Sold";
                    }
                    if (item.SeatNo == "B4")
                    {
                        SeatStatusUpdate.B4 = "Sold";
                    }
                    if (item.SeatNo == "C1")
                    {
                        SeatStatusUpdate.C1 = "Sold";
                    }
                    if (item.SeatNo == "C2")
                    {
                        SeatStatusUpdate.C2 = "Sold";
                    }
                    if (item.SeatNo == "C3")
                    {
                        SeatStatusUpdate.C3 = "Sold";
                    }
                    if (item.SeatNo == "C4")
                    {
                        SeatStatusUpdate.C4 = "Sold";
                    }
                    if (item.SeatNo == "D1")
                    {
                        SeatStatusUpdate.D1 = "Sold";
                    }
                    if (item.SeatNo == "D2")
                    {
                        SeatStatusUpdate.D2 = "Sold";
                    }
                    if (item.SeatNo == "D3")
                    {
                        SeatStatusUpdate.D3 = "Sold";
                    }
                    if (item.SeatNo == "D4")
                    {
                        SeatStatusUpdate.D4 = "Sold";
                    }
                    if (item.SeatNo == "E1")
                    {
                        SeatStatusUpdate.E1 = "Sold";
                    }
                    if (item.SeatNo == "E2")
                    {
                        SeatStatusUpdate.E2 = "Sold";
                    }
                    if (item.SeatNo == "E3")
                    {
                        SeatStatusUpdate.E3 = "Sold";
                    }
                    if (item.SeatNo == "E4")
                    {
                        SeatStatusUpdate.E4 = "Sold";
                    }

                    if (item.SeatNo == "F1")
                    {
                        SeatStatusUpdate.F1 = "Sold";
                    }
                    if (item.SeatNo == "F2")
                    {
                        SeatStatusUpdate.F2 = "Sold";
                    }
                    if (item.SeatNo == "F3")
                    {
                        SeatStatusUpdate.F3 = "Sold";
                    }
                    if (item.SeatNo == "F4")
                    {
                        SeatStatusUpdate.F4 = "Sold";
                    }

                    if (item.SeatNo == "G1")
                    {
                        SeatStatusUpdate.G1 = "Sold";
                    }
                    if (item.SeatNo == "G2")
                    {
                        SeatStatusUpdate.G2 = "Sold";
                    }
                    if (item.SeatNo == "G3")
                    {
                        SeatStatusUpdate.G3 = "Sold";
                    }
                    if (item.SeatNo == "G4")
                    {
                        SeatStatusUpdate.G4 = "Sold";
                    }
                    if (item.SeatNo == "H1")
                    {
                        SeatStatusUpdate.H1 = "Sold";
                    }
                    if (item.SeatNo == "H2")
                    {
                        SeatStatusUpdate.H2 = "Sold";
                    }
                    if (item.SeatNo == "H3")
                    {
                        SeatStatusUpdate.H3 = "Sold";
                    }
                    if (item.SeatNo == "H4")
                    {
                        SeatStatusUpdate.H4 = "Sold";
                    }
                    if (item.SeatNo == "I1")
                    {
                        SeatStatusUpdate.I1 = "Sold";
                    }
                    if (item.SeatNo == "I2")
                    {
                        SeatStatusUpdate.I2 = "Sold";
                    }
                    if (item.SeatNo == "I3")
                    {
                        SeatStatusUpdate.I3 = "Sold";
                    }
                    if (item.SeatNo == "I4")
                    {
                        SeatStatusUpdate.I4 = "Sold";
                    }
                    if (item.SeatNo == "J1")
                    {
                        SeatStatusUpdate.J1 = "Sold";
                    }
                    if (item.SeatNo == "J2")
                    {
                        SeatStatusUpdate.J2 = "Sold";
                    }
                    if (item.SeatNo == "J3")
                    {
                        SeatStatusUpdate.J3 = "Sold";
                    }
                    if (item.SeatNo == "J4")
                    {
                        SeatStatusUpdate.J4 = "Sold";
                    }
                    DbContext.SaveChanges();
                }
                if (item.Status == "Booked")
                {
                    if (item.SeatNo == "A1")
                    {
                        SeatStatusUpdate.A1 = "Booked";
                    }
                    if (item.SeatNo == "A2")
                    {
                        SeatStatusUpdate.A2 = "Booked";
                    }
                    if (item.SeatNo == "A3")
                    {
                        SeatStatusUpdate.A3 = "Booked";
                    }
                    if (item.SeatNo == "A4")
                    {
                        SeatStatusUpdate.A4 = "Booked";
                    }
                    if (item.SeatNo == "B1")
                    {
                        SeatStatusUpdate.B1 = "Booked";
                    }
                    if (item.SeatNo == "B2")
                    {
                        SeatStatusUpdate.B2 = "Booked";
                    }
                    if (item.SeatNo == "B3")
                    {
                        SeatStatusUpdate.B3 = "Booked";
                    }
                    if (item.SeatNo == "B4")
                    {
                        SeatStatusUpdate.B4 = "Booked";
                    }
                    if (item.SeatNo == "C1")
                    {
                        SeatStatusUpdate.C1 = "Booked";
                    }
                    if (item.SeatNo == "C2")
                    {
                        SeatStatusUpdate.C2 = "Booked";
                    }
                    if (item.SeatNo == "C3")
                    {
                        SeatStatusUpdate.C3 = "Booked";
                    }
                    if (item.SeatNo == "C4")
                    {
                        SeatStatusUpdate.C4 = "Booked";
                    }
                    if (item.SeatNo == "D1")
                    {
                        SeatStatusUpdate.D1 = "Booked";
                    }
                    if (item.SeatNo == "D2")
                    {
                        SeatStatusUpdate.D2 = "Booked";
                    }
                    if (item.SeatNo == "D3")
                    {
                        SeatStatusUpdate.D3 = "Booked";
                    }
                    if (item.SeatNo == "D4")
                    {
                        SeatStatusUpdate.D4 = "Booked";
                    }
                    if (item.SeatNo == "E1")
                    {
                        SeatStatusUpdate.E1 = "Booked";
                    }
                    if (item.SeatNo == "E2")
                    {
                        SeatStatusUpdate.E2 = "Booked";
                    }
                    if (item.SeatNo == "E3")
                    {
                        SeatStatusUpdate.E3 = "Booked";
                    }
                    if (item.SeatNo == "E4")
                    {
                        SeatStatusUpdate.E4 = "Booked";
                    }

                    if (item.SeatNo == "F1")
                    {
                        SeatStatusUpdate.F1 = "Booked";
                    }
                    if (item.SeatNo == "F2")
                    {
                        SeatStatusUpdate.F2 = "Booked";
                    }
                    if (item.SeatNo == "F3")
                    {
                        SeatStatusUpdate.F3 = "Booked";
                    }
                    if (item.SeatNo == "F4")
                    {
                        SeatStatusUpdate.F4 = "Booked";
                    }

                    if (item.SeatNo == "G1")
                    {
                        SeatStatusUpdate.G1 = "Booked";
                    }
                    if (item.SeatNo == "G2")
                    {
                        SeatStatusUpdate.G2 = "Booked";
                    }
                    if (item.SeatNo == "G3")
                    {
                        SeatStatusUpdate.G3 = "Booked";
                    }
                    if (item.SeatNo == "G4")
                    {
                        SeatStatusUpdate.G4 = "Booked";
                    }
                    if (item.SeatNo == "H1")
                    {
                        SeatStatusUpdate.H1 = "Booked";
                    }
                    if (item.SeatNo == "H2")
                    {
                        SeatStatusUpdate.H2 = "Booked";
                    }
                    if (item.SeatNo == "H3")
                    {
                        SeatStatusUpdate.H3 = "Booked";
                    }
                    if (item.SeatNo == "H4")
                    {
                        SeatStatusUpdate.H4 = "Booked";
                    }
                    if (item.SeatNo == "I1")
                    {
                        SeatStatusUpdate.I1 = "Booked";
                    }
                    if (item.SeatNo == "I2")
                    {
                        SeatStatusUpdate.I2 = "Booked";
                    }
                    if (item.SeatNo == "I3")
                    {
                        SeatStatusUpdate.I3 = "Booked";
                    }
                    if (item.SeatNo == "I4")
                    {
                        SeatStatusUpdate.I4 = "Booked";
                    }
                    if (item.SeatNo == "J1")
                    {
                        SeatStatusUpdate.J1 = "Booked";
                    }
                    if (item.SeatNo == "J2")
                    {
                        SeatStatusUpdate.J2 = "Booked";
                    }
                    if (item.SeatNo == "J3")
                    {
                        SeatStatusUpdate.J3 = "Booked";
                    }
                    if (item.SeatNo == "J4")
                    {
                        SeatStatusUpdate.J4 = "Booked";
                    }
                    DbContext.SaveChanges();
                }
            }
        }

        public List<TicketDetails> GetTicketStatusIDAndSeatNo(int PkID, string seatNo)
        {
            List<TicketDetails> busTicketingList = new List<TicketDetails>();
            foreach (var p in (from j in DbContext.TICKET_DETAILS
                               where j.BusAssingnPKId == PkID
                               &&
                               j.SeatNo == seatNo
                               select j).Distinct())
            {
                TicketDetails ticketInfoObj = new TicketDetails();
                ticketInfoObj.Id = p.Id;
                ticketInfoObj.ClintName = p.ClintName;
                ticketInfoObj.ClintMobile = p.ClintMobile;
                ticketInfoObj.ClintAddress = p.ClintAddress;
                ticketInfoObj.TicketPriceDue = (int)p.TicketPriceDue;
                ticketInfoObj.TicketNo = p.TicketNo;
                
                busTicketingList.Add(ticketInfoObj);
            }
            return busTicketingList;
        }


        public List<Ticketing> GetAllAssignedBus()
        {
            List<Ticketing> busTicketingList = new List<Ticketing>();
            foreach (var p in (from j in DbContext.BUS_ASSIGN select j).Distinct())
            {
                Ticketing ticketInfoObj = new Ticketing();
                ticketInfoObj.ID = p.ID;
                ticketInfoObj.TimeOfDiparture = p.TimeOfDiparture;
                ticketInfoObj.Sift = p.Sift;
                ticketInfoObj.DateOfDiparture = (DateTime)p.DateOfDiparture;
                ticketInfoObj.UniqueId = p.UniqueId;
                ticketInfoObj.Type = p.Type;
                ticketInfoObj.BusNumber = p.BusNumber;
                ticketInfoObj.TicketPrice = p.TicketPrice;
                ticketInfoObj.CounterName = p.TicketCounter;

                busTicketingList.Add(ticketInfoObj);
            }
            return busTicketingList;
        }



        public List<TicketDetails> TicketListByTicketNo(string TicketNo)
        {
            List<TicketDetails> _busTicketingList = new List<TicketDetails>();
            foreach (var p in (from j in DbContext.TICKET_DETAILS
                               where j.TicketNo == TicketNo
                               ////orderby j.TicketNo.ToList()
                               select j).Distinct())
            {
                TicketDetails ticketInfoObj = new TicketDetails();
                ticketInfoObj.Id = p.Id;
                ticketInfoObj.ClintMobile = p.ClintMobile;
                ticketInfoObj.ClintName = p.ClintName;
                ticketInfoObj.ClintAddress = p.ClintAddress;
                ticketInfoObj.Gender = p.Gender;
                ticketInfoObj.Age =(int) p.Age;
                ticketInfoObj.ReportingTime = p.BUS_ASSIGN.ReportingTime;
                ticketInfoObj.Time = p.BUS_ASSIGN.TimeOfDiparture;
                ticketInfoObj.BusNo = p.BUS_ASSIGN.BusNumber;
                ticketInfoObj.BusType = p.BUS_ASSIGN.Type;
                ticketInfoObj.Sift = p.BUS_ASSIGN.Sift;
                ticketInfoObj.Status = p.Status;
                ticketInfoObj.SeatNo = p.SeatNo;
                ticketInfoObj.EntryDate = (DateTime)p.EntryDate;
                ticketInfoObj.TotalTicketPrice = (int)p.TicketPrice;
                ticketInfoObj.TicketPrice = (int)p.BUS_ASSIGN.TicketPrice;


                ticketInfoObj.TicketPricePaid = (int)p.TicketPricePaid;
                ticketInfoObj.TicketPriceDiscount = (int)p.TicketPriceDiscount;
                ticketInfoObj.TicketPriceDue =(int) p.TicketPriceDue;
                ticketInfoObj.TicketNo = p.TicketNo;
                ticketInfoObj.BookingNo = p.BookingNo;
                ticketInfoObj.JournyDate = (DateTime)p.JournyDate;
                ticketInfoObj.FromJourny = p.JournyFrom;

                ticketInfoObj.ToJourny = p.JournyTo;
                ticketInfoObj.UserName = p.UserName;
                ticketInfoObj.UserID = (int)p.UserID;


                _busTicketingList.Add(ticketInfoObj);
            }
            return _busTicketingList;
        }

        public string GetTicketStatusIDAndSeatNoAllseat(string allseat)
        {
            string allSeat = "";
            List<string> busSeatList = new List<string>();
            foreach (var p in (from j in DbContext.TICKET_DETAILS
                               where j.TicketNo == allseat
                               select j).Distinct())
            {
                busSeatList.Add(p.SeatNo);
            }
            busSeatList.Sort();
            StringBuilder builder = new StringBuilder();
            foreach (string item in busSeatList)
            {
                builder.Append(item).Append(",");
            }
            allSeat = builder.ToString();
            return allSeat;
        }

        public List<TicketDetails> GetTicketAllTicket(int PkID)
        {
            List<TicketDetails> _busTicketingList = new List<TicketDetails>();
            foreach (var p in (from j in DbContext.TICKET_DETAILS
                               where j.BusAssingnPKId == PkID
                               ////orderby j.TicketNo.ToList()
                               select new {j.TicketNo, j.Status, j.TicketPricePaid, j.TicketPriceDue,j.ClintName}).Distinct())
            {
                TicketDetails ticketInfoObj = new TicketDetails();
                //ticketInfoObj.Id = p.Id;
                //ticketInfoObj.ClintMobile = p.ClintMobile;
                ticketInfoObj.ClintName = p.ClintName;
                //ticketInfoObj.ClintAddress = p.ClintAddress;
                //ticketInfoObj.Gender = p.Gender;
                //ticketInfoObj.Age = (int)p.Age;
                //ticketInfoObj.ReportingTime = p.BUS_ASSIGN.ReportingTime;
                //ticketInfoObj.Time = p.BUS_ASSIGN.TimeOfDiparture;
                //ticketInfoObj.BusNo = p.BUS_ASSIGN.BusNumber;
                //ticketInfoObj.BusType = p.BUS_ASSIGN.Type;
                //ticketInfoObj.Sift = p.BUS_ASSIGN.Sift;
                ticketInfoObj.Status = p.Status;
                //ticketInfoObj.SeatNo = p.SeatNo;
                //ticketInfoObj.EntryDate = (DateTime)p.EntryDate;
                //ticketInfoObj.TotalTicketPrice = (int)p.TicketPrice;
                //ticketInfoObj.TicketPrice = (int)p.BUS_ASSIGN.TicketPrice;


                ticketInfoObj.TicketPricePaid = (int)p.TicketPricePaid;
                //ticketInfoObj.TicketPriceDiscount = (int)p.TicketPriceDiscount;
                ticketInfoObj.TicketPriceDue = (int)p.TicketPriceDue;
                ticketInfoObj.TicketNo = p.TicketNo;
                //ticketInfoObj.BookingNo = p.BookingNo;
                //ticketInfoObj.JournyDate = (DateTime)p.JournyDate;
                //ticketInfoObj.FromJourny = p.JournyFrom;

                //ticketInfoObj.ToJourny = p.JournyTo;
                //ticketInfoObj.UserName = p.UserName;
                //ticketInfoObj.UserID = (int)p.UserID;


                _busTicketingList.Add(ticketInfoObj);
            }
            return _busTicketingList;
        }
    }
}
