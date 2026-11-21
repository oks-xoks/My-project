using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int lowHealthThreshold = 30; // при таком HP препятствия убивают
    [SerializeField] private TextMeshProUGUI healthText;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateUI();
    }

    // Отдельный метод для подвижных препятствий: если HP низкое — смерть
    public void TakeDamageFromObstacle(int amount)
    {
        if (currentHealth <= lowHealthThreshold)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            TakeDamage(amount);
        }
    }

    private void Die()
    {
        Debug.Log("Игрок уничтожен!");
        Destroy(gameObject);
    }

    private void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}