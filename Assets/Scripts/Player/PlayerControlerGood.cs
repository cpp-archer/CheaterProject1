using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using System.Collections;

public class PlayerControlerGood : MonoBehaviour
{
    //inputs
    public InputActionReference moveActionRef; //droite gauche devant derriere
    public InputActionReference rotationRef;
    public InputActionReference clickRef;
    public InputActionReference crouchRef; //souris

    //controller
    private CharacterController controller;

    //param et etats du perso
    private float rotateSpeed = 20f;
    public float moveSpeed = 2f;
    private bool rotated = false;
    private bool crouched = false;


    [SerializeField] float gravite = -20f;
    [SerializeField] float groundForce = -2f;
    private float vertical;

    //animations
    private Animator animator;
    private bool canMove = false;



    private void OnEnable()
    {
        crouchRef.action.Enable();

        crouchRef.action.performed += Crouch;
        crouchRef.action.canceled += UnCrouch;
    }
    private void OnDisable()
    {
        crouchRef.action.performed -= Crouch;
        crouchRef.action.canceled -= UnCrouch;

        crouchRef.action.Disable();
    }

    //void Start()
    //{
    //    //recuperation 
    //    controller = GetComponent<CharacterController>();
    //    animator = controller.GetComponent<Animator>();
    //    //controller.height = 2f;

    //    canMove = false;
    //    animator.SetTrigger("StandUp");
    //}
    IEnumerator Start()
    {
        controller = GetComponent<CharacterController>();
        animator = controller.GetComponent<Animator>();

        animator.SetTrigger("StandUp");
        yield return new WaitForSeconds(5f);
        canMove = true;

       
    }


    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

        //selon la rotate du perso
        Vector3 moveDirection = transform.TransformDirection(direction);

        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = vertical;
         vertical+= gravite * Time.deltaTime;
        
        if (!canMove)
            return;

        //pas de mouvement si crouched
        if (!crouched)
            controller.Move(velocity * Time.deltaTime);
            //controller.Move(moveDirection * Time.deltaTime * moveSpeed);

        //idle
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsBacking", false);
        animator.SetBool("IsRighting", false);
        animator.SetBool("IsLefting", false);
   
        if (clickRef.action.ReadValue<float>() > 0 && crouched ==false)
        {
           Rotate();
        }

        if (direction == Vector3.forward)
        {
         animator.SetBool("IsWalking", true);
        }

        if (direction == Vector3.back)
        {
            animator.SetBool("IsBacking", true);
        }

        if (direction == Vector3.right)
        {
            animator.SetBool("IsRighting", true);
        }

        if (direction == Vector3.left)
        {
            animator.SetBool("IsLefting", true);
        }
       
    }

    //rotate la souris
    private void Rotate()
    {      
        rotated = true;
        float mouseRotation = rotationRef.action.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);
    }

    //crouch et uncrouch
    private void Crouch(InputAction.CallbackContext context)
    {
        animator.SetBool("IsCrouched", true);//!animator.GetBool("IsCrouched"));
        Debug.Log("crouch");
        crouched = true;
    }
    private void UnCrouch(InputAction.CallbackContext context)
    {
        animator.SetBool("IsCrouched", false);//!animator.GetBool("IsCrouched"));
        Debug.Log("pluscrouch");
        crouched = false;
    }
  
}

