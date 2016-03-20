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
using System.Windows.Threading;

namespace BUSTicketing.UI
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginUI : Window
    {
        public delegate void ReadyToShowDelegate(object sender, EventArgs args);
        public event ReadyToShowDelegate ReadyToShow;
        private DispatcherTimer timer;
        private BUserManager _userManagerObj = new BUserManager();

        public LoginUI()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            txtUserName.Focus();
        }

       

      
        private bool CheckLoginField()
        {
            if (txtUserName.Text == String.Empty)
            {
                MessageBox.Show("Please type user name.", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Password == String.Empty)
            {
                MessageBox.Show("Please type user name.", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                txtUserName.Focus();
                return false;
            }
            return true;
        }
        private void LoginGoButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckLoginField())
                {
                    EUser anUser = new EUser
                    {
                        UserName = txtUserName.Text.Trim(),
                        UserPassword = txtPassword.Password
                    };
                    if (_userManagerObj.DoesExistUserinLoginMode(anUser) == true)
                    {
                        long groupId = _userManagerObj.GetAllInfoforSingleUser(anUser).UserGroupId;
                        ModuleUI dashBoardObj;
                        dashBoardObj = new ModuleUI(anUser);
                        dashBoardObj.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please retype User Name and Password correctly", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show("User login error" + exception.Message, "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LoginExitbuttonClick(object sender, RoutedEventArgs e)
        {
            //  this.Close();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            if (ReadyToShow != null)
            {
                ReadyToShow(this, null);
            }
        }
    }
}
