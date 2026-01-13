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

    private bool canRotate = false;
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


        //if (canRotate == true)
        //    Rotate();

        if (clickRef.action.ReadValue<float>() > 0)
            Rotate();

        if(direction == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            //print("move");
            animator.SetBool("IsWalking", true);
            basePosition = controller.transform.position;
        }
    }

    //private void OnClick(InputAction.CallbackContext context)
    //{
    //    canRotate = !canRotate;
    //    Debug.Log("OnClick");
    //}
    //private void OnEnable()
    //{
    //    clickRef.action.performed += OnClick;
    //}

    //private void OnDisable()
    //{
    //    clickRef.action.performed -= OnClick;
    //}
    private void Rotate()
    {
        //player rotation

        //float mouseRotation = lookActionRef.controller.MouseRotation.ReadValue<float>();
        float mouseRotation = lookActionRef.action.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * mouseRotation);
    }
}
