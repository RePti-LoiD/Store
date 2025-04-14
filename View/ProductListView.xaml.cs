using Store.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Store.View;

public sealed partial class ProductListView : Page
{
    private ObservableCollection<Product> products;

    public ProductListView()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is List<Product> products)
        {
            this.products = new ObservableCollection<Product>(products);
        }
    }
}
