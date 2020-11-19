using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerController))] // Explain why this is important
public class PlayerControls : MonoBehaviour {
    
    #region Components
        PlayerController controller;
    #endregion

    private void Start() {
        controller = GetComponent<PlayerController>();
    }

    public void OnMove(CallbackContext ctx)
    {
        controller.MovInput = ctx.ReadValue<Vector2>();
    }
}