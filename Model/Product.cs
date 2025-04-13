using System.Collections.Generic;

namespace Store.Model;

public class Product
{
    private string name;
    private string description;
    private string category;
    private float rating;

    private string provider;
    
    private List<string> tags;
    private List<Commentary> commentaries;

    private List<Spec> specs;
    private List<string> pictures;

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public string Category { get => category; set => category = value; }
    public float Rating { get => rating; set => rating = value; }

    public string Provider { get => provider; set => provider = value; }

    public List<string> Tags { get => tags; set => tags = value; }
    public List<Commentary> Commentaries { get => commentaries; set => commentaries = value; }
    
    public List<Spec> Specs { get => specs; set => specs = value; }
    public List<string> Pictures { get => pictures; set => pictures = value; }
}

