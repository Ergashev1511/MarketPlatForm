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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        IProductService productService;
        List<Product> products=new List<Product>();
        long iD;
        public ProductPage()
        {
            InitializeComponent();
            this.productService=new MarketPlatForm.wpf.Service.Services.ProductService();
            GetAllProduct();
        }
        public void SetId(long id)
        {
            iD=id;
        }
        public async void GetAllProduct()
        {
            
            products = await productService.GetAll();
           List<Product> product=products.Where(a=>a.CateogryId==iD).ToList();

            Product_list.Visibility = Visibility.Visible;
           Product_list.Children.Clear();
            foreach (Product p in product)
            {
                ProductComponent productComponent = new ProductComponent();
                productComponent.Tag = p.Id;
                productComponent.SetData(p);
                productComponent.Margin = new Thickness(8);
                Product_list.Children.Add(productComponent);
            }
        }

    }
}
