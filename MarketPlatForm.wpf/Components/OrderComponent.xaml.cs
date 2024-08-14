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
    /// Interaction logic for OrderComponent.xaml
    /// </summary>
    public partial class OrderComponent : UserControl
    {
        decimal Price;
        public OrderComponent()
        {
            InitializeComponent();
        }
        public void SetValue(string describtion,decimal price)
        {
            describtion_txt.Text = describtion;
            price_txt.Text=price.ToString();
            TotalPrice_txt.Text = price.ToString(); 
            Price = price;
        }

        private void minus_btn_Click(object sender, RoutedEventArgs e)
        {
            int cnt=int.Parse(count_txt.Text);
            if(cnt>1)
            {
                cnt--;
                count_txt.Text = cnt.ToString();
                TotalPrice_txt.Text = (cnt * Price).ToString();
            }
            if(cnt<=0)
            {
                cnt = 1;
                count_txt.Text = cnt.ToString();
                TotalPrice_txt.Text = (cnt * Price).ToString();
            }
        }

        private void plus_btn_Click(object sender, RoutedEventArgs e)
        {
            int cnt=int.Parse(count_txt.Text);
            cnt++;
            count_txt.Text = cnt.ToString();
            TotalPrice_txt.Text = (cnt * Price).ToString();

        }
    }
}
