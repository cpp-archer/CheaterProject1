using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    public void homeback()
    {
        Debug.Log("bye");
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

}
