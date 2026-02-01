using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TriggerGrimoire : MonoBehaviour
{
    public InputActionReference readActionRef;

    private Animator animator;
    public GameObject EPanel;


    private bool isReading = false;
    private bool inRange = false;

    private void Start()
    {
        EPanel.SetActive(false);
        animator = GetComponent<Animator>();
        animator.SetBool("isRead", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            EPanel.SetActive(true);
            inRange = true;
            //UImanager.panel.ShowEPanel(true);
            Debug.Log("okak ouvertAPPUY SUR E PLS");
        }
    }

    private void OnTriggerExit(Collider other)
     {
        if (other.CompareTag("player"))
        {
            inRange = false;
            //UImanager.panel.ShowEPanel(false);
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
    private void ReadGrimoire(InputAction.CallbackContext context)
    {

        if(inRange && !isReading)
        {
            StartCoroutine(ReadCoroutine());

            Debug.Log("reding");
        }
            
        //animator.SetBool("isRead", true);
        
        
        
    }


    private IEnumerator ReadCoroutine()
    {
        isReading = true;
        animator.SetBool("isRead", true);
        Debug.Log("reding");

        yield return new WaitForSeconds(5);
        animator.SetBool("isRead", false);
        isReading = false;
    }
}
