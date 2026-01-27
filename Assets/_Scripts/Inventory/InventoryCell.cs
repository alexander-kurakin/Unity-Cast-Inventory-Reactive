using System;

public class InventoryCell : IReadOnlyInventoryCell
{
    private readonly Item _item;
    private int _count;

    public InventoryCell(Item item, int count)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), count,
                "Количество не может быть ноль или отрицательное");

        _item = item;
        _count = count;
    }

    public IReadOnlyItem Item => _item;
    public int Count => _count;

    public bool IsEmpty => _count == 0;
    public bool CanAdd(int addCount) => addCount > 0;
    public bool CanRemove(int removeCount) => removeCount > 0 && removeCount <= _count;

    public void Add(int addCount)
    {
        if (CanAdd(addCount) == false)
            throw new ArgumentOutOfRangeException(nameof(addCount), addCount,
                "Неверное количество предмета для добавления");

        _count += addCount;
    }

    public void Remove(int removeCount)
    {
        if (CanRemove(removeCount) == false)
            throw new ArgumentOutOfRangeException(nameof(removeCount), removeCount,
                "Неверное количество предмета для удаления");

        _count -= removeCount;
    }
}
