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
            Debug.Log("Racer hit powerup");
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            PlayerMovement movement = other.GetComponentInParent<PlayerMovement>();
            if (movement != null)
            {
                Debug.Log("it was a player");
                movement.ModifySpeed(speedMultiplier, duration);
            } else {
                WaypointMove movementAI = other.GetComponent<WaypointMove>();
                if (movementAI != null) {
                    Debug.Log("it was ai");
                    movementAI.ModifySpeed(speedMultiplier, duration);
                }
            }
            
            Destroy(gameObject);
        }
    }
}