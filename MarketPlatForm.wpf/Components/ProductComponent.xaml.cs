using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Pages;
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
using static System.Net.Mime.MediaTypeNames;

namespace MarketPlatForm.wpf.Components
{
    /// <summary>
    /// Interaction logic for ProductComponent.xaml
    /// </summary>
    public partial class ProductComponent : UserControl
    {
        
        string path;
        MainWindow mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;


        public ProductComponent()
        {
            InitializeComponent();
        }

        public void SetData(Product product)
        {
            path=product.ImagePath;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.EndInit();

            // Image elementiga yuklash
            MyImage.Source = bitmap;
            Product_name.Text= product.Name;
            describtion_txt.Text= product.Description;  

        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            OrderPage page = new OrderPage();
            page.SetId((long)this.Tag);
            mainWindow.OrderNavigator.Content = page;

        }
    }
}
