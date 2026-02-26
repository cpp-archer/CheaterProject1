
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.InputSystem.XR;

public class IAMove : MonoBehaviour
{
    private int destPoint = 0;
    private NavMeshAgent agent;

    //etat du catch player
    public Transform target;
    public float viewDistance = 10f;
    public float viewAngle = 20f;

    private bool playerDetected;

    public GameObject panelLoose;

    //bandes
    public Transform[] bande1;
    public Transform[] bande2;
    public Transform[] bande3;

    //patrouille
    private Transform[] currentBande;
    private Transform[] points;

    //private int bandeIndex = 0;
   // private int pointToGo = 0;

    public Transform grimPoint;

    //public Animator idleAnim;
    public float waitAtBalise;
    private bool waiting = false;

   private Animator animatorIA;

    public AudioSource gaspSound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("player").transform;
        agent.enabled = true;

        panelLoose.SetActive(false);
        animatorIA = GetComponent<Animator>();

        animatorIA.SetBool("isIdle", false);
        animatorIA.SetBool("isRunning", false);
        Shuffle(2);
    }
    void Update()
    {
        if (!playerDetected)
        {
            //if (!agent.pathPending && agent.remainingDistance < 0.5f)
            //    GotoNextPoint();

            if(!agent.pathPending && agent.remainingDistance < 0.5f && !waiting)
            {
                StartCoroutine(idlePoint());
            }

        }
      Detection();
        //DrawViewCone();
    }

    private void Shuffle(int numberByBande)
    {
        points = new Transform[numberByBande * 3 + 1];

        for (int i = 0; i < numberByBande; i ++)
        {
            //points[i] = bande1[Random.Range(0, bande1.Length)];
            //points[i + 1] = bande2[Random.Range(0, bande2.Length)];
            //points[i + 2] = bande3[Random.Range(0, bande3.Length)];

            points[0 + i * 3] = bande1[Random.Range(0, bande1.Length)];
            Debug.Log("B1, point" +  points[0+i*3].name);
            
            points[1 + i * 3] = bande2[Random.Range(0, bande2.Length)];
            Debug.Log(" B2, point" + points[1 + i * 3].name);

            points[2 + i * 3] = bande3[Random.Range(0, bande3.Length)];
            Debug.Log("B3, point" + points[2 + i * 3].name);
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
    }


    private void Detection()
    {
        //distance
        float playerDistance = Vector3.Distance(target.position, transform.position);

        //si le joueur est pas assez proche on fait nada
        //if (playerDistance > viewDistance)
        //    return;


        //angle
        Vector3 targetDir = target.position + Vector3.up * 2 - transform.position;
        Debug.DrawRay(transform.position, targetDir, Color.red, Time.deltaTime);

        float angle = Vector3.Angle(targetDir, transform.forward);
        if (angle > viewAngle)
            return;

        //raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, targetDir, out hit, viewDistance))
        {
            if (hit.collider.gameObject.tag == "player") //l'ia nous suit
            {
                Debug.Log("I see you");
                playerDetected = true;
                StartCoroutine(loose());
                //Time.timeScale = 0f;
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

    IEnumerator loose()
    {
        if(playerDetected == true)
        {
            agent.isStopped = true;
            animatorIA.SetBool("isPointing", true);
            
            yield return new WaitForSeconds(2f);

            animatorIA.SetBool("isRunning", true);
            agent.speed = 8f;

            agent.isStopped = false;
            agent.SetDestination(target.position);

            Debug.Log("perdu");

            gaspSound.Play();

            yield return new WaitForSeconds(2f);
           
            panelLoose.SetActive(true);
            Time.timeScale = 0f;

        }
    }
    //void looser()
    //{
    //    if (playerDetected == true)
    //    {
    //        Debug.Log("perdu");
    //         agent.SetDestination(target.position);
    //        panelLoose.SetActive(true);
    //    }
    //}

    IEnumerator idlePoint()
    {
        waiting = true;
        agent.isStopped = true;

        animatorIA.SetBool("isIdle", true);

        yield return new WaitForSeconds(3f);

        animatorIA.SetBool("isIdle", false);

        agent.isStopped = false;
        GotoNextPoint();
        waiting = false;
    }

}
