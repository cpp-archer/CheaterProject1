    using UnityEngine;
using UnityEngine.AI;

public class IaMove : MonoBehaviour
{
    public Transform[] bande1;
    public Transform[] bande2;
    public Transform[] bande3;

    private Transform[] currentBande;
    private Transform[] currentBalise;

    private int bandeIndex = 0;
    private int pointoVisite;

    private NavMeshAgent agent;

    public Transform[] points;
    private int destPoint = 0;

    public Transform target;
    public float viewDistance = 20f;
    public float viewAngle = 45f;

    private bool playerDetected;

    public GameObject panelLoose;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("player").transform;


    }


    void ChangeBande()
    {
        if (bandeIndex == 0)
        {
            currentBande = bande1;

        }
        else if (bandeIndex == 1)
        {
            currentBande = bande2;
        }
        else
        {
            currentBande = bande3;
        }



        pointoVisite = Random.Range(3, 6);
        currentBalise = new Transform[pointoVisite];



        for(int i=0; i< pointoVisite; i++)
        {
            int rdm = Random.Range(0, currentBande.Length);
            currentBalise[i] = currentBande[rdm];

        }

        int destPoint = 0;//faut le set zzzzzzz

        //bandeIndex = 
    }



    private void GoNextPoint()
    {
        if(currentBalise.Length == 0)
        {
            return; //jsp frr 
        }

        agent.SetDestination(currentBalise[destPoint].position);

        destPoint++;
        if(destPoint >= currentBalise.Length)
        {
            ChangeBande();
        }
    }

}
