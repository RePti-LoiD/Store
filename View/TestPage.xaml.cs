using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Store.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public ObservableCollection<InventoryItem> InventoryItems { get; set; } = new()
    {
        new()
        {
            Id = 1002,
            Name = "Hydra",
            Description = "Multiple Launch Rocket System-2 Hydra",
            Quantity = 1,
        },
        new()
        {
            Id = 3456,
            Name = "MA40 AR",
            Description = "Regular assault rifle - updated version of MA5B or MA37 AR",
            Quantity = 4,
        },
        new()
        {
            Id = 5698,
            Name = "Needler",
            Description = "Alien weapon well-known for its iconic design with pink crystals",
            Quantity = 2,
        },
        new()
        {
            Id = 7043,
            Name = "Ravager",
            Description = "An incendiary plasma launcher",
            Quantity = 1,
        },
        // TODO: Add more items, maybe abstract these to a helper for other samples?
    };

        public TestPage()
        {
            InitializeComponent();
        }

    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
