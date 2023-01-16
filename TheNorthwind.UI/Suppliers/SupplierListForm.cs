using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheNorthwind.Business;

namespace TheNorthwind.UI
{
    public partial class SupplierListForm : Form
    {
        private SupplierService _supplierService = new SupplierService();

        public SupplierListForm()
        {
            InitializeComponent();
        }

        private void SupplierListForm_Load(object sender, EventArgs e)
        {
            var suppliers = _supplierService.GetAll();
            grdSupplierList.DataSource = suppliers;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdSupplierList.SelectedRows.Count > 0)
            {
                var supplier = (Supplier)grdSupplierList.SelectedRows[0].DataBoundItem;

                // Test amaçlı Id değerine bakıyoruz
                //MessageBox.Show(category.Id.ToString());

                var supplierUpdateForm = new SupplierUpdateForm(supplier.Id);
                supplierUpdateForm.MdiParent = this.MdiParent;
                supplierUpdateForm.Show(); // Load event'ini tetikler
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdSupplierList.SelectedRows.Count > 0)
            {
                var supplier = (Supplier)grdSupplierList.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"{supplier.CompanyName} isimli tedarikçiyi silmek istediğinize emin misiniz?",
                    "Dikkat!",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // servisten Delete metodunu çağır!!
                    MessageBox.Show("silindi!!");
                }
            }
        }

        private void grdSupplierList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdSupplierList.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
