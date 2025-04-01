using System.Collections.Generic;

namespace Store.Model;

public class Product
{
    private string name;
    private string description;
    private string category;
    
    private string[] tags;
    private List<Commentary> commentaries;

    private Dictionary<string, string> specs;

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public string Category { get => category; set => category = value; }
    public string[] Tags { get => tags; set => tags = value; }
    public List<Commentary> Commentaries { get => commentaries; set => commentaries = value; }
    public Dictionary<string, string> Specs { get => specs; set => specs = value; }

    
}