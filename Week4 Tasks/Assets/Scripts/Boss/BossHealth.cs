using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 200;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject deathEffect;

    public bool isInvincible = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void BossTakeDamge(int damage)
    {
        if(isInvincible)
        {
            return;
        }
        currentHealth -= damage;

        if(currentHealth <= 100)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        { 
            Debug.Log("Boss Defeated!");
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}