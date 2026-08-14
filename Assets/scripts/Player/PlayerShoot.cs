using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // vars
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float projectileSpeed = 10.0f;
    public float fireRate = 0.5f;

    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            
            // reset timer
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        // empty

        // get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // stays in 2D plane
        mousePosition.z = 0f;

        // calculate direction from Fire point to mouse
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // spawn projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // move using physics
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if(rb != null )
        {
            rb.linearVelocity = direction * projectileSpeed;
        }

        // rotate projectile to face travel direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
