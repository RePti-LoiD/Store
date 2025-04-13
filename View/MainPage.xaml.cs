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

            Loaded += OnMainPageLoaded;
        }

        private void OnMainPageLoaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage));
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
