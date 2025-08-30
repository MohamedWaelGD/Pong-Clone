using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private bool isPlayerOne;

    private void Start()
    {

        foreach (var sprite in sprites)
        {
            sprite.color = isPlayerOne ? GameState.Instance.getPlayer1Background : GameState.Instance.getPlayer2Background;
        }
    }
}
