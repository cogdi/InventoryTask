using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public event Action OnInventoryUpdated;
    public event Action<Cube> OnItemCollected;

    public const int MAX_ITEMS_COUNT = 6;
    private List<Cube> itemsList;

    private void Awake()
    {
        Instance = this;
        itemsList = new List<Cube>();
    }

    private void Start()
    {
        PlayerMotor.Instance.OnItemInteracted += PlayerMotor_OnItemInteracted;
    }

    private void PlayerMotor_OnItemInteracted(Cube cube)
    {
        if (itemsList.Count < MAX_ITEMS_COUNT)
        {
            Debug.Log("Item added");
            itemsList.Add(cube);
            OnInventoryUpdated?.Invoke();
            OnItemCollected?.Invoke(cube);
        }
    }

    public List<Cube> GetInventoryItemsList()
    {
        return itemsList;
    }
    
    public bool IsInventoryFull()
    {
        return itemsList.Count >= MAX_ITEMS_COUNT;
    }
}
