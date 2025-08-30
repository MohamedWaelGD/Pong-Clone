using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private TMPro.TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        text.text = "P1: 0 - P2: 0";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameState.Instance.OnScoreChanged += UpdateText;
    }

    private void OnDestroy()
    {
        if (GameState.Instance != null)
        {
            GameState.Instance.OnScoreChanged -= UpdateText;
        }
    }

    private void UpdateText(int player1Score, int player2Score)
    {
        text.text = $"P1: {player1Score} - P2: {player2Score}";
    }
}
