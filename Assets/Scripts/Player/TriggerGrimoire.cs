using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TriggerGrimoire : MonoBehaviour
{
    public InputActionReference readActionRef;

    public Animator animator; //animation du grimoire

    public Animator anim; //animation du perso

    //panel de la touche E
    public GameObject EPanel;

    //etats pour ne pas pouvoir read n'importe où
    private bool isReading = false;
    private bool inRange = false;

    private PlayerControlerGood player;

    public GameObject waterBall;
    public GameObject waterTrigger;

    public AudioSource bubblePop;

    private bool waterOn = true;

    public GameObject waterAura;

    public AudioClip waterBend;

    private void Start()
    {
        EPanel.SetActive(false);

        animator.SetBool("isRead", false); //grim
        anim.SetBool("IsReading", false); //player

        waterTrigger.SetActive(false);

        waterAura.SetActive(false);
    }

    private void Update()
    {
        StopStartWater();
    }

    private void StopStartWater()
    {
        if (inRange && waterOn == true)
        {
            waterBall.SetActive(false);
            waterTrigger.SetActive(true);
            //AudioSource.PlayClipAtPoint(bubblePop, transform.position);
            bubblePop.Play();
            waterOn = false;
        }
    }

    //en collision avec le grimoire
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            player = other.GetComponent<PlayerControlerGood>();
            EPanel.SetActive(true);
            inRange = true;
            Debug.Log("okak ouvertAPPUY SUR E PLS");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inRange = false;
            EPanel.SetActive(false);
            waterOn = false;
        }
    }

    private void OnEnable()
    {
        readActionRef.action.performed += ReadGrimoire;
        readActionRef.action.canceled += stopRead;
    }
    private void OnDisable()
    {
        readActionRef.action.performed -= ReadGrimoire;
        readActionRef.action.canceled -= stopRead;
    }

    //au clic on appelle la coroutine de lecture
    private void ReadGrimoire(InputAction.CallbackContext context)
    {
        if (inRange && !isReading) //dans la zone + pas deja reading
        {
            StartCoroutine(ReadCoroutine());
            waterAura.SetActive(true);
            Debug.Log("reding");
            AudioSource.PlayClipAtPoint(waterBend, transform.position);
        }
    }

    //si le joueur arrete d'appuyer sur e pdt 5sec
    private void stopRead(InputAction.CallbackContext context)
    {
        if (isReading)
        {
           // StopCoroutine(ReadCoroutine()); //ca arrete la coroutine de lecture
            cancelReading();
            waterAura.SetActive(false);
            
            Debug.Log("lecture ff");
        }
    }
 

    //anim gestion
    private IEnumerator ReadCoroutine()
    {
        isReading = true;
        player.canMove = false;
       
        animator.SetBool("isRead", true);
        anim.SetBool("IsReading", true);

        Debug.Log("reading");

        float timer = 0f;
        float readTime = 5f;

        while (timer < readTime)
        {
            if (!readActionRef.action.IsPressed())
            {
                cancelReading();
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }
      //  yield return new WaitForSeconds(5);

        Debug.Log("grim lu");

        cancelReading();
        

        //animator.SetBool("isRead", false);
        //anim.SetBool("IsReading", false);
        //player.canMove = true;

        //isReading = false;
    }

    private void cancelReading()
    {
        animator.SetBool("isRead", false);
        anim.SetBool("IsReading", false);
        player.canMove = true;
        isReading = false;
        waterAura.SetActive(false);
    }
}
