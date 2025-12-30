using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainMenu, Playing, Paused, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "OpeningScreen")
            UpdateGameState(GameState.MainMenu);
        else
            UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState newState)
    {
        CurrentState = newState;
        EventManager.TriggerGameStateChanged(newState);

        switch (newState)
        {
            case GameState.Paused:
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                Time.timeScale = 1f; 
                break;
        }
    }

    
    private void OnEnable()
    {
        EventManager.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath()
    {
        UpdateGameState(GameState.GameOver);
    }
}
