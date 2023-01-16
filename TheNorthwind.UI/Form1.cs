using TheNorthwind.UI.Customers;

namespace TheNorthwind.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuCategoriesForm_Click(object sender, EventArgs e)
        {
            var categoryListForm = new CategoryListForm();
            categoryListForm.MdiParent = this;
            categoryListForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void menuProductListForm_Click(object sender, EventArgs e)
        {
            var productListForm = new ProductListForm();
            productListForm.MdiParent = this;
            productListForm.Show();
        }

        private void menuProductCreateForm_Click(object sender, EventArgs e)
        {
            var productCreateForm = new ProductCreateForm();
            productCreateForm.MdiParent = this;
            productCreateForm.Show();
        }

        private void �r�nlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var productListForm = new ProductListForm();
            productListForm.MdiParent = this;
            productListForm.Show();
        }

        private void yeniKategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productCreateForm = new ProductCreateForm();
            productCreateForm.MdiParent = this;
            productCreateForm.Show();
        }

        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var categoryListForm = new CategoryListForm();
            categoryListForm.MdiParent = this;
            categoryListForm.Show();
        }

        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var categoryCreateForm = new CategoryCreateForm();
            categoryCreateForm.MdiParent = this;
            categoryCreateForm.Show();
        }

        private void tedarik�ilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var supplierListForm = new SupplierListForm();
            supplierListForm.MdiParent = this;
            supplierListForm.Show();
        }

        private void tedarik�iEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var supplierCreateForm = new SupplierCreateForm();
            supplierCreateForm.MdiParent = this;
            supplierCreateForm.Show();
        }

        private void m��terilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerListForm = new customerListForm();
            customerListForm.MdiParent = this;
            customerListForm.Show();
        }

        private void m��teriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerCreateForm=new CustomerCreateForm();
            customerCreateForm.MdiParent = this;
            customerCreateForm.Show();
        }

        private void kategoriY�netimiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}