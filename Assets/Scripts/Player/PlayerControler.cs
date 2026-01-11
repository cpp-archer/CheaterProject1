using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere
    public InputActionReference lookActionRef;
    private float _rotateSpeed = 50f;
    private CharacterController controller;

    public float moveSpeed = 5f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 stickDirection = moveActionRef.action.ReadValue<Vector2>();

        //g d a ar
        Vector3 direction = new Vector3(stickDirection.x, 0, stickDirection.y);

        controller.Move(direction * Time.deltaTime * moveSpeed);


        DogMovement();
    }

    private void DogMovement()
    {
        //player rotation

        //float mouseRotation = lookActionRef.controller.MouseRotation.ReadValue<float>();
        float mouseRotation = lookActionRef.action.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed * mouseRotation);
    }
}
