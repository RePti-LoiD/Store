using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Store.View;

public sealed partial class TestShimmerPage : Page, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    

    public TestShimmerPage()
    {
        InitializeComponent();
    }

    private Visibility ReverseVisibility(Visibility vis) => vis switch
    {
        Visibility.Collapsed => Visibility.Visible,
        Visibility.Visible => Visibility.Collapsed,
        _ => throw new System.NotImplementedException(),

    };

    private Visibility BoolToVisibility(bool value) => value ? Visibility.Visible : Visibility.Collapsed;
}