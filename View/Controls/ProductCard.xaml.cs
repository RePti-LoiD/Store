
using Store.Model;
using Store.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Store.View;

public sealed partial class ProductCard : UserControl, INotifyPropertyChanged
{
    private ProductViewModel? product;
    private CartViewModel? cart;
    
    public ProductViewModel? Product 
    { 
        get => product; 
        set
        {
            product = value;

            OnPropertyChanged();
        }
    }

    public CartViewModel? Cart
    {
        get => cart;
        set
        {
            cart = value;

            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private Action<object, ProductViewModel?, UIElement>? onClick;

    private Visibility ButtonVisibility
    {
        get => IsButtonVisible();
    }

    private Visibility AppenderVisibility
    {
        get => IsButtonVisible() == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }

    private int ProductInCartCount
    {
        get
        {
            if (cart!.Products.ContainsKey(Product!.Product))
                return cart!.Products[Product!.Product];

            return 0;
        }

    }

    public ProductCard()
    {
        InitializeComponent();
    }

    public ProductCard(ProductViewModel productViewModel, CartViewModel cart, Action<object, ProductViewModel?, UIElement> onClick) : this()
    {
        Product = productViewModel;
        Cart = cart;

        this.onClick = onClick;
    }

    private void OnPropertyChanged([CallerMemberName] string property = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    private void Grid_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        onClick?.Invoke(this, product, ProductCardImage);
    }

    private Visibility IsButtonVisible()
    {
        if (Cart!.Products.ContainsKey(Product!.Product))
            return Visibility.Collapsed;

        return Visibility.Visible;
    }

    private void AddButtonClick(object sender, RoutedEventArgs e)
    {
        Cart!.AddProduct(Product!.Product);
        
        UpdateBinds();
    }

    private void IncrementButtonClick(object sender, RoutedEventArgs e)
    {
        Cart!.IncrementProduct(Product!.Product);

        UpdateBinds();
    }

    private void DecrementButtonClick(object sender, RoutedEventArgs e)
    {
        Cart!.DecrementProduct(Product!.Product);
        UpdateBinds();
    }

    private void UpdateBinds()
    {
        OnPropertyChanged(nameof(ButtonVisibility));
        OnPropertyChanged(nameof(AppenderVisibility));
        OnPropertyChanged(nameof(ProductInCartCount));
    }
}
