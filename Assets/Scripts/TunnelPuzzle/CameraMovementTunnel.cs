using UnityEngine;
using UnityEngine.Splines;

public class CameraMovementTunnel : MonoBehaviour
{
    public SplineContainer splineContainer;

    [Range(0f, 1f)]
    public float progress = 0f;

    [Header("Speed Settings")]
    public float startSpeed = 0.1f;
    public float speed;
    public float maxSpeed = 0.5f;
    public float acceleration = 0.05f;

    [Header("Stop Settings")]
    public float stopDuration = 1.5f;
    private bool isMoving = true;

    void Start()
    {
        speed = startSpeed;
    }

    void Update()
    {
        if (!isMoving) return;

        // -------- Acceleration --------
        speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);

        // -------- Move along spline --------
        progress += speed * Time.deltaTime;
        progress = Mathf.Clamp01(progress);

        Vector3 position = splineContainer.EvaluatePosition(progress);
        Vector3 forward = splineContainer.EvaluateTangent(progress);

        transform.position = position;

        if (forward != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(forward);

        if (progress >= 1f)
        {
            Debug.Log("there it is");
        }
    }

    public void StopMovement()
    {
        if (isMoving)
            StartCoroutine(StopRoutine());
    }

    System.Collections.IEnumerator StopRoutine()
    {
        isMoving = false;

        yield return new WaitForSeconds(stopDuration);

        isMoving = true;
    }

    public void ResetSpeedOnHit()
    {
        speed = startSpeed;
    }
}