using CommunityToolkit.Labs.WinUI.MarkdownTextBlock;
using Store.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Store.View;

public sealed partial class ProductPage : Page
{
    private ProductViewModel productViewModel;

    public ProductPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is ProductViewModel productViewModel)
        {
            this.productViewModel = productViewModel;
            MarkdownTextBlock.Config = new MarkdownConfig();
        }
    }

    private void PipsPager_SelectedIndexChanged(Microsoft.UI.Xaml.Controls.PipsPager sender, Microsoft.UI.Xaml.Controls.PipsPagerSelectedIndexChangedEventArgs args)
    {
        ImageFlipView.SelectedIndex = sender.SelectedPageIndex;
    }
}
