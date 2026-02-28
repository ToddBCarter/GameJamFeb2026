using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] List<Transform> Destinations;
    NavMeshAgent NavMeshAgent;

    private int currentWaypoint = 0;

    private float baseSpeed;
    [SerializeField] float speedVariance = 2f;
    [SerializeField] float minChangeInterval = 2f;
    [SerializeField] float maxChangeInterval = 5f;
    [SerializeField] float smoothingValue = 0.5f;
    private float speedChangeTimer;

    private void SetDestination()
    {
        Vector3 targetVector = Destinations[currentWaypoint].transform.position;
        //Destinations[currentWaypoint].position
        NavMeshAgent.SetDestination(targetVector);
    }

    private void MoveRoutine()
    {
        SetDestination();

        if(currentWaypoint == Destinations.Count - 1) {
            currentWaypoint = 0;
        } else {
            currentWaypoint++;
        }
    }

    private void ScheduleSpeedChange()
    {
        speedChangeTimer = Random.Range(minChangeInterval, maxChangeInterval);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavMeshAgent = this.GetComponent<NavMeshAgent>();
        if (NavMeshAgent != null) {
            baseSpeed = NavMeshAgent.speed;
            ScheduleSpeedChange();
            SetDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        speedChangeTimer -= Time.deltaTime;
        if (speedChangeTimer <= 0f) {
            float randomOffset = Random.Range(-speedVariance, speedVariance);
            NavMeshAgent.speed = Mathf.Lerp(NavMeshAgent.speed, (baseSpeed + randomOffset), (Time.deltaTime * smoothingValue));
            //Debug.Log("Current speed: " + NavMeshAgent.speed);
        }

        if (!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance) 
            MoveRoutine();
    }
}
