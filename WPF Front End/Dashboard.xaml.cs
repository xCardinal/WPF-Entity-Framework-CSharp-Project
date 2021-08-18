using BusinessLayer;
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

namespace WPF_Front_End
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private Brains _mainBrain = new Brains();
        public Dashboard()
        {
            InitializeComponent();
            RetreiveMovies();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
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
        public void RetreiveMovies()
        {
            //listOfMovies.ItemsSource = _mainBrain.ListOfMovies();
            listOfMovies.ItemsSource = _mainBrain.RetrieveAll();
        }

        private void UpdateMovieList(object sender, RoutedEventArgs e)
        {
            RetreiveMovies();
        }

        private void listOfMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
