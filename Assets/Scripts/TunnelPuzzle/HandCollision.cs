using UnityEngine;
using UnityEngine.Windows;

public class HandCollision : MonoBehaviour
{
    public CameraMovementTunnel cameraMove;
    public VignetteController vignette;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("allo");
            cameraMove.StopMovement();
            cameraMove.ResetSpeedOnHit();

            vignette.Flash();

            //AudioManager.instance.PlaySFX(AudioManager.instance.hurt);
        }
    }
}