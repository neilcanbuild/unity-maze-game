using UnityEngine;

public class DamagePlayer : MonoBehaviour
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

