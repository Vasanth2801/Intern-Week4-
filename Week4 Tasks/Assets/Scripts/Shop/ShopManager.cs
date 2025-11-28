using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Slider healthSlider;
    public int maxHealth = 100, maxDamage = 30;
    int currentHealth, currentDamage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetDefs();
    }

    void SetDefs()
    {
        PlayerPrefs.SetInt("MaxDamage", 10);
        PlayerPrefs.SetInt("MaxHealth", 100);

       healthSlider.maxValue = maxHealth;
       healthSlider.value = currentHealth;
    }

    public void UpgradeHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 20;
            PlayerPrefs.SetInt("MaxHealth", currentHealth);
            healthSlider.value = currentHealth;
            Debug.Log("Health Upgraded to: " + currentHealth);
        }
        else
        {
            Debug.Log("Health is already at maximum!");
        }
    }

    public void UpgradeDamage()
    {
        if (currentDamage < maxDamage)
        {
            currentDamage += 5;
            PlayerPrefs.SetInt("MaxDamage", currentDamage);
            Debug.Log("Damage Upgraded to: " + currentDamage);
        }
        else
        {
            Debug.Log("Damage is already at maximum!");
        }
    }
}
