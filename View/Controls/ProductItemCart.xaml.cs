using Store.Model;
using Store.ViewModel;
using System;
using Windows.UI.Xaml.Controls;

namespace Store.View.Controls;

public sealed partial class ProductItemCart : UserControl
{
    private CartViewModel? cartViewModel;
    private Product? product;

    private Action<object, Product>? onClick;

    public ProductItemCart()
    {
        InitializeComponent();
    }

    public ProductItemCart(CartViewModel cartViewModel, Product product, Action<object, Product>? onClick = null) : this()
    {
        this.cartViewModel = cartViewModel;
        this.product = product;

        this.onClick = onClick;
    }

    private string CountOf() => 
        cartViewModel!.CountOf(product!).ToString();

    private string TotalCostOf() =>
        cartViewModel!.TotalCostOf(product!).ToString();

    private void LaunchProductPage(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e) =>
        onClick?.Invoke(sender, product!);
}