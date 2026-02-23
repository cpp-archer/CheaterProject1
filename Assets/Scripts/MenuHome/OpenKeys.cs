using UnityEngine;
using UnityEngine.InputSystem;

public class OpenKeys : MonoBehaviour
{
    public GameObject touches;

    private void Start()
    {
        touches.SetActive(false);
    }

    public void keysClick()
    {
        touches.SetActive(true);
    }
}


