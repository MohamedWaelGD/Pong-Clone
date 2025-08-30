using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameUI;
    [SerializeField] private TMPro.TMP_Text stateText;
    [SerializeField] private Image backgroundImage;

    private void Awake()
    {
        gameUI?.gameObject.SetActive(false);
    }

    private void Start()
    {
        GameState.Instance.OnGameOver += UpdateGameStateUI;
    }

    private void UpdateGameStateUI(int playerNumber)
    {
        gameUI.gameObject.SetActive(true);
        stateText.text = $"Player {playerNumber} Wins!";

        backgroundImage.color = playerNumber == 1 ? GameState.Instance.getPlayer1Background : GameState.Instance.getPlayer2Background;
    }
}
