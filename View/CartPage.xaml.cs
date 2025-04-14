using Store.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Store.View;

public sealed partial class CartPage : Page
{
    private CartViewModel cart;

    public CartPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("DirectConnectedAnimation");
        if (anim != null)
            anim.TryStart(MainGrid);

        if (e.Parameter is CartViewModel cartViewModel)
            cart = cartViewModel;
    }
}
