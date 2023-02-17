using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol: MonoBehaviour {
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int currentWaypoint = 0;
    void Start () {
        navMeshAgent.SetDestination (waypoints[currentWaypoint].position);
    }

    // Update is called once per frame
    void Update () {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[currentWaypoint].position);
        }
    }
}
