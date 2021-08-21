using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                //MyMediaElement.LoadedBehavior = MediaState.Play;
                MyMediaElement.Source = new Uri(@selectedMovie.VideoPath);
                MyMediaElement.Play();
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
            MyMediaElement.Stop();
            reference.ToggleTrailer();
        }
        private MediaState GetMediaState(MediaElement myMedia)
        {
            FieldInfo hlp = typeof(MediaElement).GetField("_helper", BindingFlags.NonPublic | BindingFlags.Instance);
            object helperObject = hlp.GetValue(myMedia);
            FieldInfo stateField = helperObject.GetType().GetField("_currentState", BindingFlags.NonPublic | BindingFlags.Instance);
            MediaState state = (MediaState)stateField.GetValue(helperObject);
            return state;
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(GetMediaState(MyMediaElement)==MediaState.Play)
            {
                MyMediaElement.Pause();
            }
            else
            {
                MyMediaElement.Play();
            }
            
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Stop();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Pause();
        }
    }
}
