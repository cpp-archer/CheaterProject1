
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class IAMove2 : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        //agent.destination = points[destPoint].position;
        agent.SetDestination(points[destPoint].position);

        destPoint = (destPoint + 1)% points.Length;
        //destPoint = Random.Range(0, points.Length);
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
