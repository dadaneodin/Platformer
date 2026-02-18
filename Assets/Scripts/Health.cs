using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isAlive;
    [SerializeField] private GameObject person;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if(currentHealth > 0)
            isAlive = true;
        else
            {
                isAlive = false;
                Death();
            }

    }

    private void Death()
    {
        if(isAlive == false)
            Destroy(person);

    }
}
