using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private int damageOnContact = 20;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingForward = true;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * moveDistance;
    }

    private void Update()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPos) < 0.1f)
                movingForward = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.1f)
                movingForward = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health health = collision.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damageOnContact);
            }
        }
    }
}