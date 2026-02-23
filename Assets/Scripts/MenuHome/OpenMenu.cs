using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuOptions;
    public InputActionReference openMenuActionRef;
    void Start()
    {
        menuOptions.SetActive(false);
    }

    public void menuClick() //pour le click souris
    {
        menuOptions.SetActive(!menuOptions.activeSelf);
    }

    private void OnEnable()
    {
        openMenuActionRef.action.performed += openMenu;
    }

    private void OnDisable()
    {
        openMenuActionRef.action.performed -= openMenu;
    }

    public void openMenu(InputAction.CallbackContext context) //pour btn clavier
    {
        menuOptions.SetActive(!menuOptions.activeSelf);
        Debug.Log(menuOptions.activeSelf);
    }
}
