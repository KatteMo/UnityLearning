using UnityEngine;

public class Coin : MonoBehaviour
{
    [HideInInspector] public CoinSpawner spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance?.AddPoint();
            spawner?.OnCoinCollected();
            Destroy(gameObject);
        }
    }
}