using BusinessLayer;
using Data;
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
        }

        public void SetUser()
        {
            //_mainBrain.SelectedUser
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
            listOfMoviesBox.ItemsSource = _mainBrain.RetrieveAll();
        }

        private void UpdateMovieList(object sender, RoutedEventArgs e)
        {
            //RetreiveMovies();
        }

        private void SelectionChangedMethod(object sender, SelectionChangedEventArgs e)
        {
            _mainBrain.SetSelectedMovie(listOfMoviesBox.SelectedItem);
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            //Ok Button

            if(txtSearch.Text == "/movies")
            {
                //Display all movies
                listOfMoviesBox.ItemsSource = _mainBrain.RetrieveAll();
            }
            else if(txtSearch.Text == "/love")
            {
                //Display list of fav movies
                listOfMoviesBox.ItemsSource = _mainBrain.RetrieveFavourites();
            }
            else if(txtSearch.Text != string.Empty)
            {
                //Retrieve txtSearch.Text movie from db.
                listOfMoviesBox.ItemsSource = _mainBrain.RetrieveMovie(txtSearch.Text);  
            }
        }

        private void Add_Remove_Favourite(object sender, RoutedEventArgs e)
        {
            _mainBrain.AddRemoveFavourite();
        }
    }
}
