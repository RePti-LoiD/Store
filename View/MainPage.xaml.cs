using Store.View;
using Store.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Store
{
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

        public MainPage()
        {
            InitializeComponent();

            Loaded += OnMainPageLoaded;
        }

        private void OnMainPageLoaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage), new ProductViewModel()
            {
                Name = "Тортик",
                Description = mdDescription,
                Rating = 4.3f,
                Provider = "ИП Ибрагимов",
                Category = "Кулинария",
                Commentaries = [],
                Tags = [
                    "Кулинария", 
                    "Торты", 
                    "Бакалея"
                ],
                Pictures = [
                    "ms-appx:///Resources/chocolate_cake.jpg", 
                    "ms-appx:///Resources/chocolate_cake_2.jpg", 
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
            });

            //Frame.Navigate(typeof(TestPage));
        }

        public void Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
