using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public string Name { get; private set; }
    public Sprite Icon { get => icon; }

    [SerializeField] private Sprite icon;

    private void Awake()
    {
        Name = name;
    }

    private void Start()
    {
        PlayerInventory.Instance.OnItemCollected += PlayerMotor_OnItemCollected;
    }

    private void PlayerMotor_OnItemCollected(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }
}