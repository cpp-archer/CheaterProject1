using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;

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

    //anim
    private Animator animator;

   
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

    void Start()
    {
      
        controller = GetComponent<CharacterController>();
        animator = controller.GetComponent<Animator>();
        //controller.height = 2f;
    }

    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

        //selon la rotate du perso
        Vector3 moveDirection = transform.TransformDirection(direction);

        //crouched = crouchRef.action.ReadValue<float>() > 0;
        //animator.SetBool("IsCrouched", crouched);

        if (!crouched)
            controller.Move(moveDirection * Time.deltaTime * moveSpeed);

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
        
        //if (crouchRef.action.ReadValue<float>() > 0)
        //{
        //    animator.SetBool("IsCrouched", true);
        //    //crouched = !crouched;
        //}

        //animator.SetBool("IsCrouched", crouchRef.action.ReadValue<float>() > 0);
    }

    private void Rotate()
    {      
        rotated = true;
        float mouseRotation = rotationRef.action.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);
    }


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

