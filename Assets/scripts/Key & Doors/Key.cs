using UnityEngine;

public class Key : MonoBehaviour
{
    // variables
    public AudioSource keyAudio;
    // reference onTrigger Event
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        // compare to make sure contact with player
        if(collision.CompareTag("Player"))
        {
            // add key to player inventory
            PlayerInventory.keyAcquired = true;

            // play a sound
            keyAudio.Play();

            // destroy object
            Destroy(gameObject);


        }

    }

}
