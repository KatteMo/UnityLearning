using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 2f;          
    public Transform targetPlayer;    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (targetPlayer == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
            {
                targetPlayer = p.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (GameManagerMain.Instance != null && GameManagerMain.Instance.IsGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (targetPlayer == null)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 dir = (targetPlayer.position - transform.position).normalized;
        rb.linearVelocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManagerMain.Instance.GameOver();
        }
    }
}