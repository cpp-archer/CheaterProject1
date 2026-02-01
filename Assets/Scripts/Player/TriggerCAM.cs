using UnityEngine;

public class CamTriggerSwitch : MonoBehaviour
{

    //public GameObject wall;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private void Start()
    {
        //cam1.SetActive(true);
        //cam2.SetActive(false);
        //cam3.SetActive(false);
        SwitchCam(cam1);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "wall2")
        {
        //    cam1.SetActive(!cam1.activeSelf);
        //    cam2.SetActive(!cam2.activeSelf);
        //    Debug.Log("switch");

            SwitchCam(cam2);
        }

        if(other.tag== "wall3")
        {
            //cam1.SetActive(false);
            //cam2.SetActive(false);
            //cam3.SetActive(!cam3.activeSelf);
            SwitchCam(cam3);
        }
        if(other.tag == "wall1")
            SwitchCam(cam1);
    }

    private void SwitchCam(GameObject cam)
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam.SetActive(true);
    }
}
