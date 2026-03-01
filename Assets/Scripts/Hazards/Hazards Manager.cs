using UnityEngine;

public class HazardsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] quicksandZones;
    [SerializeField] private float quicksandInterval = 5f;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private Transform[] meteorSpawnPoints;
    [SerializeField] private float meteorSpawnInterval = 10f;
    [SerializeField] private float height = 10f;

    private float quicksandTimer;
    private float meteorTimer;

    void Start()
    {
        foreach (var zone in quicksandZones)
        {
            zone.SetActive(false);
        }
    }

    void Update()
    {
        quicksandTimer += Time.deltaTime;
        if (quicksandTimer >= quicksandInterval)
        {
            ActivateQuicksand();
            quicksandTimer = 0f;
        }

        meteorTimer += Time.deltaTime;
        if (meteorTimer >= meteorSpawnInterval)
        {
            SpawnMeteor();
            meteorTimer = 0f;
        }
    }

    void ActivateQuicksand()
    {
        foreach (var zone in quicksandZones)
        {
            zone.SetActive(false);
        }

        int activateQuicksand = Random.Range(0, quicksandZones.Length);

        for (int i = 0; i < activateQuicksand; i++)
        {
            int zoneActivated = Random.Range(0, quicksandZones.Length);
            if (!quicksandZones[zoneActivated].activeInHierarchy)
            {
                quicksandZones[zoneActivated].SetActive(true);
                Debug.Log("Set zone " + zoneActivated + " on! " + i + "/" + activateQuicksand);
            }
            else
            {
                i--;
            }
        }
    }

    void SpawnMeteor()
    {
        if (meteorSpawnPoints.Length == 0 || meteorPrefab == null) return;

        int meteorsActivated = Random.Range(3, meteorSpawnPoints.Length/2);

        for (int i = 0; i < meteorsActivated; i++)
        {
            int zoneActivated = Random.Range(0, meteorSpawnPoints.Length);
            Vector3 spawnPos = meteorSpawnPoints[zoneActivated].position + Vector3.up * height;

            GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
            Rigidbody rb = meteor.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.linearVelocity = Vector3.down * 30f;
                rb.angularVelocity += new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            }
        }
    }
}
