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
    public partial class ProductListForm : Form
    {
        private ProductService _productService = new ProductService();
        private const string ConnectionString =
            "Server=.; Database=Northwind; Integrated Security=true;";

        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = @"
select 
ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,
UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued from Products";
                    sqlConnection.Open();
                    var productList = new List<Product>();
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            //var prod = new Product() { 
                            //    Id = dataReader.GetInt32("ProductID"),
                            //    Name = dataReader.GetString("ProductName"),
                            //    SupplierId = dataReader.IsDBNull("SupplierID") 
                            //        ? default 
                            //        : dataReader.GetInt32("SupplierID")
                            //};

                            var product = new Product();
                            product.Id = (int)dataReader["ProductID"];
                            product.Name = (string)dataReader["ProductName"];

                            // Eğer dataReader["HÜCRE_ADI"] değeri veritabanından NULL
                            // değer geliyorsa aşağıdaki satır runtime'da hata fırlatacaktır
                            // Result Set'ten NULL gelebilecek değerleri aşağıdaki gibi
                            // doğrudan cast etme işlemi yapamam
                            //product.SupplierId = (int)dataReader["SupplierID"];

                            // Result Set'ten NULL gelebilecek değerleri aşağıdaki örneklerde
                            // olduğu gibi kontrollü bir şekilde karşılamam gerekiyor

                            //product.SupplierId =
                            //    dataReader["SupplierID"] == DBNull.Value
                            //    ? default
                            //    : (int)dataReader["SupplierID"];

                            //product.SupplierId =
                            //    dataReader.IsDBNull("SupplierID")
                            //    ? (int?)null
                            //    : (int?)dataReader["SupplierID"];

                            product.SupplierId =
                                dataReader.IsDBNull("SupplierID")
                                ? default
                                : dataReader.GetInt32("SupplierID");

                            // TODO: Extension method geliştirilecek
                            // Sonra geliştirilecek Extension Method
                            //product.SupplierId = dataReader.GetNullableInt32("SupplierID");

                            product.CategoryId = dataReader.IsDBNull("CategoryID")
                                ? default
                                : dataReader.GetInt32("CategoryID");

                            product.QuantityPerUnit = (string)dataReader["QuantityPerUnit"];

                            product.UnitPrice = dataReader["UnitPrice"] == DBNull.Value
                                ? default
                                : dataReader.GetDecimal("UnitPrice");
                            //(decimal)dataReader["UnitPrice"];

                            product.UnitsInStock = dataReader["UnitsInStock"] != DBNull.Value
                                ? dataReader.GetInt16("UnitsInStock")
                                : default;

                            product.UnitsOnOrder = !dataReader.IsDBNull("UnitsOnOrder")
                                ? (short)dataReader["UnitsOnOrder"]
                                : default;

                            product.ReorderLevel = dataReader.IsDBNull("ReorderLevel")
                                ? default
                                : (short)dataReader["ReorderLevel"];

                            product.Discontinued = (bool)dataReader["Discontinued"];
                            productList.Add(product);
                        }
                        sqlConnection.Close();

                        grdProduct.DataSource = productList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata aldın\n" + ex.ToString());
                }
            }
        }

        private void ProductListForm_Load_1(object sender, EventArgs e)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                try
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = @"
select 
ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,
UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued from Products";
                    sqlConnection.Open();
                    var productList = new List<Product>();
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var product = new Product()
                            {
                                Id = dataReader.GetInt32("ProductID"),
                                Name = dataReader.GetString("ProductName"),
                                CategoryId = dataReader.GetInt32Nullable("CategoryID"),
                                SupplierId = dataReader.GetInt32Nullable("SupplierID"),
                                QuantityPerUnit = dataReader.GetString("QuantityPerUnit"),
                                UnitPrice = dataReader.GetDecimalNullable("UnitPrice"),
                                UnitsInStock = dataReader.GetInt16Nullable("UnitsInStock"),
                                UnitsOnOrder = dataReader.GetInt16Nullable("UnitsOnOrder"),
                                ReorderLevel = dataReader.GetInt16Nullable("ReorderLevel"),
                                Discontinued = dataReader.GetBoolean("Discontinued")
                            };

                            productList.Add(product);
                        }
                    }

                    sqlConnection.Close();
                    grdProduct.DataSource = productList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata aldın\n" + ex.ToString());
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdProduct.SelectedRows.Count > 0)
            {
                var category = (Category)grdProduct.SelectedRows[0].DataBoundItem;

                // Test amaçlı Id değerine bakıyoruz
                //MessageBox.Show(category.Id.ToString());

                var productUpdateForm = new ProductUpdateForm();
                productUpdateForm.MdiParent = this.MdiParent;
                productUpdateForm.Show(); // Load event'ini tetikler
            }
            RefReshForm();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdProduct.SelectedRows.Count > 0)
            {
                var product = (Product)grdProduct.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"{product.Name} isimli ürünü silmek istediğinize emin misiniz?",
                    "Dikkat!",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // servisten Delete metodunu çağır!!
                    _productService.Delete(product);
                    MessageBox.Show("silindi!!");
                }
                RefReshForm();
            }
        }

        private void RefReshForm()
        {
            var categories = _productService.GetAll();
            grdProduct.DataSource = categories;
        }

        private void grdProduct_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdProduct.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
