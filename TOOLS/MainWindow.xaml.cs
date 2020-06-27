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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;

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
            databaseInfos.Add(new DatabaseInfo("127", "127.0.0.1"));
            DataBaseChoose.ItemsSource = databaseInfos;
            DataBaseChoose.DisplayMemberPath = "Name";

        }
        string DatabaseIp;

        private void DataBaseChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Title = DataBaseChoose.SelectedValue.ToString();
            DatabaseIp = DataBaseChoose.SelectedValue.ToString();
           
        }

      

        string Connection = "server=127.0.0.1; uid=root;" +
                "pwd=12345;database=test";

        private string Get_connection()
        {
            
            string connstr = "server="+DatabaseIp +"; uid=root;pwd=12345;database=test";

                return connstr;

        }
        

        //检查下拉框选择
        private void Check_DataBaseChoose()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Check_DataBaseChoose();
        }

        public String Strconn;
        private void Select_all(String Connection)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            conn.ConnectionString = Connection;

            try
            {
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM `laneheartbeat`;";
                cmd.Prepare();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM `laneheartbeat`", conn);

                Log_Textblock.Text = cmd.ExecuteScalar().ToString();
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable dt = new DataTable();
                sda.Fill(ds, "dt");
                Result_DataGrid.DataContext = ds;


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error");
            }



        }


        private void get_1k_resule(String Connection)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            conn.ConnectionString = Connection;

            try
            {
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM `laneheartbeat`;";
                cmd.Prepare();

                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM `laneheartbeat` LIMIT 500", conn);

                Log_Textblock.Text = cmd.ExecuteScalar().ToString();
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable dt = new DataTable();
                sda.Fill(ds, "dt");
                Result_DataGrid.DataContext = ds;
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error");
            }


        }


        //数据库连接
        private void Connect_Database()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=12345;database=test";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
             
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            Select_all(Get_connection());
            
        }
         
        private void Get_1k_Button_Click(object sender, RoutedEventArgs e)
        {
            get_1k_resule(Connection);
        }


    }
}