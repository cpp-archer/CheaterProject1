
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UIElements;


public class IAMove2 : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    public Transform target;
    public float viewDistance = 10.0f;
    public float viewAngle = 30.0f;


    bool playerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
        agent.enabled = true;
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        //agent.destination = points[destPoint].position;
        agent.SetDestination(points[destPoint].position);

        destPoint = (destPoint + 1) % points.Length;
        //destPoint = Random.Range(0, points.Length);

    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();


        Detection();
      //DrawViewCone();

    }

    private void Detection()
    {

        //distance
        float playerDistance= Vector3.Distance(target.position, transform.position);

        //angle
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        Debug.DrawRay(transform.position, targetDir, Color.red);
        if (angle < viewAngle)
        {
            Debug.Log("Close");
        }
       
        //raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, targetDir, out hit, viewDistance))
        {
            if (hit.transform == target)
            {
                Debug.Log("I see you");
                playerDetected = true;
            }
        else
        {
                Debug.Log("I don't see you");
         }
            
        }
    }
    //void DrawViewCone()
    //{
    //    int rayCount = 15; 
    //    float stepAngle = (viewAngle * 2) / rayCount;

    //    for (int i = 0; i <= rayCount; i++)
    //    {
    //        float angle = -viewAngle + stepAngle * i;
    //        Vector3 dir = Quaternion.Euler(0, angle, 0) * transform.forward;

    //        Debug.DrawRay(transform.position, dir * viewDistance, Color.yellow);
    //    }
    //}

}
