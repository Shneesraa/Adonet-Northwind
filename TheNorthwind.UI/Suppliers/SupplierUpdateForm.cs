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
    public partial class SupplierUpdateForm : Form
    {
        public SupplierUpdateForm(int id)
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier()
            {
                Address = (string)txtAddress.Text,
                City = (string)txtCity.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = (string)txtContactName.Text,
                ContactTitle = (string)txtContactTitle.Text,
                Country = (string)txtCountry.Text,
                Fax = (string)txtFax.Text,
                Phone = (string)txtPhone.Text,
                PostalCode = (string)txtPostalCode.Text,
                Region = (string)txtRegion.Text,
                HomePage = (string)txtHomePage.Text,
            };

            var supplierService = new SupplierService();
            var result = supplierService.Create(supplier);

            if (result.IsSuccess)
            {
                MessageBox.Show("Başarılı");
            }
        }
    }
}
