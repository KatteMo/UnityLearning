using UnityEngine;
using TMPro;  

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private TextMeshProUGUI scoreTextUI;
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddPoint()
    {
        score += 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreTextUI != null)
        {
            scoreTextUI.text = "Score: " + score;
        }
    }
}