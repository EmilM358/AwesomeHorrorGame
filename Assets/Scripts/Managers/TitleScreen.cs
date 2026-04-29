using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject settings;

    private void Awake()
    {
        settings.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Settings()
    {
        bool isOpen = settings.activeSelf;
        settings.SetActive(!isOpen);
    }
    public void Quit()
    {
        Application.Quit();
    }
}