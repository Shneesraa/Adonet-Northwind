using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheNorthwind.Business;

namespace TheNorthwind.UI
{
    public partial class ProductUpdateForm : Form
    {
        public ProductUpdateForm()
        {
            InitializeComponent();
        }

        private void ProductUpdateForm_Load(object sender, EventArgs e)
        {
            var categoryService = new CategoryService();
            var categories = categoryService.GetAll();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            var supplierService = new SupplierService();
            var suppliers = supplierService.GetAll();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = new Product()
            {
                Name = txtName.Text,
                SupplierId = (int)cmbSupplier.SelectedValue,
                CategoryId = (int)cmbCategory.SelectedValue,
                QuantityPerUnit = txtQuantityPerUnit.Text,
                UnitPrice = numUnitPrice.Value,
                UnitsInStock = (short)numUnitsInStock.Value,
                UnitsOnOrder = (short)numUnitsOnOrder.Value,
                ReorderLevel = (short)numReorderLevel.Value,
                Discontinued = chkDiscontinued.Checked
            };

            var productService = new ProductService();
            var result = productService.Create(product);

            if (result.IsSuccess)
            {
                MessageBox.Show("Başarılı");
            }
        }
    }
}
