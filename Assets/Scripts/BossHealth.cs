using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class BossHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] public bool isAlive;
    [SerializeField] private GameObject person;
    [SerializeField] public Image healthBarImage;
    [SerializeField] public TMP_Text healthText;
    [SerializeField] private GameObject deathPanel;

    // ==========================================
    // НАГРАДА ПОСЛЕ СМЕРТИ БОССА
    // ==========================================
    [Header("Объекты после смерти босса")]
    [SerializeField] private GameObject firstRewardObject;
    [SerializeField] private GameObject secondRewardObject;


    void Start()
    {
        
    }
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

    public void CheckIsAlive()
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
        // АКТИВИРУЕМ НАГРАДУ ПЕРЕД УДАЛЕНИЕМ
        if (firstRewardObject != null)
            firstRewardObject.SetActive(true);

        if (secondRewardObject != null)
            secondRewardObject.SetActive(true);


         if(person != null)
            Destroy(person);

        if(deathPanel != null)
            deathPanel.SetActive(true);
        // else
        //     deathPanel.SetActive(false);


        if(isAlive == false)
        {
            Destroy(person);
            // deathPanel.SetActive(true);
            Die();
        }
    }

    void UpdateHealth(float currentHealth, float maxHealth)
    {
        // Добавим проверку, чтобы не было ошибок, если бар не привязан
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentHealth / maxHealth;
            
        if (healthText != null)
            healthText.text = currentHealth.ToString();
    }

     void Die()
    {   
        // if(gameObject.CompareTag("Damageable"))
        if (ScoreManager.instance != null) // проверка на всякий случай
            ScoreManager.instance.AddKil();
            
        Destroy(gameObject);
    }
}