using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    private GeneralActions inputActions;
    private InputAction select;

    [SerializeField] private Transform CameraTransform;
    [SerializeField] private LayerMask SelectableLayer;
    [SerializeField] private float MaxSelectDistance;

    private Vector3 MousePos;

    private void Awake()
    {
        inputActions = new GeneralActions();
    }

    private void Update()
    {
        // This is apparently the mouse pos in pixels and not world coords...
        // Gotta translate that
        MousePos = Mouse.current.position.ReadValue();
        Debug.Log("Update (MousePos): " + MousePos);
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
            

            Debug.Log("Select pressed: " + MousePos);

            // Make a vector that starts from the camera position and ends at the cursor... i think... gotta figure that out one sec

            //RaycastHit hit;
            //bool didHit = Physics.Raycast(CameraTransform.position, transform.forward, out hit, MaxSelectDistance, SelectableLayer);
            // camera's transform, direction vector (calculated based on the cursor ugh), out hit, MaxDistance... check this, selectable layer mask

        }
    }
}
