using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    # region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Instance already assigned!");
            return;
        }

        instance = this;
    }
    # endregion

    public List<Item> items = new List<Item>();
    public int spaces = 20;

    public bool AddItem(Item newItem)
    {
        if (items.Count < spaces)
        {
            items.Add(newItem);
            return true;
        }
        else
        {
            Debug.Log("There is no space enough!");
            return false;
        }
    }

    public bool RemoveItem(Item item)
    {
        items.Remove(item);
        return true;
    }
}
