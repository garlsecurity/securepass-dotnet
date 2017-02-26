using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Data;

namespace GUI.Class.Data
{
    public partial class GroupDataControl : UserControl
    {
        public GroupGUIAPI GroupGuiapi { get; set; }

        public GroupDataControl()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            GroupGuiapi.deleteGroup();
        }

        private void GroupDataControl_Load(object sender, EventArgs e)
        {

        }


        private void GroupDataButtonAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
