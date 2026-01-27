using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class Inventory
{
    private List<InventoryCell> _cells = new();
    private int _maxCapacity;

    public Inventory(List<InventoryCell> cells, int maxSize)
    {
        _cells = new List<InventoryCell>(cells);

        if (maxSize < CurrentSize)
            throw new ArgumentOutOfRangeException(nameof(maxSize), maxSize, $"Переданный максимальный размер {maxSize} меньше текущего размера {CurrentSize}");

        MaxSize = maxSize;
    }

    public int MaxSize { get; }

    public int CurrentSize => _cells.Sum(cells => cells.Count);

    public IReadOnlyList<IReadOnlyInventoryCell> Cells => _cells;

    public bool TryAdd(Item item, int count)
    {
        if (item == null || count <= 0)
        {
            Debug.LogError($"Параметры заданы некорректно: item={item}, count={count}");
            return false;
        }

        if (CurrentSize + count > MaxSize)
        {
            Debug.LogError($"Добавляемое количество {count} превышает максимальную вместимость инвентаря {MaxSize}, текущая вместимость {CurrentSize}");
            return false;
        }

        InventoryCell cell = _cells.FirstOrDefault(cell => cell.Item.Equals(item));

        if (cell != null)
        {
            cell.Add(count);
            Debug.Log($"Найдена текущая ячейка - пытаемся добавить в нее {count}. Текущее количество {cell.Count}");
            return true;
        } else
        {
            _cells.Add(new InventoryCell(item, count));
            Debug.Log("Нет такого предмета, создаем новую ячейку");
            return true;
        }
    }

    public IReadOnlyList<IReadOnlyInventoryCell> GetItemsByName (string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        IReadOnlyList<IReadOnlyInventoryCell> resultList =
            Cells.Where((IReadOnlyInventoryCell cell) => cell.Item.Name == name).ToList();

        return resultList;
    }

    public IReadOnlyList<(string Name, int Count)> GetAllItems()
    {
        if (Cells.Count == 0)
            return null;

        IReadOnlyList<(string Name, int Count)> resultList =
            Cells.Select((IReadOnlyInventoryCell cell) => (cell.Item.Name, cell.Count)).ToList();

        return resultList;
    }

}