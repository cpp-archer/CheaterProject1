using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.InputSystem;

public class finishZone : MonoBehaviour
{
    public Transform[] finishSpawn;

    public GameObject zone;

    public GameObject panelWin;
  
    public TriggerGrimoire GrimLu;
    private bool zoneHere = false;
    private void Start()
    {
        zone.SetActive(false);
        panelWin.SetActive(false);
    }
    private void Update()
    {
        if(GrimLu.grimIsLu  && !zoneHere)
        {
            zone.SetActive(true);
            GenfinishZone();
            zoneHere = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && GrimLu.grimIsLu == true)
        { 
            //other.transform.position = finishSpawn[0].position;
            StartCoroutine(animeWin());
        }
    }

    IEnumerator animeWin()
    {
        yield return new WaitForSeconds(1f);
        panelWin.SetActive(true);
        Debug.Log("winnn");
        Time.timeScale = 0f;
    }

    private void GenfinishZone()
    {
        int rdm = Random.Range(0, finishSpawn.Length);
        //print(rdm);

        GameObject zoneFinish = Instantiate(zone);
        zoneFinish.transform.parent = finishSpawn[rdm];
        zoneFinish.transform.localPosition = Vector3.zero;
        zoneFinish.SetActive(true);

        transform.position = finishSpawn[rdm].position;
    }

}

