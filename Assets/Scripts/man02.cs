using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class man02 : MonoBehaviour
{
    public float partrolSpeed = 3f;
    //public float partrolWaitTime = 0.5f;
    public Transform patrolWayPoints;

    private NavMeshAgent agent;
    private float patrolTimer = 0f;
    private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }
    void Patrolling()
    {
        agent.isStopped = false;
        agent.speed = partrolSpeed;
        if (agent.remainingDistance < agent.stoppingDistance)
        {

            patrolTimer += Time.deltaTime;
            wayPointIndex++;
        }
        agent.destination = patrolWayPoints.GetChild(wayPointIndex).position;
    }
}
