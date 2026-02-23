using UnityEngine;

public class leavesSound : MonoBehaviour
{

    //public AudioClip leaves;

    public AudioSource leaves;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            //AudioSource.PlayClipAtPoint(leaves, transform.position,1f);
            leaves.Play();

        }
    }
}
