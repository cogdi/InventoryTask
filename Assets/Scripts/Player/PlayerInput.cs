using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    public event Action OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.OnFoot.Enable();
        playerInputActions.OnFoot.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke();
    }   

    public Vector2 GetMovementVectorNormalized()
    {
        return playerInputActions.OnFoot.Move.ReadValue<Vector2>().normalized;
    }

    public Vector2 GetLookingAxis()
    {
        return playerInputActions.OnFoot.Look.ReadValue<Vector2>();
    }

    private void OnDestroy()
    {
        playerInputActions.Dispose();
    }
}
