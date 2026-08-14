 using UnityEngine;

public class SpikeballHazard : MonoBehaviour
{
    // destory after so many seconds
    public float lifetime = 15.0f;

    void Start()
    {
        // destroys object after many seconds (lifetime)
        Destroy(gameObject, lifetime);
    }
}
