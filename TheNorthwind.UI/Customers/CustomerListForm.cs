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

namespace TheNorthwind.UI.Customers
{
    public partial class customerListForm : Form
    {
        private CustomerService _customerService = new CustomerService();

        public customerListForm()
        {
            InitializeComponent();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            //    var customer = _customerService.GetAll();
            //    grdCustomerList.DataSource = customer;
            RefReshForm();
        }

        private void grdCustomerList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex>0)
            {
                grdCustomers.Rows[e.RowIndex].Selected = true;
            }
        }

        public void RefReshForm()
        {
            var customers = _customerService.GetAll();
            grdCustomers.DataSource = customers;
        }

        private void menuCreateForm_Click(object sender, EventArgs e)
        {
            if (grdCustomers.SelectedRows.Count>0)
            {
                var customer=(Customer)grdCustomers.SelectedRows[0].DataBoundItem;

                var customerUpdateForm = new CustomerUpdateForm(customer.Id);
                customerUpdateForm.MdiParent = this.MdiParent;
                customerUpdateForm.Show(); // Load event'ini tetikler
            }
            RefReshForm();
        }

        private void menuDeleteForm_Click(object sender, EventArgs e)
        {
            if (grdCustomers.SelectedRows.Count > 0)
            {
                var customer = (Customer)grdCustomers.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"{customer.CompanyName} isimli şirketi silmek istediğinize emin misiniz?",
                    "Dikkat!",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // servisten Delete metodunu çağır!!
                    var commandResult = _customerService.Delete(customer);
                    MessageBox.Show("silindi!!");
                    foreach (var mdiChild in MdiParent.MdiChildren)
                    {
                        if (mdiChild is CustomerListForm)
                        {
                            ((CustomerListForm)mdiChild).RefReshForm();
                        }
                    }
                    RefReshForm();
                }
             
            }
        }
    }
}
