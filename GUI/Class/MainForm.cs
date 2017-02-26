using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Class.Data;
using GUI.Data;
using GUI.TestData;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;
using UnitTests.Tests;

namespace GUI
{
    public partial class Form1 : Form
    {
        private GroupGUIAPI _groupGuiapi;

        public Form1()
        {
            InitializeComponent();
            var _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            _groupGuiapi = new GroupGUIAPI(ListGroup, "wiran.net");
            _groupGuiapi.addGroupToListBox();
            DataGroupContainer.Controls.Add(_groupGuiapi.GroupDataControl);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.Out.WriteLine(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
//            TreeNode treeNode = new TreeNode("Windows");
//            treeView1.Nodes.Add(treeNode);
//            //
//            // Another node following the first node.
//            //
//            treeNode = new TreeNode("Linux");
//            treeView1.Nodes.Add(treeNode);
//            //
//            // Create two child nodes and put them in an array.
//            // ... Add the third node, and specify these as its children.
//            //
//            TreeNode node2 = new TreeNode("C#");
//            TreeNode node3 = new TreeNode("VB.NET");
//            TreeNode[] array = new TreeNode[] { node2, node3 };
//            //
//            // Final node.
//            //
//            treeNode = new TreeNode("Dot Net Perls", array);
//            treeView1.Nodes.Add(treeNode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            GroupsAPITest.createTestGroup();
            GroupsMemberReq groupsMemberReq = new GroupsMemberReq();
            groupsMemberReq.GROUP = TestUtility.GroupTestName;
            groupsMemberReq.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;

            var groupsMemberAddResp = GroupsAPI.GroupsMemberAdd(groupsMemberReq);

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("colBestBefore", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("colStatus", typeof(string)));
            dt.Columns.Add(new DataColumn("colChoose", typeof(bool)));

            dt.Columns["colStatus"].Expression = String.Format("IIF(colBestBefore < #{0}#, 'Ok','Not ok')", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            dt.Rows.Add(DateTime.Now.AddDays(-1));
            dt.Rows.Add(DateTime.Now.AddDays(1));
            dt.Rows.Add(DateTime.Now.AddDays(2));
            dt.Rows.Add(DateTime.Now.AddDays(-2));

            dataGridUsers.DataSource = dt;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            DataCreator.createTestGroups("@wiran.net");

            string[] data = Data.GroupGUIAPI.LoadListGroup(TestUtility.realmTestName);
            for (int i = 0; i < data.Length; i++)
            {
                String groupMembers = "GroupMembers";
                String groupXattrs = "GroupXattrs";
                TreeNode groupMembersNode = new TreeNode(groupMembers);
                TreeNode groupXattrsNode = new TreeNode(groupXattrs);
                TreeNode[] array = new TreeNode[] { groupMembersNode, groupXattrsNode };

                TreeNode group = new TreeNode(data[i], array);
                treeView1.Nodes.Add(group);
            }

        }

        private void ListGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            _groupGuiapi.ListClicked(sender, e);
        }

        private void ListGroup_DoubleClick(object sender, EventArgs e)
        {
            _groupGuiapi.ListDoubleClicked(sender, e);
        }
    }
}
