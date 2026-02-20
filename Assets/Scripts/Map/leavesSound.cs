using UnityEngine;

public class leavesSound : MonoBehaviour
{

    public AudioClip leaves;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            AudioSource.PlayClipAtPoint(leaves, transform.position);
           
        }
    }
}
