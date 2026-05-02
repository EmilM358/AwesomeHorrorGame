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
        // EXPLANATION OF THE FRUSTUM AND NEAR CLIPPING PLANE
        // On every frame, get the position of the mouse and translate it to world coords.
        // The actual position obtained is relative to the camera frustum's near clip plane.
        // Imagine a pyramid with no point at the top. Two flat parallel surfaces on the top and bottom.
        // That, is a frustum. The shape itself.
        // The camera has a frustum. That is, the view of the camera is a frustum. Select the camera in unity, you will see the camera's frustum.
        // The near clipping plane is the smaller face of the frustum, that being the face closest to the camera.

        // Position of the mouse relative to the screen.
        MousePos = Mouse.current.position.ReadValue();
        // Add the z position, i.e. distance to the near clipping plane.
        MousePos.z = Camera.main.nearClipPlane;
        // Convert to world position, i.e. the world position on the near clipping plane.
        MouseWorldPos = Camera.main.ScreenToWorldPoint(MousePos);

        Hover();
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

    // Gonna keep this mess here for a bit longer just in case.
    private void Select(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
            //Debug.Log("Select pressed: " + MousePos);

            // Make a vector that starts from the camera position and ends at the cursor... i think... gotta figure that out one sec
            //Vector3 cursorDirection = MouseWorldPos - CameraTransform.position;
            //Vector3 cursorDirectionExtended = cursorDirection * MaxSelectDistance;

            // Debug.DrawRay(CameraTransform.position, cursorDirection, Color.green, MaxSelectDistance);

            // PROBLEM: Does not handle multiple hits. Might choose between multiple objects in the way of the ray.
            RaycastHit hit;
            //bool didHit = Physics.Raycast(CameraTransform.position, cursorDirectionExtended, out hit, MaxSelectDistance, SelectableLayer);
            bool didHit = CursorRay(out hit);


            // If the RayCast hit a selectable layered object.
            if (didHit)
            {
                Selectable selectable;
                if (hit.collider.gameObject.TryGetComponent(out selectable))
                {
                    selectable.Selected();
                }
            }

            
        }
    }

    private void Hover()
    {
        RaycastHit hit;
        bool didHit = CursorRay(out hit);

        if (didHit)
        {
            Selectable selectable;
            if (hit.collider.gameObject.TryGetComponent(out selectable))
            {
                selectable.Hovering();
            }
        }
    }

    private bool CursorRay(out RaycastHit hit)
    {
        Vector3 cursorDirection = MouseWorldPos - CameraTransform.position;
        Vector3 cursorDirectionExtended = cursorDirection * MaxSelectDistance;

        return Physics.Raycast(CameraTransform.position, cursorDirectionExtended, out hit, MaxSelectDistance, SelectableLayer);
    }
}
