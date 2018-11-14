using BoatGCS.Entities;
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
using BoatGCS.Utils;

namespace BoatGCS
{
    /// <summary>
    /// Логика взаимодействия для ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dbcontext = new GpsDataContext();
            dbcontext.ChangeDatabase(
                initialCatalog: "name-of-another-initialcatalog",
                dataSource: @".\sqlexpress" // could be ip address 120.273.435.167 etc
                );
            var mainWindow = new MainWindow();
            mainWindow.ChangeDataBaseContex(dbcontext);
            this.Close();
        }
    }
}
