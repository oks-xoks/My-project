using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D или стрелки
        float vertical = Input.GetAxis("Vertical");     // W/S или стрелки

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}