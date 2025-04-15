using Newtonsoft.Json;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace Store.Helpers.DataProviders;

public class ProductDataProvider : INotifyPropertyChanged
{
    public static ObservableCollection<Product> Data { get; private set; } = [];

    private static ProductDataProvider? instance;

    public event PropertyChangedEventHandler? PropertyChanged;

    public static ProductDataProvider Init()
    {
        instance ??= new ProductDataProvider();

        return instance;
    }

    public async Task LoadDataAsync()
    {
        try
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(GlobalConst.DEFAULT_PRODUCT_JSON_PATH);
            string json = await FileIO.ReadTextAsync(file);

            Thread.Sleep(2000);

            Data = [.. JsonConvert.DeserializeObject<Product[]>(json)!];
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Data)));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }
    }
}