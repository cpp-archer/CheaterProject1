using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere
    public InputActionReference lookActionRef;
    public InputActionReference clickRef;

    private float rotateSpeed = 50f;
    private CharacterController controller;

    // public float moveSpeed = 0.5f;

    private bool rotated = false;

    private Vector3 basePosition;

    private Animator animator;
    //public AnimationClip anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        basePosition = controller.transform.position;

        animator = controller.GetComponent<Animator>();
        // anim.speed = 5;
    }

    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);


        //comm pour pas que jme deplace en + de l'animation
        //controller.Move(direction * Time.deltaTime * moveSpeed);



        if (clickRef.action.ReadValue<float>() > 0)
        {
            Rotate();
        }
        if (direction == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsBacking", false);
            animator.SetBool("IsRighting", false);
            animator.SetBool("IsLefting", false);

            rotated = false;
        }

        //if(!rotated)
            controller.transform.eulerAngles = new Vector3(0, 0, 0);

        if (direction == Vector3.forward)
        {
            //print("move");
            animator.SetBool("IsWalking", true);

            //basePosition = controller.transform.position;
        }

        else if (direction == Vector3.back)
        {
            animator.SetBool("IsBacking", true);
            //basePosition = controller.transform.position;

        }

        else if (direction == Vector3.right)
        {
            animator.SetBool("IsRighting", true);
            //basePosition = controller.transform.position;

            //if (clickRef.action.ReadValue<float>() == 0 && !rotated)
            if (!rotated)
                controller.transform.eulerAngles = new Vector3(0, 5, 0); //sinon elle se taille
            //else if (clickRef.action.ReadValue<float>() > 0)
            //    Rotate();
        }
        else if (direction == Vector3.left)
        {
            animator.SetBool("IsLefting", true);
            //basePosition = controller.transform.position;

           // if (clickRef.action.ReadValue<float>() == 0 && !rotated)
           if(!rotated)
                controller.transform.eulerAngles = new Vector3(0, -19, 0);
            //else if(clickRef.action.ReadValue<float>() > 0)
            //    Rotate();
        }
    }


    private void Rotate()
    {

        float mouseRotation = lookActionRef.action.ReadValue<float>();


        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);

        rotated = true;
    }
}
