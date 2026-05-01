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
    private Vector3 MouseWorldPos;

    private void Awake()
    {
        inputActions = new GeneralActions();
    }

    private void Update()
    {
        // This is apparently the mouse pos in pixels and not world coords...
        // Gotta translate that
        // There's a line for that in that website
        MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Camera.main.nearClipPlane;
        MouseWorldPos = Camera.main.ScreenToWorldPoint(MousePos);


        //Debug.Log("Update MousePos: " + MousePos + " MouseWorldPos: " + MouseWorldPos);


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
            Vector3 cursorDirection = MouseWorldPos - CameraTransform.position;
            Vector3 cursorDirectionExtended = cursorDirection * MaxSelectDistance;

            // Debug.DrawRay(CameraTransform.position, cursorDirection, Color.green, 30f);

            RaycastHit hit;
            bool didHit = Physics.Raycast(CameraTransform.position, cursorDirectionExtended, out hit, MaxSelectDistance, SelectableLayer);
            // camera's transform, direction vector (calculated based on the cursor ugh), out hit, MaxDistance... check this, selectable layer mask


            if (didHit) Debug.Log(hit.collider.gameObject.name);
        }
    }
}
