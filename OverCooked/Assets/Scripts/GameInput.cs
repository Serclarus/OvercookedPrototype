using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{   
    public event EventHandler OnInteractAction;

    NewControls inputScript;

    //called before first frame
    void Awake()
    {
        inputScript = new NewControls();
        inputScript.Player.Enable();
        inputScript.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = inputScript.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;

    }
}
