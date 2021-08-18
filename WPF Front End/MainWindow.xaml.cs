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
using BusinessLayer;
using System.Data.SqlClient;
using System.Configuration;

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
            if(_mainBrain.Login(txtUsername.Text, txtPassword.Password))
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtwRegister_Click(object sender, RoutedEventArgs e)
        {
            if (_mainBrain.Create(txtNewUsername.Text, txtNewPassword.Password))
            {
                MessageBox.Show("Registration Complete", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Username is taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
