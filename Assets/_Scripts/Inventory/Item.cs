public class Item : IReadOnlyItem
{
    public string Name { get; }

    public Item(string name)
    {
        Name = name;
    }
}