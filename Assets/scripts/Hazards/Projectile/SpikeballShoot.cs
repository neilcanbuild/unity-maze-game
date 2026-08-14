using Unity.VisualScripting;
using UnityEngine;

public class SpikeballShoot : MonoBehaviour
{
    // define variables and headers
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;

    [Header("Firing Settings")]
    public float fireRate = 2.0f;
    public Vector2 shootDirection = Vector2.left;

    // our timer
    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextFireTime)
        {
            // call fire method
            Fire();

            // set timer up for next shot
            nextFireTime = Time.time + (1f / fireRate);


        }
    }
    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // apply physics to move projectile
            rb.linearVelocity = shootDirection.normalized * projectileSpeed;
        }

    }
}
