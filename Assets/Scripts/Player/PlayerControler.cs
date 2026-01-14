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

    public float moveSpeed = 0.5f;

  
    private Vector3 basePosition;

    private Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        basePosition = controller.transform.position;

        animator = controller.GetComponent<Animator>();

    }

    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();

        //g d a ar
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

        controller.Move(direction * Time.deltaTime * moveSpeed);


        if (clickRef.action.ReadValue<float>() > 0)
            Rotate();

        if (direction == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsBacking", false);

        }

        if (direction == Vector3.forward)
        {
            //print("move");
            animator.SetBool("IsWalking", true);
            basePosition = controller.transform.position;
        }

        if(direction == Vector3.back)
        {
             animator.SetBool("IsBacking", true);
            basePosition = controller.transform.position;
        }
    }

  
    private void Rotate()
    {

        float mouseRotation = lookActionRef.action.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);
    }
}
