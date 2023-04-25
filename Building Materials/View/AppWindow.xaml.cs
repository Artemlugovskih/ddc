using Building_Materials.Entity;
using Building_Materials.ViewModel;
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

namespace Building_Materials.View
{
    /// <summary>
    /// Логика взаимодействия для AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddOrEditWindow(null);
            addWindow.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
