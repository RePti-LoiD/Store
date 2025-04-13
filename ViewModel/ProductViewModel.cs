﻿using Store.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Store.ViewModel;

public class ProductViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Product product { get; set; } = new Product()
    {
        Name = "NULL",
        Description = "NULL",
        Category = "NULL",
        Provider = "ИП Ибрагимов",
        Commentaries = [],
        Specs = [],
        Tags = [],
        Pictures = ["/Resources/chocolate_cake.jpg", "/Resources/chocolate_cake2.jpg"]
    };

    public ProductViewModel() { }

    public ProductViewModel(Product product)
    {
        this.product = product;
    }

    private List<Picture> pictures = new List<Picture>();

    public List<Picture> Pictures
    {
        get => pictures;
        set
        {
            pictures = value;

            OnProperyChanged();
        }
    }

    public string Name
    {
        get => product.Name;
        set
        {
            if (string.IsNullOrEmpty(value)) return;
            product.Name = value;

            OnProperyChanged();
        }
    }

    public string Description
    {
        get => product.Description;
        set
        {
            if (string.IsNullOrEmpty(value)) return;
            product.Description = value; 
            
            OnProperyChanged();
        }
    }

    public string Category
    {
        get => product.Category;
        set
        {
            if (string.IsNullOrEmpty(value)) return;
            product.Category = value;

            OnProperyChanged();
        }
    }

    public string Provider
    {
        get => product.Provider;
        set
        {
            if (string.IsNullOrEmpty(value)) return;
            product.Provider = value;

            OnProperyChanged();
        }
    }

    public List<Commentary> Commentaries
    {
        get => product.Commentaries;
        set 
        { 
            product.Commentaries = value; 
            
            OnProperyChanged();
        }
    }

    public void AddComment(Commentary commentary)
    {
        product.Commentaries.Add(commentary);
        OnProperyChanged("Commentaries");
    }

    public void RemoveCommentary(int index)
    {
        if (index < 0 || product.Commentaries.Count < index) return;

        product.Commentaries.RemoveAt(index);
        OnProperyChanged("Commentaries");
    }

    public void RemoveCommentary(string content)
    {
        var targetCommentary = product.Commentaries.Where(x => x.Content.Contains(content)).First();

        if (targetCommentary == null) return;
        product.Commentaries.Remove(targetCommentary);

        OnProperyChanged("Commentaries");
    }

    public List<Commentary> GetAllCommentaries() =>
        product.Commentaries;

    public string[] GetTags() => 
        product.Tags;

    public Dictionary<string, string> GetSpecs() => 
        product.Specs;

    private void OnProperyChanged([CallerMemberName] string property = "") => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}

public record Picture(string path);