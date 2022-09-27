using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public Transform [] destinations;

    public float distanceToFollowPath = 2;

    private int i = 0;

    public GameObject player;

    public float distancetofollowplayer = 5.0f;

        void Start()
        {
            navMeshAgent.destination = destinations[i].transform.position;

            navMeshAgent = GetComponent<NavMeshAgent>();

        }

    void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < distancetofollowplayer)
        {
            navMeshAgent.destination = player.transform.position;
        }
        else
        {
            EnemyPath();
        }

    }


    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

    }


}