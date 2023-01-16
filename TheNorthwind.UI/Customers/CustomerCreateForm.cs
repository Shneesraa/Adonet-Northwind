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

namespace TheNorthwind.UI.Customers
{
    public partial class CustomerCreateForm : Form
    {
        private CustomerService _customerService = new CustomerService();

        public CustomerCreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                Id =  txtCustomerID.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,  
                ContactTitle = txtContactTitle.Text,    
                Address = txtAddress.Text,  
                City=txtCity.Text,
                Region=txtRegion.Text,
                PostalCode=txtPostalCode.Text,
                Country=txtCountry.Text,
                Phone=txtPhone.Text,
                Fax=txtFax.Text,
            };

            var result = _customerService.Create(customer);

            if (result.IsSuccess)
            {
                Close();
            }
            else
            {
                MessageBox.Show(result.Message);
            }

            foreach (var mdiChild in MdiParent.MdiChildren)
            {
                if (mdiChild is CustomerCreateForm)
                {
                    ((customerListForm)mdiChild).RefReshForm();
                }
            }
        }
    }
}
