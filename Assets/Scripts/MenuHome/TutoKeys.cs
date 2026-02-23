using UnityEngine;
using UnityEngine.InputSystem;

public class TutoKeys : MonoBehaviour
{
    public GameObject tutoP;
    public InputActionReference openTutoActionRef;

    void Start()
    {
        tutoP.SetActive(true);
    }
    public void tutoClick() //click souris
    {
        tutoP.SetActive(!tutoP.activeSelf);
    }

    private void OnEnable()
    {
        openTutoActionRef.action.performed += openTuto;
    }

    private void OnDisable()
    {
        openTutoActionRef.action.performed -= openTuto;
    }

    private void openTuto(InputAction.CallbackContext context)
    {
        tutoP.SetActive(!tutoP.activeSelf);
        Debug.Log(tutoP.activeSelf);
    }
}
