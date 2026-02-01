using UnityEngine;

public class TriggerGrimoire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("okak ouvert");
        }
    }
}
