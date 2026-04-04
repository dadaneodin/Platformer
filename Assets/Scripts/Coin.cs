using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 50;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
