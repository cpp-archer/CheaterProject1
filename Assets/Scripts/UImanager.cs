using UnityEngine;

public class UImanager : MonoBehaviour
{

    public static UImanager panel;
    public GameObject EPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel = this;
        EPanel.SetActive(false);
    }

    public void ShowEPanel(bool show)
    {
        EPanel.SetActive(show);
    }
}
