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
using Data;

namespace WPF_Front_End
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Dashboard reference;
        public Page1(Dashboard instance, Movie selectedMovie)
        {
            InitializeComponent();
            reference = instance;
            if (selectedMovie != null)
                {
                MyMediaElement.MediaFailed += MyMediaElement_MediaFailed;
                MyMediaElement.LoadedBehavior = MediaState.Play;
                MyMediaElement.Source = new Uri(@selectedMovie.VideoPath);
                //MyMediaElement.Source =
                //    new Uri(@"https://drive.google.com/file/d/1gl-fQpVPpAXLhNiiLAdKv-zcvedksXtT/view?usp=sharing", UriKind.Absolute);
                //
            };
            
        }

        void MyMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }

        private void CloseTrailer(object sender, RoutedEventArgs e)
        {
            reference.ToggleTrailer();
        }
    }
}
