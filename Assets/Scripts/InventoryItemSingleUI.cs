using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;

    public void SetItemData(string text, Sprite icon)
    {
        itemName.text = text;
        itemIcon.sprite = icon;
    }
}
