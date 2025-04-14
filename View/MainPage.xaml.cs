using CommunityToolkit.Labs.WinUI.MarkdownTextBlock;
using Store.Model;
using Store.View;
using Store.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Store;

public sealed partial class MainPage : Page
{
    private readonly string mdDescription = @"# Описание торта  

### **Название**: Классический бисквитный торт с кремом  

### **Внешний вид**:  
Круглый торт диаметром ~20 см, высотой ~8 см. Состоит из 3–4 бисквитных слоёв, пропитанных сиропом, прослоенных нежным масляным или заварным кремом. Поверхность покрыта гладкой кремовой глазурью, украшена ягодами (клубника, малина), шоколадной стружкой или декором из мастики.  

### **Вкус и текстура**:  
- **Бисквит**: воздушный, слегка влажный, с ванильным или шоколадным вкусом.  
- **Крем**: сливочный, не приторный, с балансом сладости и легкой кислинки (если добавлены ягоды).  
- **Дополнительно**: возможны прослойки из фруктового джема или карамели.  

### **Вес/Размер**:  
- Стандартный: 1–1.5 кг (рассчитан на 6–8 персон).  
- Мини-версия: ~500 г (на 2–3 человек).  

### **Оформление**:  
Элегантный, но не перегруженный декор. Подходит для праздников (дни рождения, свадьбы) или семейного чаепития.  

**Примеры вариаций**:  
- «Медовик» с медовыми коржами и сметанным кремом.  
- «Красный бархат» с терпковатым вкусом какао и сливочным сыром.  ";

    private ObservableCollection<ProductViewModel> products = new();

    private static UIElement lastSelected;

    public MainPage()
    {
        InitializeComponent();

        Loaded += OnMainPageLoaded;
    }

    private void OnMainPageLoaded(object sender, RoutedEventArgs e)
    {
        var cake = new Product()
        {
            Name = "Тортик",
            Description = mdDescription,
            Rating = 4.3f,
            Cost = 799.99d,
            Provider = "ИП Ибрагимов",
            Category = "Кулинария",
            Commentaries = [],
            Tags = [
                "Кулинария",
                "Торты",
                "Бакалея"
            ],
            Pictures = [
                "ms-appx:///Resources/chocolate_cake_2.jpg",
                "ms-appx:///Resources/chocolate_cake.jpg",
                "ms-appx:///Resources/chocolate_cake_3.jpg"
            ],
            Specs = [
                new() {
                    SpecName = "Ккал",
                    SpecValue = "542"
                },
                new() {
                    SpecName = "Белки",
                    SpecValue = "8.5"
                },
                new() {
                    SpecName = "Жиры",
                    SpecValue = "37.7"
                },
                new() {
                    SpecName = "Углеводы",
                    SpecValue = "42.2"
                },
                new() {
                    SpecName = "Вес",
                    SpecValue = "700г"
                }
            ]
        };
        
        var cakeVM = new ProductViewModel(cake);
        
        var cakeVM2 = new ProductViewModel((cake.Clone() as Product)!);
        cakeVM2.Pictures[0] = cakeVM2.Pictures[2];
        cakeVM2.Name = "cakeVM2.Pictures[1]";

        products.Add(cakeVM);
        products.Add(cakeVM2);
        products.Add(cakeVM);

        foreach (var product in products)
            Grid.Items.Add(new ProductCard(product, LaunchProductPage));
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("DirectConnectedAnimation");
        if (anim != null && lastSelected != null)
            anim.TryStart(lastSelected);
    }

    public void LaunchProductPage(object sender, ProductViewModel? productViewModel)
    {
        lastSelected = (sender as UIElement)!;

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("DirectConnectedAnimation", lastSelected);
        Frame.Navigate(typeof(ProductPage), productViewModel, new DrillInNavigationTransitionInfo());
    }
}