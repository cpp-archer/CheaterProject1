using UnityEngine;

public class closeFirst : MonoBehaviour
{

    public GameObject first;
    public AudioSource roche;
    public GameObject menuEsc;
    private void Start()
    {
        menuEsc.SetActive(false);
    }

    public void closeFirstPanel()
    {
        first.SetActive(false); 
        Debug.Log("ok fermé");

        menuEsc.SetActive(true);

        Time.timeScale = 1;
        roche.Play();
    }


}

