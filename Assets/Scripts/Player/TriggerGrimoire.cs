using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TriggerGrimoire : MonoBehaviour
{
    public InputActionReference readActionRef;

    private Animator animator;

    //panel de la touche E
    public GameObject EPanel;

    //etats pour ne pas pouvoir read n'importe où
    private bool isReading = false;
    private bool inRange = false;

    private void Start()
    {
        EPanel.SetActive(false);

        //animation setup
        animator = GetComponent<Animator>();
        animator.SetBool("isRead", false);
    }


    //en collision avec le grimoire
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
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
        }
    }

    private void OnEnable()
    {
        readActionRef.action.performed += ReadGrimoire;
    }
    private void OnDisable()
    {
        readActionRef.action.performed -= ReadGrimoire;
    }

    //au clic on appelle la coroutine de lecture
    private void ReadGrimoire(InputAction.CallbackContext context)
    {
        if(inRange && !isReading) //dans la zone + pas deja reading
        {
            StartCoroutine(ReadCoroutine());

            Debug.Log("reding");
        }                  
    }

    //anim gestion
    private IEnumerator ReadCoroutine()
    {
        isReading = true;
        animator.SetBool("isRead", true);
        Debug.Log("reading");

        yield return new WaitForSeconds(5);
        animator.SetBool("isRead", false);
        isReading = false;
    }
}
