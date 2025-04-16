using CommunityToolkit.Labs.WinUI.MarkdownTextBlock;
using Store.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Store.View;

public sealed partial class ProductPage : Page, INotifyPropertyChanged
{
    private ProductViewModel productViewModel;
    private CartViewModel cart;

    public CartViewModel Cart 
    { 
        get => cart; 
        set
        {
            cart = value;

            OnPropertyChanged();
        }
    }
    public ProductViewModel Product 
    { 
        get => productViewModel; 
        set
        {
            productViewModel = value;

            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ProductPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("DirectConnectedAnimation");
        if (anim != null)
            anim.TryStart(ImageFlipView);

        if (e.Parameter is ProductViewModel productViewModel)
        {
            this.Product = productViewModel;
            MarkdownTextBlock.Config = new MarkdownConfig();
            Cart = CartViewModel.Init();
        }
    }

    private void PipsPager_SelectedIndexChanged(Microsoft.UI.Xaml.Controls.PipsPager sender, Microsoft.UI.Xaml.Controls.PipsPagerSelectedIndexChangedEventArgs args)
    {
        ImageFlipView.SelectedIndex = sender.SelectedPageIndex;
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("DirectConnectedAnimation", ImageFlipView);
        Frame.GoBack(new DrillInNavigationTransitionInfo());
    }

    private void OnPropertyChanged([CallerMemberName] string property = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}
