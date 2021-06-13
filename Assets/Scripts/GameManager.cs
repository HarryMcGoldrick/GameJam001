using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public GameState State;
    public float Score;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        State = GameState.Playing;
    }

    public void SetGameState(GameState state)
    {
        State = state;

        if (state == GameState.GameOver)
        {
            Debug.LogError("asjkhdbakjsd");
        }
    }
}

public enum GameState
{
    Playing,
    GameOver
}
