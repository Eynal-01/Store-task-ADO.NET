using Store_task_ADO.NET.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Store_task_ADO.NET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid { get; internal set; }
        public static ObservableCollection<ProductUC> ProductViews { get; set; } = new ObservableCollection<ProductUC>();
    }
}
