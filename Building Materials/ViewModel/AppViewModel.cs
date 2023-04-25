using Building_Materials.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building_Materials.ViewModel
{
    public class AppViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {


                _products = value;
                OnPropertyChanged(nameof(Products));

            }
        }
        public AppViewModel()
        {
            Initialize();
            LoadData();
        }

        private void Initialize()
        {
            Products = new ObservableCollection<Product>();
        }

        public void LoadData()
        {
            Products.Clear();
            using (var db = new TradeEntities())
            {
                var _productList = db.Product.ToList();
                _productList.ForEach(u => Products.Add(u));
            }
        }
    }
}
