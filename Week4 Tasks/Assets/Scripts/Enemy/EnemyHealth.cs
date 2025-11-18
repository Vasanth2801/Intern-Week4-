using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 30;
    public float currentHealth;
    [SerializeField] private GameObject enemyDeath;
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {  
           Instantiate(enemyDeath, transform.position, Quaternion.identity);
           UIManager.instance.AddKill();
           Destroy(gameObject);
        }
    }
}