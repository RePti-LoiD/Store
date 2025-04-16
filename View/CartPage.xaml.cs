using Store.View.Controls;
using Store.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Store.View;

public sealed partial class CartPage : Page
{
    private CartViewModel Cart;

    public CartPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        Cart = CartViewModel.Init();

        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("DirectConnectedAnimation");
        if (anim != null)
            anim.TryStart(MainGrid);

        foreach (var product in Cart.Products)
            ProductList.Items.Add(new ProductItemCart(Cart, product.Key, (_, product) => Frame.Navigate(typeof(ProductPage), new ProductViewModel(product))));
    }

    private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        Frame.GoBack();
    }
}
