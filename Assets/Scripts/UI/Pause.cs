using UnityEngine;

public class Pause : MonoBehaviour
{
   // public GameObject pause;
    public void  pauseGame()
    {
        Time.timeScale = 0;
       // pause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        //pause.SetActive(false);

    }
}
