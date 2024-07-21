using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform itemTemplate;

    private void Awake()
    {
        itemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        PlayerInventory.Instance.OnInventoryUpdated += PlayerInventory_OnInventoryUpdated; ;

        UpdateVisual();
    }

    private void PlayerInventory_OnInventoryUpdated()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == itemTemplate)
                continue;
            Destroy(child.gameObject);
        }

        foreach (Cube cube in PlayerInventory.Instance.GetInventoryItemsList())
        {
            Transform itemTransform = Instantiate(itemTemplate, container);

            if (itemTransform.gameObject.TryGetComponent<InventoryItemSingleUI>(out InventoryItemSingleUI item))
            {
                item.SetItemData(cube.Name, cube.Icon);
                itemTransform.gameObject.SetActive(true);
            }
        }
    }
}
