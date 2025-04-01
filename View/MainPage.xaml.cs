using Store.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Store
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ImagePickPage));
        }
    }
}
