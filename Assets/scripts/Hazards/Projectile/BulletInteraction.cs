using UnityEngine;

public class BulletInteraction : MonoBehaviour
{
    public GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyable"))
        {
            // create explosion effect
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // destroy object that is hit
            Destroy(collision.gameObject);

            // destroy bullet
            Destroy(gameObject);
        }
    }
}
