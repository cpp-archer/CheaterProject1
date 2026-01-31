using UnityEngine;

public class CamTriggerSwitch : MonoBehaviour
{

    //public GameObject wall;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            cam1.SetActive(!cam1.activeSelf);
            cam2.SetActive(!cam2.activeSelf);
            Debug.Log("switch");
        }

        if(other.tag== "wall2")
        {
            cam1.SetActive(!cam1.activeSelf);
            cam2.SetActive(!cam2.activeSelf);
            cam3.SetActive(!cam3.activeSelf);
        }
    }
}
