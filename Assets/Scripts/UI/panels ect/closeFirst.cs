using UnityEngine;

public class closeFirst : MonoBehaviour
{

    public GameObject first;
    public AudioSource roche;
    public GameObject menu;
    private void Start()
    {
        menu.SetActive(false);
    }

    public void closeFirstPanel()
    {
        first.SetActive(false);
        
    Debug.Log("ok fermé");
        menu.SetActive(true);
        Time.timeScale = 1;
        roche.Play();

    }


}

