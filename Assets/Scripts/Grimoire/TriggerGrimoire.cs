using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class TriggerGrimoire : MonoBehaviour
{
    public InputActionReference readActionRef;
    private PlayerControlerGood player;

    public Animator animator; //animation du grimoire
    public Animator anim; //animation du perso quand il lira

    //panel de la touche E d'interaction
    public GameObject EPanel;

    //etats pour ne pas pouvoir read n'importe où
    private bool isReading = false;
    private bool inRange = false;

    public bool grimIsLu = false;

    //decors
    public GameObject waterAura;
    public GameObject waterBall;
    public GameObject waterTrigger;

    private bool waterOn = true;

    //sons
    public AudioClip waterBend;
    public AudioSource bubblePop;

    public GameObject progressBar;
    public Image fillImg;


    public GameObject dejaLuPanel;

    private void Start()
    {

        progressBar.SetActive(false);
        dejaLuPanel.SetActive(false);

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
        if (grimIsLu)
        {
            StartCoroutine(alrLu());
            EPanel.SetActive(false);
            return;
        }
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

        progressBar.SetActive(true);

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

            fillImg.fillAmount =timer / readTime;
            yield return null;
        }
      //  yield return new WaitForSeconds(5);

        Debug.Log("grim lu");
        grimIsLu = true;
        cancelReading();

    }

    private void cancelReading()
    {
        animator.SetBool("isRead", false);
        anim.SetBool("IsReading", false);
        player.canMove = true;
        isReading = false;
        waterAura.SetActive(false);

        fillImg.fillAmount = 0;
        progressBar.SetActive(false);
    }

    IEnumerator alrLu()
    {
        dejaLuPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        dejaLuPanel.SetActive(false);
    }
}
