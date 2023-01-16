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
    public partial class CategoryListForm : Form
    {
        private CategoryService _categoryService = new CategoryService();

        public CategoryListForm()
        {
            InitializeComponent();
        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            RefReshForm();
            // data bind
        }

        private void grdCategories_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grdCategories.Rows[e.RowIndex].Selected = true;
            }
        }

        private void menuUpdateCategory_Click(object sender, EventArgs e)
        {
            if (grdCategories.SelectedRows.Count > 0)
            {
                var category = (Category)grdCategories.SelectedRows[0].DataBoundItem;

                // Test amaçlı Id değerine bakıyoruz
                //MessageBox.Show(category.Id.ToString());

                var categoryUpdateForm = new CategoryUpdateForm(category.Id);
                categoryUpdateForm.MdiParent = this.MdiParent;
                categoryUpdateForm.Show(); // Load event'ini tetikler
            }
            RefReshForm();
        }

        private void menuDeleteCategory_Click(object sender, EventArgs e)
        {
            if (grdCategories.SelectedRows.Count > 0)
            {
                var category = (Category)grdCategories.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show(
                    $"{category.Name} isimli kategoriyi silmek istediğinize emin misiniz?",
                    "Dikkat!",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // servisten Delete metodunu çağır!!
                    var commandResult = _categoryService.Delete(category);
                    MessageBox.Show("silindi!!");
                    foreach (var mdiChild in MdiParent.MdiChildren)
                    {
                        if (mdiChild is CategoryListForm)
                        {
                            ((CategoryListForm)mdiChild).RefReshForm();
                        }
                    }
                }
                RefReshForm();
            }
        }

        public void RefReshForm()
        {
            var categories = _categoryService.GetAll();
            grdCategories.DataSource = categories;
        }
    }
}
