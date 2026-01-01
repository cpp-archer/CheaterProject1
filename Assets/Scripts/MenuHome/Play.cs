using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public void playbutton()
    {
        Debug.Log("go");
        SceneManager.LoadScene("room");
    }
}
