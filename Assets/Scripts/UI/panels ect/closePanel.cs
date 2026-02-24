using UnityEngine;

public class closePanel : MonoBehaviour
{
    public GameObject panelTclose;

    public void closePanelBack()
    {
        panelTclose.SetActive(false);
        Debug.Log("ok fermé");
    }


}
