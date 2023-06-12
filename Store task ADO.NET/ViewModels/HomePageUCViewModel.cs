using Store_task_ADO.NET.Commands;
using Store_task_ADO.NET.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Store_task_ADO.NET.Helpers;
using System;
using Store_task_ADO.NET.Models;

namespace Store_task_ADO.NET.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand MoreCommand { get; set; }

        public ObservableCollection<ProductUC> ProductViews { get; set; } = new ObservableCollection<ProductUC>();
        public TextBox SearchTb { get; set; }

        public HomePageUCViewModel()
        {
            App.ProductViews = ProductViews;
            DatabaseHelper.AddProducts(ProductViews);

            MoreCommand = new RelayCommand((uc) =>
            {
                var uc2 = uc;

            });

            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == "Search . . .")
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = "Search . . .";
                }
            });
        }
    }
}
