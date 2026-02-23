using UnityEditor;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    public GameObject panelToOpen;
    void Start()
    {
        panelToOpen.SetActive(false);

    }

     public void OpenPanel()
     {
        panelToOpen.SetActive(true);
     }
    
}
