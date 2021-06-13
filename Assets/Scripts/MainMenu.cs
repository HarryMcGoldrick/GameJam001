using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject GameOverPanel;

    private Animator mainMenuAnimator;
    private Animator gameOverAnimator;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        mainMenuAnimator = MainMenuPanel.GetComponent<Animator>();
        gameOverAnimator = GameOverPanel.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OpenMainMenu()
    {
        GameOverPanel.SetActive(true);
        mainMenuAnimator.SetTrigger("Open");
    }

    public void CloseMainMenu()
    {
        mainMenuAnimator.SetTrigger("Close");
    }

    public void OpenGameOver()
    {
        GameOverPanel.SetActive(true);
        gameOverAnimator.SetTrigger("Open");
    }

    public void CloseGameOver()
    {
        gameOverAnimator.SetTrigger("Close");
    }
}
