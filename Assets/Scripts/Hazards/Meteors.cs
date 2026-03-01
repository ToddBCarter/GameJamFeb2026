using UnityEngine;

public class Meteors : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.5f;
    [SerializeField] private float slowDuration = 2f;
    [SerializeField] private float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Racer")) return;

        PlayerMovement movement = collision.collider.GetComponentInParent<PlayerMovement>();
        if (movement != null)
        {
            movement.ModifySpeed(slowMultiplier, slowDuration);
        }

        Destroy(gameObject);
    }
}