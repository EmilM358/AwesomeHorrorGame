using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    private GeneralActions inputActions;
    private InputAction select;

    private void Awake()
    {
        inputActions = new GeneralActions();
    }

    private void OnEnable()
    {
        select = inputActions.Player.Select;
        select.Enable();
        select.performed += Select;
    }
    private void OnDisable()
    {
        select.Disable();
        select.performed -= Select;
    }

    private void Select(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Select pressed");
        }
    }
}
