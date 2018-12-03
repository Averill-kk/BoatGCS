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
        GpsDataContext dbcontext = new GpsDataContext("null");
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
            

            var mainWindow = new MainWindow();
            string connectionString = String.Format("Data Source={0};Initial Catalog=GpsData;Integrated Security=True;Pooling=False",connectionAddressTextBox.Text);
            try
            {
                dbcontext = new GpsDataContext(connectionString);
                mainWindow.ChangeDataBaseContex(dbcontext);
                mainWindow.UpdateDataGrid();
            }
            catch (Exception ex) {
                MessageBox.Show( "Ошибка подключения к базе данных, проверьте правильность написания IP-адреса", "Ошибка подключения",
MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }

    }
}
