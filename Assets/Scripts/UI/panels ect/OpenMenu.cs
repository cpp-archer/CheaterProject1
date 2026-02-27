using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMenu : MonoBehaviour
{
    public GameObject menuOptions;
    public InputActionReference openMenuActionRef;
    public GameObject aidePanelFirst;
    public GameObject touchesPanel;
    public GameObject aidePanel;

    public AudioSource roche;

    void Start()
    {
        menuOptions.SetActive(false);
        Time.timeScale = 0;
        aidePanelFirst.SetActive(true);
        touchesPanel.SetActive(false);
        aidePanel.SetActive(false);
    }

    public void menuClick() //pour le click souris
    {
        if (aidePanel.activeSelf || touchesPanel.activeSelf || aidePanel.activeSelf)
        {
            aidePanel.SetActive(false);
            touchesPanel.SetActive(false);
            menuOptions.SetActive(false);
            aidePanelFirst.SetActive(false);
            roche.Play();

        }
        menuOptions.SetActive(!menuOptions.activeSelf);

        if (menuOptions.activeSelf)
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
        if(aidePanel.activeSelf || touchesPanel.activeSelf || aidePanelFirst.activeSelf)
        {
            aidePanel.SetActive(false);
            touchesPanel.SetActive(false);
            menuOptions.SetActive(false);
            aidePanelFirst.SetActive(false);
            roche.Play();
        }
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
