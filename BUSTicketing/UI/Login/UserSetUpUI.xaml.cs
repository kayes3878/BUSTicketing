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
    /// Interaction logic for UserSetUpUI.xaml
    /// </summary>
    public partial class UserSetUpUI : Window
    {
        private BSUserManager _aBsUserManager = new BSUserManager();
        private long userIdforModify = 0;

        public UserSetUpUI()
        {
            InitializeComponent();
            PopulateUserList();
            PopulateUserGroupCombo();
        }

        private void PopulateUserList()
        {
            try
            {
                lvUser.ItemsSource = _aBsUserManager.GetAllUser();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Retrieving Information.", "Modify User", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void PopulateUserGroupCombo()
        {
            try
            {
                BSUserGroupManager aBsUserGroup = new BSUserGroupManager();
                cmbUserGroup.ItemsSource = aBsUserGroup.GetAllUserGroup();
                cmbUserGroup.DisplayMemberPath = "GroupName";
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading User Group Name.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }



        private void SaveOperationofUser()
        {
            bool stat = false;
            if (_aBsUserManager.DoesExistUserinSaveMode(txtUserName.Text.Trim()) == false)
            {
                ESUser anUser = new ESUser();
                anUser.UserName = txtUserName.Text.Trim();
                anUser.UserPassword = txtPassword.Password;
                anUser.UserGroupId = (cmbUserGroup.SelectedItem as ESUserGroup).Id;
                stat = _aBsUserManager.SaveUserInfo(anUser);
                if (stat)
                {
                    MessageBox.Show("User Info has been Saved.", "User Setup", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    ResetUser();
                }
            }
            else
            {
                MessageBox.Show("User Already Exist.", "User Setup", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateOperationofUser()
        {
            bool stat = false;
            if (_aBsUserManager.DoesExistUserinUpdateMode(txtUserName.Text.Trim(), userIdforModify) == false)
            {
                ESUser anUser = new ESUser();
                anUser.UserId = userIdforModify;
                anUser.UserName = txtUserName.Text.Trim();
                anUser.UserPassword = txtPassword.Password;
                anUser.UserGroupId = (cmbUserGroup.SelectedItem as ESUserGroup).Id;
                stat = _aBsUserManager.UpdateUserInfo(anUser);
                if (stat)
                {
                    MessageBox.Show("User Info has been Updated.", "User Setup", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    ResetUser();
                }
            }
            else
            {
                MessageBox.Show("User Already Exist.", "User Setup", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool CheckFieldofUser()
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter User Name.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Password == string.Empty)
            {
                MessageBox.Show("Please Enter Password.", "User Setup", MessageBoxButton.OK, MessageBoxImage.Information);
                txtPassword.Focus();
                return false;
            }
            if (txtConfirmPass.Password == string.Empty)
            {
                MessageBox.Show("Please Enter Confirm Password.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                txtConfirmPass.Focus();
                return false;
            }
            if (txtPassword.Password != txtConfirmPass.Password)
            {
                MessageBox.Show("Password and Confirm Password Must be Same.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                txtConfirmPass.Focus();
                return false;
            }
            if (cmbUserGroup.Text == string.Empty)
            {
                MessageBox.Show("Please Select User Group.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                cmbUserGroup.Focus();
                return false;
            }
            return true;
        }

        private void BtnResetUserClick(object sender, RoutedEventArgs e)
        {
            ResetUser();
        }

        private void ResetUser()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtConfirmPass.Password = string.Empty;
            btnAddUser.Content = "Add";
            PopulateUserGroupCombo();
            PopulateUserList();
        }

        private void EditUserClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUser.SelectedIndex > -1)
                {
                    ESUser anEUser = lvUser.SelectedItem as ESUser;
                    userIdforModify = anEUser.UserId;
                    txtUserName.Text = anEUser.UserName;
                    txtPassword.Password = anEUser.UserPassword;
                    txtConfirmPass.Password = anEUser.UserPassword;
                    cmbUserGroup.Text = anEUser.UserGroupName;
                    btnAddUser.Content = "Modify";
                }
                else
                {
                    MessageBox.Show("Select an User First.", "Modify User", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Updating.", "Modify User", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void RemoveUserClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUser.SelectedIndex > -1)
                {
                    if (
                        MessageBox.Show("Are you sure want to Delete the Record?", "Confirmation",
                                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        bool stat = false;
                        ESUser anEUser = lvUser.SelectedItem as ESUser;
                        stat = _aBsUserManager.DeleteUser(anEUser.UserId);
                        if (stat)
                        {
                            MessageBox.Show("user Information has been Deleted.", "Modify User", MessageBoxButton.OK,
                                            MessageBoxImage.Information);
                            ResetUser();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select an User First.", "Modify User", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Deletion.", "Modify User", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofUser())
                {
                    if (btnAddUser.Content.ToString() == "Add")
                    {
                        SaveOperationofUser();
                    }
                    else if (btnAddUser.Content.ToString() == "Modify")
                    {
                        UpdateOperationofUser();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Storing Information.", "User Setup", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
