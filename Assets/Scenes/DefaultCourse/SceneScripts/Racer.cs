using UnityEngine;

public class Racer : MonoBehaviour
{
    private int CurrentLaps = 0;

    public int getLaps()
    {
        return CurrentLaps;
    }

    public void incLaps()
    {
        CurrentLaps++;
    }
}
