using UnityEngine;
public class DamageDealerOrc : MonoBehaviour
{
   [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
}