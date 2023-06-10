using Store_task_ADO.NET.Commands;
using Store_task_ADO.NET.Models;
using Store_task_ADO.NET.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Store_task_ADO.NET.ViewModels
{
    public class AboutProductViewModel : BaseViewModel
    {
        public Window ProductWindow { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }

        public AboutProductViewModel(Product product, Window productWindow)
        {
            Product = product;
            ProductWindow = productWindow;

            DeleteCommand = new RelayCommand(async (d) =>
            {
                await DatabaseHelper.DeleteProductById(Product.Id);
                ProductWindow.Close();
                MessageBox.Show("Product was deleted successfully!");
                //DatabaseHelper.AddProductsToCollectionFromDatabase(400,20, ((App.MyGrid.Children[0] as HomePageUC).DataContext as HomePageUCViewModel).ProductViews);
                //DatabaseHelper.AddProductsToCollectionFromDatabase(400, 20, App.ProductViews);
                App.ProductViews.Remove(App.ProductViews.FirstOrDefault(p => p.Id.Text == Product.Id.ToString()));
                //var view = ProductViews.FirstOrDefault(p => (p.DataContext as ProductUCViewModel).Product.Id == Product.Id);
                //ProductViews.Remove(view);..
            });

            SaveChangesCommand = new RelayCommand(async (e) =>
            {
                await DatabaseHelper.UpdateProduct(product);
                ProductWindow.Close();
                MessageBox.Show("Product was updated successfully!");
            });
        }
    }
}
