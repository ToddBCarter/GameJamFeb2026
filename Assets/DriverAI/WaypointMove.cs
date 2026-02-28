using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class WaypointMove : MonoBehaviour
{
    [SerializeField] List<Transform> Destinations;
    NavMeshAgent NavMeshAgent;

    private int currentWaypoint = 0;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavMeshAgent = this.GetComponent<NavMeshAgent>();
        if (NavMeshAgent != null) {
            SetDestination();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance) 
            MoveRoutine();
    }
}
