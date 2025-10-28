using UnityEngine;
using TMPro;

public class GameManagerMain : MonoBehaviour
{
    public static GameManagerMain Instance;
    [SerializeField] private TextMeshProUGUI gameOverText;  
    public bool IsGameOver { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        gameOverText?.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;

        gameOverText?.gameObject.SetActive(true);

        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.enabled = false; 
            Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
            if (prb != null) prb.linearVelocity = Vector2.zero;
        }
    }
}