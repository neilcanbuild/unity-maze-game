using UnityEngine;

public class LavaHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // call player health method called lost life
            // let player know it's dead
            PlayerHP.LoseLife();
        }
    }
}

