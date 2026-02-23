using UnityEngine;

public class CamTriggerSwitch : MonoBehaviour
{

    //public GameObject wall;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    Collider cam1C;
    Collider cam2C;
    Collider cam3C;


    private int ordre=1;

    private void Start()
    {

        SwitchCam(cam1);
        ordre = 1;

    }
    private void OnTriggerStay(Collider other)
    {
   
        //cam 1 au pont (2eme cam)
        if(other.tag== "wall2")
        {     
            SwitchCam(cam2);
            ordre = 2;

          //  return;
        }

       else if(other.tag == "wall3" && ordre == 2)
        {
            SwitchCam(cam3);
            ordre = 3;

        }

       else if(other.tag == "wall4" && ordre == 3)
        {
            SwitchCam(cam1);
            ordre = 1;

        }
    }

    private void SwitchCam(GameObject cam)
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam.SetActive(true);
    }
}
