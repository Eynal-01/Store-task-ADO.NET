using Store_task_ADO.NET.Commands;
using Store_task_ADO.NET.Models;
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
            //ImageSource = Helpers.ImageHelpers.StringToImageSource(Product.Image);

            MoreCommand = new RelayCommand((e) =>
            {
                var aboutProductView = new MoreAboutProductWindow();
                var aboutProductViewModel = new MoreAboutProductWindowViewModel(Product, ImageSource, aboutProductView);
                aboutProductView.DataContext = aboutProductViewModel;
                aboutProductView.Show();
            });
        }
    }
}
