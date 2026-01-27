using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private Item _testItem;
    private Inventory _testInventory;
    private InventoryCell _testCell;
    private List<InventoryCell> _testList = new();

    private void Awake()
    {   
        _testCell = new InventoryCell(new Item("Sword"), 500);

        Debug.Log(_testCell);

        _testList.Add(_testCell);
        _testInventory = new Inventory(_testList, 600);

        _testItem = new Item("Binoculars");

        if (_testInventory.TryAdd(_testItem, 190))
            Debug.Log($"Успешно добавили {_testItem.Name} в инвентарь");

        if (_testInventory.TryAdd(_testItem, 190))
            Debug.Log($"Успешно добавили {_testItem.Name} в инвентарь");

        IReadOnlyList<(string Name, int Count)> resultInventory = _testInventory.GetAllItems();

        foreach ((string Name, int Count) item in resultInventory)
            Debug.Log($"{item.Name} x {item.Count}");

        if (_testInventory.TryAdd(_testItem, 600))
            Debug.Log($"Успешно добавили {_testItem} в инвентарь");

    }
}
