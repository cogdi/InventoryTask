using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI onCollectingItemText;
    private string collectItemText = "Collect [E]";
    private string inventoryFullText = "Inventory is full!";

    private float rayDistance;
    private LayerMask interactableLayerMask;

    private void Awake()
    {
        onCollectingItemText.gameObject.SetActive(false);
    }

    private void Start()
    {
        rayDistance = PlayerMotor.Instance.InteractionDistance;
        interactableLayerMask = PlayerMotor.Instance.InteractableLayerMask;
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (PlayerInventory.Instance.IsInventoryFull())
            onCollectingItemText.text = inventoryFullText;
        else
            onCollectingItemText.text = collectItemText;


        if (Physics.Raycast(PlayerLook.Instance.GetCameraPosition(), PlayerLook.Instance.GetCameraTransformForward(), rayDistance, interactableLayerMask))
        {

            onCollectingItemText.gameObject.SetActive(true);
        }

        else
        {
            onCollectingItemText.gameObject.SetActive(false);
        }
        
    }
}
