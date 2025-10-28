using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Vector2 minPos = new Vector2(-5f, -5f);
    [SerializeField] private Vector2 maxPos = new Vector2(5f, 5f);
    private GameObject currentCoin; 

    void Start()
    {
        SpawnNewCoin();
    }

    public void SpawnNewCoin()
    {
        if (currentCoin != null)
            return;

        float x = Random.Range(minPos.x, maxPos.x);
        float y = Random.Range(minPos.y, maxPos.y);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        currentCoin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);

        Coin coinScript = currentCoin.GetComponent<Coin>();
        if (coinScript != null)
        {
            coinScript.spawner = this;
        }
    }

    public void OnCoinCollected()
    {
        currentCoin = null;
        SpawnNewCoin();
    }
}