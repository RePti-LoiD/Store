using Store.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Store.ViewModel;

public class CartViewModel : INotifyPropertyChanged
{
    private static CartViewModel instance;
    private static Dictionary<Product, int> products = [];

    public event PropertyChangedEventHandler? PropertyChanged;

    public Dictionary<Product, int> Products 
    {
        get => products; 
        private set
        {
            products = value;
            
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(Count));
        }
    }

    public int Count { get => products.Count; }

    public static CartViewModel Init()
    {
        instance ??= new CartViewModel();

        return instance;
    }

    private CartViewModel() { }

    public void AddProduct(Product product)
    {
        if (!Products.ContainsKey(product))
            Products[product] = 1;

        OnPropertyChanged(nameof(Products));
        OnPropertyChanged(nameof(Count));
    }

    public void IncrementProduct(Product product)
    {
        if (Products.ContainsKey(product))
            Products[product] += 1;
        else
            Products[product] = 1;

        OnPropertyChanged(nameof(Products));
        OnPropertyChanged(nameof(Count));
    }

    public void RemoveProduct(Product product)
    {
        if (!Products.ContainsKey(product)) return;

        Products.Remove(product);

        OnPropertyChanged(nameof(Products));
        OnPropertyChanged(nameof(Count));
    }

    public void DecrementProduct(Product product)
    {
        if (!Products.ContainsKey(product)) return;

        if (Products[product] == 1)
            Products.Remove(product);
        else
            Products[product] -= 1;

        OnPropertyChanged(nameof(Products));
        OnPropertyChanged(nameof(Count));
    }

    public Dictionary<Product, int> GetProductsInCart() => products;

    public void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}