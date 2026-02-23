using UnityEngine;

public class Reprendre : MonoBehaviour
{
    public GameObject panelPauseMenu;
    public void reprendre()
    {
        panelPauseMenu.SetActive(false);
    }
}

