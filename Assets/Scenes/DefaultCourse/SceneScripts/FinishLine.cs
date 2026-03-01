using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static int totalRacers = 2;
    [SerializeField] private int TotalLaps = 3;
    [SerializeField] private TMP_Text[] leaderboardTexts;
    [SerializeField] private GameObject leaderboard;
    private int place = 0;

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

            if (CurrentLap >= TotalLaps) {
                if (place < leaderboardTexts.Length)
                {
                    Timer timer = other.GetComponent<Timer>();
                    if(timer == null)
                    {
                        Debug.Log("null");
                    }
                    timer.StopTimer();
                    float time = timer.GetElapsedTime();
                    leaderboardTexts[place].text += other.name + "     " + time;
                    Debug.Log(other.name + " got " + (place + 1) + " place!");
                    timer.Won();
                    place++;
                }
                else
                {
                    Debug.Log(other.name + " finished but leaderboard is full");
                }

                if (totalRacers == 1)
                {
                    Debug.Log("out of racers");
                    leaderboard.SetActive(true);
                    place = leaderboardTexts.Length + 1;
                }
                else
                {
                    totalRacers--;
                    Debug.Log("Total racers left: " +  totalRacers);
                }
                return;
            }
        }
    }
}
