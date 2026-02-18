
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UIElements;

public class IAMove : MonoBehaviour
{
    private int destPoint = 0;
    private NavMeshAgent agent;

    //etat du catch player
    public Transform target;
    public float viewDistance = 20f;
    public float viewAngle = 45f;

    private bool playerDetected;

    public GameObject panelLoose;

    //bandes
    public Transform[] bande1;
    public Transform[] bande2;
    public Transform[] bande3;

    //patrouille
    private Transform[] currentBande;
    private Transform[] points;

    private int bandeIndex = 0;
    private int pointToGo = 0;

    public Transform grimPoint;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //GotoNextPoint();

        target = GameObject.FindGameObjectWithTag("player").transform;
        agent.enabled = true;

        //ChangeBande();

        panelLoose.SetActive(false);

        Shuffle(2);
    }
    void Update()
    {
        if (!playerDetected)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
     //  Detection();
        DrawViewCone();
    }

    //private void ChangeBande()
    //{
    //    if (bandeIndex == 0)
    //    {
    //        currentBande = bande1;
    //    }
    //    else if (bandeIndex == 1)
    //    {
    //        currentBande = bande2;
    //    }
    //    else
    //    {
    //        currentBande = bande3;
    //    }

    //    //on choisi 1 ou 2 points a visiter
    //    // pointToGo = Random.Range(2, 3);
    //    pointToGo = 2;

    //    points = new Transform[pointToGo + 1]; //+1 pour le grimoire

    //    //on parcours les points a visiter
    //    for (int i = 0; i < pointToGo; i++)
    //    {
    //        //on choisit un point random dans la bande
    //        int rdm = Random.Range(0, currentBande.Length);
    //        points[i] = currentBande[rdm];

    //        Debug.Log("point" + points[i].name + "bande" + bandeIndex);
    //    }

    //    points[pointToGo] = grimPoint;
    //    Debug.Log("gogrimoire");

    //    //pour revenir a bande1
    //    bandeIndex++;
    //    if (bandeIndex > 2)
    //    {
    //        bandeIndex = 0;
    //    }
    //    Debug.Log(bandeIndex);
    //    destPoint = 0;
    //    GotoNextPoint();
    //}

    private void Shuffle(int numberByBande)
    {
        points = new Transform[numberByBande * 3 + 1];

        for (int i = 0; i < numberByBande; i ++)
        {
            //points[i] = bande1[Random.Range(0, bande1.Length)];
            //points[i + 1] = bande2[Random.Range(0, bande2.Length)];
            //points[i + 2] = bande3[Random.Range(0, bande3.Length)];

            points[0 + i * 3] = bande1[Random.Range(0, bande1.Length)];
            Debug.Log("Bande 1, point" +  points[0+i*3].name);
            
            points[1 + i * 3] = bande2[Random.Range(0, bande2.Length)];
            Debug.Log("Bande 2, point" + points[1 + i * 3].name);

            points[2 + i * 3] = bande3[Random.Range(0, bande3.Length)];
            Debug.Log("Bande 3, point" + points[2 + i * 3].name);
        }

        points[numberByBande * 3] = grimPoint;
        Debug.Log("grimoirePoint");

        for (int i = 0; i < points.Length; i++)
        {
            int rdm = Random.Range(0, points.Length);
            Transform copie = points[i];
            points[i] = points[rdm];
            points[rdm] = copie;
            Debug.Log(points[i]);
        }

    }
   private void GotoNextPoint()
    {
        if (destPoint >= points.Length)
            destPoint = 0;

        agent.SetDestination(points[destPoint].position);

        destPoint++;


        //agent.destination = points[destPoint].position;
        //agent.SetDestination(points[destPoint].position);



        //si on a fait tout les points de la bande (donc le rdm entre 3 et 6)
        //if(destPoint >= points.Length)
        //if(destPoint==points.Length-1)
        //{
        //ChangeBande();
        //return; //pattern fini on se taille de la bande
        //}
        //destPoint++; //pour keep track du rdm
        //destPoint = (destPoint + 1) % points.Length;
        //destPoint = Random.Range(0, points.Length);
    }


    //private void Detection()
    //{
    //    //distance
    //    float playerDistance = Vector3.Distance(target.position, transform.position);

    //    //si le joueur est pas assez proche on fait nada
    //    if (playerDistance > viewDistance)
    //        return;


    //    //angle
    //    Vector3 targetDir = target.position + Vector3.up * 2 - transform.position;
    //    Debug.DrawRay(transform.position, targetDir, Color.red, Time.deltaTime);

    //    float angle = Vector3.Angle(targetDir, transform.forward);
    //    if (angle > viewAngle)
    //        return;

    //    //raycast
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, targetDir, out hit, viewDistance))
    //    {
    //        if (hit.collider.gameObject.tag == "player") //l'ia nous suit
    //        {
    //            Debug.Log("I see you");
    //            playerDetected = true;
    //            looser();
    //        }
    //        else
    //        {
    //            Debug.Log("I don't see you");
    //        }
    //    }
    //}
    void DrawViewCone()
    {
        int rayCount = 15;
        float stepAngle = (viewAngle * 2) / rayCount;

        for (int i = 0; i <= rayCount; i++)
        {
            float angle = -viewAngle + stepAngle * i;
            Vector3 dir = Quaternion.Euler(0, angle, 0) * transform.forward;

            Debug.DrawRay(transform.position, dir * viewDistance, Color.yellow);
        }
    }
    void looser()
    {
        //if(playerDetected == true)
        //{
        Debug.Log("perdu");
        agent.SetDestination(target.position);
        //panelLoose.SetActive(true);
        //}
    }

}
