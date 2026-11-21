using UnityEngine;

public class Coin : MonoBehaviour  
{
    [SerializeField] private int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Wallet wallet = other.GetComponent<Wallet>();
            if (wallet != null)
            {
                wallet.AddCoins(coinValue);
            }
            Destroy(gameObject);
        }
    }
}