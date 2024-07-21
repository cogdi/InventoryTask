using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor Instance;

    public event Action<Cube> OnItemInteracted;
    public float InteractionDistance { get => interactionDistance; }
    public LayerMask InteractableLayerMask { get => interactableLayerMask; }

    private CharacterController controller;
    private float speed = 6.5f;
    private float interactionDistance = 5f;
    [SerializeField] private LayerMask interactableLayerMask;

    private void Awake()
    {
        Instance = this;

        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        PlayerInput.Instance.OnInteractAction += PlayerInput_OnInteractAction;
    }

    private void PlayerInput_OnInteractAction()
    {
        Interact();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = PlayerInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }

    private void Interact()
    {
        Ray ray = new Ray(PlayerLook.Instance.GetCameraPosition(), PlayerLook.Instance.GetCameraTransformForward());
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionDistance, interactableLayerMask))
        {
            if (hitInfo.transform.gameObject.TryGetComponent<Cube>(out Cube cube))
            {
                OnItemInteracted?.Invoke(cube);
                Debug.Log("Interaction performed");
            }
        }
    }
}
