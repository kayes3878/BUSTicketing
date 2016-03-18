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
    /// Interaction logic for ModulePermissionUI.xaml
    /// </summary>
    public partial class ModulePermissionUI : Window
    {
        BSModulePermissionManager _objBsModulePermissionManager = new BSModulePermissionManager();
        List<string> listAvailablemodule = new List<string>();
        List<string> listPermittedModule = new List<string>();
        string[] availableModule = new string[] { "Ticketing", "Security" };
        public ModulePermissionUI()
        {
            InitializeComponent();
            PopulateUserGroupComboforModule();
            LoadAvailableModule();
            lbNotPermittedModule.Items.Clear();
            lbPermittedModule.Items.Clear();
        }
        private void LoadAvailableModule()
        {
            try
            {
                foreach (string item in availableModule)
                {
                    listAvailablemodule.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading Available Module.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void PopulateUserGroupComboforModule()
        {
            try
            {
                BSUserGroupManager aBUserGroup = new BSUserGroupManager();
                cmbUserGroupofModule.Items.Clear();
                foreach (var userGroup in aBUserGroup.GetAllUserGroup())
                {
                    if (userGroup.GroupName.ToLower() != "Super Admin".ToLower())
                    {
                        cmbUserGroupofModule.Items.Add(userGroup);
                    }
                }
                cmbUserGroupofModule.DisplayMemberPath = "GroupName";
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading User Group Name.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnSaveModulePermissionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofModule())
                {
                    if (btnSaveModulePermission.Content.ToString() == "Save")
                    {
                        if (SaveModulePermission())
                        {
                            MessageBox.Show("Saved Success.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                            ResetModulePermission();
                        }
                    }
                    else
                    {
                        if (UpdateModulePermission())
                        {
                            MessageBox.Show("Updated Success.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                            ResetModulePermission();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Saving.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool UpdateModulePermission()
        {
            bool stat = false;
            //Insert
            foreach (string module in lbPermittedModule.Items)
            {
                if (DuplicacyCheckPermittedModuleforInsert(module))
                {
                    ESModulePermission objEmodule = new ESModulePermission();
                    objEmodule.ModuleName = module.ToString();
                    objEmodule.UserGroupId = (cmbUserGroupofModule.SelectedItem as ESUserGroup).Id;
                    stat = _objBsModulePermissionManager.SaveModulePermission(objEmodule);
                }
            }
            //Delete

            foreach (string module in listPermittedModule)
            {
                if (DuplicacyCheckPermittedModuleforDelete(module))
                {
                    ESModulePermission objEmodule = new ESModulePermission();
                    objEmodule.ModuleName = module.ToString();
                    objEmodule.UserGroupId = (cmbUserGroupofModule.SelectedItem as ESUserGroup).Id;
                    stat = _objBsModulePermissionManager.DeleteSingleModulePermission(objEmodule);
                }
            }
            return stat;
        }
        /*This checking is needed for Update Module*/
        private bool DuplicacyCheckPermittedModuleforInsert(string moduleName)
        {
            foreach (string itm in listPermittedModule)
            {
                if (itm == moduleName)
                {
                    return false;
                }
            }
            return true;
        }
        private bool DuplicacyCheckPermittedModuleforDelete(string moduleName)
        {
            foreach (string itm in lbPermittedModule.Items)
            {
                if (itm == moduleName)
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckFieldofModule()
        {
            if (cmbUserGroupofModule.Text == string.Empty)
            {
                MessageBox.Show("Please Select User Group.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbUserGroupofModule.Focus();
                return false;
            }
            if (lbPermittedModule.Items.Count == 0)
            {
                MessageBox.Show("Please Fillup Permitted List.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                lbPermittedModule.Focus();
                return false;
            }
            return true;
        }
        private bool SaveModulePermission()
        {
            bool stat = false;
            foreach (var item in lbPermittedModule.Items)
            {
                ESModulePermission objEmodule = new ESModulePermission();
                objEmodule.ModuleName = item.ToString();
                objEmodule.UserGroupId = (cmbUserGroupofModule.SelectedItem as ESUserGroup).Id;
                stat = _objBsModulePermissionManager.SaveModulePermission(objEmodule);
            }
            return stat;
        }
        private void BtnDeleteModulePermissionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofModule())
                {
                    if (MessageBox.Show("Are you sure want to Delete the Record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (DeleteModulePermission())
                        {
                            MessageBox.Show("Deletion Success.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Deletion.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool DeleteModulePermission()
        {
            return _objBsModulePermissionManager.DeleteModulePermission((cmbUserGroupofModule.SelectedItem as ESUserGroup).Id);
        }
        private void BtnResetModulePermissionClick(object sender, RoutedEventArgs e)
        {
            ResetModulePermission();
        }
        private void ResetModulePermission()
        {
            PopulateUserGroupComboforModule();
            lbPermittedModule.Items.Clear();
            lbNotPermittedModule.Items.Clear();
            listPermittedModule.Clear();
            btnSaveModulePermission.Content = "Save";
        }
        private void CmbUserGroupofModuleSelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbUserGroupofModule.SelectedIndex > -1)
                {
                    long groupId = (cmbUserGroupofModule.SelectedItem as ESUserGroup).Id;

                    lbPermittedModule.Items.Clear();
                    lbNotPermittedModule.Items.Clear();
                    listPermittedModule.Clear();

                    foreach (ESModulePermission objPermittedModule in _objBsModulePermissionManager.GetPermittedModule(groupId))
                    {
                        lbPermittedModule.Items.Add(objPermittedModule.ModuleName);
                        listPermittedModule.Add(objPermittedModule.ModuleName);
                    }

                    if (listPermittedModule.Count > 0)
                    {
                        btnSaveModulePermission.Content = "Update";
                    }
                    else
                    {
                        btnSaveModulePermission.Content = "Save";
                    }

                    foreach (string NotPermittedModule in _objBsModulePermissionManager.GetNOTPermittedModule(listAvailablemodule, listPermittedModule))
                    {
                        lbNotPermittedModule.Items.Add(NotPermittedModule);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading User Groups Permittted Module.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnMoveModule_Click(object sender, RoutedEventArgs e)
        {
            if (lbNotPermittedModule.SelectedIndex > -1)
            {
                lbPermittedModule.Items.Add(lbNotPermittedModule.SelectedItem);
                lbNotPermittedModule.Items.Remove(lbNotPermittedModule.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please Select Not Permitted Module First.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                lbNotPermittedModule.Focus();
            }
        }
        private void btnDeleteModule_Click(object sender, RoutedEventArgs e)
        {
            if (lbPermittedModule.SelectedIndex > -1)
            {
                lbNotPermittedModule.Items.Add(lbPermittedModule.SelectedItem);
                lbPermittedModule.Items.Remove(lbPermittedModule.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please Select Permitted Module First.", "Module Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                lbPermittedModule.Focus();
            }
        }
    }
}
