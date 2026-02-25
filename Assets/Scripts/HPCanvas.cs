using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCanvas : MonoBehaviour
{
    [SerializeField] public Image healthBarImage;
    public Image fillAmount;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
     private void Start()
    {
        if(maxHealth != 0)
            healthBarImage.fillAmount = currentHealth/maxHealth;
        
        currentHealth -= damage;
    healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    
}
