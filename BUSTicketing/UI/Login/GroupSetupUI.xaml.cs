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
    /// Interaction logic for GroupSetupUI.xaml
    /// </summary>
    public partial class GroupSetupUI : Window
    {
        BSUserGroupManager _aBuserGroup = new BSUserGroupManager();
        long UserGroupIdModify = 0;
        private string caption = "User Group";
        public GroupSetupUI()
        {
            InitializeComponent();
            txtUserGroupName.Text = string.Empty;
            btnAddUserGroup.Content = "Add";
            PopulateUserGroupList();
        }
        private void PopulateUserGroupList()
        {
            try
            {
                lvUserGroup.ItemsSource = _aBuserGroup.GetAllUserGroup();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem Occur While Retrieving user Group Information." + exception.Message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnAddUserGroupClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofUserGroup())
                {
                    if (btnAddUserGroup.Content.ToString() == "Add")
                    {
                        SaveOperationofUserGroup();
                        PopulateUserGroupList();
                    }
                    if (btnAddUserGroup.Content.ToString() == "Modify")
                    {
                        UpdateOperationofUserGroup();
                        PopulateUserGroupList();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Storing Information.", caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateOperationofUserGroup()
        {
            bool stat = false;
            if (_aBuserGroup.DoesExistGroupinUpdateMode(txtUserGroupName.Text.Trim(), UserGroupIdModify) == false)
            {
                ESUserGroup anUserGroup = new ESUserGroup();
                anUserGroup.Id = UserGroupIdModify;
                anUserGroup.GroupName = txtUserGroupName.Text.Trim();
                stat = _aBuserGroup.UpdateUserGroup(anUserGroup);
                if (stat)
                {
                    MessageBox.Show("Group Name has been Updated", caption, MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                MessageBox.Show("Group Name Already Exist.", caption, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void SaveOperationofUserGroup()
        {
            bool stat = false;
            if (_aBuserGroup.DoesExistGroupinSaveMode(txtUserGroupName.Text.Trim()) == false)
            {
                ESUserGroup anUserGroup = new ESUserGroup();
                anUserGroup.GroupName = txtUserGroupName.Text.Trim();
                stat = _aBuserGroup.SaveUserGroup(anUserGroup);
                if (stat)
                {
                    MessageBox.Show("Group Name has been Saved", caption, MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                MessageBox.Show("Group Name Already Exist.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool CheckFieldofUserGroup()
        {
            if (txtUserGroupName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Group Name.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                txtUserGroupName.Focus();
                return false;
            }
            return true;
        }
        private void EditUserGroupClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUserGroup.SelectedIndex > -1)
                {
                    if ((lvUserGroup.SelectedItem as ESUserGroup).GroupName.ToLower() == "Super Admin".ToLower())
                    {
                        MessageBox.Show(" This Group can not be Modified.", caption, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ESUserGroup anEsUserGroup = lvUserGroup.SelectedItem as ESUserGroup;
                        UserGroupIdModify = anEsUserGroup.Id;
                        txtUserGroupName.Text = anEsUserGroup.GroupName;
                        btnAddUserGroup.Content = "Modify";
                    }
                }
                else
                {
                    MessageBox.Show("Select an User Group First.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                    lvUserGroup.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Selection.", caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RemoveUserGroupClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUserGroup.SelectedIndex > -1)
                {
                    if ((lvUserGroup.SelectedItem as ESUserGroup).GroupName.ToLower() == "Super Admin".ToLower())
                    {
                        MessageBox.Show(" This Group can not be Removed.", caption, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure want to Delete the Record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            if (MessageBox.Show("After Deletion You will Lost  This Group Related All Information.", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                            {
                                bool stat = false;
                                ESUserGroup anEsUserGroup = lvUserGroup.SelectedItem as ESUserGroup;
                                stat = _aBuserGroup.DeleteUserGroup(anEsUserGroup.Id);
                                if (stat)
                                {
                                    MessageBox.Show("Group Information has been Deleted", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                                    // InitialTaskforUserGroup();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select an User Group First.", caption, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Deletion.", caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void groupClosebutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
