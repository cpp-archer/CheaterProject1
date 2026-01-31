using UnityEngine;

public class CamTriggerSwitch : MonoBehaviour
{

    //public GameObject wall;
    public GameObject cam1;
    public GameObject cam2;

    private void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            cam1.SetActive(!cam1.activeSelf);
            cam2.SetActive(!cam2.activeSelf);
            Debug.Log("switch");
        }
    }
}
