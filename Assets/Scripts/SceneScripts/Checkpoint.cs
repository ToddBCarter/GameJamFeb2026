using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Racer")) {
            Racer racer = other.GetComponent<Racer>();
            if (racer != null) {
                racer.checkpointTrue();                
            }
        }
    }
}
