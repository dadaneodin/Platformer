using UnityEngine;

public class DieEnemyManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Die()
    {
        ScoreManager.instance.AddKil();
        Destroy(gameObject);
    }
}
