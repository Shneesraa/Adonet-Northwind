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
    public partial class CustomerUpdateForm : Form
    {
        private CustomerService _customerService = new CustomerService();
        private string _customerId;

        public CustomerUpdateForm(string ıd)
        {
            InitializeComponent();
            _customerId = ıd;
        }

    }
}
