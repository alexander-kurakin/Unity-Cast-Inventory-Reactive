public interface IReadOnlyInventoryCell
{
     IReadOnlyItem Item { get; }
     int Count { get; }
}