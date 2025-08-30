using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private int winningScore = 5;
    [SerializeField] private float resetDelay = 2f;

    [Header("Prefaps")]
    [SerializeField] private GameObject ballPrefap;

    [Header("Players colors")]
    [SerializeField] private Color player1Background;
    [SerializeField] private Color player2Background;

    [Header("Scene Settings")]
    [SerializeField] private string mainMenuScene;

    public Color getPlayer1Background { get => player1Background; }
    public Color getPlayer2Background { get => player2Background; }

    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    public bool gameOver { get; private set; }

    public event Action<int, int> OnScoreChanged;
    public event Action<int> OnGameOver;

    private InitPosition[] objects;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        objects = FindObjectsByType<InitPosition>(FindObjectsSortMode.None);

        GenerateBall();
    }

    private GameObject GenerateBall()
    {
        return Instantiate(ballPrefap, Vector2.zero, Quaternion.identity);
    }

    public void AddPlayerScore(int playerNumber, int score)
    {
        if (playerNumber == 1)
        {
            player1Score += score;
        } else
        {
            player2Score += score;
        }
        OnScoreChanged?.Invoke(player1Score, player2Score);

        if (player1Score >= winningScore)
        {
            gameOver = true;
            OnGameOver?.Invoke(1);
            return;
        }
        else if (player2Score >= winningScore)
        {
            gameOver = true;
            OnGameOver?.Invoke(2);
            return;
        }

        Invoke(nameof(ResetGame), resetDelay);
    }

    private void ResetGame()
    {
        var newBall = GenerateBall();
        foreach (var obj in objects)
        {
            obj.ResetPosition();
            if (obj.TryGetComponent<AIMovement>(out var ai))
            {
                ai.setBallTarget(newBall);
            }
        }
    }

    public void RestartScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
