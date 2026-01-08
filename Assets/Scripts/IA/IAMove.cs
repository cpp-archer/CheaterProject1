    using UnityEngine;
using UnityEngine.AI;

public class IaMove : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        //agent.destination = goal.position;
        //agent.SetDestination(goal.position);  
    }


}
