using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Components;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketPlatForm.wpf.Pages
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        ICategoryService _categoryService;
        List<Category> _categories=new List<Category>(); 
        public CategoryPage()
        {
            InitializeComponent();
            this._categoryService=new MarketPlatForm.wpf.Service.Services.CategoryService();
            GetAllCategory();
        }

        public async void GetAllCategory()
        {
            _categories = await _categoryService.GetAll();
            Category_list.Visibility = Visibility.Visible;
            Category_list.Children.Clear();
            foreach (Category c in _categories)
            {
                CategoryComponent category = new CategoryComponent();
                category.Tag = c.Id;
                category.setdata(c);
                category.Margin=new Thickness(5, 15, 5, 2);
                Category_list.Children.Add(category);
            }

        }
       
    }
}
