using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] int TotalLaps = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Racer")) {
            //CurrentLap++;
            Racer racer = other.GetComponent<Racer>();
            if (racer == null) {
                Debug.Log("Attach Racer.cs script to this racer!");
                return;
            }
            racer.incLaps();

            int CurrentLap = racer.getLaps();

            Debug.Log(other.name + ": Lap " + CurrentLap + "/" + TotalLaps);

            if(CurrentLap >= TotalLaps) {
                Debug.Log(other.name + " is the winner!");
                // stop game here or otherwise don't let multiple winners be declared 
                return;
            }
        }
    }
}
