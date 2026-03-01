using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float duration = 5f;
    [SerializeField] private float rotationSpeed = 120f;
    [SerializeField] private AudioClip collectSound;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Racer"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            PlayerMovement movement = other.GetComponentInParent<PlayerMovement>();
            if (movement != null)
            {
                movement.ModifySpeed(speedMultiplier, duration);
            }
            
            Destroy(gameObject);
        }
    }
}