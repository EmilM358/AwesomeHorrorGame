using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HandController : MonoBehaviour
{
    public float moveRange = 0.5f;
    public float smoothTime = 0.05f;
    public float forwardDistance = 0.5f;

    private Rigidbody rb;
    private Camera cam;
    private Vector3 velocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        // 1. Get mouse position
        Vector2 mouse = Input.mousePosition;

        // 2. Normalize to -1 to 1
        Vector2 input = new Vector2(
            (mouse.x / Screen.width) * 2f - 1f,
            (mouse.y / Screen.height) * 2f - 1f
        );

        input = Vector2.ClampMagnitude(input, 1f);

        // 3. Camera basis
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;
        Vector3 camUp = cam.transform.up;

        // 4. Target position in front of camera
        Vector3 targetPos =
            cam.transform.position +
            camForward * forwardDistance +
            camRight * input.x * moveRange +
            camUp * input.y * moveRange;

        // 5. Smooth movement
        Vector3 newPos = Vector3.SmoothDamp(
            rb.position,
            targetPos,
            ref velocity,
            smoothTime
        );

        rb.MovePosition(newPos);
    }
}