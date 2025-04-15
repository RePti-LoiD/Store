using Store.Helpers.DataProviders;
using Store.View;
using Store.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Store;

public sealed partial class MainPage : Page, INotifyPropertyChanged
{
    private ObservableCollection<ProductViewModel> products = new();
    private CartViewModel cart;
    private ProductDataProvider productDataProvider;

    private bool isLoad;
    public bool IsLoad
    {
        get => isLoad;
        set
        {
            isLoad = value;

            OnPropertyChanged();
        }
    }

    private static UIElement? lastSelected;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainPage()
    {
        InitializeComponent();

        cart = CartViewModel.Init();
        
        productDataProvider = ProductDataProvider.Init();

        _ = DispatcherQueue.GetForCurrentThread().TryEnqueue(DispatcherQueuePriority.Low, async () =>
        {
            await productDataProvider!.LoadDataAsync();

            Debug.WriteLine(ProductDataProvider.Data);
            Debug.WriteLine(ProductDataProvider.Data.Count);

            products = new(ProductDataProvider.Data.Select(x => new ProductViewModel(x)));

            foreach (var product in products)
                Grid.Items.Add(new ProductCard(product, cart, LaunchProductPage));

            IsLoad = true;
        });
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("DirectConnectedAnimation");
        if (anim != null && lastSelected != null)
            anim.TryStart(lastSelected);
    }

    private void LaunchCartPage(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(TestShimmerPage));
    }

    public void LaunchProductPage(object sender, ProductViewModel? productViewModel, UIElement uIElement)
    {
        lastSelected = uIElement;

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("DirectConnectedAnimation", lastSelected);
        Frame.Navigate(typeof(ProductPage), productViewModel, new DrillInNavigationTransitionInfo());
    }

    private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        List<string> submittedProducts;

        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var userValue = sender.Text.ToLower().Replace(" ", "");

            submittedProducts = products.Select(x => x.Name).Where(x => x.ToLower().Replace(" ", "").Contains(userValue)).ToList();
        }
        else
        {
            submittedProducts = new List<string>();
        }

        sender.ItemsSource = submittedProducts;
    }

    private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (args.SelectedItem != null)
            sender.Text = args.SelectedItem.ToString();
    }

    private void AutoSuggestBox_QuerrySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.QueryText != null)
            LaunchProductPage(this, products.Where(x => x.Name.Equals(args.QueryText)).First(), lastSelected);
    }

    private void OnPropertyChanged([CallerMemberName] string property = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    private Visibility BoolToVisibility(bool value) => 
        value ? Visibility.Visible : Visibility.Collapsed;
    private Visibility ReverseVisibility(Visibility visibility) => 
        visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    private Visibility ReverseVisibility(bool value) => BoolToVisibility(!value);
}