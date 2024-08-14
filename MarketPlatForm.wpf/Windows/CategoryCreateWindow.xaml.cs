using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MarketPlatForm.wpf.Windows
{
    /// <summary>
    /// Interaction logic for CategoryCreateWindow.xaml
    /// </summary>
    public partial class CategoryCreateWindow : Window
    {
        ICategoryService categoryService;
        public CategoryCreateWindow()
        {
            InitializeComponent();
            this.categoryService = new MarketPlatForm.wpf.Service.Services.CategoryService();
        }

        private async void catSave_btn_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            category.CategoryName=category_txt.Text;
            if(category_txt.Text!=string.Empty)
            {
                await categoryService.Create(category);

            }
            else
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            category_txt.Text=string.Empty; 
            this.Close();
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();

        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
