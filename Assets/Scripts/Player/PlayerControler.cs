using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere
    public InputActionReference rotationRef;
    public InputActionReference clickRef;
    public InputActionReference crouchRef; //souris

    private float rotateSpeed = 20f;
    private CharacterController controller;

    // public float moveSpeed = 0.5f;

    private bool rotated = false;

    //private Vector3 basePosition;

    private Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        //basePosition = controller.transform.position;

        animator = controller.GetComponent<Animator>();
        // anim.speed = 5;





    }


    //private void OnEnable()
    //{
    //    crouchRef.action.performed += Crouch;
    //}
    //private void OnDisable()
    //{
    //    crouchRef.action.performed -= Crouch;
    //}


    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);


        //comm pour pas que jme deplace en + de l'animation
        //controller.Move(direction * Time.deltaTime * moveSpeed);


        //if (direction == Vector3.zero)
        //{
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsBacking", false);
        animator.SetBool("IsRighting", false);
        animator.SetBool("IsLefting", false);
        //animator.SetBool("IsCrouched", false);
        //    rotated = false;
        //}
        if (clickRef.action.ReadValue<float>() > 0)
        {
            Rotate();
        }
       

        //if(!rotated)
            //controller.transform.eulerAngles = new Vector3(0, 0, 0);

        if (direction == Vector3.forward)
        {
            //print("move");
            animator.SetBool("IsWalking", true);

            if (clickRef.action.ReadValue<float>() == 0 && !rotated)
                controller.transform.eulerAngles = new Vector3(0, 0, 0);

            //basePosition = controller.transform.position;
        }

         if (direction == Vector3.back)
        {
            animator.SetBool("IsBacking", true);


            if (clickRef.action.ReadValue<float>() == 0 && !rotated)
                controller.transform.eulerAngles = new Vector3(0, 360, 0);
            //basePosition = controller.transform.position;

        }

         if (direction == Vector3.right)
        {
            animator.SetBool("IsRighting", true);
            //basePosition = controller.transform.position;

            //if (!rotated)
            if (clickRef.action.ReadValue<float>() == 0 && !rotated)
                controller.transform.eulerAngles = new Vector3(0, 5, 0); //sinon elle se taille
            //else if (clickRef.action.ReadValue<float>() > 0)
            //    Rotate();
        }
         if (direction == Vector3.left)
        {
            animator.SetBool("IsLefting", true);
            //basePosition = controller.transform.position;

            //if (!rotated)
            if (clickRef.action.ReadValue<float>() == 0 && !rotated)
                controller.transform.eulerAngles = new Vector3(0, -19, 0);
            //else if (clickRef.action.ReadValue<float>() > 0)
            //    Rotate();
        }
        if (crouchRef.action.ReadValue<float>() > 0)
        {
            animator.SetBool("IsCrouched", true);
        }

        if (direction == Vector3.zero)
            rotated = false;


    }


    private void Rotate()
    {

        float mouseRotation = rotationRef.action.ReadValue<float>();


        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);

        rotated = true;
    }


    //private void Crouch(InputAction.CallbackContext context)
    //{
    //    animator.SetBool("IsCrouched", !animator.GetBool("IsCrouched"));
    //    Debug.Log("crouch");
    //}
}



////playercontrolergood avant SOLID
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.XR;
//using UnityEngine.UIElements;

//public class PlayerControlerGood : MonoBehaviour
//{

//    //inputs
//    public InputActionReference moveActionRef; //droite gauche devant derriere
//    public InputActionReference rotationRef;
//    public InputActionReference clickRef;
//    public InputActionReference crouchRef; //souris

//    //controller
//    private CharacterController controller;

//    //param et etats du perso
//    private float rotateSpeed = 20f;
//    public float moveSpeed = 2f;
//    private bool rotated = false;

//    //anim
//    private Animator animator;

//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        animator = controller.GetComponent<Animator>();
//    }

//    void Update()
//    {
//        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
//        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

//        //selon la rotate du perso
//        Vector3 moveDirection = transform.TransformDirection(direction);

//        controller.Move(moveDirection * Time.deltaTime * moveSpeed);

//        animator.SetBool("IsWalking", false);
//        animator.SetBool("IsBacking", false);
//        animator.SetBool("IsRighting", false);
//        animator.SetBool("IsLefting", false);

//        if (clickRef.action.ReadValue<float>() > 0)
//        {
//            Rotate();
//        }

//        if (direction == Vector3.forward)
//        {
//            animator.SetBool("IsWalking", true);
//        }

//        if (direction == Vector3.back)
//        {
//            animator.SetBool("IsBacking", true);
//        }

//        if (direction == Vector3.right)
//        {
//            animator.SetBool("IsRighting", true);
//        }
//        if (direction == Vector3.left)
//        {
//            animator.SetBool("IsLefting", true);
//        }
//        if (crouchRef.action.ReadValue<float>() > 0)
//        {
//            animator.SetBool("IsCrouched", true);
//        }

//    }


//    private void Rotate()
//    {

//        float mouseRotation = rotationRef.action.ReadValue<float>();


//        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);

//        rotated = true;
//    }
//}
