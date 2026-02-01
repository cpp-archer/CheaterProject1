using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TriggerGrimoire : MonoBehaviour
{
    public InputActionReference readActionRef;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRead", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            UImanager.panel.ShowEPanel(true);
            Debug.Log("okak ouvertAPPUY SUR E PLS");
        }
    }

    private void OnTriggerExit(Collider other)
     {
        if (other.CompareTag("player"))
        {
            UImanager.panel.ShowEPanel(false);
            //EPanel.SetActive(false);
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
        animator.SetBool("isRead", true);
        Debug.Log("reding");
    }
}
