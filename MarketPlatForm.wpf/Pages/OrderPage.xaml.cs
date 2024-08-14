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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        IProductService productService;
        long productId;

        public OrderPage()
        {
            InitializeComponent();
            this.productService=new MarketPlatForm.wpf.Service.Services.ProductService();
            GetProduct();
        }
        public void SetId(long Id)
        {
            productId = Id;
        }

        public async void GetProduct()
        {
            List<Product> products = new List<Product>();
            products = await productService.GetAll();

            var product=products.FirstOrDefault(a=>a.Id==productId);

            order_list.Visibility = Visibility.Visible;
            order_list.Children.Clear();
            OrderComponent orderComponent = new OrderComponent();
            orderComponent.Tag = product.Id;
            orderComponent.SetValue(product.Description, product.Price);
            orderComponent.Margin=new Thickness(10, 10, 3, 0);
            order_list.Children.Add(orderComponent);
        }
    }
}
