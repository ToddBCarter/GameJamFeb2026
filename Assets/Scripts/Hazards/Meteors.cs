using UnityEngine;

public class Meteors : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.5f;
    [SerializeField] private float slowDuration = 2f;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private AudioClip collectSound;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Racer")) return;

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        PlayerMovement movement = collision.collider.GetComponentInParent<PlayerMovement>();
        if (movement != null)
        {
            movement.ModifySpeed(slowMultiplier, slowDuration);
        }

        Destroy(gameObject);
    }
}