using UnityEngine;

public class TunnelGameManager : MonoBehaviour
{
    public float timeLimit = 30f;

    private float timer;
    private bool isRunning = true;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (!isRunning) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Fail();
        }
    }

    void Fail()
    {
        isRunning = false;
        // Stop camera, trigger fail state tba
    }

    public void Success()
    {
        isRunning = false;
    }
}