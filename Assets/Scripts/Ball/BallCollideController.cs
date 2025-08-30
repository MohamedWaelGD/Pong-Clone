using UnityEngine;
using UnityEngine.Rendering;

public class BallCollideController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask[] targetCollides;
    [SerializeField] private GameObject hitEffect;

    [Header("Sounds")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip destroySound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayHitSound();
        CheckCollisionImpact(collision);
    }

    private void CheckCollisionImpact(Collision2D collision)
    {
        foreach (LayerMask layer in targetCollides)
        {
            if (CheckLayerTarget(collision, layer))
            {
                var layerName = LayerMask.LayerToName(collision.gameObject.layer);

                if (layerName == "Player 1")
                {
                    GameState.Instance.AddPlayerScore(1, 1);
                }
                else
                {
                    GameState.Instance.AddPlayerScore(2, 1);
                }
                DestroyBall();
                Destroy(gameObject);

                break;
            }
        }
    }

    private void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    private void DestroyBall()
    {
        if (destroySound != null)
        {
            var soundObj = SoundsUtility.Play2DSound(destroySound);
            Destroy(soundObj, destroySound.length + 1);
        }

        if (hitEffect != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (effect)
            {
                Destroy(effect, 1f);
            }
        }
    }

    private static bool CheckLayerTarget(Collision2D hit, LayerMask layer)
    {
        return ((1 << hit.gameObject.layer) & layer) != 0;
    }
}
