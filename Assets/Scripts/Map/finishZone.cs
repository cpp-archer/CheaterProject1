using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class finishZone : MonoBehaviour
{
    public Transform[] finishSpawn;

    public GameObject zone;
    //public GameObject panelWin;

   // public Animator animationFinish;

  
    private TriggerGrimoire GrimLu;
    private void Start()
    {
        zone.SetActive(false);
        //animationFinish.SetBool("IsFinish", false);
    }
    private void Update()
    {
        if(GrimLu.grimIsLu)
        {
            zone.SetActive(true);
            GenfinishZone();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        { 
            other.transform.position = finishSpawn[0].position;
            StartCoroutine(animeWin());
        }
    }

    IEnumerator animeWin()
    {
      //  animationFinish.SetBool("IsFinish", true);

        yield return new WaitForSeconds(5f);
        // panelWin.SetActive(true);
        Debug.Log("winnn");
    }

    private void GenfinishZone()
    {
        int rdm = Random.Range(0, finishSpawn.Length);
        //print(rdm);

        GameObject zoneFinish = Instantiate(zone);
       
        zoneFinish.transform.parent = finishSpawn[rdm];
        zoneFinish.transform.localPosition = Vector3.zero;


        Vector3 grimPos = new Vector3(zoneFinish.transform.position.x, zoneFinish.transform.position.y, zoneFinish.transform.position.z + 1.5f);

    }

}

