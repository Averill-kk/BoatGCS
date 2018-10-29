using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoatGCS.Utils
{
    [Serializable]
    public class ConnectionString : INotifyPropertyChanged
    {
        public static readonly string DefaultDatabase = "GpsData";
        private static XmlSerializer _serializer = null;
        private static string _connDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + DefaultDatabase;
        private static string _connFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + DefaultDatabase + @"\ConnectionString.xml";


        private ConnectionString()
        {
            this.ConnectMode = 0;
            this.NotShow = true;

        }

        public static String DefaultConnectionString
        {
            get
            {
                // По-умолчанию локальное соединение
                System.Data.SqlClient.SqlConnectionStringBuilder builder =
                new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.DataSource = string.Format(@".\SQLEXPRESS");
                builder.IntegratedSecurity = true;
                builder.InitialCatalog = DefaultDatabase;
                builder.MultipleActiveResultSets = true;
                return builder.ConnectionString;
            }
        }

        public static ConnectionString _current;
        public static ConnectionString Current
        {
            get
            {
                if (_current == null)
                {
                    _serializer = new XmlSerializer(typeof(ConnectionString));
                    _current = new ConnectionString();
#if LOCAL
                    // локальное соединение
                    System.Data.SqlClient.SqlConnectionStringBuilder builder =
        new System.Data.SqlClient.SqlConnectionStringBuilder();
                    builder.DataSource = string.Format(@".\SQLEXPRESS");
                    builder.IntegratedSecurity = true;
                    builder.InitialCatalog = DefaultDatabase;
                    builder.MultipleActiveResultSets = true;
                    _current.Connection = builder.ConnectionString;
#else
                    try
                    {
                        if (File.Exists(_connFile))
                        {
                            using (var fs = File.OpenRead(_connFile))
                            {
                                _current = _serializer.Deserialize(fs) as ConnectionString;
                            }
                        }
                    }
                    catch
                    {
                    }

#endif
                }
                return _current;
            }
            set
            {
                _current = value;
                using (FileStream fs = File.Create(_connFile))
                {
                    _serializer.Serialize(fs, _current);
                }
            }
        }

        private string _ipconnect;
        public string IPconnect
        {
            get
            {
                return _ipconnect;
            }
            set
            {
                if (_ipconnect != value)
                {
                    _ipconnect = value;
                    OnPropertyChanged("IPconnect");
                }
            }
        }

        private string _connection;
        public string Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (_connection != value)
                {
                    _connection = value;
                    OnPropertyChanged("Connection");
                }
            }
        }

        private bool _notShow;
        public bool NotShow
        {
            get
            {
                return _notShow;
            }
            set
            {
                _notShow = value;
                OnPropertyChanged("NotShow");
            }

        }

        private int _connectmode;
        public int ConnectMode
        {
            get
            {
                return _connectmode;
            }
            set
            {
                if (_connectmode != value)
                {
                    _connectmode = value;
                    OnPropertyChanged("ConnectMode");
                }

            }
        }

        public void SaveConnectionString()
        {
            if (!Directory.Exists(_connDirectory))
                Directory.CreateDirectory(_connDirectory);

            using (FileStream fs = File.Create(_connFile))
                _serializer.Serialize(fs, this);
        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion //INotifyPropertyChanged
    }
}
