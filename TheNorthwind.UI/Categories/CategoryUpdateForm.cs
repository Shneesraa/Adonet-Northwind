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
    public partial class CategoryUpdateForm : Form
    {
        private CategoryService _categoryService = new CategoryService();
        private int _categoryId;

        public CategoryUpdateForm(int categoryId)
        {
            InitializeComponent();

            _categoryId = categoryId;
        }

        //public void SetCategoryId(int categoryId)
        //{
        //    _categoryId = categoryId;
        //}

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {
            var category = _categoryService.GetById(_categoryId);
            txtName.Text = category.Name;
            txtDescription.Text = category.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

            var categoryService = new ProductService();
            var result = _categoryService.Create(category);

            if (result.IsSuccess)
            {
                MessageBox.Show("Başarılı");
            }
        }
    }
}
