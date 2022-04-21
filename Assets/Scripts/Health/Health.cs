using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        ResetHealth();
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth >= maxHealth)
        {
            ResetHealth();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }
}
