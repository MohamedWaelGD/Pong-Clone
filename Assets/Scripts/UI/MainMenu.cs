using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string SceneGamePlay;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneGamePlay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
