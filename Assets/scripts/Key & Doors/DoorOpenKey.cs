using UnityEngine;

public class DoorOpenKey : MonoBehaviour
{
    // variables
    public AudioSource doorAudio;
    // detect collision event
    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if(collision.gameObject.CompareTag("Player") && PlayerInventory.keyAcquired == true)
        {
            gameObject.SetActive(false);

            // play sound
            doorAudio.Play();

            // use key
            PlayerInventory.keyAcquired = false;
        }
    }
}
