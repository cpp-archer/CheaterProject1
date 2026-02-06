using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Drowns : MonoBehaviour
{

    public GameObject panelLose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelLose.SetActive(false);
    }


   private IEnumerator untilPanel()
    {   
        yield return new WaitForSeconds(1);
        panelLose.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
           
            StartCoroutine(untilPanel());
        }
    }
    
}
