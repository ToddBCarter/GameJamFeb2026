using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 4f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        int currentCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(lightningPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
