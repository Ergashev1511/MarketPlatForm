using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Pages;
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

namespace MarketPlatForm.wpf.Components
{
    /// <summary>
    /// Interaction logic for CategoryComponent.xaml
    /// </summary>
    public partial class CategoryComponent : UserControl
    {
        //MainWindow mainWindow;
        IProductService productService;
        List<Product> pro = new List<Product>();
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;


        public CategoryComponent()
        {
            InitializeComponent();
            this.productService=new MarketPlatForm.wpf.Service.Services.ProductService();   
           // this.mainWindow = new MainWindow();
           
        }

        public void setdata(Category category)
        {
            category_btn.Content = category.CategoryName;
        }
         public async void GetAllProduct()
        {
            long categoryId = (long)this.Tag;
           List<Product> products = await productService.GetAll();
            var pro = products.Where(x => x.CateogryId == categoryId).ToList();

            //productPage.Product_list.Visibility = Visibility.Visible;
            //productPage.Product_list.Children.Clear();
            //foreach (Product product in products)
            //{
            //    ProductComponent productComponent = new ProductComponent();
            //    productComponent.Tag = product.Id;
            //    productComponent.SetData(product);
            //    productComponent.Margin = new Thickness(5, 5, 5, 5);
            //    productPage.Product_list.Children.Add(productComponent);
            //}
        }
        private void category_btn_Click(object sender, RoutedEventArgs e)
        {
            ProductPage page = new ProductPage();
            page.SetId((long)this.Tag);
            mainWindow.productnavigator.Content = page;

           // GetAllProduct();
        }

       
    }
}
