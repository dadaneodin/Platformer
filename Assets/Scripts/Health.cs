using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isAlive;
    [SerializeField] private GameObject person;
    [SerializeField] public Image healthBarImage;
    [SerializeField] public TMP_Text healthText;
    [SerializeField] private GameObject deathPanel;

    private void Update()
    {
        UpdateHealth(currentHealth, maxHealth);
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealth(currentHealth, maxHealth);
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
         if(person != null)
            Destroy(person);
            
        if(deathPanel != null)
            deathPanel.SetActive(true);

        // if(isAlive == false)
        //     Destroy(person);
        // deathPanel.SetActive(true);
    }

    void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
        healthText.text = currentHealth.ToString();
    }

    
}
