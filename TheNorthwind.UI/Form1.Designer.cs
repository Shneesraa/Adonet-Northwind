namespace TheNorthwind.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.katagloGönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünlerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçilerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tedarikçiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategorilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriYönetimiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşterilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.katagloGönetimiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // katagloGönetimiToolStripMenuItem
            // 
            this.katagloGönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünlerToolStripMenuItem,
            this.tedarikçilerToolStripMenuItem,
            this.kategoriYönetimiToolStripMenuItem,
            this.müşteriYönetimiToolStripMenuItem});
            this.katagloGönetimiToolStripMenuItem.Name = "katagloGönetimiToolStripMenuItem";
            this.katagloGönetimiToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.katagloGönetimiToolStripMenuItem.Text = "Katalog Yönetimi";
            // 
            // ürünlerToolStripMenuItem
            // 
            this.ürünlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünlerToolStripMenuItem1,
            this.yeniKategoriToolStripMenuItem});
            this.ürünlerToolStripMenuItem.Name = "ürünlerToolStripMenuItem";
            this.ürünlerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ürünlerToolStripMenuItem.Text = "Ürün Yönetimi";
            // 
            // ürünlerToolStripMenuItem1
            // 
            this.ürünlerToolStripMenuItem1.Name = "ürünlerToolStripMenuItem1";
            this.ürünlerToolStripMenuItem1.Size = new System.Drawing.Size(185, 26);
            this.ürünlerToolStripMenuItem1.Text = "Ürünler";
            this.ürünlerToolStripMenuItem1.Click += new System.EventHandler(this.ürünlerToolStripMenuItem1_Click);
            // 
            // yeniKategoriToolStripMenuItem
            // 
            this.yeniKategoriToolStripMenuItem.Name = "yeniKategoriToolStripMenuItem";
            this.yeniKategoriToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.yeniKategoriToolStripMenuItem.Text = "Yeni Ürün Ekle";
            this.yeniKategoriToolStripMenuItem.Click += new System.EventHandler(this.yeniKategoriToolStripMenuItem_Click);
            // 
            // tedarikçilerToolStripMenuItem
            // 
            this.tedarikçilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tedarikçilerToolStripMenuItem1,
            this.tedarikçiEkleToolStripMenuItem});
            this.tedarikçilerToolStripMenuItem.Name = "tedarikçilerToolStripMenuItem";
            this.tedarikçilerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tedarikçilerToolStripMenuItem.Text = "Tedarikçi Yönetimi";
            // 
            // tedarikçilerToolStripMenuItem1
            // 
            this.tedarikçilerToolStripMenuItem1.Name = "tedarikçilerToolStripMenuItem1";
            this.tedarikçilerToolStripMenuItem1.Size = new System.Drawing.Size(182, 26);
            this.tedarikçilerToolStripMenuItem1.Text = "Tedarikçiler";
            this.tedarikçilerToolStripMenuItem1.Click += new System.EventHandler(this.tedarikçilerToolStripMenuItem1_Click);
            // 
            // tedarikçiEkleToolStripMenuItem
            // 
            this.tedarikçiEkleToolStripMenuItem.Name = "tedarikçiEkleToolStripMenuItem";
            this.tedarikçiEkleToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.tedarikçiEkleToolStripMenuItem.Text = "Tedarikçi Ekle";
            this.tedarikçiEkleToolStripMenuItem.Click += new System.EventHandler(this.tedarikçiEkleToolStripMenuItem_Click);
            // 
            // kategoriYönetimiToolStripMenuItem
            // 
            this.kategoriYönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategorilerToolStripMenuItem,
            this.kategoriEkleToolStripMenuItem});
            this.kategoriYönetimiToolStripMenuItem.Name = "kategoriYönetimiToolStripMenuItem";
            this.kategoriYönetimiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kategoriYönetimiToolStripMenuItem.Text = "Kategori Yönetimi";
            this.kategoriYönetimiToolStripMenuItem.Click += new System.EventHandler(this.kategoriYönetimiToolStripMenuItem_Click);
            // 
            // kategorilerToolStripMenuItem
            // 
            this.kategorilerToolStripMenuItem.Name = "kategorilerToolStripMenuItem";
            this.kategorilerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kategorilerToolStripMenuItem.Text = "Kategoriler";
            this.kategorilerToolStripMenuItem.Click += new System.EventHandler(this.kategorilerToolStripMenuItem_Click);
            // 
            // kategoriEkleToolStripMenuItem
            // 
            this.kategoriEkleToolStripMenuItem.Name = "kategoriEkleToolStripMenuItem";
            this.kategoriEkleToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kategoriEkleToolStripMenuItem.Text = "Kategori Ekle";
            this.kategoriEkleToolStripMenuItem.Click += new System.EventHandler(this.kategoriEkleToolStripMenuItem_Click);
            // 
            // müşteriYönetimiToolStripMenuItem
            // 
            this.müşteriYönetimiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşterilerToolStripMenuItem,
            this.müşteriEkleToolStripMenuItem});
            this.müşteriYönetimiToolStripMenuItem.Name = "müşteriYönetimiToolStripMenuItem";
            this.müşteriYönetimiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.müşteriYönetimiToolStripMenuItem.Text = "Müşteri Yönetimi";
            // 
            // müşterilerToolStripMenuItem
            // 
            this.müşterilerToolStripMenuItem.Name = "müşterilerToolStripMenuItem";
            this.müşterilerToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.müşterilerToolStripMenuItem.Text = "Müşteriler";
            this.müşterilerToolStripMenuItem.Click += new System.EventHandler(this.müşterilerToolStripMenuItem_Click);
            // 
            // müşteriEkleToolStripMenuItem
            // 
            this.müşteriEkleToolStripMenuItem.Name = "müşteriEkleToolStripMenuItem";
            this.müşteriEkleToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.müşteriEkleToolStripMenuItem.Text = "Müşteri Ekle";
            this.müşteriEkleToolStripMenuItem.Click += new System.EventHandler(this.müşteriEkleToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem katagloGönetimiToolStripMenuItem;
        private ToolStripMenuItem ürünlerToolStripMenuItem;
        private ToolStripMenuItem ürünlerToolStripMenuItem1;
        private ToolStripMenuItem yeniKategoriToolStripMenuItem;
        private ToolStripMenuItem tedarikçilerToolStripMenuItem;
        private ToolStripMenuItem tedarikçilerToolStripMenuItem1;
        private ToolStripMenuItem tedarikçiEkleToolStripMenuItem;
        private ToolStripMenuItem kategoriYönetimiToolStripMenuItem;
        private ToolStripMenuItem kategorilerToolStripMenuItem;
        private ToolStripMenuItem kategoriEkleToolStripMenuItem;
        private ToolStripMenuItem müşteriYönetimiToolStripMenuItem;
        private ToolStripMenuItem müşterilerToolStripMenuItem;
        private ToolStripMenuItem müşteriEkleToolStripMenuItem;
    }
}