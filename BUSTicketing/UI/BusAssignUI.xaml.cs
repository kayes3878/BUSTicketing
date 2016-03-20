using BLL;
using ENTITY;
using ENTITY.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BUSTicketing.UI
{
    /// <summary>
    /// Interaction logic for BusAssignUI.xaml
    /// </summary>
    public partial class BusAssignUI : Window
    {
        PreSetup _ObjPreSetup = new PreSetup();
        PreSetupManeger _preSetupManegerObj = new PreSetupManeger();
        TicketStatusManager ticketStatusManagerObj = new TicketStatusManager();
        List<Ticketing> allAssignedBusList;
        public BusAssignUI()
        {
            InitializeComponent();
            DepartureDateDatepicker.SelectedDate = DateTime.Today;
            LoadBusTypeComBox();
            LoadSiftComboBox();
            LoadTicketCounterCombobox();
            LoadTimeCmbBox();
            LoadbusNumberComboBox();
            LoadAssignedBusListView();
            LoadlastStopCmbBox();
            LoadReportingTimeCmbBox();

        }

        private void LoadReportingTimeCmbBox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            reportintgTimeCombobox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllTime();
            foreach (PreSetup preset in presetupList)
            {
                reportintgTimeCombobox.ItemsSource = presetupList;
            }
            reportintgTimeCombobox.DisplayMemberPath = "TimeOfDiparture";
        }

        private void LoadlastStopCmbBox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            lastStopCmbBox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllCounterName();
            foreach (PreSetup preset in presetupList)
            {
                lastStopCmbBox.ItemsSource = presetupList;
            }
            lastStopCmbBox.DisplayMemberPath = "CounterName";
        }

      
        private void LoadAssignedBusListView()
        {
            //DateTime dateOfDeparture = (DateTime)clnd.SelectedDate;
            allAssignedBusList = new List<Ticketing>();

            allAssignedBusList = ticketStatusManagerObj.GetAllAssignedBus();
            if (allAssignedBusList.Count > 0)
            {
                AllBusAssignListView.Items.Clear();
                foreach (var item in allAssignedBusList)
                {
                    AllBusAssignListView.Items.Add(item);
                }
            }
        }

        private void LoadbusNumberComboBox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            busNumberComboBox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllbusNumber();
            foreach (PreSetup preset in presetupList)
            {
                busNumberComboBox.ItemsSource = presetupList;
            }
            busNumberComboBox.DisplayMemberPath = "BusNumber";
        }

        private void LoadTimeCmbBox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            TimeCmbBox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllTime();
            foreach (PreSetup preset in presetupList)
            {
                TimeCmbBox.ItemsSource = presetupList;
            }
            TimeCmbBox.DisplayMemberPath = "TimeOfDiparture";
        }

        private void LoadTicketCounterCombobox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            TicketCounterCombobox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllCounterName();
            foreach (PreSetup preset in presetupList)
            {
                TicketCounterCombobox.ItemsSource = presetupList;
            }
            TicketCounterCombobox.DisplayMemberPath = "CounterName";
        }

        private void LoadSiftComboBox()
        {
            List<PreSetup> presetupList = new List<PreSetup>();
            SiftComboBox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllSift();
            foreach (PreSetup preset in presetupList)
            {
                SiftComboBox.ItemsSource = presetupList;
            }
            SiftComboBox.DisplayMemberPath = "Sift";
        }

        private void LoadBusTypeComBox()
        {

            List<PreSetup> presetupList = new List<PreSetup>();
            BusTypeComBox.Items.Clear();
            presetupList = _preSetupManegerObj.GetAllBusType();
            foreach (PreSetup preset in presetupList)
            {
                BusTypeComBox.ItemsSource = presetupList;
            }
            BusTypeComBox.DisplayMemberPath = "BUSType";
        }


        private void savebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticketing TicketingObj = new Ticketing();
                TicketingObj.BusNumber = busNumberComboBox.Text;
                TicketingObj.DateOfDiparture = (DateTime)DepartureDateDatepicker.SelectedDate;
                TicketingObj.Sift = SiftComboBox.Text;
                TicketingObj.TimeOfDiparture = TimeCmbBox.Text;
                TicketingObj.Type = BusTypeComBox.Text;
                //TicketingObj.UniqueId = UniqueCodeTextbox.Text;
                TicketingObj.ReportingTime = reportintgTimeCombobox.Text;
                TicketingObj.CounterName = TicketCounterCombobox.Text;
                TicketingObj.LastStop = lastStopCmbBox.Text;

                TicketingObj.TicketPrice = Convert.ToInt32(ticketPriceTextBox.Text);
                _preSetupManegerObj.SaveBusInfoForAssign(TicketingObj);
                MessageBox.Show("Bus Assign SuccessFull","OK");
                LoadAssignedBusListView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void ticketPriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           e.Handled = !Validations.IsInteger(e.Text);  
           base.OnPreviewTextInput(e);  
        }

 
    }
}
