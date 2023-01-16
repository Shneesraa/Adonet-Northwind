namespace TheNorthwind.UI
{
    partial class CategoryListForm
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
            this.grdCategories = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuUpdateCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCategories
            // 
            this.grdCategories.AllowUserToAddRows = false;
            this.grdCategories.AllowUserToDeleteRows = false;
            this.grdCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCategories.ContextMenuStrip = this.contextMenuStrip1;
            this.grdCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCategories.Location = new System.Drawing.Point(0, 0);
            this.grdCategories.MultiSelect = false;
            this.grdCategories.Name = "grdCategories";
            this.grdCategories.ReadOnly = true;
            this.grdCategories.RowHeadersWidth = 51;
            this.grdCategories.RowTemplate.Height = 29;
            this.grdCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCategories.Size = new System.Drawing.Size(800, 451);
            this.grdCategories.TabIndex = 0;
            this.grdCategories.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCategories_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpdateCategory,
            this.menuDeleteCategory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 52);
            // 
            // menuUpdateCategory
            // 
            this.menuUpdateCategory.Name = "menuUpdateCategory";
            this.menuUpdateCategory.Size = new System.Drawing.Size(132, 24);
            this.menuUpdateCategory.Text = "Düzenle";
            this.menuUpdateCategory.Click += new System.EventHandler(this.menuUpdateCategory_Click);
            // 
            // menuDeleteCategory
            // 
            this.menuDeleteCategory.Name = "menuDeleteCategory";
            this.menuDeleteCategory.Size = new System.Drawing.Size(132, 24);
            this.menuDeleteCategory.Text = "Sil";
            this.menuDeleteCategory.Click += new System.EventHandler(this.menuDeleteCategory_Click);
            // 
            // CategoryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.grdCategories);
            this.Name = "CategoryListForm";
            this.Text = "CategoryListForm";
            this.Load += new System.EventHandler(this.CategoryListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategories)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grdCategories;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menuUpdateCategory;
        private ToolStripMenuItem menuDeleteCategory;
    }
}