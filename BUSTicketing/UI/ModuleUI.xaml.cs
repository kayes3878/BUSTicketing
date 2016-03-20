using BLL.LoginBLL;
using BUSTicketing.UI.Login;
using ENTITY.Login;
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
    /// Interaction logic for ModuleUI.xaml
    /// </summary>
    public partial class ModuleUI : Window
    {

        EUser anUser = new EUser();
        
       

        //private bool _Trial;

        public ModuleUI()
        {
            InitializeComponent();
        }



        public ModuleUI(EUser objUser)
            : this()
        {
            anUser = objUser;
            
            
            if (objUser.UserGroupName != "Super Admin")
            {
                dashBoardTicket.IsEnabled = false;
                dashBoardTicket.Visibility = Visibility.Hidden;
                dashBoardSecurityButton.IsEnabled = false;
                dashBoardSecurityButton.Visibility = Visibility.Hidden;

                LoadUserRoleControl();
            }
        }

        private void LoadUserRoleControl()
        {
            try
            {
                BSModulePermissionManager objBModule = new BSModulePermissionManager();
                List<ESModulePermission> listModule = objBModule.GetPermittedModule(anUser.UserGroupId);
                foreach (var item in listModule)
                {
                    if (item.ModuleName == "Ticketing")
                    {
                        dashBoardTicket.IsEnabled = true;
                        dashBoardTicket.Visibility = Visibility.Visible;
                    }
                    else if (item.ModuleName == "Security")
                    {
                        dashBoardSecurityButton.IsEnabled = true;
                        dashBoardSecurityButton.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        private void dashBoardSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            SecurityDashBoardUI securityDashBoard;
            if (anUser.UserGroupName == "Super Admin")
            {
                securityDashBoard = new SecurityDashBoardUI();
            }
            else
            {
                securityDashBoard = new SecurityDashBoardUI(anUser.UserGroupId);
            }
            securityDashBoard.ShowDialog();
        }

        private void dashBoardHospitalButton_Click(object sender, RoutedEventArgs e)
        {
            TicketingUI TicketingDashBoard;
            if (anUser.UserGroupName == "Super Admin")
            {
                TicketingDashBoard = new TicketingUI(anUser);
            }
            else
            {
                TicketingDashBoard = new TicketingUI(anUser);
            }
            TicketingDashBoard.ShowDialog();
        }

        private void LoginExitbuttonClick(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }




        
    }
}
