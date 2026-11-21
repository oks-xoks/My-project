using UnityEngine;

public class PlayerTrailController : MonoBehaviour
{
    [SerializeField] private ParticleSystem trail;

    private void Update()
    {
        // Проверяем, нажаты ли клавиши движения
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        bool isMoving = Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f;
        
        if (isMoving)
        {
            if (!trail.isPlaying)
                trail.Play();
        }
        else
        {
            if (trail.isPlaying)
                trail.Stop();
        }
    }
}