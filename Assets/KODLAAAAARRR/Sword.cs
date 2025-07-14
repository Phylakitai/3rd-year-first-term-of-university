using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 15; 
    public float damageCooldown = 0.5f;
    private float lastDamageTime = 0f; 
    private void OnTriggerStay(Collider collider)
    {
     
        if (collider.CompareTag("Enemy"))
        {
            if (Time.time - lastDamageTime >= damageCooldown) 
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damage);                   
                    lastDamageTime = Time.time; 
                }
            }
        }
    }
}
