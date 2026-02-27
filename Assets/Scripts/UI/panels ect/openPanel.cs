using UnityEditor;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    public GameObject panelToOpen;
    public AudioSource roche;

    void Start()
    {
        panelToOpen.SetActive(false);
    }

     public void OpenPanel()
     {
        panelToOpen.SetActive(true);
        roche.Play();
    }

}
