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
    /// Interaction logic for MenuPermissionUI.xaml
    /// </summary>
    public partial class MenuPermissionUI : Window
    {
        public MenuPermissionUI()
        {
            InitializeComponent();
            PopulateUserGroupComboforMenu();
            cmbModuleName.Items.Clear();
            treeNotPermittedMenu.Items.Clear();
            treePermittedMenu.Items.Clear();
        }
        BMenuPermissionManager _objBMenuPermissionManager = new BMenuPermissionManager();
        Menu mnu = new Menu();
        TreeView treeAvailableMenu = new TreeView();



        private void LoadMenuIntoTree()
        {
            treeAvailableMenu.Items.Clear();
            try
            {
                foreach (MenuItem it in mnu.Items)
                {
                    TreeViewItem treeItem = new TreeViewItem();
                    treeItem.Foreground = Brushes.Maroon;
                    treeItem.Header = it.Header;
                    treeItem.Name = it.Name;
                    ProcessTree(it, treeItem);
                    treeAvailableMenu.Items.Add(treeItem);
                    treeItem.IsExpanded = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading Available Menu", "Security", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ProcessTree(MenuItem it, TreeViewItem newChild)
        {
            foreach (MenuItem obj in it.Items)
            {
                TreeViewItem child = new TreeViewItem();
                child.Header = obj.Header;
                child.Name = obj.Name;
                newChild.Items.Add(child);
                ProcessTree(obj, child);
            }
        }

        private void PopulateUserGroupComboforMenu()
        {
            try
            {
                BSUserGroupManager aBUserGroup = new BSUserGroupManager();
                cmbUserGroupMenuPerm.Items.Clear();
                foreach (var userGroup in aBUserGroup.GetAllUserGroup())
                {
                    if (userGroup.GroupName.ToLower() != "Super Admin".ToLower())
                    {
                        cmbUserGroupMenuPerm.Items.Add(userGroup);
                    }
                }
                cmbUserGroupMenuPerm.DisplayMemberPath = "GroupName";
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading User Group Name.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbUserGroupMenuPerm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbUserGroupMenuPerm.SelectedIndex > -1)
                {
                    cmbModuleName.Items.Clear();
                    BSModulePermissionManager objBMP = new BSModulePermissionManager();
                    long groupId = (cmbUserGroupMenuPerm.SelectedItem as ESUserGroup).Id;
                    foreach (ESModulePermission objPermittedModule in objBMP.GetPermittedModule(groupId))
                    {
                        cmbModuleName.Items.Add(objPermittedModule);
                    }
                    treeNotPermittedMenu.Items.Clear();
                    treePermittedMenu.Items.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading User Groups Permittted Module.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbModuleName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbModuleName.SelectedIndex > -1)
                {
                    if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Ticketing")
                    {
                        TicketingUI busAssignUIDashobj = new TicketingUI();
                        mnu.Items.Clear();
                        mnu = busAssignUIDashobj.GetAllBusAssignMainMenu();
                    }
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Account Management")
                    //{
                    //    //SecurityDashBoardUI securityDashBoard = new SecurityDashBoardUI();
                    //    //mnu.Items.Clear();
                    //    //mnu = securityDashBoard.GetAllSecurityMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "HR & Payroll")
                    //{
                    //    PISDashBoardUI pisDashBoard = new PISDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = pisDashBoard.GetAllPisMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Result Management")
                    //{
                    //    ResultManagementDeshBoard ResultManagementMainWindow = new ResultManagementDeshBoard();
                    //    mnu.Items.Clear();
                    //    mnu = ResultManagementMainWindow.GetAllResultMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Attendence")
                    //{
                    //    AttendenceSystemDashBoardUI AttendenceMainUIObj = new AttendenceSystemDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = AttendenceMainUIObj.GetAllAttendenceMainMenu();
                    //}
                    ////Student fee
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Student")
                    //{
                    //    FeesDashBoardUI feeMainUIObj = new FeesDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = feeMainUIObj.GetAllfeesMenuMenu();
                    //}

                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Course")
                    //{
                    //    CourseDashBoardUI CourseMainUIObj = new CourseDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = CourseMainUIObj.GetAllcourseMainMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Report")
                    //{
                    //    ReportDashBoard reportMainWindow = new ReportDashBoard();
                    //    mnu.Items.Clear();
                    //    mnu = reportMainWindow.GetAllreportMainMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Security")
                    //{
                    //    SecurityDashBoardUI securityDashBoard = new SecurityDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = securityDashBoard.GetAllSecurityMenu();
                    //}

                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Scholarship")
                    //{
                    //    ScholarshipMamagementDashBoardUI ScholarshipDashboard = new ScholarshipMamagementDashBoardUI();
                    //    mnu.Items.Clear();
                    //    mnu = ScholarshipDashboard.GetAllScholarshipMenu();
                    //}
                    //else if ((cmbModuleName.SelectedItem as ESModulePermission).ModuleName.Trim() == "Job Placement")
                    //{
                    //    //SurgeryDashboard surgeryDashboard = new SurgeryDashboard();
                    //    //mnu.Items.Clear();
                    //    //mnu = surgeryDashboard.GetAllSurgeryMenu();
                    //}
                    else
                    {
                        mnu.Items.Clear();
                    }
                    LoadMenuIntoTree();
                    PopulateTreeGroupWise();
                    PopulateNotPermittedTree();
                    if (treePermittedMenu.Items.Count > 0)
                    {
                        btnSaveMenuPermission.Content = "Update";
                    }
                    else
                    {
                        btnSaveMenuPermission.Content = "Save";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur While Loading Permittted Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /*****************Most Logical Part of this File***************************
         * Check Available tree(get from Module UI) and treePermittedMenu item
         * If portion task:if available tree item does not exist in the permittedtree
         * Else portion task: if exist then count their child and if missmatch child then checking and add mismatch item into NotPermitted tree.        
        ************************************************************************************/

        private void PopulateNotPermittedTree()
        {
            treeNotPermittedMenu.Items.Clear();
            if (treeAvailableMenu.Items.Count > 0)
            {
                for (int i = 0; i < treeAvailableMenu.Items.Count; i++)
                {
                    TreeViewItem tree = treeAvailableMenu.Items[i] as TreeViewItem;
                    if (DuplicacyCheck(tree, treePermittedMenu))
                    {
                        TreeViewItem trItem = new TreeViewItem();
                        trItem.Header = tree.Header;
                        trItem.Name = tree.Name;
                        trItem.Foreground = Brushes.Maroon;
                        trItem.IsExpanded = true;
                        treeNotPermittedMenu.Items.Add(trItem);
                        if (tree.HasItems)
                        {
                            foreach (TreeViewItem it in tree.Items)
                            {
                                TreeViewItem subNode = new TreeViewItem();
                                subNode.Header = it.Header;
                                subNode.Name = it.Name;
                                trItem.Items.Add(subNode);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < treePermittedMenu.Items.Count; j++)
                        {
                            TreeViewItem objTree = treePermittedMenu.Items[j] as TreeViewItem;
                            if (objTree.Name == tree.Name && objTree.Items.Count != tree.Items.Count)
                            {
                                TreeViewItem trItem = new TreeViewItem();
                                trItem.Header = tree.Header;
                                trItem.Name = tree.Name;
                                trItem.Foreground = Brushes.Maroon;
                                trItem.IsExpanded = true;
                                treeNotPermittedMenu.Items.Add(trItem);
                                if (tree.HasItems)
                                {
                                    foreach (TreeViewItem objFirstTreeItem in tree.Items)
                                    {
                                        if (duplicacyCheckChild(objFirstTreeItem))
                                        {
                                            TreeViewItem subNode = new TreeViewItem();
                                            subNode.Header = objFirstTreeItem.Header;
                                            subNode.Name = objFirstTreeItem.Name;
                                            trItem.Items.Add(subNode);
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool duplicacyCheckChild(TreeViewItem child)
        {
            if (treePermittedMenu.Items.Count > 0)
            {
                for (int i = 0; i < treePermittedMenu.Items.Count; i++)
                {
                    TreeViewItem obj = treePermittedMenu.Items[i] as TreeViewItem;
                    if (obj.HasItems)
                    {
                        foreach (TreeViewItem it in obj.Items)
                        {
                            if (it.Header.ToString() == child.Header.ToString() && it.Name == child.Name)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void PopulateTreeGroupWise()
        {
            treePermittedMenu.Items.Clear();
            try
            {
                EMenuPermission objEMP = new EMenuPermission();
                objEMP.UserGroupId = (cmbUserGroupMenuPerm.SelectedItem as ESUserGroup).Id;
                objEMP.ModuleId = (cmbModuleName.SelectedItem as ESModulePermission).Id;
                foreach (EMenuPermission objEParent in _objBMenuPermissionManager.GetAccParentMenuGroupWise(objEMP))
                {
                    TreeViewItem newChild = new TreeViewItem();
                    newChild.Header = objEParent.ParentMenuContent;
                    newChild.Name = objEParent.ParentMenuName;
                    newChild.Foreground = Brushes.Maroon;
                    newChild.IsExpanded = true;
                    treePermittedMenu.Items.Add(newChild);
                    objEMP.ParentMenuName = objEParent.ParentMenuName;
                    List<EMenuPermission> listChild = _objBMenuPermissionManager.GetAccChildMenuGroupWise(objEMP);
                    if (listChild.Count > 0)
                    {
                        foreach (EMenuPermission objEchild in listChild)
                        {
                            TreeViewItem child = new TreeViewItem();
                            child.Header = objEchild.ChildMenuContent;
                            child.Name = objEchild.ChildMenuName;
                            newChild.Items.Add(child);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void treeNotPermittedMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = treeNotPermittedMenu.SelectedItem as TreeViewItem;
            if (item != null)
            {
                if (item.HasItems)
                {
                    btnMoveMenuItem.IsEnabled = false;
                    btnMoveAllMenuItem.IsEnabled = true;
                }
                else
                {
                    btnMoveMenuItem.IsEnabled = true;
                    btnMoveAllMenuItem.IsEnabled = false;
                }
            }
        }

        private void treePermittedMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = treePermittedMenu.SelectedItem as TreeViewItem;
            if (item != null)
            {
                if (item.HasItems)
                {
                    btnDeleteMenuItem.IsEnabled = false;
                    btnDeleteAllMenuItem.IsEnabled = true;
                }
                else
                {
                    btnDeleteMenuItem.IsEnabled = true;
                    btnDeleteAllMenuItem.IsEnabled = false;
                }
            }
        }

        private void btnMoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Move_DeleteMenu(treeNotPermittedMenu, treePermittedMenu);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur to Move Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Move_DeleteMenu(TreeView treeSource, TreeView treeDestination)
        {
            TreeViewItem item = treeSource.SelectedItem as TreeViewItem;
            if (item != null)
            {
                /*****************************Parent****************************************************/

                TreeViewItem parentItem = item.Parent as TreeViewItem;
                if (parentItem != null)
                {
                    TreeViewItem PermittedParent = new TreeViewItem();
                    PermittedParent.Header = parentItem.Header;
                    PermittedParent.Name = parentItem.Name;
                    // PermittedParent.Foreground = Brushes.Maroon;
                    /**************************************************************************************/
                    TreeViewItem child = new TreeViewItem();
                    child.Header = item.Header;
                    child.Name = item.Name;
                    if (DuplicacyCheck(PermittedParent, treeDestination))
                    {
                        treeDestination.Items.Add(PermittedParent);
                        PermittedParent.Items.Add(child);
                        PermittedParent.IsExpanded = true;
                        parentItem.Items.Remove(item);
                        if (parentItem.HasItems == false)
                        {
                            treeSource.Items.Remove(parentItem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < treeDestination.Items.Count; i++)
                        {
                            var obj = treeDestination.Items[i] as TreeViewItem;
                            if (obj.Name == PermittedParent.Name)
                            {
                                obj.Items.Add(child);
                                parentItem.Items.Remove(item);
                                if (parentItem.HasItems == false)
                                {
                                    treeSource.Items.Remove(parentItem);
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    TreeViewItem child = new TreeViewItem();
                    child.Header = item.Header;
                    child.Name = item.Name;
                    child.Foreground = Brushes.Maroon;
                    treeDestination.Items.Add(child);
                    treeSource.Items.Remove(item);
                }
            }
        }

        private bool DuplicacyCheck(TreeViewItem node, TreeView tr)
        {
            if (tr.Items.Count > 0)
            {
                for (int i = 0; i < tr.Items.Count; i++)
                {
                    TreeViewItem tree = tr.Items[i] as TreeViewItem;
                    bool check = (tree.Header.ToString() == node.Header.ToString());
                    bool checkName = (tree.Name == node.Name);
                    if (check && checkName)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnMoveAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Move_Delete_AllMenu(treeNotPermittedMenu, treePermittedMenu);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur to Move Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Move_Delete_AllMenu(TreeView treeSource, TreeView treeDestination)
        {
            TreeViewItem item = treeSource.SelectedItem as TreeViewItem;
            if (item != null)
            {
                /*****************************Parent****************************************************/
                if (DuplicacyCheck(item, treeDestination))
                {
                    TreeViewItem node = new TreeViewItem();
                    node.Header = item.Header;
                    node.Name = item.Name;
                    node.Foreground = Brushes.Maroon;
                    node.IsExpanded = true;
                    treeDestination.Items.Add(node);
                    /**************************************************************************************/
                    if (item.HasItems)
                    {
                        foreach (TreeViewItem it in item.Items)
                        {
                            TreeViewItem subNode = new TreeViewItem();
                            subNode.Header = it.Header;
                            subNode.Name = it.Name;
                            node.Items.Add(subNode);
                        }
                    }
                    treeSource.Items.Remove(item);
                }
            }
        }

        private void btnDeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Move_DeleteMenu(treePermittedMenu, treeNotPermittedMenu);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur to Delete Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteAllMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Move_Delete_AllMenu(treePermittedMenu, treeNotPermittedMenu);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur to Delete Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaveMenuPermission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofMenu())
                {
                    if (btnSaveMenuPermission.Content.ToString() == "Save")
                    {

                        bool SaveStatus = false;
                        SaveStatus = SaveMenuPermission(SaveStatus);
                        if (SaveStatus == true)
                        {
                            MessageBox.Show("User menu has been successfully saved", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                            ResetMenu();
                        }
                    }
                    else if (btnSaveMenuPermission.Content.ToString() == "Update")
                    {
                        _objBMenuPermissionManager.DeleteUserRole((cmbUserGroupMenuPerm.SelectedItem as ESUserGroup).Id, (cmbModuleName.SelectedItem as ESModulePermission).Id);
                        bool Status = false;
                        Status = SaveMenuPermission(Status);
                        if (Status == true)
                        {
                            MessageBox.Show("User menu has been successfully Updated.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                            ResetMenu();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool SaveMenuPermission(bool SaveStatus)
        {
            for (int i = 0; i < treePermittedMenu.Items.Count; i++)
            {
                TreeViewItem objTreeItem = treePermittedMenu.Items[i] as TreeViewItem;
                EMenuPermission objMenu = new EMenuPermission();
                objMenu.UserGroupId = ((ESUserGroup)cmbUserGroupMenuPerm.SelectedItem).Id;
                objMenu.ModuleId = (cmbModuleName.SelectedItem as ESModulePermission).Id;
                objMenu.ParentMenuName = objTreeItem.Name;
                objMenu.ParentMenuContent = objTreeItem.Header.ToString();
                if (objTreeItem.HasItems)
                {
                    foreach (TreeViewItem it in objTreeItem.Items)
                    {
                        objMenu.ChildMenuName = it.Name;
                        objMenu.ChildMenuContent = it.Header.ToString();
                        SaveStatus = _objBMenuPermissionManager.SaveMenuUserGroupWise(objMenu);
                    }
                }
                else
                {
                    SaveStatus = _objBMenuPermissionManager.SaveMenuUserGroupWise(objMenu);
                }
            }
            return SaveStatus;
        }

        private bool CheckFieldofMenu()
        {
            if (cmbUserGroupMenuPerm.Text == string.Empty)
            {
                MessageBox.Show("Please Select User Group.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbUserGroupMenuPerm.Focus();
                return false;
            }
            if (treePermittedMenu.Items.Count == 0)
            {
                MessageBox.Show("Please Fillup Permitted Menu.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                treePermittedMenu.Focus();
                return false;
            }
            return true;
        }

        private void btnDeleteMenuPermission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFieldofMenu())
                {
                    if (MessageBox.Show("Are you sure want to Delete the Record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (_objBMenuPermissionManager.DeleteUserRole((cmbUserGroupMenuPerm.SelectedItem as ESUserGroup).Id, (cmbModuleName.SelectedItem as ESModulePermission).Id))
                        {
                            MessageBox.Show("Deletion Success.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Information);
                            ResetMenu();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem Occur while Deletion.", "Menu Permission", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetMenu()
        {
            treeAvailableMenu.Items.Clear();
            treeNotPermittedMenu.Items.Clear();
            treePermittedMenu.Items.Clear();
            PopulateUserGroupComboforMenu();
            cmbModuleName.Items.Clear();
            btnSaveMenuPermission.Content = "Save";
        }

        private void btnResetMenuPermission_Click(object sender, RoutedEventArgs e)
        {
            ResetMenu();
        }




    }
}
