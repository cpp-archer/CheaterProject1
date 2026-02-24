using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuOptions;
    public InputActionReference openMenuActionRef;


    void Start()
    {
        menuOptions.SetActive(false);
        Time.timeScale = 1;
    }

    public void menuClick() //pour le click souris
    {
        menuOptions.SetActive(!menuOptions.activeSelf);
        
        if(menuOptions.activeSelf)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1;
        }

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

        if (menuOptions.activeSelf)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1;
        }


        Debug.Log(menuOptions.activeSelf);
        //Time.timeScale = 0;
    }
}
