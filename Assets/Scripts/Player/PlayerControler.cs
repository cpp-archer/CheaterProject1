using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControler : MonoBehaviour
{
    public InputActionReference moveActionRef; //droite gauche devant derriere

    private CharacterController controller;
    public float moveSpeed = 5f;

    private AudioSource bee;

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

    }
}
