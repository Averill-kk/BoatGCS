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
using System.Data.Entity;
using BoatGCS.Entities;

namespace BoatGCS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GpsDataContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new GpsDataContext();
            db.GpsDatas.Load();
            gpsDataGrid.ItemsSource = db.GpsDatas.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.GpsDatas.Load();
            gpsDataGrid.ItemsSource = db.GpsDatas.Local.ToBindingList();
        }
    }
}
