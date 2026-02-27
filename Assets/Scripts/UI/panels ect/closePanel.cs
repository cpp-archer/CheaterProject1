using Unity.VisualScripting;
using UnityEngine;

public class closePanel : MonoBehaviour
{
    public GameObject panelTclose;
    public AudioSource roche;

    public void closePanelBack()
    {
        panelTclose.SetActive(false);
        Debug.Log("ok fermé");
        roche.Play();
    }
}
