using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    // Counts how many safe platforms the player is touching
    private int platformContacts = 0;

    // Other scripts can check this
    public bool IsOnPlatform()
    {
        return platformContacts > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player begins touching a safe platform
        if (collision.CompareTag("Platform"))
        {
            platformContacts++;
            Debug.Log("Entered Platform. Contacts = " + platformContacts);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Player completely leaves a safe platform
        if (collision.CompareTag("Platform"))
        {
            platformContacts--;

            // Prevent the number from accidentally going below zero
            if (platformContacts < 0)
            {
                platformContacts = 0;
                Debug.Log("Exited Platform. Contacts = " + platformContacts);
            }
        }
    }
}