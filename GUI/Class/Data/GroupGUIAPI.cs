using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUI.Class.Data;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace GUI.Data
{
    public class GroupGUIAPI
    {
        // This list box contain all groups
        private ListBox _listBox;
        private String _realmName;

        // Gui for groupId and Description
        public GroupDataControl GroupDataControl = new GroupDataControl();

        public GroupGUIAPI(ListBox listBox, String realmName)
        {
            _listBox = listBox;
            _realmName = realmName;
            GroupDataControl.GroupGuiapi = this;
        }

        public static string[] LoadListGroup(String realmName)
        {
            GroupsListReq groupsListReq = new GroupsListReq();
            groupsListReq.REALM = "@" + realmName;
            var groupListResp = GroupsAPI.GroupsList(groupsListReq);
            return groupListResp.group.ToArray();
        }

        public void addGroupToListBox()
        {
            _listBox.DataSource = LoadListGroup(_realmName);
        }

        public void populateGroupDataControl(String groupID ,String description)
        {
//            GroupDataControl.GroupIdTextBox.Text = ((ListBox) sender).SelectedItem.ToString();
//            GroupDataControl.GroupIdTextBox.Text = ((ListBox) sender).SelectedItem.ToString();
        }

        // When list clicked groupDAtaControl is populated
        public void ListClicked(object sender, EventArgs e)
        {
            GroupDataControl.GroupIdText = ((ListBox) sender).SelectedItem.ToString();
            GroupDataControl.readOnly();
            GroupDataControl.buttonStatus(true,  true);
            // How can we load description?
        }

        // When list clicked groupDAtaControl is populated and user could edit data
        public void ListDoubleClicked(object sender, EventArgs e)
        {
            GroupDataControl.GroupIdText = ((ListBox)sender).SelectedItem.ToString();
            GroupDataControl.editable();
            GroupDataControl.buttonStatus(false,  false);

            // How can we load description?
        }


        public GroupDeleteResp deleteGroup()
        {
            var groupIdReq = new GroupIDReq();
            groupIdReq.GROUP = GroupDataControl.GroupIdText;
            var groupDeleteResp = GroupsAPI.GroupsDelete(groupIdReq);
            _listBox.DataSource= LoadListGroup(_realmName);
            GroupDataControl.buttonStatus(true,  false);
            return groupDeleteResp;
        }
        // Interface


    }
}