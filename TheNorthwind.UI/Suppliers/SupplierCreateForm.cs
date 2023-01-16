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
    public partial class SupplierCreateForm : Form
    {
        private SupplierService _supplierService = new SupplierService();
        public SupplierCreateForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                Region = (string)txtRegion.Text
            };

            var result = _supplierService.Create(supplier);
            ProccessCommandResult(result);

            // CommandResult nesnesini UI katmanında nasıl kullanabilirim?

            // Yöntem 1
            // Başarılı da olsa başarısız da olsa mesajı doğrudan yazdırabilirsin
            //MessageBox.Show(result.Message);

            // ------------------------------------------------------ //

            // Ya da
            // Yöntem 2
            
        }

        private void ProccessCommandResult(CommandResult commandResult)
        {
            if (commandResult.IsSuccess)
            {
                // Kaydetme başarılı olursa formu kapat
                var dialogResult = MessageBox.Show("Yeni bir kayıt eklemek istiyor musunuz?",
                    commandResult.Message,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearForm();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                var dialogResult = MessageBox.Show("Hatayı görmek istiyor musunuz?",
                    commandResult.Message,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(commandResult.ErrorMessage);
                }
            }
        }

        private void ClearForm()
        {
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtContactTitle.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtRegion.Text = string.Empty;
        }

        private void SupplierCreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
