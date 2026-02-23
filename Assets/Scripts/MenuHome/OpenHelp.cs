using UnityEngine;

public class OpenHelp : MonoBehaviour
{
    public GameObject help;

    private void Start()
    {
        help.SetActive(false);
    }

    public void helpClick()
    {
        help.SetActive(true);
    }
}



