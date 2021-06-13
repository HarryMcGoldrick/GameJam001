using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject GameOverPanel;

    private Animator mainMenuAnimator;
    private Animator gameOverAnimator;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        MainMenuPanel.SetActive(false);

        mainMenuAnimator = MainMenuPanel.GetComponent<Animator>();
        gameOverAnimator = GameOverPanel.GetComponent<Animator>();

        if (GameManager.Instance.State == GameState.GameOver)
        {
            OpenGameOver();
        } else
        {
            OpenMainMenu();
        }

    }

    public void PlayGame()
    {
        GameManager.Instance.SetGameState(GameState.Playing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OpenMainMenu()
    {
        MainMenuPanel.SetActive(true);
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
        scoreText.text = formatNumber(GameManager.Instance.Score);

    }

    public void CloseGameOver()
    {
        gameOverAnimator.SetTrigger("Close");
        GameOverPanel.SetActive(false);
    }

    string formatNumber(float number)
    {
        string s = string.Format("{0:0.00}", number);
        if (s.EndsWith("00"))
        {
            s = ((int)number).ToString();
        }
        return s;
    }
}
 