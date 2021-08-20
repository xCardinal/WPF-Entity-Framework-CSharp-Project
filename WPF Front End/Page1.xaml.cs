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

namespace WPF_Front_End
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Dashboard reference;
        public Page1(Dashboard instance)
        {
            InitializeComponent();
            reference = instance;
        }

        private void CloseTrailer(object sender, RoutedEventArgs e)
        {
            reference.ToggleTrailer();
        }
    }
}
