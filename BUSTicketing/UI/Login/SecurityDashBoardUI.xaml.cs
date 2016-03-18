using BLL.LoginBLL;
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

namespace BUSTicketing.UI.Login
{
    /// <summary>
    /// Interaction logic for SecurityDashBoardUI.xaml
    /// </summary>
    public partial class SecurityDashBoardUI : Window
    {

        private BMenuPermissionManager objBMenuPermission = new BMenuPermissionManager();
        public SecurityDashBoardUI()
        {
            InitializeComponent();
        }

        public SecurityDashBoardUI(long userGroupId)
            : this()
        {
            LoadMenuInTree(userGroupId);
        }

        private void LoadMenuInTree(long userGroupId)
        {
            try
            {
                foreach (MenuItem it in securityMenu.Items)
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
        private void mnuGroupSetup_Click(object sender, RoutedEventArgs e)
        {
            GroupSetupUI groupSetup = new GroupSetupUI();
            groupSetup.Show();
        }
        private void mnuUserSetup_Click(object sender, RoutedEventArgs e)
        {
            UserSetUpUI userSetobj = new UserSetUpUI();
            userSetobj.Show();
        }
        private void mnuModuleSetup_Click(object sender, RoutedEventArgs e)
        {
            ModulePermissionUI modulePermissionObj = new ModulePermissionUI();
            modulePermissionObj.Show();
        }

        private void mnuMenuSetup_Click(object sender, RoutedEventArgs e)
        {
            MenuPermissionUI menuPermissionObj = new MenuPermissionUI();
            menuPermissionObj.Show();
        }

        internal Menu GetAllSecurityMenu()
        {
            return securityMenu;
        }

        private void viewLog_Click(object sender, RoutedEventArgs e)
        {
            //Window1 log = new Window1();
            //log.Show();
        }
    }
}
