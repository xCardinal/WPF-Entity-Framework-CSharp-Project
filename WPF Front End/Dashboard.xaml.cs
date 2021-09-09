using Data;
using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;
using BusinessLayer;

namespace WPF_Front_End
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private Brains _mainBrain = new Brains();

        public Dashboard instance;
        public Dashboard()
        {
            InitializeComponent();
            SetUser();
            instance = this;
        }

        public void SetUser()
        {
            _mainBrain.LoadUser();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
        private void SelectionChangedMethod(object sender, SelectionChangedEventArgs e)
        {
            _mainBrain.SetSelectedMovie(listOfMoviesBox.SelectedItem);
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            //Ok Button

            if (txtSearch.Text == "/movies")
            {
                //Display all movies
                RetrieveAllTitles();
            }
            else if (txtSearch.Text == "/love")
            {
                //Display list of fav movies
                LoadFavouriteTitles();
            }
            else if (txtSearch.Text.ToLower() == "/mischief managed") Application.Current.Shutdown();
            else if (txtSearch.Text.ToLower() == "/exit") Application.Current.Shutdown();
            else if (txtSearch.Text != string.Empty)
            {
                //Retrieve txtSearch.Text movie from db.
                listOfMoviesBox.ItemsSource = _mainBrain.RetrieveMovie(txtSearch.Text);
            }
        }
        
        private void Add_Remove_Favourite(object sender, RoutedEventArgs e)
        {
            _mainBrain.AddRemoveFavourite();
            if(!_mainBrain.RetrieveFavourites.Contains(_mainBrain.SelectedMovie))
            {
                LoadFavouriteTitles();
            }
        }
        private void LoadMovies(object sender, RoutedEventArgs e)
        {
            RetrieveAllTitles();
        }
        public void LoadFavouriteTitles(object sender, RoutedEventArgs e)
        {
            LoadFavouriteTitles();
        }
        public void LoadFavouriteTitles()
        {
            listOfMoviesBox.ItemsSource = _mainBrain.RetrieveFavourites;
        }
        public void RetrieveAllTitles()
        {
            listOfMoviesBox.ItemsSource = _mainBrain.RetrieveAll();
        }

        private void TrailerMethod(object sender, RoutedEventArgs e)
        {
            if (_mainBrain.SelectedMovie == null) return;
            if(_mainBrain.SelectedMovie.VideoPath == null)
            {
                MessageBox.Show("Trailer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Main.Content = new Page1(this, _mainBrain.SelectedMovie);
            ToggleTrailer();
        }
        public void ToggleTrailer()
        {
            //Dim the screen 
            DimImage.Visibility = DimImage.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            //Show Page
            Main.Visibility = Main.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
