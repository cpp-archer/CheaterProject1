using UnityEngine;

public class closeFirst : MonoBehaviour
{

    public GameObject first;

    public void closeFirstPanel()
    {
        first.SetActive(false);
        Debug.Log("ok fermé");
        Time.timeScale = 1;
    }


}

