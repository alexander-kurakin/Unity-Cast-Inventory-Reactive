using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private Item _testItem1;
    private Item _testItem2;
    private Item _testItem3;
    private Item _testItem4;

    private Inventory _testInventory;
    private Inventory _testInventory2;
    private InventoryCell _testCell;
    private List<InventoryCell> _testList = new();
    private List<InventoryCell> _testList2 = new();

    private void Awake()
    {
        //Items
        _testItem1  = new Item("Binoculars");
        _testItem2 = new Item("Sword");
        _testItem3 = new Item("Sword");
        _testItem4 = new Item("Popcorn seeds");

        //Cells
        _testCell = new InventoryCell(new Item("Sword"), 500);
        Debug.Log("Предсоздали ячейку с " + _testCell.Count + " " + _testCell.Item.Name);

        //list of cells
        _testList.Add(_testCell);

        //Inventory

        //_testInventory = new Inventory(_testList, -1000);
        //ArgumentOutOfRangeException: Переданный максимальный размер - 1000 меньше текущего размера 500
        //Parameter name: maxSize
        //Actual value was -1000.
        //Inventory..ctor(System.Collections.Generic.List`1[T] cells, System.Int32 maxSize)(at Assets / _Scripts / Inventory / Inventory.cs:20)
        //InventoryExample.Awake()(at Assets / _Scripts / Examples / InventoryExample.cs:29)

        _testInventory = new Inventory(_testList, 1800);
        Debug.Log("Успех - создан новый инвентарь с вместимостью " + _testInventory.MaxSize);

        _testInventory2 = new Inventory(_testList2, 1000);
        Debug.Log($"Успешно создали пустой инвентарь вместимостью {_testInventory2.MaxSize}");

        //Содержимое пустого инвентаря
        IReadOnlyList<(string Name, int Count)> emptyInventory = _testInventory2.GetAllItems();
        Debug.Log($"Успешно получили пустой список ячеек пустого инвентаря;Inventory count = {emptyInventory.Count}");

        //Инкапсуляция
        //_testInventory._cells.Add //not accessible
        //_testInventory.Cells.Add // not possible - readonly list
        //_testInventory.Cells[0].Item.Name = "blah"; //not possible - readonly item
        //_testInventory.MaxSize = 1; //not possible - readonly

        //Добавление
        if (_testInventory.TryAdd(_testItem1, 190))
            Debug.Log($"Успешно добавили {_testItem1.Name} в инвентарь");

        if (_testInventory.TryAdd(_testItem2, 250))
            Debug.Log($"Успешно добавили {_testItem2.Name} в инвентарь");

        if (_testInventory.TryAdd(_testItem3, 250))
            Debug.Log($"Успешно добавили {_testItem3.Name} в инвентарь");

        if (_testInventory.TryAdd(_testItem4, 2500) == false)
            Debug.Log($"Ожидаемо не удалось добавить предмет с количеством 2500 в инвентарь вместимостью 1800");

        //Содержимое инвентаря после тестов на вставку
        IReadOnlyList<(string Name, int Count)> resultInventory = _testInventory.GetAllItems();

        foreach ((string Name, int Count) item in resultInventory)
            Debug.Log($"{item.Count} {item.Name}");

        //Удаление из инвентаря
        if (_testInventory.TryRemove(_testItem3, 900))
            Debug.Log($"Успешно удалили 900 {_testItem3.Name}");

        if (_testInventory.TryRemove(_testItem3, 100))
            Debug.Log($"Успешно удалили 100 {_testItem3} а также всю ячейку");

        if (!_testInventory.TryRemove(_testItem3, 100))
            Debug.Log($"Ожидаемо не удалось удалить 100 {_testItem3.Name} - предмета нет");

        if (!_testInventory.TryRemove(_testItem1, 191))
            Debug.Log($"Ожидаемо не удалось удалить 191 {_testItem1.Name} - в инвентаре меньше предметов");

        //Содержимое инвентаря после тестов на удаление
        IReadOnlyList<(string Name, int Count)> resultInventory2 = _testInventory.GetAllItems();

        foreach ((string Name, int Count) item in resultInventory2)
            Debug.Log($"{item.Count} {item.Name}");
    }
}
