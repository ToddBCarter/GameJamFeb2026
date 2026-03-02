using UnityEngine;

//lowkey everyones got a copy of this script attached. could use this one to check checkpoint status

public class Racer : MonoBehaviour
{
    private int CurrentLaps = 0;
    private bool passedCheckpoint = false;

    public int getLaps()
    {
        return CurrentLaps;
    }

    public void incLaps()
    {
        CurrentLaps++;
    }

    public void checkpointTrue()
    {
        passedCheckpoint = true;
    }

    public void checkpointFalse()
    {
        passedCheckpoint = false;
    }

    public bool returnCheckpointValue()
    {
        return passedCheckpoint;
    }
}
