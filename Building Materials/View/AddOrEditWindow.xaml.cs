using Building_Materials.Entity;
using Building_Materials.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace Building_Materials.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditWindow.xaml
    /// </summary>
    public partial class AddOrEditWindow : Window
    {
        private Product product = new Product();
        public AddOrEditWindow(System.Collections.ObjectModel.ObservableCollection<Product> selectedProduct)
        {
            InitializeComponent();
            foreach (var item in App.Current.Windows)
            {
                if (item is AppWindow)
                {
                    Owner = (AppWindow)item;
                }
            }
            if (selectedProduct != null)
            {
                product = selectedProduct.FirstOrDefault();
            }
            DataContext = product;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new TradeEntities())
            {

                db.Product.AddOrUpdate(DataContext as Product);
                db.SaveChanges();
                ((Owner as AppWindow).DataContext as AppViewModel).LoadData();

                Close();
            }
        }
    }
}
