namespace TheNorthwind.UI.Customers
{
    partial class customerListForm
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
            this.components = new System.ComponentModel.Container();
            this.grdCustomers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCreateForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteForm = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCustomers
            // 
            this.grdCustomers.AllowUserToAddRows = false;
            this.grdCustomers.AllowUserToDeleteRows = false;
            this.grdCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomers.Location = new System.Drawing.Point(0, 0);
            this.grdCustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCustomers.MultiSelect = false;
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.ReadOnly = true;
            this.grdCustomers.RowHeadersWidth = 51;
            this.grdCustomers.RowTemplate.Height = 25;
            this.grdCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCustomers.Size = new System.Drawing.Size(914, 600);
            this.grdCustomers.TabIndex = 0;
            this.grdCustomers.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCustomerList_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateForm,
            this.menuDeleteForm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            // 
            // menuCreateForm
            // 
            this.menuCreateForm.Name = "menuCreateForm";
            this.menuCreateForm.Size = new System.Drawing.Size(210, 24);
            this.menuCreateForm.Text = "Düzenle";
            this.menuCreateForm.Click += new System.EventHandler(this.CustomerListForm_Load);
            // 
            // menuDeleteForm
            // 
            this.menuDeleteForm.Name = "menuDeleteForm";
            this.menuDeleteForm.Size = new System.Drawing.Size(210, 24);
            this.menuDeleteForm.Text = "Sil";
            this.menuDeleteForm.Click += new System.EventHandler(this.menuDeleteForm_Click);
            // 
            // customerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.grdCustomers);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "customerListForm";
            this.Text = "CustomerListForm";
            this.Load += new System.EventHandler(this.CustomerListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grdCustomers;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menuCreateForm;
        private ToolStripMenuItem menuDeleteForm;
    }
}