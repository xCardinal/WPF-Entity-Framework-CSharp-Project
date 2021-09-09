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
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using BusinessLayer;

namespace WPF_Front_End
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brains _mainBrain = new Brains();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btwLogin_Click(object sender, RoutedEventArgs e)
        {
            if(_mainBrain.Login(txtUsername.Text.ToLower(), txtPassword.Password))
            {
                //MessageBox.Show("Login Successfully","Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("Account Details Wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try 
            {
                DragMove();
            }
            catch
            {

            }
            
        }
        private void LinkedIn(object sender, RoutedEventArgs e)
        {
            string linkedInPath = "https://www.linkedin.com/in/sergio-pessegueiro/";
            //System.Diagnostics.Process.Start("iexplorer.exe", linkedInPath);


            //string defaultBrowserPath = GetDefaultBrowserPath();

            //try

            //{

            //    // launch default browser

            //    Process.Start(defaultBrowserPath, linkedInPath);

            //}

            //catch (Exception exp)

            //{

            //    MessageBox.Show(exp.Message);

            //}

            Process p = new Process();

            p.StartInfo.FileName = GetDefaultBrowserPath();

            p.StartInfo.Arguments = linkedInPath;

            p.Start();

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtwRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewUsername.Text == string.Empty || txtNewPassword.Password == string.Empty)
            {
                MessageBox.Show("Fields can not be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (_mainBrain.Create(txtNewUsername.Text, txtNewPassword.Password))
            {
                MessageBox.Show("Registration Complete", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            else
            {
                MessageBox.Show("Username is taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private static string GetDefaultBrowserPath()

        {

            string key = @"htmlfile\shell\open\command";

            RegistryKey registryKey =

            Registry.ClassesRoot.OpenSubKey(key, false);

            // get default browser path

            return ((string)registryKey.GetValue(null, null)).Split('"')[1];

        }
    }
}
