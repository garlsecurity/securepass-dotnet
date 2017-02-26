namespace GUI
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListGroup = new System.Windows.Forms.ListBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DataGroupContainer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListGroup
            // 
            this.ListGroup.FormattingEnabled = true;
            this.ListGroup.ItemHeight = 16;
            this.ListGroup.Location = new System.Drawing.Point(3, 290);
            this.ListGroup.Name = "ListGroup";
            this.ListGroup.Size = new System.Drawing.Size(207, 276);
            this.ListGroup.TabIndex = 2;
            this.ListGroup.SelectedIndexChanged += new System.EventHandler(this.ListGroup_SelectedIndexChanged);
            this.ListGroup.DoubleClick += new System.EventHandler(this.ListGroup_DoubleClick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(207, 277);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.button4);
            this.UserPanel.Controls.Add(this.dataGridUsers);
            this.UserPanel.Controls.Add(this.button1);
            this.UserPanel.Controls.Add(this.button2);
            this.UserPanel.Controls.Add(this.textBox1);
            this.UserPanel.Controls.Add(this.vScrollBar1);
            this.UserPanel.Controls.Add(this.label1);
            this.UserPanel.Location = new System.Drawing.Point(259, 3);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(635, 277);
            this.UserPanel.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(358, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "TestGroup";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username});
            this.dataGridUsers.Location = new System.Drawing.Point(62, 147);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.RowTemplate.Height = 24;
            this.dataGridUsers.Size = new System.Drawing.Size(509, 104);
            this.dataGridUsers.TabIndex = 4;
            this.dataGridUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Username
            // 
            this.Username.HeaderText = "User name";
            this.Username.Name = "Username";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(614, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 277);
            this.vScrollBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.6824F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.3176F));
            this.tableLayoutPanel1.Controls.Add(this.UserPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListGroup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DataGroupContainer, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 594);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DataGroupContainer
            // 
            this.DataGroupContainer.Location = new System.Drawing.Point(259, 290);
            this.DataGroupContainer.Name = "DataGroupContainer";
            this.DataGroupContainer.Size = new System.Drawing.Size(536, 200);
            this.DataGroupContainer.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(45, 632);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 159);
            this.panel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 838);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ListGroup;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel DataGroupContainer;
    }
}

