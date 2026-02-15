using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Drowns : MonoBehaviour
{
    public GameObject panelLose;
    void Start()
    {
        panelLose.SetActive(false);
    }

   private IEnumerator untilPanel()
    {   
        yield return new WaitForSeconds(0.5f);
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
