
using Store.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Store.View;

public sealed partial class ProductCard : UserControl, INotifyPropertyChanged
{
    private ProductViewModel? product;
    public ProductViewModel? Product 
    { 
        get => product; 
        set
        {
            product = value;

            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private Action<object, ProductViewModel?>? onClick;

    public ProductCard()
    {
        InitializeComponent();
    }

    public ProductCard(ProductViewModel productViewModel, Action<object, ProductViewModel?> onClick) : this()
    {
        Product = productViewModel;

        this.onClick = onClick;
    }

    private void OnPropertyChanged([CallerMemberName] string property = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    private void Grid_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        onClick?.Invoke(this, product);
    }
}
