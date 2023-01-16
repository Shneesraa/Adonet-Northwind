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
    public partial class ProductCreateForm : Form
    {
        public ProductCreateForm()
        {
            InitializeComponent();
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

            }
        }

        private void ProductCreateForm_Load(object sender, EventArgs e)
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

            // SOLID => S, O, L, I, D => Single Responsibilty Principle
            // GetCategories gibi bir metodu herhangi bir Form sınıfında yazmak
            // SOLID prensiplerine aykırı
            // Aşağıdaki gibi bir kodlama ideal değil
            //var categoryListForm = new CategoryListForm();
            //var categories = categoryListForm.GetCategories();

            

            //using (var sqlConnection = new SqlConnection(DbSettings.ConnectionString))
            //using (var sqlCommand = sqlConnection.CreateCommand())
            //{
            //    sqlCommand.CommandText = "select CategoryID, CategoryName, Description from Categories";

            //    try
            //    {
            //        var categoryList = new List<Category>();

            //        sqlConnection.Open();
            //        using (var reader = sqlCommand.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                categoryList.Add(new Category()
            //                {

            //                });
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
