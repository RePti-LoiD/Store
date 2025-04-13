using Store.ViewModel;
using Windows.UI.Xaml.Controls;

namespace Store.View;

public sealed partial class ProductPage : Page
{
    private ProductViewModel productViewModel = new()
    {
        Name = "Тортик",
        Description = "Description",
        Category = "Category",
        Commentaries = [],
        Pictures = [new("/Resources/chocolate_cake.jpg")]
    };

    public ProductPage()
    {
        InitializeComponent();
    }

    private void PipsPager_SelectedIndexChanged(Microsoft.UI.Xaml.Controls.PipsPager sender, Microsoft.UI.Xaml.Controls.PipsPagerSelectedIndexChangedEventArgs args)
    {
        //ImageFlipView.SelectedIndex = sender.SelectedPageIndex;
    }
}
