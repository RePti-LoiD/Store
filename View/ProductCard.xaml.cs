using Store.Model;
using Store.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace Store.View;

public sealed partial class ProductCard : UserControl, INotifyPropertyChanged
{
    private ProductViewModel product;

    public ProductViewModel Product 
    { 
        get => product; 
        set
        {
            product = value;

            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public ProductCard()
    {
        InitializeComponent();

        Loaded += ProductCard_Loaded;
    }

    public ProductCard(ProductViewModel productViewModel) : this()
    {
        Product = productViewModel;
    }


    private void ProductCard_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        
    }

    private void OnPropertyChanged([CallerMemberName] string property = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}
