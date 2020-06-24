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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace TOOLS
{

    class DatabaseInfo
    {
        private string _Name = "";
        private string _Ip = "";

        public string Name
        {
            get
            {
                return _Name;

            }

        }

        public string Ip
        {
            get
            {
                return _Ip;
            }

        }

        public DatabaseInfo(String ShowText, String RealVal)
        {
            _Name = ShowText;
            _Ip = RealVal;

        }
        public override string ToString()
        {
            return _Ip.ToString();
        }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "查询工具";

            List<DatabaseInfo> databaseInfos = new List<DatabaseInfo>();
            databaseInfos.Add(new DatabaseInfo("三江南", "111.1111.111.111"));
            databaseInfos.Add(new DatabaseInfo("大浪", "222.222.222。222"));
            databaseInfos.Add(new DatabaseInfo("融安", "222.222.222。222"));
            databaseInfos.Add(new DatabaseInfo("融水", "222.222.222。222"));
            databaseInfos.Add(new DatabaseInfo("潭头", "222.222.222。222"));
            databaseInfos.Add(new DatabaseInfo("柳城东", "222.222.222。222"));
            databaseInfos.Add(new DatabaseInfo("凤山", "222.222.222。222"));
            DataBaseChoose.ItemsSource = databaseInfos;
            DataBaseChoose.DisplayMemberPath = "Name";
            
        }
        public string DatabaseIp;

        private void DataBaseChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Title = DataBaseChoose.SelectedValue.ToString();
           DatabaseIp= DataBaseChoose.SelectedValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataBaseChoose.SelectedIndex == -1)
            {
                MessageBox.Show("请选择服务器");
            }
            else
            {
                MessageBox.Show(DatabaseIp);
            }
        }
    }
}