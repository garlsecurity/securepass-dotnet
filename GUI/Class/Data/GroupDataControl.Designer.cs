using System;
using System.Windows.Forms;

namespace GUI.Class.Data
{
    partial class GroupDataControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void dd(bool status)
        {
            BtnDel.Enabled = status;
        }

        public string GroupDescription
        {
            get { return GroupDescriptionTextBox.Text; }
            set { GroupDescriptionTextBox.Text = value; }
        }

        public String GroupIdText
        {
            get { return GroupIdTextBox.Text; }
            set { GroupIdTextBox.Text = value; }
        }

        public void readOnly()
        {
            GroupIdTextBox.Enabled = false;
            GroupDescriptionTextBox.Enabled = false;
        }

        public void editable()
        {
            GroupDescriptionTextBox.Enabled = true;
            GroupIdTextBox.Enabled = true;
        }

       public void buttonStatus(bool add,bool delete)
       {
           BtnDel.Enabled = delete;
           addBtn.Enabled = add;
       }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupDataPanel = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.GroupDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.GroupIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupDataPanel
            // 
            this.GroupDataPanel.Controls.Add(this.addBtn);
            this.GroupDataPanel.Controls.Add(this.BtnDel);
            this.GroupDataPanel.Controls.Add(this.GroupDescriptionTextBox);
            this.GroupDataPanel.Controls.Add(this.GroupIdTextBox);
            this.GroupDataPanel.Controls.Add(this.label2);
            this.GroupDataPanel.Controls.Add(this.label3);
            this.GroupDataPanel.Location = new System.Drawing.Point(20, 3);
            this.GroupDataPanel.Name = "GroupDataPanel";
            this.GroupDataPanel.Size = new System.Drawing.Size(584, 129);
            this.GroupDataPanel.TabIndex = 6;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(391, 7);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(477, 7);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 7;
            this.BtnDel.Text = "Delete";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // GroupDescriptionTextBox
            // 
            this.GroupDescriptionTextBox.Location = new System.Drawing.Point(148, 88);
            this.GroupDescriptionTextBox.Name = "GroupDescriptionTextBox";
            this.GroupDescriptionTextBox.Size = new System.Drawing.Size(404, 22);
            this.GroupDescriptionTextBox.TabIndex = 3;
            // 
            // GroupIdTextBox
            // 
            this.GroupIdTextBox.Location = new System.Drawing.Point(148, 50);
            this.GroupIdTextBox.Name = "GroupIdTextBox";
            this.GroupIdTextBox.Size = new System.Drawing.Size(404, 22);
            this.GroupIdTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Group ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Description";
            // 
            // GroupDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupDataPanel);
            this.Name = "GroupDataControl";
            this.Size = new System.Drawing.Size(665, 175);
            this.GroupDataPanel.ResumeLayout(false);
            this.GroupDataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GroupDataPanel;
        private System.Windows.Forms.TextBox GroupDescriptionTextBox;
        private System.Windows.Forms.TextBox GroupIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Button BtnDel;
        private Button addBtn;
    }
}
