using UnityEngine;
using UnityEngine.InputSystem;

public class TutoKeys : MonoBehaviour
{
    public GameObject keysPanel;
    public InputActionReference openKeysActionRef;

    void Start()
    {
        keysPanel.SetActive(true);
    }
    public void tutoClick() //click souris
    {
        keysPanel.SetActive(!keysPanel.activeSelf);
    }

    private void OnEnable()
    {
        openKeysActionRef.action.performed += openTuto;
    }

    private void OnDisable()
    {
        openKeysActionRef.action.performed -= openTuto;
    }

    private void openTuto(InputAction.CallbackContext context)
    {
        keysPanel.SetActive(!keysPanel.activeSelf);
        Debug.Log(keysPanel.activeSelf);
    }
}
