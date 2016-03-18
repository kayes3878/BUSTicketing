using BLL;
using BLL.LoginBLL;
using BUSTicketing.Reporting.Crystal;
using BUSTicketing.Reporting.Entity;
using ENTITY;
using ENTITY.Login;
using ENTITY.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BUSTicketing.UI
{
    /// <summary>
    /// Interaction logic for TicketingUI.xaml
    /// </summary>
    public partial class TicketingUI : Window
    {
        private BMenuPermissionManager objBMenuPermission = new BMenuPermissionManager();
        EUser anUser = new EUser();

        Ticketing ticketingObj = new Ticketing();
        List<Ticketing> ticketinglistStatus;
        TicketStatusManager ticketStatusManagerObj = new TicketStatusManager();
        PreSetupManeger _preSetupManegerObj = new PreSetupManeger();
        TicketDetails ticketDetailsObj = new TicketDetails();
        List<TicketDetails> ticketDetailsList;
        TicketDetails obj;
        private long p;

        string GloblaTicketID;

        public TicketingUI()
        {
            InitializeComponent();
            LoadAllButton();
            dateLable.Content = DateTime.Today.DayOfWeek;
            LoadticketNo();
            LoadtoJournyCombobox();
       }

        private void LoadtoJournyCombobox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            toJournyCombobox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllCounterName();
            foreach (PreSetup preset in presetupList)
            {
                toJournyCombobox.ItemsSource = presetupList;
            }
            toJournyCombobox.DisplayMemberPath = "CounterName";
        }

        private void LoadticketNo()
        {
            GloblaTicketID = uniqueCode().ToString();
            ticketBookingNumberlable.Content = GloblaTicketID;
        }

        static string uniqueCode()
        {
            string characters = "01234A56789";
            string time = DateTime.UtcNow.Ticks.ToString();
            var code = "";
            for (var i = 0; i < characters.Length; i += 2)
            {
                if ((i + 2) <= time.Length)
                {
                    var number = int.Parse(time.Substring(i, 2));
                    if (number > characters.Length - 1)
                    {
                        var one = double.Parse(number.ToString().Substring(0, 1));
                        var two = double.Parse(number.ToString().Substring(1, 1));
                        code += characters[Convert.ToInt32(one)];
                        code += characters[Convert.ToInt32(two)];
                    }
                    else
                        code += characters[number];
                }
            }
            return code;
        }
        public TicketingUI(EUser _UserObj)
            : this()
        {
            setUser(_UserObj);

        }

       
        public void setUser(EUser _Obj)
        {
            anUser = _Obj;
        }

        private void LoadMenuInTree(long userGroupId)
        {
            try
            {
                foreach (MenuItem it in topManu.Items)
                {
                    if (objBMenuPermission.IsExistParentMenu(it.Name, userGroupId))
                    {
                        ProcessTree(it, userGroupId);
                    }
                    else
                    {
                        it.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading Available Menu", "Report", MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }

        private void ProcessTree(MenuItem it, long userGroupId)
        {
            foreach (MenuItem obj in it.Items)
            {
                if (objBMenuPermission.IsExistChildMenu(obj.Name, userGroupId))
                {
                    ProcessTree(obj, userGroupId);
                }
                else
                {
                    obj.Visibility = Visibility.Collapsed;
                }
            }
        }
      
       

        private void LoadAllButton()
        {
            //DateTime departureDate = ;
            //da departureTime = "";
            //string Sift = "";

            //ticketinglistStatus = new List<Ticketing>();
            //ticketinglistStatus = ticketStatusManagerObj.GetTicketStatus(departureTime, Sift);
            //string a1 = "Booking";
            //string a2 = "Sell";

            //if (a1 == "Booking")
            //{
            //    seat_1_Button.Background = Brushes.AntiqueWhite;
            //}
            //if (a2 == "Sell")
            //{
            //    seat_2_Button.Background = Brushes.Azure;
            //}

            
        }
        //////public DateTime datexyx;

        private void clnd_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearLable();

            DateTime dateOfDeparture = (DateTime)clnd.SelectedDate;
            ticketinglistStatus = new List<Ticketing>();
            ticketinglistStatus = ticketStatusManagerObj.GetTicketStatus(dateOfDeparture);
            
            if (ticketinglistStatus.Count > 0)
            {
                allStatusBydateListView.Items.Clear();
                foreach (var item in ticketinglistStatus)
                {
                    allStatusBydateListView.Items.Add(item);
                }
            }
            if (ticketinglistStatus.Count <= 0)
            {
                allStatusBydateListView.Items.Clear();
            }
            if (ticketinglistStatus.Count == 1)
            {
                foreach (var item in ticketinglistStatus)
                {
                    Date.Content = Convert.ToString(item.DateOfDiparture.Date.Date);
                    Time.Content =  item.TimeOfDiparture;
                    BusNo.Content = item.BusNumber;
                    BusType.Content = item.Type;
                    Sift.Content = item.Sift;
                    BusAssingnPKIdLable.Content = item.ID;
                    //BusUniqueCodeLable.Content = item.UniqueId;

                    fromJournyTextbox.Text = item.CounterName;
                    seatFareTextnox.Text = item.TicketPrice.ToString();
                    #region A1
                    ///// A1
                    if (item.A1 != null && item.A1 != "")
                    {
                        if (item.A1 == "Sold")
                        {
                            A1.Background = Brushes.Green;
                        }
                        if (item.A1 == "Booked")
                        {
                            A1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        A1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region A2
                    ///// A2
                    if (item.A2 != null && item.A2 != "")
                    {
                        if (item.A2 == "Sold")
                        {
                            A2.Background = Brushes.Green;

                        }
                        if (item.A2 == "Booked")
                        {
                            A2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region A3
                    ///// A3
                    if (item.A3 != null && item.A3 != "")
                    {
                        if (item.A3 == "Sold")
                        {
                            A3.Background = Brushes.Green;

                        }
                        if (item.A3 == "Booked")
                        {
                            A3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region A4
                    ///// A4
                    if (item.A4 != null && item.A4 != "")
                    {
                        if (item.A4 == "Sold")
                        {
                            A4.Background = Brushes.Green;

                        }
                        if (item.A4 == "Booked")
                        {
                            A4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region B1
                    ///// B1
                    if (item.B1 != null && item.B1 != "")
                    {
                        if (item.B1 == "Sold")
                        {
                            B1.Background = Brushes.Green;
                        }
                        if (item.B1 == "Booked")
                        {
                            B1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        B1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region B2
                     ///// B2
                    if (item.B2 != null && item.B2 != "")
                    {
                        if (item.B2 == "Sold")
                        {
                            B2.Background = Brushes.Green;

                        }
                        if (item.B2 == "Booked")
                        {
                            B2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region B3
                     ///// B3
                    if (item.B3 != null && item.B3 != "")
                    {
                        if (item.B3 == "Sold")
                        {
                            B3.Background = Brushes.Green;

                        }
                        if (item.B3 == "Booked")
                        {
                            B3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region B4
                    ///// B4
                    if (item.B4 != null && item.B4 != "")
                    {
                        if (item.B4 == "Sold")
                        {
                            B4.Background = Brushes.Green;

                        }
                        if (item.B4 == "Booked")
                        {
                            B4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region C1
                        ///// C1
                    if (item.C1 != null && item.C1 != "")
                    {
                        if (item.C1 == "Sold")
                        {
                            C1.Background = Brushes.Green;
                        }
                        if (item.C1 == "Booked")
                        {
                            C1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        C1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region C2
                      ///// C2
                    if (item.C2 != null && item.C2 != "")
                    {
                        if (item.C2 == "Sold")
                        {
                            C2.Background = Brushes.Green;

                        }
                        if (item.C2 == "Booked")
                        {
                            C2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region C3
                    ///// C3
                    if (item.C3 != null && item.C3 != "")
                    {
                        if (item.C3 == "Sold")
                        {
                            C3.Background = Brushes.Green;

                        }
                        if (item.C3 == "Booked")
                        {
                            C3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region C4
                    ///// C4
                    if (item.C4 != null && item.C4 != "")
                    {
                        if (item.C4 == "Sold")
                        {
                            C4.Background = Brushes.Green;

                        }
                        if (item.C4 == "Booked")
                        {
                            C4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region D1
                     ///// D1
                    if (item.D1 != null && item.D1 != "")
                    {
                        if (item.D1 == "Sold")
                        {
                            D1.Background = Brushes.Green;
                        }
                        if (item.D1 == "Booked")
                        {
                            D1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        D1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region D2
                    ///// D2
                    if (item.D2 != null && item.D2 != "")
                    {
                        if (item.D2 == "Sold")
                        {
                            D2.Background = Brushes.Green;

                        }
                        if (item.D2 == "Booked")
                        {
                            D2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region D3
                     ///// D3
                    if (item.D3 != null && item.D3 != "")
                    {
                        if (item.D3 == "Sold")
                        {
                            D3.Background = Brushes.Green;

                        }
                        if (item.D3 == "Booked")
                        {
                            D3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region D4
                     ///// D4
                    if (item.D4 != null && item.D4 != "")
                    {
                        if (item.D4 == "Sold")
                        {
                            D4.Background = Brushes.Green;

                        }
                        if (item.D4 == "Booked")
                        {
                            D4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region E1
                     ///// E1
                    if (item.E1 != null && item.E1 != "")
                    {
                        if (item.E1 == "Sold")
                        {
                            E1.Background = Brushes.Green;
                        }
                        if (item.E1 == "Booked")
                        {
                            E1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        E1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region E2
                     ///// E2
                    if (item.E2 != null && item.E2 != "")
                    {
                        if (item.E2 == "Sold")
                        {
                            E2.Background = Brushes.Green;

                        }
                        if (item.E2 == "Booked")
                        {
                            E2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region E3
                      ///// E3
                    if (item.E3 != null && item.E3 != "")
                    {
                        if (item.E3 == "Sold")
                        {
                            E3.Background = Brushes.Green;

                        }
                        if (item.E3 == "Booked")
                        {
                            E3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region E4
                     ///// E4
                    if (item.E4 != null && item.E4 != "")
                    {
                        if (item.E4 == "Sold")
                        {
                            E4.Background = Brushes.Green;

                        }
                        if (item.E4 == "Booked")
                        {
                            E4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region F1
                    ///// F1
                    if (item.F1 != null && item.F1 != "")
                    {
                        if (item.F1 == "Sold")
                        {
                            F1.Background = Brushes.Green;
                        }
                        if (item.F1 == "Booked")
                        {
                            F1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        F1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region F2
                      ///// F2
                    if (item.F2 != null && item.F2 != "")
                    {
                        if (item.F2 == "Sold")
                        {
                            F2.Background = Brushes.Green;

                        }
                        if (item.F2 == "Booked")
                        {
                            F2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region F3
                     ///// F3
                    if (item.F3 != null && item.F3 != "")
                    {
                        if (item.F3 == "Sold")
                        {
                            F3.Background = Brushes.Green;

                        }
                        if (item.F3 == "Booked")
                        {
                            F3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F3.Background = Brushes.LightGray;
                    }
                    #endregion 
                    #region F4
                       ///// F4
                    if (item.F4 != null && item.F4 != "")
                    {
                        if (item.F4 == "Sold")
                        {
                            F4.Background = Brushes.Green;

                        }
                        if (item.F4 == "Booked")
                        {
                            F4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region G1
                    ///// G1
                    if (item.G1 != null && item.G1 != "")
                    {
                        if (item.G1 == "Sold")
                        {
                            G1.Background = Brushes.Green;
                        }
                        if (item.G1 == "Booked")
                        {
                            G1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        G1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region G2
                     ///// G2
                    if (item.G2 != null && item.G2 != "")
                    {
                        if (item.G2 == "Sold")
                        {
                            G2.Background = Brushes.Green;
                        }
                        if (item.G2 == "Booked")
                        {
                            G2.Background = Brushes.Yellow;

                        }
                    }
                    else
                    {
                        G2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region G3
                    ///// G3
                    if (item.G3 != null && item.G3 != "")
                    {
                        if (item.G3 == "Sold")
                        {
                            G3.Background = Brushes.Green;

                        }
                        if (item.G3 == "Booked")
                        {
                            G3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        G3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region G4
                    ///// G4
                    if (item.G4 != null && item.G4 != "")
                    {
                        if (item.G4 == "Sold")
                        {
                            G4.Background = Brushes.Green;

                        }
                        if (item.G4 == "Booked")
                        {
                            G4.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        G4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region H1
                    ///// H1
                    if (item.H1 != null && item.H1 != "")
                    {
                        if (item.H1 == "Sold")
                        {
                            H1.Background = Brushes.Green;
                        }
                        if (item.H1 == "Booked")
                        {
                            H1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        H1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region H2
                    ///// H2
                    if (item.H2 != null && item.H2 != "")
                    {
                        if (item.H2 == "Sold")
                        {
                            H2.Background = Brushes.Green;

                        }
                        if (item.H2 == "Booked")
                        {
                            H2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region H3
                    ///// H3
                    if (item.H3 != null && item.H3 != "")
                    {
                        if (item.H3 == "Sold")
                        {
                            H3.Background = Brushes.Green;

                        }
                        if (item.H3 == "Booked")
                        {
                            H3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region H4
                    ///// H4
                    if (item.H4 != null && item.H4 != "")
                    {
                        if (item.H4 == "Sold")
                        {
                            H4.Background = Brushes.Green;

                        }
                        if (item.H4 == "Booked")
                        {
                            H4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region I1
                    ///// I1
                    if (item.I1 != null && item.I1 != "")
                    {
                        if (item.I1 == "Sold")
                        {
                            I1.Background = Brushes.Green;
                        }
                        if (item.I1 == "Booked")
                        {
                            I1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        I1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region I2
                    ///// I2
                    if (item.I2 != null && item.I2 != "")
                    {
                        if (item.I2 == "Sold")
                        {
                            I2.Background = Brushes.Green;

                        }
                        if (item.I2 == "Booked")
                        {
                            I2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region I3
                    ///// I3
                    if (item.I3 != null && item.I3 != "")
                    {
                        if (item.I3 == "Sold")
                        {
                            I3.Background = Brushes.Green;

                        }
                        if (item.I3 == "Booked")
                        {
                            I3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region I4
                    ///// I4
                    if (item.I4 != null && item.I4 != "")
                    {
                        if (item.I4 == "Sold")
                        {
                            I4.Background = Brushes.Green;

                        }
                        if (item.I4 == "Booked")
                        {
                            I4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I4.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region J1
                    ///// J1
                    if (item.J1 != null && item.J1 != "")
                    {
                        if (item.J1 == "Sold")
                        {
                            J1.Background = Brushes.Green;
                        }
                        if (item.J1 == "Booked")
                        {
                            J1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        J1.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region J2
                    ///// J2
                    if (item.J2 != null && item.J2 != "")
                    {
                        if (item.J2 == "Sold")
                        {
                            J2.Background = Brushes.Green;

                        }
                        if (item.J2 == "Booked")
                        {
                            J2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J2.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region J3
                    ///// J3
                    if (item.J3 != null && item.J3 != "")
                    {
                        if (item.J3 == "Sold")
                        {
                            J3.Background = Brushes.Green;

                        }
                        if (item.J3 == "Booked")
                        {
                            J3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J3.Background = Brushes.LightGray;
                    }
                    #endregion
                    #region J4
                    ///// J4
                    if (item.J4 != null && item.J4 != "")
                    {
                        if (item.J4 == "Sold")
                        {
                            J4.Background = Brushes.Green;

                        }
                        if (item.J4 == "Booked")
                        {
                            J4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J4.Background = Brushes.LightGray;
                    }
                    #endregion
                }
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                LoadalTicketByDate(PkID);
            }
            dateLable.Content = Convert.ToString(clnd.SelectedDate.Value.DayOfWeek);
              
        }

        private void ClearLable()
        {
            Date.Content = "";
            Time.Content = "";
            BusNo.Content = "";
            BusType.Content = "";
            Sift.Content = "";
            BusAssingnPKIdLable.Content = "";
            //BusUniqueCodeLable.Content = "";
            A1.Background = Brushes.LightGray;
            A2.Background = Brushes.LightGray;
            A3.Background = Brushes.LightGray;
            A4.Background = Brushes.LightGray;
            B1.Background = Brushes.LightGray;
            B2.Background = Brushes.LightGray;
            B3.Background = Brushes.LightGray;
            B4.Background = Brushes.LightGray;

            C1.Background = Brushes.LightGray;
            C2.Background = Brushes.LightGray;
            C3.Background = Brushes.LightGray;
            C4.Background = Brushes.LightGray;

            D1.Background = Brushes.LightGray;
            D2.Background = Brushes.LightGray;
            D3.Background = Brushes.LightGray;
            D4.Background = Brushes.LightGray;

            E1.Background = Brushes.LightGray;
            E2.Background = Brushes.LightGray;
            E3.Background = Brushes.LightGray;
            E4.Background = Brushes.LightGray;

            F1.Background = Brushes.LightGray;
            F2.Background = Brushes.LightGray;
            F3.Background = Brushes.LightGray;
            F4.Background = Brushes.LightGray;

            G1.Background = Brushes.LightGray;
            G2.Background = Brushes.LightGray;
            G3.Background = Brushes.LightGray;
            G4.Background = Brushes.LightGray;

            H1.Background = Brushes.LightGray;
            H2.Background = Brushes.LightGray;
            H3.Background = Brushes.LightGray;
            H4.Background = Brushes.LightGray;

            I1.Background = Brushes.LightGray;
            I2.Background = Brushes.LightGray;
            I3.Background = Brushes.LightGray;
            I4.Background = Brushes.LightGray;

            J1.Background = Brushes.LightGray;
            J2.Background = Brushes.LightGray;
            J3.Background = Brushes.LightGray;
            J4.Background = Brushes.LightGray;
           
        }

        
        private void allStatusBydateListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SeatStatusView();
        }

        private void SeatStatusView()
        {
            if (allStatusBydateListView.SelectedIndex > -1)
            {
                int PkID = ((Ticketing)allStatusBydateListView.SelectedItem).ID;
                ticketinglistStatus = new List<Ticketing>();
                LoadalTicketByDate(PkID);
                
                //SoldAndBookingListView
                ticketinglistStatus = ticketStatusManagerObj.GetTicketStatusID(PkID);
                if (ticketinglistStatus.Count == 1)
                {
                    foreach (var item in ticketinglistStatus)
                    {
                        Date.Content = Convert.ToString(item.DateOfDiparture.Date);
                        Time.Content = item.TimeOfDiparture;
                        BusNo.Content = item.BusNumber;
                        BusType.Content = item.Type;
                        Sift.Content = item.Sift;
                        BusAssingnPKIdLable.Content = item.ID;
                        //BusUniqueCodeLable.Content = item.UniqueId;
                        fromJournyTextbox.Text = item.CounterName;
                        seatFareTextnox.Text = item.TicketPrice.ToString();
                        ///// A1
                        if (item.A1 != null && item.A1 != "")
                        {
                            if (item.A1 == "Sold")
                            {
                                A1.Background = Brushes.Green;
                            }
                            if (item.A1 == "Booked")
                            {
                                A1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            A1.Background = Brushes.LightGray;
                        }
                        ///// A2
                        if (item.A2 != null && item.A2 != "")
                        {
                            if (item.A2 == "Sold")
                            {
                                A2.Background = Brushes.Green;

                            }
                            if (item.A2 == "Booked")
                            {
                                A2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            A2.Background = Brushes.LightGray;
                        }
                        ///// A3
                        if (item.A3 != null && item.A3 != "")
                        {
                            if (item.A3 == "Sold")
                            {
                                A3.Background = Brushes.Green;

                            }
                            if (item.A3 == "Booked")
                            {
                                A3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            A3.Background = Brushes.LightGray;
                        }
                        ///// A4
                        if (item.A4 != null && item.A4 != "")
                        {
                            if (item.A4 == "Sold")
                            {
                                A4.Background = Brushes.Green;

                            }
                            if (item.A4 == "Booked")
                            {
                                A4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            A4.Background = Brushes.LightGray;
                        }

                        ///// B1
                        if (item.B1 != null && item.B1 != "")
                        {
                            if (item.B1 == "Sold")
                            {
                                B1.Background = Brushes.Green;
                            }
                            if (item.B1 == "Booked")
                            {
                                B1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            B1.Background = Brushes.LightGray;
                        }
                        ///// B2
                        if (item.B2 != null && item.B2 != "")
                        {
                            if (item.B2 == "Sold")
                            {
                                B2.Background = Brushes.Green;

                            }
                            if (item.B2 == "Booked")
                            {
                                B2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            B2.Background = Brushes.LightGray;
                        }
                        ///// B3
                        if (item.B3 != null && item.B3 != "")
                        {
                            if (item.B3 == "Sold")
                            {
                                B3.Background = Brushes.Green;

                            }
                            if (item.B3 == "Booked")
                            {
                                B3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            B3.Background = Brushes.LightGray;
                        }
                        ///// B4
                        if (item.B4 != null && item.B4 != "")
                        {
                            if (item.B4 == "Sold")
                            {
                                B4.Background = Brushes.Green;

                            }
                            if (item.B4 == "Booked")
                            {
                                B4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            B4.Background = Brushes.LightGray;
                        }
                        ///// C1
                        if (item.C1 != null && item.C1 != "")
                        {
                            if (item.C1 == "Sold")
                            {
                                C1.Background = Brushes.Green;
                            }
                            if (item.C1 == "Booked")
                            {
                                C1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            C1.Background = Brushes.LightGray;
                        }
                        ///// C2
                        if (item.C2 != null && item.C2 != "")
                        {
                            if (item.C2 == "Sold")
                            {
                                C2.Background = Brushes.Green;

                            }
                            if (item.C2 == "Booked")
                            {
                                C2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            C2.Background = Brushes.LightGray;
                        }
                        ///// C3
                        if (item.C3 != null && item.C3 != "")
                        {
                            if (item.C3 == "Sold")
                            {
                                C3.Background = Brushes.Green;

                            }
                            if (item.C3 == "Booked")
                            {
                                C3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            C3.Background = Brushes.LightGray;
                        }
                        ///// C4
                        if (item.C4 != null && item.C4 != "")
                        {
                            if (item.C4 == "Sold")
                            {
                                C4.Background = Brushes.Green;

                            }
                            if (item.C4 == "Booked")
                            {
                                C4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            C4.Background = Brushes.LightGray;
                        }
                        ///// D1
                        if (item.D1 != null && item.D1 != "")
                        {
                            if (item.D1 == "Sold")
                            {
                                D1.Background = Brushes.Green;
                            }
                            if (item.D1 == "Booked")
                            {
                                D1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            D1.Background = Brushes.LightGray;
                        }
                        ///// D2
                        if (item.D2 != null && item.D2 != "")
                        {
                            if (item.D2 == "Sold")
                            {
                                D2.Background = Brushes.Green;

                            }
                            if (item.D2 == "Booked")
                            {
                                D2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            D2.Background = Brushes.LightGray;
                        }
                        ///// D3
                        if (item.D3 != null && item.D3 != "")
                        {
                            if (item.D3 == "Sold")
                            {
                                D3.Background = Brushes.Green;

                            }
                            if (item.D3 == "Booked")
                            {
                                D3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            D3.Background = Brushes.LightGray;
                        }
                        ///// D4
                        if (item.D4 != null && item.D4 != "")
                        {
                            if (item.D4 == "Sold")
                            {
                                D4.Background = Brushes.Green;

                            }
                            if (item.D4 == "Booked")
                            {
                                D4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            D4.Background = Brushes.LightGray;
                        }
                        ///// E1
                        if (item.E1 != null && item.E1 != "")
                        {
                            if (item.E1 == "Sold")
                            {
                                E1.Background = Brushes.Green;
                            }
                            if (item.E1 == "Booked")
                            {
                                E1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            E1.Background = Brushes.LightGray;
                        }
                        ///// E2
                        if (item.E2 != null && item.E2 != "")
                        {
                            if (item.E2 == "Sold")
                            {
                                E2.Background = Brushes.Green;

                            }
                            if (item.E2 == "Booked")
                            {
                                E2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            E2.Background = Brushes.LightGray;
                        }
                        ///// E3
                        if (item.E3 != null && item.E3 != "")
                        {
                            if (item.E3 == "Sold")
                            {
                                E3.Background = Brushes.Green;

                            }
                            if (item.E3 == "Booked")
                            {
                                E3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            E3.Background = Brushes.LightGray;
                        }
                        ///// E4
                        if (item.E4 != null && item.E4 != "")
                        {
                            if (item.E4 == "Sold")
                            {
                                E4.Background = Brushes.Green;

                            }
                            if (item.E4 == "Booked")
                            {
                                E4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            E4.Background = Brushes.LightGray;
                        }
                        ///// F1
                        if (item.F1 != null && item.F1 != "")
                        {
                            if (item.F1 == "Sold")
                            {
                                F1.Background = Brushes.Green;
                            }
                            if (item.F1 == "Booked")
                            {
                                F1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            F1.Background = Brushes.LightGray;
                        }
                        ///// F2
                        if (item.F2 != null && item.F2 != "")
                        {
                            if (item.F2 == "Sold")
                            {
                                F2.Background = Brushes.Green;

                            }
                            if (item.F2 == "Booked")
                            {
                                F2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            F2.Background = Brushes.LightGray;
                        }
                        ///// F3
                        if (item.F3 != null && item.F3 != "")
                        {
                            if (item.F3 == "Sold")
                            {
                                F3.Background = Brushes.Green;

                            }
                            if (item.F3 == "Booked")
                            {
                                F3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            F3.Background = Brushes.LightGray;
                        }
                        ///// F4
                        if (item.F4 != null && item.F4 != "")
                        {
                            if (item.F4 == "Sold")
                            {
                                F4.Background = Brushes.Green;

                            }
                            if (item.F4 == "Booked")
                            {
                                F4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            F4.Background = Brushes.LightGray;
                        }
                        ///// G1
                        if (item.G1 != null && item.G1 != "")
                        {
                            if (item.G1 == "Sold")
                            {
                                G1.Background = Brushes.Green;
                            }
                            if (item.G1 == "Booked")
                            {
                                G1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            G1.Background = Brushes.LightGray;
                        }
                        ///// G2
                        if (item.G2 != null && item.G2 != "")
                        {
                            if (item.G2 == "Sold")
                            {
                                G2.Background = Brushes.Green;
                            }
                            if (item.G2 == "Booked")
                            {
                                G2.Background = Brushes.Yellow;

                            }
                        }
                        else
                        {
                            G2.Background = Brushes.LightGray;
                        }
                        ///// G3
                        if (item.G3 != null && item.G3 != "")
                        {
                            if (item.G3 == "Sold")
                            {
                                G3.Background = Brushes.Green;

                            }
                            if (item.G3 == "Booked")
                            {
                                G3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            G3.Background = Brushes.LightGray;
                        }
                        ///// G4
                        if (item.G4 != null && item.G4 != "")
                        {
                            if (item.G4 == "Sold")
                            {
                                G4.Background = Brushes.Green;

                            }
                            if (item.G4 == "Booked")
                            {
                                G4.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            G4.Background = Brushes.LightGray;
                        }
                        ///// H1
                        if (item.H1 != null && item.H1 != "")
                        {
                            if (item.H1 == "Sold")
                            {
                                H1.Background = Brushes.Green;
                            }
                            if (item.H1 == "Booked")
                            {
                                H1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            H1.Background = Brushes.LightGray;
                        }
                        ///// H2
                        if (item.H2 != null && item.H2 != "")
                        {
                            if (item.H2 == "Sold")
                            {
                                H2.Background = Brushes.Green;

                            }
                            if (item.H2 == "Booked")
                            {
                                H2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            H2.Background = Brushes.LightGray;
                        }
                        ///// H3
                        if (item.H3 != null && item.H3 != "")
                        {
                            if (item.H3 == "Sold")
                            {
                                H3.Background = Brushes.Green;

                            }
                            if (item.H3 == "Booked")
                            {
                                H3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            H3.Background = Brushes.LightGray;
                        }
                        ///// H4
                        if (item.H4 != null && item.H4 != "")
                        {
                            if (item.H4 == "Sold")
                            {
                                H4.Background = Brushes.Green;

                            }
                            if (item.H4 == "Booked")
                            {
                                H4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            H4.Background = Brushes.LightGray;
                        }
                        ///// I1
                        if (item.I1 != null && item.I1 != "")
                        {
                            if (item.I1 == "Sold")
                            {
                                I1.Background = Brushes.Green;
                            }
                            if (item.I1 == "Booked")
                            {
                                I1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            I1.Background = Brushes.LightGray;
                        }
                        ///// I2
                        if (item.I2 != null && item.I2 != "")
                        {
                            if (item.I2 == "Sold")
                            {
                                I2.Background = Brushes.Green;

                            }
                            if (item.I2 == "Booked")
                            {
                                I2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            I2.Background = Brushes.LightGray;
                        }
                        ///// I3
                        if (item.I3 != null && item.I3 != "")
                        {
                            if (item.I3 == "Sold")
                            {
                                I3.Background = Brushes.Green;

                            }
                            if (item.I3 == "Booked")
                            {
                                I3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            I3.Background = Brushes.LightGray;
                        }
                        ///// I4
                        if (item.I4 != null && item.I4 != "")
                        {
                            if (item.I4 == "Sold")
                            {
                                I4.Background = Brushes.Green;

                            }
                            if (item.I4 == "Booked")
                            {
                                I4.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            I4.Background = Brushes.LightGray;
                        }
                        ///// J1
                        if (item.J1 != null && item.J1 != "")
                        {
                            if (item.J1 == "Sold")
                            {
                                J1.Background = Brushes.Green;
                            }
                            if (item.J1 == "Booked")
                            {
                                J1.Background = Brushes.Yellow;
                            }

                        }
                        else
                        {
                            J1.Background = Brushes.LightGray;
                        }
                        ///// J2
                        if (item.J2 != null && item.J2 != "")
                        {
                            if (item.J2 == "Sold")
                            {
                                J2.Background = Brushes.Green;

                            }
                            if (item.J2 == "Booked")
                            {
                                J2.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            J2.Background = Brushes.LightGray;
                        }
                        ///// J3
                        if (item.J3 != null && item.J3 != "")
                        {
                            if (item.J3 == "Sold")
                            {
                                J3.Background = Brushes.Green;

                            }
                            if (item.J3 == "Booked")
                            {
                                J3.Background = Brushes.Yellow;

                            }

                        }
                        else
                        {
                            J3.Background = Brushes.LightGray;
                        }
                        ///// J4
                        if (item.J4 != null && item.J4 != "")
                        {
                            if (item.J4 == "Sold")
                            {
                                J4.Background = Brushes.Green;
                            }
                            if (item.J4 == "Booked")
                            {
                                J4.Background = Brushes.Yellow;

                            }
                        }
                        else
                        {
                            J4.Background = Brushes.LightGray;
                        }
                    }
                }
            }
        }

        private void LoadalTicketByDate(int PkID)
        {
            List<TicketDetails> TicketDetailsListByBusPkID = new List<TicketDetails>();
            TicketDetailsListByBusPkID = ticketStatusManagerObj.GetTicketAllTicket(PkID);
            if (TicketDetailsListByBusPkID.Count > 0)
            {
                SoldAndBookingListView.Items.Clear();
                foreach (var item in TicketDetailsListByBusPkID)
                {
                    SoldAndBookingListView.Items.Add(item);
                }
            }
        }


        private void removeSeat_Click(object sender, RoutedEventArgs e)
        {
            if (ticketPurchageDetailsListView.SelectedIndex > -1)
            {
                ChangeCollorForRemove(((TicketDetails)ticketPurchageDetailsListView.SelectedItem).SeatNo);
                ticketPurchageDetailsListView.Items.RemoveAt(ticketPurchageDetailsListView.Items.IndexOf(ticketPurchageDetailsListView.SelectedItem));
                if ((!string.IsNullOrEmpty(seatFareTextnox.Text)))
                {
                    ticketDetailsList = new List<TicketDetails>();

                    foreach (TicketDetails j in ticketPurchageDetailsListView.Items)
                    {
                        ticketDetailsObj = new TicketDetails();
                        ticketDetailsObj.SeatNo = j.SeatNo;
                        ticketDetailsList.Add(obj);
                    }
                    var totalSeat = ticketDetailsList.Count();
                    totalAmountTextBox.Text = (Convert.ToInt32(seatFareTextnox.Text) * totalSeat).ToString();
                    paidAmountTextBox.Text = totalAmountTextBox.Text;
                }
            }
        }

        private void ChangeCollorForRemove(string SeatNo)
        {
            if (A1.Content == SeatNo)
            {
                A1.Background = Brushes.LightGray;
            }
            if (A2.Content == SeatNo)
            {
                A2.Background = Brushes.LightGray;
            }
            if (A3.Content == SeatNo)
            {
                A3.Background = Brushes.LightGray;
            } 
            if (A4.Content == SeatNo)
            {
                A4.Background = Brushes.LightGray;
            }

            if (B1.Content == SeatNo)
            {
                B1.Background = Brushes.LightGray;
            }
            if (B2.Content == SeatNo)
            {
                B2.Background = Brushes.LightGray;
            }
            if (B3.Content == SeatNo)
            {
                B3.Background = Brushes.LightGray;
            }
            if (B4.Content == SeatNo)
            {
                B4.Background = Brushes.LightGray;
            }

            if (C1.Content == SeatNo)
            {
                C1.Background = Brushes.LightGray;
            }
            if (C2.Content == SeatNo)
            {
                C2.Background = Brushes.LightGray;
            }
            if (C3.Content == SeatNo)
            {
                C3.Background = Brushes.LightGray;
            }
            if (C4.Content == SeatNo)
            {
                C4.Background = Brushes.LightGray;
            }

            if (D1.Content == SeatNo)
            {
                D1.Background = Brushes.LightGray;
            }
            if (D2.Content == SeatNo)
            {
                D2.Background = Brushes.LightGray;
            }
            if (D3.Content == SeatNo)
            {
                D3.Background = Brushes.LightGray;
            }
            if (D4.Content == SeatNo)
            {
                D4.Background = Brushes.LightGray;
            }

            if (E1.Content == SeatNo)
            {
                E1.Background = Brushes.LightGray;
            }
            if (E2.Content == SeatNo)
            {
                E2.Background = Brushes.LightGray;
            }
            if (E3.Content == SeatNo)
            {
                E3.Background = Brushes.LightGray;
            }
            if (E4.Content == SeatNo)
            {
                E4.Background = Brushes.LightGray;
            }

            if (F1.Content == SeatNo)
            {
                F1.Background = Brushes.LightGray;
            }
            if (F2.Content == SeatNo)
            {
                F2.Background = Brushes.LightGray;
            }
            if (F3.Content == SeatNo)
            {
                F3.Background = Brushes.LightGray;
            }
            if (F4.Content == SeatNo)
            {
                F4.Background = Brushes.LightGray;
            }
            if (G1.Content == SeatNo)
            {
                G1.Background = Brushes.LightGray;
            }
            if (G2.Content == SeatNo)
            {
                G2.Background = Brushes.LightGray;
            }
            if (G3.Content == SeatNo)
            {
                G3.Background = Brushes.LightGray;
            }
            if (G4.Content == SeatNo)
            {
                G4.Background = Brushes.LightGray;
            }
            if (H1.Content == SeatNo)
            {
                H1.Background = Brushes.LightGray;
            }
            if (H2.Content == SeatNo)
            {
                H2.Background = Brushes.LightGray;
            }
            if (H3.Content == SeatNo)
            {
                H3.Background = Brushes.LightGray;
            }
            if (H4.Content == SeatNo)
            {
                H4.Background = Brushes.LightGray;
            }
            if (I1.Content == SeatNo)
            {
                I1.Background = Brushes.LightGray;
            }
            if (I2.Content == SeatNo)
            {
                I2.Background = Brushes.LightGray;
            }
            if (I3.Content == SeatNo)
            {
                I3.Background = Brushes.LightGray;
            }
            if (I4.Content == SeatNo)
            {
                I4.Background = Brushes.LightGray;
            }
            if (J1.Content == SeatNo)
            {
                J1.Background = Brushes.LightGray;
            }
            if (J2.Content == SeatNo)
            {
                J2.Background = Brushes.LightGray;
            }
            if (J3.Content == SeatNo)
            {
                J3.Background = Brushes.LightGray;
            }
            if (J4.Content == SeatNo)
            {
                J4.Background = Brushes.LightGray;
            } 


        }
 
        private void SeatSelect(string Seatno, Button btn)
        {
            ticketDetailsList = new List<TicketDetails>();

            foreach (TicketDetails j in ticketPurchageDetailsListView.Items)
            {
                //DataRowView CompRow;
                ticketDetailsObj = new TicketDetails();
                ticketDetailsObj.SeatNo = j.SeatNo;
                if (ticketDetailsObj.SeatNo == Seatno)
                {
                   
                    ticketDetailsList.Add(obj);
                    //ticketPurchageDetailsListView.SelectedItems = 
                    //ticketPurchageDetailsListView.Items.RemoveAt(ticketPurchageDetailsListView.Items.IndexOf(ticketPurchageDetailsListView.SelectedItem));
                     
                }
            }
            if (ticketDetailsList.Count == 0)
            {
                ticketDetailsObj = new TicketDetails();
                ticketDetailsObj.BusAssingnPKId = Convert.ToInt32(BusAssingnPKIdLable.Content);
                //ticketDetailsObj.BusUniqueCode = BusUniqueCodeLable.Content.ToString();
                ticketDetailsObj.BusNo = BusNo.Content.ToString();
                ticketDetailsObj.Time = Time.Content.ToString();
                ticketDetailsObj.BusType = BusType.Content.ToString();
                ticketDetailsObj.Sift = Sift.Content.ToString();
                ticketDetailsObj.SeatNo = Seatno;
                ticketDetailsObj.JournyDate = Convert.ToDateTime(Date.Content);
                ticketDetailsObj.EntryDate = DateTime.Today;
                ticketPurchageDetailsListView.Items.Add(ticketDetailsObj);
                SeatInisialCatch(btn);
            }
            ////// 
            if ((!string.IsNullOrEmpty(seatFareTextnox.Text)))
            {
                ticketDetailsList = new List<TicketDetails>();

                foreach (TicketDetails j in ticketPurchageDetailsListView.Items)
                {
                    ticketDetailsObj = new TicketDetails();
                    ticketDetailsObj.SeatNo = j.SeatNo;
                    ticketDetailsList.Add(obj);
                }
                var totalSeat = ticketDetailsList.Count();
                totalAmountTextBox.Text = (Convert.ToInt32(seatFareTextnox.Text) * totalSeat).ToString();
                if (bookingChqBox.IsChecked == false)
                {
                    paidAmountTextBox.Text = totalAmountTextBox.Text;
                }
                if (bookingChqBox.IsChecked == true)
                {
                    dueAmountTextBox.Text = totalAmountTextBox.Text;
                }
            }
        }


        private void SeatInisialCatch(Button btn)
        {
            btn.Background = Brushes.Coral;
        }
        private void SeatStatusChqPopUp(int PkID, string seatNo, Button btn)
        {
            //if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
            //{
                if (btn.Background == Brushes.Green || btn.Background == Brushes.Yellow)
                {
                
                        ticketDetailsList = new List<TicketDetails>();
                        ticketDetailsList = ticketStatusManagerObj.GetTicketStatusIDAndSeatNo(PkID, seatNo);


                        string ClintName = "";
                        string ClintMobileNo = "";
                        string address = "";
                        string due = "";
                        string allseat = "";

                        foreach (TicketDetails item in ticketDetailsList)
                        {
                            ClintName = item.ClintName;
                            ClintMobileNo = item.ClintMobile;
                            address = item.ClintAddress;
                            due = item.TicketPriceDue.ToString();
                            allseat = ticketStatusManagerObj.GetTicketStatusIDAndSeatNoAllseat(item.TicketNo);

                        }
                        ticketInfoPopup.PlacementTarget = btn;
                        ticketInfoPopup.Placement = PlacementMode.Left;
                        ticketInfoPopupBlock.Text = ClintName + ", \n" + ClintMobileNo + ", \n" + address + ", \n" + "Due -" + due + " TK" + ", \n" + allseat;
                        ticketInfoPopup.IsOpen = true;
                    }
                //}
        }
        private void A1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = A1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }

        }

        #region ALL BUTTON ClICK EVENT
        private void A2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = A2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = A3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void A4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = A4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = B1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = B2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = B3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = B4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = C1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = C2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }

        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = C3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void C4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = C4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = D1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = D2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = D3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = D4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = E1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = E2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = E3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void E4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = E4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void F1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = F1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void F2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = F2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void F3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = F3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void F4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = F4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }
        private void G1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = G1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void G2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = G2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void G3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = G3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void G4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = G4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = H1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = H1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = H3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void H4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = H4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void I1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = I1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void I2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = I2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void I3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = I3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void I4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = I4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void J1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = J1;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void J2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = J2;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void J3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = J3;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }

        private void J4_Click(object sender, RoutedEventArgs e)
        {
            Button btn = J4;
            string Seatno = btn.Content.ToString();
            if (SaleChqBox.IsChecked == true || bookingChqBox.IsChecked == true)
            {
                if (btn.Background != Brushes.Green && btn.Background != Brushes.Yellow && BusAssingnPKIdLable.Content != "")
                {
                    SeatSelect(Seatno, btn);
                }
            }
            if (SaleChqBox.IsChecked == false && bookingChqBox.IsChecked == false && ReturnChqBox.IsChecked == false && BusAssingnPKIdLable.Content != "")
            {
                int PkID = Convert.ToInt32(BusAssingnPKIdLable.Content);
                string seatNo = btn.Content.ToString();
                SeatStatusChqPopUp(PkID, seatNo, btn);
            }
        }
        #endregion
        private void seatFareTextnox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (e.Handled != !Validations.IsInteger(e.Text))
            {
                popCaesar.PlacementTarget = seatFareTextnox;
                
                popCaesar.Placement = PlacementMode.Right;
                popCaesar.IsOpen = true;
            }
            if (e.Handled == !Validations.IsInteger(e.Text))
            {
                popCaesar.IsOpen = false;
            }
            e.Handled = !Validations.IsInteger(e.Text);
            base.OnPreviewTextInput(e); 
        }

        private void seatFareTextnox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(seatFareTextnox.Text)))
            {
                ticketDetailsList = new List<TicketDetails>();

                foreach (TicketDetails j in ticketPurchageDetailsListView.Items)
                {
                    ticketDetailsObj = new TicketDetails();
                    ticketDetailsObj.SeatNo = j.SeatNo;
                    ticketDetailsList.Add(obj);
                }
                var totalSeat = ticketDetailsList.Count();
                totalAmountTextBox.Text = (Convert.ToInt32(seatFareTextnox.Text) * totalSeat).ToString();
                paidAmountTextBox.Text = totalAmountTextBox.Text;
            }
            if (seatFareTextnox.Text == "")
            {
                totalAmountTextBox.Text = "";
                paidAmountTextBox.Text = "";
            }
        }

        private void paidAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(paidAmountTextBox.Text)) && (!string.IsNullOrEmpty(totalAmountTextBox.Text)))
            {
                dueAmountTextBox.Text = (Convert.ToInt32(totalAmountTextBox.Text) - Convert.ToInt32(paidAmountTextBox.Text)).ToString();
            }
        }

        private void paidAmountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Handled != !Validations.IsInteger(e.Text))
            {
                popCaesar.PlacementTarget = paidAmountTextBox;

                popCaesar.Placement = PlacementMode.Right;
                popCaesar.IsOpen = true;
            }
            if (e.Handled == !Validations.IsInteger(e.Text))
            {
                popCaesar.IsOpen = false;
            }
            e.Handled = !Validations.IsInteger(e.Text);
            base.OnPreviewTextInput(e); 
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //popCaesar.PlacementTarget = saveButton;
            //popCaesar.Placement = PlacementMode.Left;
            //helpBlock.Text = "Here is some text. <LineBreak/> Here is <LineBreak/> some <LineBreak/> more.";
            //popCaesar.IsOpen = true;
            try
            {
                if (saveButton.Content == "Sale")
                {
                    ticketDetailsList = new List<TicketDetails>();

                    for (int i = 0; i < ticketPurchageDetailsListView.Items.Count; i++)
                    {
                        ticketDetailsObj = new TicketDetails();
                        TicketDetails ticketDetailsListViewObj = (TicketDetails)ticketPurchageDetailsListView.Items[i];
                        ticketDetailsObj.BusAssingnPKId = ticketDetailsListViewObj.BusAssingnPKId;
                        ticketDetailsObj.BusNo = ticketDetailsListViewObj.BusNo;

                        ticketDetailsObj.BusType = ticketDetailsListViewObj.BusType;
                        //ticketDetailsObj.BusUniqueCode = ticketDetailsListViewObj.BusUniqueCode;

                        ticketDetailsObj.ClintAddress = clintAddressTextBox.Text;
                        ticketDetailsObj.ClintMobile = clintMobileTextBox.Text;
                        ticketDetailsObj.ClintName = clintNameTextBox.Text;


                        ticketDetailsObj.EntryDate = DateTime.Today;
                        if (genderMaleChq.IsChecked == true)
                        {
                            ticketDetailsObj.Gender = "Male";
                        }
                        if (genderFimaleChq.IsChecked == true)
                        {
                            ticketDetailsObj.Gender = "Female";
                        }
                        if (genderFimaleChq.IsChecked == false && genderMaleChq.IsChecked == false)
                        {
                            ticketDetailsObj.Gender = "N/A";
                        }
                        ticketDetailsObj.JournyDate = ticketDetailsListViewObj.JournyDate;
                        ticketDetailsObj.SeatNo = ticketDetailsListViewObj.SeatNo;
                        ticketDetailsObj.Sift = ticketDetailsListViewObj.Sift;
                        ticketDetailsObj.Status = "Sold";
                        ticketDetailsObj.TicketNo = ticketBookingNumberlable.Content.ToString();


                        if (totalAmountTextBox.Text == "")
                        {
                            ticketDetailsObj.TicketPrice = 0;
                        }
                        if (totalAmountTextBox.Text != "")
                        {
                            ticketDetailsObj.TicketPrice = Convert.ToInt32(totalAmountTextBox.Text);
                        }

                        if (paidAmountTextBox.Text == "")
                        {
                            ticketDetailsObj.TicketPricePaid = 0;
                        }
                        if (paidAmountTextBox.Text != "")
                        {
                            ticketDetailsObj.TicketPricePaid = Convert.ToInt32(paidAmountTextBox.Text);
                        }

                        if (dueAmountTextBox.Text == "")
                        {
                            ticketDetailsObj.TicketPriceDue = 0;
                        }
                        if (dueAmountTextBox.Text != "")
                        {
                            ticketDetailsObj.TicketPriceDue = Convert.ToInt32(dueAmountTextBox.Text);
                        }
                        if (discountTextBox.Text == "")
                        {
                            ticketDetailsObj.TicketPriceDiscount = 0;
                        }
                        if (discountTextBox.Text != "")
                        {
                            ticketDetailsObj.TicketPriceDiscount = Convert.ToInt32(discountTextBox.Text);
                        }
                        ticketDetailsObj.Time = ticketDetailsListViewObj.Time;
                        ticketDetailsObj.ToJourny = toJournyCombobox.Text;
                        ticketDetailsObj.FromJourny = fromJournyTextbox.Text;
                        ticketDetailsObj.Age = Convert.ToInt32(ageTextBox.Text);
                        ticketDetailsObj.UserID = (int)anUser.UserId;
                        ticketDetailsObj.UserName = anUser.UserName;
                        ticketDetailsList.Add(ticketDetailsObj);
                    }


                    if (ticketDetailsList.Count != 0)
                    {
                        ticketStatusManagerObj.SaveTicketDetails(ticketDetailsList);
                        //ticketStatusManagerObj.UpdateTicketStatus(ticketDetailsList);
                        MessageBox.Show("Purchase Successful Insert ", "Successful Entry");
                        LoadTicketStatus(ticketDetailsObj.BusAssingnPKId);
                        LoadticketNo();
                        ClearAll();

                        string info = "Ticket Issue Successfull , Are you want to print Ticket ?";
                        MessageBoxResult result = MessageBox.Show(info, "Successful Entry", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            List<TicketDetails> _TicketDetailsListPrintTicket = new List<TicketDetails>();

                            RTicketPrint _rTicketPrintreportObj = new RTicketPrint();
                            List<RTicketPrint> _RTicketPrintReportList = new List<RTicketPrint>();

                            _TicketDetailsListPrintTicket = ticketStatusManagerObj.TicketListByTicketNo(ticketDetailsObj.TicketNo);

                            /////Site NO. in a string
                            List<string> strList = new List<string>();
                            foreach (var item in _TicketDetailsListPrintTicket)
                            {
                                strList.Add(item.SeatNo);
                            }
                            strList.Sort();
                            StringBuilder builder = new StringBuilder();
                            foreach (string item in strList)
                            {
                                builder.Append(item).Append(",");
                            }
                            /////Site NO. in a string

                            foreach (TicketDetails p in _TicketDetailsListPrintTicket)
                            {

                                _rTicketPrintreportObj.Id = p.Id;
                                _rTicketPrintreportObj.ClintMobile = p.ClintMobile;
                                _rTicketPrintreportObj.ClintName = p.ClintName;
                                _rTicketPrintreportObj.ClintAddress = p.ClintAddress;
                                _rTicketPrintreportObj.Gender = p.Gender;
                                _rTicketPrintreportObj.Age = p.Age;
                                _rTicketPrintreportObj.BusNo = p.BusNo;
                                _rTicketPrintreportObj.BusType = p.BusType;
                                _rTicketPrintreportObj.Sift = p.Sift;
                                _rTicketPrintreportObj.Status = p.Status;
                                _rTicketPrintreportObj.SeatNo = builder.ToString(); 
                                _rTicketPrintreportObj.EntryDate = (DateTime)p.EntryDate;
                                _rTicketPrintreportObj.TicketPrice = (int)p.TicketPrice;
                                _rTicketPrintreportObj.TotalTicketPrice = (int)p.TotalTicketPrice;
                                _rTicketPrintreportObj.TicketPricePaid = (int)p.TicketPricePaid;
                                _rTicketPrintreportObj.TicketPriceDiscount = (int)p.TicketPriceDiscount;
                                _rTicketPrintreportObj.TicketPriceDue = (int)p.TicketPriceDue;
                                _rTicketPrintreportObj.TicketNo = p.TicketNo;
                                _rTicketPrintreportObj.BookingNo = p.BookingNo;
                                _rTicketPrintreportObj.JournyDate = (DateTime)p.JournyDate;
                                _rTicketPrintreportObj.FromJourny = p.FromJourny;
                                _rTicketPrintreportObj.ToJourny = p.ToJourny;
                                _rTicketPrintreportObj.ReportingTime = p.ReportingTime;
                                _rTicketPrintreportObj.Time = p.Time;
                                _rTicketPrintreportObj.UserName = p.UserName;
                                _rTicketPrintreportObj.UserID = (int)p.UserID;
                                _RTicketPrintReportList.Add(_rTicketPrintreportObj);
                                if (_RTicketPrintReportList.Count == 1)
                                {
                                    break;
                                }
                            }

                            if (_RTicketPrintReportList.Count > 0)
                            {
                                RTicketPrintReport Report = new RTicketPrintReport();
                                ReportUtility.Display_report(Report, _RTicketPrintReportList, this);
                            }
                            else
                            {
                                MessageBox.Show("Don't have any records.", "Employee Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            }



                        }
                        //else
                        //{
                        //    MessageBox.Show("Please Follow the Required Process", "Follow the System");
                        //}

                    }
                }
                    if (saveButton.Content == "Booking")
                    {
                        ticketDetailsList = new List<TicketDetails>();

                        for (int i = 0; i < ticketPurchageDetailsListView.Items.Count; i++)
                        {
                            ticketDetailsObj = new TicketDetails();
                            TicketDetails ticketDetailsListViewObj = (TicketDetails)ticketPurchageDetailsListView.Items[i];
                            ticketDetailsObj.BusAssingnPKId = ticketDetailsListViewObj.BusAssingnPKId;
                            ticketDetailsObj.BusNo = ticketDetailsListViewObj.BusNo;

                            ticketDetailsObj.BusType = ticketDetailsListViewObj.BusType;
                            //ticketDetailsObj.BusUniqueCode = ticketDetailsListViewObj.BusUniqueCode;

                            ticketDetailsObj.ClintAddress = clintAddressTextBox.Text;
                            ticketDetailsObj.ClintMobile = clintMobileTextBox.Text;
                            ticketDetailsObj.ClintName = clintNameTextBox.Text;


                            ticketDetailsObj.EntryDate = DateTime.Today;
                            if (genderFimaleChq.IsChecked == true)
                            {
                                ticketDetailsObj.Gender = "Male";
                            }
                            if (genderMaleChq.IsChecked == true)
                            {
                                ticketDetailsObj.Gender = "Female";
                            }
                            if (genderFimaleChq.IsChecked == false && genderMaleChq.IsChecked == false)
                            {
                                ticketDetailsObj.Gender = "N/A";
                            }
                            ticketDetailsObj.JournyDate = ticketDetailsListViewObj.JournyDate;
                            ticketDetailsObj.SeatNo = ticketDetailsListViewObj.SeatNo;
                            ticketDetailsObj.Sift = ticketDetailsListViewObj.Sift;
                            ticketDetailsObj.Status = "Booked";
                            ticketDetailsObj.TicketNo = ticketBookingNumberlable.Content.ToString();

                            if (totalAmountTextBox.Text == "")
                            {
                                ticketDetailsObj.TicketPrice = 0;
                            }
                            if (totalAmountTextBox.Text != "")
                            {
                                ticketDetailsObj.TicketPrice = Convert.ToInt32(totalAmountTextBox.Text);
                            }

                            if (paidAmountTextBox.Text == "")
                            {
                                ticketDetailsObj.TicketPricePaid = 0;
                            }
                            if (paidAmountTextBox.Text != "")
                            {
                                ticketDetailsObj.TicketPricePaid = Convert.ToInt32(paidAmountTextBox.Text);
                            }

                            if (dueAmountTextBox.Text == "")
                            {
                                ticketDetailsObj.TicketPriceDue = 0;
                            }
                            if (dueAmountTextBox.Text != "")
                            {
                                ticketDetailsObj.TicketPriceDue = Convert.ToInt32(dueAmountTextBox.Text);
                            }
                            
                            if (discountTextBox.Text == "")
                            {
                                ticketDetailsObj.TicketPriceDiscount = 0;
                            }
                            if (discountTextBox.Text != "")
                            {
                                ticketDetailsObj.TicketPriceDiscount = Convert.ToInt32(discountTextBox.Text);
                            }
                            ticketDetailsObj.Time = ticketDetailsListViewObj.Time;
                            ticketDetailsObj.ToJourny = toJournyCombobox.Text;
                            ticketDetailsObj.FromJourny = fromJournyTextbox.Text;
                            ticketDetailsObj.Age = Convert.ToInt32(ageTextBox.Text);

                            ticketDetailsObj.UserID = (int)anUser.UserId;
                            ticketDetailsObj.UserName = anUser.UserName;

                            ticketDetailsList.Add(ticketDetailsObj);
                        }
                        ticketStatusManagerObj.SaveTicketDetails(ticketDetailsList);
                        //ticketStatusManagerObj.UpdateTicketStatus(ticketDetailsList);
                        MessageBox.Show("Booking Successful Compite ", "Successful Booking");
                        LoadTicketStatus(ticketDetailsObj.BusAssingnPKId);
                        LoadticketNo();
                        ClearAll();
                    }
                
            }
            catch (FormatException)
            {
                if (totalAmountTextBox.Text == "")
                {
                    popCaesar.PlacementTarget = totalAmountTextBox;
                    popCaesar.Placement = PlacementMode.Right;
                    helpBlock.Text = "please Fill the Amount";
                    popCaesar.IsOpen = true;
                }
                else if (seatFareTextnox.Text == "")
                {
                    popCaesar.PlacementTarget = seatFareTextnox;
                    popCaesar.Placement = PlacementMode.Right;
                    helpBlock.Text = "Please fill Up the Seat Fare";
                    popCaesar.IsOpen = true;
                }

            }
        }
        private void ClearAll()
        {
            ticketPurchageDetailsListView.Items.Clear();
            toJournyCombobox.SelectedIndex = -1;

            totalAmountTextBox.Text= "";
            paidAmountTextBox.Text= "";
            dueAmountTextBox.Text= "";
            discountTextBox.Text= "";
            clintMobileTextBox.Text= "";
            clintNameTextBox.Text= "";
            clintAddressTextBox.Text= "";
            genderFimaleChq.IsChecked = false;
            genderFimaleChq.IsChecked = false;
        }
        private void LoadTicketStatus(int p)
        {
            int PkID = p;
            ticketinglistStatus = new List<Ticketing>();
            ticketinglistStatus = ticketStatusManagerObj.GetTicketStatusID(PkID);
            if (ticketinglistStatus.Count == 1)
            {
                foreach (var item in ticketinglistStatus)
                {
                    Date.Content = Convert.ToString(item.DateOfDiparture.Date);
                    Time.Content = item.TimeOfDiparture;
                    BusNo.Content = item.BusNumber;
                    BusType.Content = item.Type;
                    Sift.Content = item.Sift;
                    BusAssingnPKIdLable.Content = item.ID;
                    //BusUniqueCodeLable.Content = item.UniqueId;
                    ///// A1
                    if (item.A1 != null)
                    {
                        if (item.A1 == "Sold")
                        {
                            A1.Background = Brushes.Green;
                        }
                        if (item.A1 == "Booked")
                        {
                            A1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        A1.Background = Brushes.LightGray;
                    }
                    ///// A2
                    if (item.A2 != null)
                    {
                        if (item.A2 == "Sold")
                        {
                            A2.Background = Brushes.Green;

                        }
                        if (item.A2 == "Booked")
                        {
                            A2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A2.Background = Brushes.LightGray;
                    }
                    ///// A3
                    if (item.A3 != null)
                    {
                        if (item.A3 == "Sold")
                        {
                            A3.Background = Brushes.Green;

                        }
                        if (item.A3 == "Booked")
                        {
                            A3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A3.Background = Brushes.LightGray;
                    }
                    ///// A4
                    if (item.A4 != null)
                    {
                        if (item.A4 == "Sold")
                        {
                            A4.Background = Brushes.Green;

                        }
                        if (item.A4 == "Booked")
                        {
                            A4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        A4.Background = Brushes.LightGray;
                    }

                    ///// B1
                    if (item.B1 != null)
                    {
                        if (item.B1 == "Sold")
                        {
                            B1.Background = Brushes.Green;
                        }
                        if (item.B1 == "Booked")
                        {
                            B1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        B1.Background = Brushes.LightGray;
                    }
                    ///// B2
                    if (item.B2 != null)
                    {
                        if (item.B2 == "Sold")
                        {
                            B2.Background = Brushes.Green;

                        }
                        if (item.B2 == "Booked")
                        {
                            B2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B2.Background = Brushes.LightGray;
                    }
                    ///// B3
                    if (item.B3 != null)
                    {
                        if (item.B3 == "Sold")
                        {
                            B3.Background = Brushes.Green;

                        }
                        if (item.B3 == "Booked")
                        {
                            B3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B3.Background = Brushes.LightGray;
                    }
                    ///// B4
                    if (item.B4 != null)
                    {
                        if (item.B4 == "Sold")
                        {
                            B4.Background = Brushes.Green;

                        }
                        if (item.B4 == "Booked")
                        {
                            B4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        B4.Background = Brushes.LightGray;
                    }
                    ///// C1
                    if (item.C1 != null)
                    {
                        if (item.C1 == "Sold")
                        {
                            C1.Background = Brushes.Green;
                        }
                        if (item.C1 == "Booked")
                        {
                            C1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        C1.Background = Brushes.LightGray;
                    }
                    ///// C2
                    if (item.C2 != null)
                    {
                        if (item.C2 == "Sold")
                        {
                            C2.Background = Brushes.Green;

                        }
                        if (item.C2 == "Booked")
                        {
                            C2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C2.Background = Brushes.LightGray;
                    }
                    ///// C3
                    if (item.C3 != null)
                    {
                        if (item.C3 == "Sold")
                        {
                            C3.Background = Brushes.Green;

                        }
                        if (item.C3 == "Booked")
                        {
                            C3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C3.Background = Brushes.LightGray;
                    }
                    ///// C4
                    if (item.C4 != null)
                    {
                        if (item.C4 == "Sold")
                        {
                            C4.Background = Brushes.Green;

                        }
                        if (item.C4 == "Booked")
                        {
                            C4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        C4.Background = Brushes.LightGray;
                    }
                    ///// D1
                    if (item.D1 != null)
                    {
                        if (item.D1 == "Sold")
                        {
                            D1.Background = Brushes.Green;
                        }
                        if (item.D1 == "Booked")
                        {
                            D1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        D1.Background = Brushes.LightGray;
                    }
                    ///// D2
                    if (item.D2 != null)
                    {
                        if (item.D2 == "Sold")
                        {
                            D2.Background = Brushes.Green;

                        }
                        if (item.D2 == "Booked")
                        {
                            D2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D2.Background = Brushes.LightGray;
                    }
                    ///// D3
                    if (item.D3 != null)
                    {
                        if (item.D3 == "Sold")
                        {
                            D3.Background = Brushes.Green;

                        }
                        if (item.D3 == "Booked")
                        {
                            D3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D3.Background = Brushes.LightGray;
                    }
                    ///// D4
                    if (item.D4 != null)
                    {
                        if (item.D4 == "Sold")
                        {
                            D4.Background = Brushes.Green;

                        }
                        if (item.D4 == "Booked")
                        {
                            D4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        D4.Background = Brushes.LightGray;
                    }
                    ///// E1
                    if (item.E1 != null)
                    {
                        if (item.E1 == "Sold")
                        {
                            E1.Background = Brushes.Green;
                        }
                        if (item.E1 == "Booked")
                        {
                            E1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        E1.Background = Brushes.LightGray;
                    }
                    ///// E2
                    if (item.E2 != null)
                    {
                        if (item.E2 == "Sold")
                        {
                            E2.Background = Brushes.Green;

                        }
                        if (item.E2 == "Booked")
                        {
                            E2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E2.Background = Brushes.LightGray;
                    }
                    ///// E3
                    if (item.E3 != null)
                    {
                        if (item.E3 == "Sold")
                        {
                            E3.Background = Brushes.Green;

                        }
                        if (item.E3 == "Booked")
                        {
                            E3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E3.Background = Brushes.LightGray;
                    }
                    ///// E4
                    if (item.E4 != null)
                    {
                        if (item.E4 == "Sold")
                        {
                            E4.Background = Brushes.Green;

                        }
                        if (item.E4 == "Booked")
                        {
                            E4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        E4.Background = Brushes.LightGray;
                    }
                    ///// F1
                    if (item.F1 != null)
                    {
                        if (item.F1 == "Sold")
                        {
                            F1.Background = Brushes.Green;
                        }
                        if (item.F1 == "Booked")
                        {
                            F1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        F1.Background = Brushes.LightGray;
                    }
                    ///// F2
                    if (item.F2 != null)
                    {
                        if (item.F2 == "Sold")
                        {
                            F2.Background = Brushes.Green;

                        }
                        if (item.F2 == "Booked")
                        {
                            F2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F2.Background = Brushes.LightGray;
                    }
                    ///// F3
                    if (item.F3 != null)
                    {
                        if (item.F3 == "Sold")
                        {
                            F3.Background = Brushes.Green;

                        }
                        if (item.F3 == "Booked")
                        {
                            F3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F3.Background = Brushes.LightGray;
                    }
                    ///// F4
                    if (item.F4 != null)
                    {
                        if (item.F4 == "Sold")
                        {
                            F4.Background = Brushes.Green;

                        }
                        if (item.F4 == "Booked")
                        {
                            F4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        F4.Background = Brushes.LightGray;
                    }
                    ///// G1
                    if (item.G1 != null)
                    {
                        if (item.G1 == "Sold")
                        {
                            G1.Background = Brushes.Green;
                        }
                        if (item.G1 == "Booked")
                        {
                            G1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        G1.Background = Brushes.LightGray;
                    }
                    ///// G2
                    if (item.G2 != null)
                    {
                        if (item.G2 == "Sold")
                        {
                            G2.Background = Brushes.Green;
                        }
                        if (item.G2 == "Booked")
                        {
                            G2.Background = Brushes.Yellow;

                        }
                    }
                    else
                    {
                        G2.Background = Brushes.LightGray;
                    }
                    ///// G3
                    if (item.G3 != null)
                    {
                        if (item.G3 == "Sold")
                        {
                            G3.Background = Brushes.Green;

                        }
                        if (item.G3 == "Booked")
                        {
                            G3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        G3.Background = Brushes.LightGray;
                    }
                    ///// G4
                    if (item.G4 != null)
                    {
                        if (item.G4 == "Sold")
                        {
                            G4.Background = Brushes.Green;

                        }
                        if (item.G4 == "Booked")
                        {
                            G4.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        G4.Background = Brushes.LightGray;
                    }
                    ///// H1
                    if (item.H1 != null)
                    {
                        if (item.H1 == "Sold")
                        {
                            H1.Background = Brushes.Green;
                        }
                        if (item.H1 == "Booked")
                        {
                            H1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        H1.Background = Brushes.LightGray;
                    }
                    ///// H2
                    if (item.H2 != null)
                    {
                        if (item.H2 == "Sold")
                        {
                            H2.Background = Brushes.Green;

                        }
                        if (item.H2 == "Booked")
                        {
                            H2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H2.Background = Brushes.LightGray;
                    }
                    ///// H3
                    if (item.H3 != null)
                    {
                        if (item.H3 == "Sold")
                        {
                            H3.Background = Brushes.Green;

                        }
                        if (item.H3 == "Booked")
                        {
                            H3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H3.Background = Brushes.LightGray;
                    }
                    ///// H4
                    if (item.H4 != null)
                    {
                        if (item.H4 == "Sold")
                        {
                            H4.Background = Brushes.Green;

                        }
                        if (item.H4 == "Booked")
                        {
                            H4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        H4.Background = Brushes.LightGray;
                    }
                    ///// I1
                    if (item.I1 != null)
                    {
                        if (item.I1 == "Sold")
                        {
                            I1.Background = Brushes.Green;
                        }
                        if (item.I1 == "Booked")
                        {
                            I1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        I1.Background = Brushes.LightGray;
                    }
                    ///// I2
                    if (item.I2 != null)
                    {
                        if (item.I2 == "Sold")
                        {
                            I2.Background = Brushes.Green;

                        }
                        if (item.I2 == "Booked")
                        {
                            I2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I2.Background = Brushes.LightGray;
                    }
                    ///// I3
                    if (item.I3 != null)
                    {
                        if (item.I3 == "Sold")
                        {
                            I3.Background = Brushes.Green;

                        }
                        if (item.I3 == "Booked")
                        {
                            I3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I3.Background = Brushes.LightGray;
                    }
                    ///// I4
                    if (item.I4 != null)
                    {
                        if (item.I4 == "Sold")
                        {
                            I4.Background = Brushes.Green;

                        }
                        if (item.I4 == "Booked")
                        {
                            I4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        I4.Background = Brushes.LightGray;
                    }
                    ///// J1
                    if (item.J1 != null)
                    {
                        if (item.J1 == "Sold")
                        {
                            J1.Background = Brushes.Green;
                        }
                        if (item.J1 == "Booked")
                        {
                            J1.Background = Brushes.Yellow;
                        }

                    }
                    else
                    {
                        J1.Background = Brushes.LightGray;
                    }
                    ///// J2
                    if (item.J2 != null)
                    {
                        if (item.J2 == "Sold")
                        {
                            J2.Background = Brushes.Green;

                        }
                        if (item.J2 == "Booked")
                        {
                            J2.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J2.Background = Brushes.LightGray;
                    }
                    ///// J3
                    if (item.J3 != null)
                    {
                        if (item.J3 == "Sold")
                        {
                            J3.Background = Brushes.Green;

                        }
                        if (item.J3 == "Booked")
                        {
                            J3.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J3.Background = Brushes.LightGray;
                    }
                    ///// J4
                    if (item.J4 != null)
                    {
                        if (item.J4 == "Sold")
                        {
                            J4.Background = Brushes.Green;

                        }
                        if (item.J4 == "Booked")
                        {
                            J4.Background = Brushes.Yellow;

                        }

                    }
                    else
                    {
                        J4.Background = Brushes.LightGray;
                    }

                }

            }
        }
        private void ShowWindow(string className)
        {
            bool isOpen = false;
            Window objWindowName = new Window();
            try
            {
                foreach (Window objWindow in Application.Current.Windows)
                {
                    string[] splitedNamespace = (objWindow.ToString()).Split('.');
                    string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];

                    if (aClassNameFromCollection == className)
                    {
                        isOpen = true;
                        objWindowName = objWindow;
                        break;
                    }
                }
                if (isOpen == false)
                {
                    #region SHOW DESIRED WINDOW
                    switch (className)
                    {
                        case "BusAssignUI":
                            BusAssignUI _busAssignUI = new BusAssignUI();
                            _busAssignUI.Owner = this;
                            _busAssignUI.Show();
                            break;
                    }
                    #endregion SHOW DESIRED WINDOW
                }
                if (isOpen)
                {
                    foreach (Window objWindow in Application.Current.Windows)
                    {
                        string[] splitedNamespace = (objWindow.ToString()).Split('.');
                        string aClassNameFromCollection = splitedNamespace[splitedNamespace.Length - 1];

                        if (aClassNameFromCollection == className)
                        {
                            objWindowName.WindowState = WindowState.Normal;
                            objWindowName.Activate();
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Occured While Showing Window.\n" + exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BusAssignMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow("BusAssignUI");
        }
        private void SaleChqBox_Checked(object sender, RoutedEventArgs e)
        {
            bookingChqBox.IsChecked = false;
            ReturnChqBox.IsChecked = false;
            saveButton.Content = "Sale";
            saveButton.IsEnabled = true;
            clearCountFild();
        }
        private void bookingChqBox_Checked(object sender, RoutedEventArgs e)
        {
            SaleChqBox.IsChecked = false;
            ReturnChqBox.IsChecked = false;
            saveButton.Content = "Booking";
            saveButton.IsEnabled = true;
            clearCountFild();
        }
        private void clearCountFild()
        {
            dueAmountTextBox.Text = "";
            paidAmountTextBox.Text = "";
            totalAmountTextBox.Text = "";
            discountTextBox.Text = "";
        }
        private void ReturnChqBox_Checked(object sender, RoutedEventArgs e)
        {
            bookingChqBox.IsChecked = false;
            SaleChqBox.IsChecked = false;
            saveButton.Content = "Return";
            saveButton.IsEnabled = true;
        }

        internal Menu GetAllBusAssignMainMenu()
        {
            return topManu;
        }

        private void SaleChqBox_Unchecked(object sender, RoutedEventArgs e)
        {
            saveButton.IsEnabled = false;
            SeatStatusView();
            ticketPurchageDetailsListView.Items.Clear();
        }

        private void bookingChqBox_Unchecked(object sender, RoutedEventArgs e)
        {
            saveButton.IsEnabled = false;
            SeatStatusView();
            ticketPurchageDetailsListView.Items.Clear();
        }

        private void ReturnChqBox_Unchecked(object sender, RoutedEventArgs e)
        {
            saveButton.IsEnabled = false;
        }

        private void genderMaleChq_Checked(object sender, RoutedEventArgs e)
        {
            genderFimaleChq.IsChecked = false;
        }

        private void genderFimaleChq_Checked(object sender, RoutedEventArgs e)
        {
            genderMaleChq.IsChecked = false;
        }

        private void BookingToPurchageContextMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SoldAndBookingListView.SelectedIndex > -1)
                {
                    string TicketNo = ((TicketDetails)SoldAndBookingListView.SelectedItem).TicketNo;
                    List<TicketDetails> _ticketDetailsListPrintTicket = new List<TicketDetails>();
                    _ticketDetailsListPrintTicket = ticketStatusManagerObj.TicketListByTicketNo(TicketNo);
                    ticketPurchageDetailsListView.Items.Clear();
                    foreach (TicketDetails p in _ticketDetailsListPrintTicket)
                    {
                        ticketBookingNumberlable.Content = p.TicketNo;
                        clintNameTextBox.Text = p.ClintName;
                        clintMobileTextBox.Text = p.ClintMobile;
                        clintAddressTextBox.Text = p.ClintAddress;
                        ageTextBox.Text = p.Age.ToString();
                        fromJournyTextbox.Text = p.FromJourny;
                        toJournyCombobox.Text = p.ToJourny;

                        seatFareTextnox.Text =  p.TicketPrice.ToString();
                        totalAmountTextBox.Text = p.TotalTicketPrice.ToString();
                        dueAmountTextBox.Text =  p.TicketPriceDue.ToString();
                        paidAmountTextBox.Text = p.TicketPricePaid.ToString();
                        break;
                    }
                    foreach (TicketDetails TicketDetails in _ticketDetailsListPrintTicket)
                    {
                        ticketPurchageDetailsListView.Items.Add(TicketDetails);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }

}


