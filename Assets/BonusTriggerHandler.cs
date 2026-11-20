using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BonusTriggerHandler : MonoBehaviour
{
    [SerializeField] private Animator bonusAnimator;

    private static readonly int PlayerInRangeHash = Animator.StringToHash("PlayerInRange");

    private void Awake()
    {
        if (bonusAnimator == null)
        {
            bonusAnimator = GetComponent<Animator>();
        }

        if (bonusAnimator == null)
        {
            Debug.LogError($"[BonusTriggerHandler] Animator не найден на объекте {gameObject.name}!", this);
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bonusAnimator.SetBool(PlayerInRangeHash, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bonusAnimator.SetBool(PlayerInRangeHash, false);
        }
    }
}