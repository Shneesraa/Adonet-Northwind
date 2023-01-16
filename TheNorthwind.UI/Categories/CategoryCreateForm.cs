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
    public partial class CategoryCreateForm : Form
    {
        private CategoryService _categoryService = new CategoryService();

        public CategoryCreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

            var result = _categoryService.Create(category);

            // CommandResult nesnesini UI katmanında nasıl kullanabilirim?

            // Yöntem 1
            // Başarılı da olsa başarısız da olsa mesajı doğrudan yazdırabilirsin
            MessageBox.Show(result.Message);

            // ------------------------------------------------------ //

            // Ya da
            // Yöntem 2
            if (result.IsSuccess)
            {
                // Kaydetme başarılı olursa formu kapat
                Close();
            }
            else
            {
                // Hata durumunda mesajı yazdır
                MessageBox.Show(result.Message);
            }

            foreach (var mdiChild in MdiParent.MdiChildren)
            {
                if (mdiChild is CategoryCreateForm)
                {
                    ((CategoryListForm)mdiChild).RefReshForm();
                }
            }
        }

        private void CategoryCreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
