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
        //private Program _mainProgram = new Program();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btwLogin_Click(object sender, RoutedEventArgs e)
        {
            //Do nothing
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
    }
}
