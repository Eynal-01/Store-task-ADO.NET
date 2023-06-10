using Store_task_ADO.NET.Commands;
using Store_task_ADO.NET.Models;
using Store_task_ADO.NET.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Store_task_ADO.NET.ViewModels
{
    public class ProductUCViewModel : BaseViewModel
    {
        public RelayCommand MoreCommand { get; set; }

        public Product Product { get; set; }

        public ProductUCViewModel(Product _product)
        {
            Product = _product;

            MoreCommand = new RelayCommand((e) =>
            {
                var aboutProductView = new AboutProductWindow();
                var aboutProductViewModel = new AboutProductViewModel(Product, aboutProductView);
                aboutProductView.DataContext = aboutProductViewModel;
                aboutProductView.Show();
            });
        }
    }
}