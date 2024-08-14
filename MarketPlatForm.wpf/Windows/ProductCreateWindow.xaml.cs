using MarketPlatForm.Api.Models;
using MarketPlatForm.wpf.Service.IService;
using Microsoft.Win32;
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
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        IProductService productService;
        ICategoryService categoryService;
        string imagePath;
        List<Category> categories;

        public ProductCreateWindow()
        {
            InitializeComponent();
            this.productService=new MarketPlatForm.wpf.Service.Services.ProductService();
            this.categoryService=new MarketPlatForm.wpf.Service.Services.CategoryService();
            GetAllCategory(); 
        }


        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void Create_category_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CategoryCreateWindow categoryCreateWindow = new CategoryCreateWindow();
            categoryCreateWindow.ShowDialog();
        }

        private void image_upload_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                 imagePath = openFileDialog.FileName;
               // ImgStorage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
               // ImgIcon.Visibility = Visibility.Hidden;
            }
            //ImgIcon.Visibility = Visibility.Hidden;

        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name=productName_txt.Text;
            product.Description = describtion_txt.Text;
            product.Price =decimal.Parse(price_txt.Text);
            product.CateogryId = categories.Any() ? categories[categroy_combo.SelectedIndex].Id : 0;
            product.ImagePath=imagePath;
            if(product.ImagePath != null && productName_txt.Text!=string.Empty && describtion_txt.Text!=string.Empty && price_txt.Text != string.Empty) 
            {
                await productService.Create(product);
            } 
            else
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }

            productName_txt.Text = describtion_txt.Text = price_txt.Text = imagePath=string.Empty;
            this.Close();   
        }


        public async Task GetAllCategory()
        {
            categories = await categoryService.GetAll();
            if(categories !=null && categories.Any())
            {
                categroy_combo.ItemsSource = categories.Select(a=>a.CategoryName);
                categroy_combo.Items.Refresh();
            }
        }
    }
}
