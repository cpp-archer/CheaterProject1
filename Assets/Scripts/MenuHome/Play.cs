using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Play : MonoBehaviour
{
    public void playbutton()
    {
        Debug.Log("go");
        SceneManager.LoadScene("test2");
    }
}
