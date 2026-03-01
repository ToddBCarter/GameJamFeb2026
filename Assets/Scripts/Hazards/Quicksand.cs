using UnityEngine;

public class Quicksand : MonoBehaviour
{
    [SerializeField] private float slowMultiplier = 0.4f; // fraction of normal speed

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("slowing!");
        if (!other.CompareTag("Racer")) return;

        PlayerMovement movement = other.GetComponentInParent<PlayerMovement>();
        if (movement != null)
        {
            movement.SetSpeedMultiplier(slowMultiplier);
        } else {
            WaypointMove movementAI = other.GetComponent<WaypointMove>();
            if (movementAI != null) {
                movementAI.SetSpeedMultiplier(slowMultiplier);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Racer")) return;

        PlayerMovement movement = other.GetComponentInParent<PlayerMovement>();
        if (movement != null)
        {
            movement.SetSpeedMultiplier(1f);
        } else {
            WaypointMove movementAI = other.GetComponent<WaypointMove>();
            if (movementAI != null) {
                movementAI.SetSpeedMultiplier(1f);
            }
        }
    }
}