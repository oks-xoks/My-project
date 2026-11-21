using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float impactThreshold = 5f; // минимальная сила удара для взрыва
    [SerializeField] private float explosionRadius = 5f; // радиус поражения

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.relativeVelocity.magnitude >= impactThreshold)
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Урон всем, кто в радиусе взрыва
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                Health health = hit.GetComponent<Health>();
                if (health != null)
                    health.TakeDamage(50); // Половина HP
            }
        }

        Destroy(gameObject); // бочка уничтожается
    }

    // Показываем радиус взрыва в редакторе (зелёная сфера при выделении)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}