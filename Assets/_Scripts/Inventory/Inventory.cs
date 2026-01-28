using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class Inventory
{
    private List<InventoryCell> _cells;
    private int _maxCapacity;

    public Inventory(List<InventoryCell> cells, int maxSize)
    {
        _cells = new List<InventoryCell>(cells);

        if (maxSize < CurrentSize)
            throw new ArgumentOutOfRangeException(nameof(maxSize), maxSize,
                $"Переданный максимальный размер {maxSize} меньше текущего размера {CurrentSize}");

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
            Debug.LogError($"Добавляемое количество {count} {item.Name} превышает максимальную вместимость инвентаря {MaxSize}, текущая вместимость {CurrentSize}");
            return false;
        }

        InventoryCell cell = FindCell(item);

        if (cell != null)
        {
            Debug.Log($"Найдена текущая ячейка с {item.Name} - пытаемся добавить в нее {count}. Текущее количество {cell.Count}");
            cell.Add(count);

            return true;
        } else
        {
            Debug.Log($"Нет такого предмета {item.Name}, создаем новую ячейку");
            _cells.Add(new InventoryCell(item, count));
            return true;
        }
    }

    public bool TryRemove(Item item, int count)
    {
        if (item == null || count <= 0)
        {
            Debug.LogError($"Параметры заданы некорректно: item={item}, count={count}");
            return false;
        }

        InventoryCell cell = FindCell(item);

        if (cell == null)
        {
            Debug.LogError($"В инвентаре нет предмета {item.Name}");
            return false;
        }

        if (cell.Count < count)
        {
            Debug.LogError($"Нельзя удалить {count} {item.Name}. В наличии только {cell.Count}");
            return false;
        }

        Debug.Log($"Найдена ячейка с {item.Name} — удаляем {count}. Текущее количество {cell.Count}");
        cell.Remove(count);

        if (cell.Count == 0)
        {
            Debug.Log($"Количество {item.Name} стало 0 — удаляем ячейку");
            _cells.Remove(cell);
        }

        return true;
    }

    private InventoryCell FindCell(Item item)
    {
        return _cells.FirstOrDefault(cell => cell.Item.Name.Equals(item.Name));
    }

    public IReadOnlyList<(string Name, int Count)> GetAllItems()
    {
        if (Cells.Count == 0)
            return new List<(string Name, int Count)>();

        IReadOnlyList<(string Name, int Count)> resultList =
            Cells.Select((IReadOnlyInventoryCell cell) => (cell.Item.Name, cell.Count)).ToList();

        return resultList;
    }

}