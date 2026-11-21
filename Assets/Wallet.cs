using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    public int Coins => coins;

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    private void Start()
    {
        UpdateUI();
    }
}